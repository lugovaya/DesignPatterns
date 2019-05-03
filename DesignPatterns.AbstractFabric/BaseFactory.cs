namespace DesignPatterns.AbstractFabric
{
    public abstract class BaseFactory<T> where T : class
    {
        public abstract T Create();
    }
}