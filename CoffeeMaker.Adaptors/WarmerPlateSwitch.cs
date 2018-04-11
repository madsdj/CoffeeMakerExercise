using System;
using CoffeeMaker.Domain;

namespace CoffeeMaker.Adaptors
{
    public class WarmerPlateSwitch : ISwitch<WarmerPlateState>
    {
        public void Set(WarmerPlateState state)
        {
            throw new NotImplementedException();
        }
    }
}
