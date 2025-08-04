using System;

// https://codefinity.com/blog/Object-Oriented-Programming-(OOP)?utm_source=google&utm_medium=cpc&utm_campaign=21743132563&utm_content=168389656552&utm_term=object%20oriented%20programming%20c%2B%2B%20exercises&dki=Object%20Oriented%20Programming%20C%2B%2B%20Exercises&gad_source=1&gad_campaignid=21743132563&gbraid=0AAAAABTeUgR--PTm3bDtWdBu02h_HoaRH&gclid=Cj0KCQjwtMHEBhC-ARIsABua5iT92EUszzwWu8XAXRcvSlkWCXzt8uqOR-9OhAAdl3vXYlFn-hHqrRcaAh6DEALw_wcB

namespace Lng.OOPConcepts
{
    #region Replace Conditional Statements (IF/ELSE or SWITCH) With Polymorphism

    public interface IBrick
    {
        int Witdh { get; }
        int Height { get; }
        string UsageDescription { get; }
        int CalculateHowManyBricksAreNeeded(int wallWidth);
    }

    public class SolidBrick : IBrick
    {
        public int CalculateHowManyBricksAreNeeded(int wallWidth)
        {
            return wallWidth * Witdh;
        }

        public int Witdh => 10;
        public int Height => 5;
        public string UsageDescription => "";
    }

    public class ConcreteBlock : IBrick
    {
        public int CalculateHowManyBricksAreNeeded(int wallWidth)
        {
            return wallWidth * Witdh;
        }

        public int Witdh => 20;
        public int Height => 6;
        public string UsageDescription => "ConcreteBlock";
    }

    public class GlassBlock : IBrick
    {
        public int CalculateHowManyBricksAreNeeded(int wallWidth)
        {
            return wallWidth * Witdh;
        }

        public int Witdh => 5;
        public int Height => 5;
        public string UsageDescription => "The wall was build with glass blocks to make use of natural light";
    }

    public class Bricklayer
    {
        public int WallWidth { get; set; }
        public int BricksQuantity { get; private set; }

        public void CalculateQuantity(IBrick tj)
        {
            BricksQuantity = tj.CalculateHowManyBricksAreNeeded(WallWidth);
        }
    }

    #endregion

    /// <summary>
    /// OOP breaks the code into separate objects, each with its own properties and actions. This not only simplifies development but also makes it easier to maintain and extend projects over time.
    /// </summary>
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Calculate how many bricks are needed to build a wall.");

            var bricklayer = new Bricklayer
            {
                WallWidth = 5
            };

            bricklayer.CalculateQuantity(new GlassBlock());

            Console.WriteLine(bricklayer.BricksQuantity);
            Console.WriteLine(bricklayer.BricksQuantity);
        }
    }
}