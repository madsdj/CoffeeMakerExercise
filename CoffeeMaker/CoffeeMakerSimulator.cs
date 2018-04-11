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
        private WarmerPlateStatus _warmerPlateStatus;
        private BrewButtonStatus _brewButtonStatus;
        private BoilerState _boilerState;
        private ReliefValveState _reliefValveState;
        private int _waterLevel = 100;
        private int _coffeeLevel = 0;

        public WarmerPlateStatus GetWarmerPlateStatus()
        {
            return _warmerPlateStatus;
        }

        public BoilerStatus GetBoilerStatus()
        {
            return _waterLevel > 10 ? BoilerStatus.NOT_EMPTY : BoilerStatus.EMPTY;
        }

        public BrewButtonStatus GetBrewButtonStatus()
        {
            var result = _brewButtonStatus;
            _brewButtonStatus = BrewButtonStatus.NOT_PUSHED;
            return result;
        }

        public void SetBoilerState(BoilerState state)
        {
            _boilerState = state;
        }

        public void SetWarmerState(WarmerState state)
        {
        }

        public void SetIndicatorState(IndicatorState state)
        {
        }

        public void SetReliefValveState(ReliefValveState state)
        {
            _reliefValveState = state;
        }

        public void PressBrewButton()
        {
            _brewButtonStatus = BrewButtonStatus.PUSHED;
        }

        public void RefillWater()
        {
            _waterLevel = 100;
        }

        public void Tick()
        {
            if (_waterLevel > 0 && _boilerState == BoilerState.ON)
            {
                _waterLevel--;
                if (_reliefValveState == ReliefValveState.CLOSED)
                    _coffeeLevel++;
            }
        }
    }
}
