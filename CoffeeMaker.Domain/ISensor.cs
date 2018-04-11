using System;

namespace CoffeeMaker.Domain
{
    public interface ISensor<TStatus>
    {
        event EventHandler StatusChanged;
        TStatus Status { get; }
    }
}
