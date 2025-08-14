using Shouldly;

namespace Lng.ThradsafeStructures;

public class ConcurrentCounterTests
{
    static int counter = 0;

    /// <summary>
    /// Why: lock is faster and simpler for in-process concurrency control.
    /// </summary>
    private static readonly object lockObj = new object();
    
    /// <summary>
    /// When to use: Ensuring only one thread at a time accesses a critical section.
    /// </summary>
    private static readonly Mutex _mutex = new Mutex();

    [Fact]
    public void Increment_WhenExecutingParallelThreads_ShouldReturnTheSameValue()
    {
        Task t1 = Task.Run(Increment);
        Task t2 = Task.Run(Increment);

        Task.WaitAll(t1, t2);

        counter.ShouldNotBe(2000000);
    }

    static void Increment()
    {
        for (int i = 0; i < 1_000_000; i++)
        {
            counter++;
        }
    }

    [Fact]
    public void SafeIncrement_WhenExecutingParallelThreads_ShouldReturnTheSameValue()
    {
        Task t1 = Task.Run(SafeIncrement);
        Task t2 = Task.Run(SafeIncrement);

        Task.WaitAll(t1, t2);

        counter.ShouldBe(2000000);
    }

    static void SafeIncrement()
    {
        for (int i = 0; i < 1_000_000; i++)
        {
            lock (lockObj)
            {
                counter++;
            }
        }
    }

    [Fact]
    public void InterlockedIncrement_WhenExecutingParallelThreads_ShouldReturnTheSameValue()
    {
        Task t1 = Task.Run(InterlockedIncrement);
        Task t2 = Task.Run(InterlockedIncrement);

        Task.WaitAll(t1, t2);

        counter.ShouldBe(2000000);
    }

    static void InterlockedIncrement()
    {
        for (int i = 0; i < 1_000_000; i++)
        {
            Interlocked.Increment(ref counter);
        }
    }

    static void MutexIncrement()
    {
        _mutex.WaitOne(); // Lock
        try
        {
            //Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} entered.");
            for (int i = 0; i < 1_000_000; i++)
            {
                counter++;
            }
        }
        finally
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} leaving.");
            _mutex.ReleaseMutex(); // Unlock
        }

    }

    /// <summary>
    /// When to use: Preventing multiple processes from running at the same time.
    /// </summary>
    static void GlobalMutexIncrement()
    {
        using var mutex = new Mutex(false, "Global\\MyUniqueAppMutex");
        Console.WriteLine("Trying to acquire the mutex...");
        if (!mutex.WaitOne(TimeSpan.FromSeconds(5), false))
        {
            Console.WriteLine("Another instance is already running.");
            return;
        }

        try
        {
            Console.WriteLine("Mutex acquired. Running process...");
            for (int i = 0; i < 1_000_000; i++)
            {
                counter++;
            }
        }
        finally
        {
            mutex.ReleaseMutex();
            Console.WriteLine("Mutex released.");
        }
    }
}