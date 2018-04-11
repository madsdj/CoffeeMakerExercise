using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMaker.Hardware.Api;

namespace CoffeeMaker
{
    public class CoffeeMakerSimulator : ICoffeeMaker
    {
        public BoilerStatus GetBoilerStatus()
        {
            throw new NotImplementedException();
        }

        public BrewButtonStatus GetBrewButtonStatus()
        {
            throw new NotImplementedException();
        }

        public WarmerPlateStatus GetWarmerPlateStatus()
        {
            throw new NotImplementedException();
        }

        public void SetBoilerState(BoilerState state)
        {
            throw new NotImplementedException();
        }

        public void SetIndicatorState(IndicatorState state)
        {
            throw new NotImplementedException();
        }

        public void SetReliefValveState(ReliefValveState state)
        {
            throw new NotImplementedException();
        }

        public void SetWarmerState(WarmerState state)
        {
            throw new NotImplementedException();
        }
    }
}
