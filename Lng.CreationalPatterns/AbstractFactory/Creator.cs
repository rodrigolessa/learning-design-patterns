namespace Lng.CreationalPatterns.AbstractFactory;

public abstract class Creator
{
    public interface IProduct
    {
        string Operation();
    }
    
    /// <summary>
    /// The Factory Method defines a method, which should be used for creating objects instead of using a direct constructor call
    /// </summary>
    /// <returns></returns>
    public abstract IProduct FactoryMethod();
    
    public string SomeOperation()
    {
        var product = FactoryMethod();
        return product.Operation();
    }
}