namespace Desktop.Services
{
    internal interface IServiceLocator
    {
        T GetService<T>();
    }
}