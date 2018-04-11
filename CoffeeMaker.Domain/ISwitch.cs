namespace CoffeeMaker.Domain
{
    public interface ISwitch<TState>
    {
        void Set(TState state);
    }
}
