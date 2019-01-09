using System;
using CoffeeMaker.Hardware.Api;

namespace CoffeeMaker
{
    public class CoffeeMakerSimulator : ICoffeeMaker
    {
        private IndicatorState _readyIndicator = IndicatorState.OFF;
        private WarmerState _warmerState = WarmerState.OFF;
        private BrewButtonStatus _brewButtonStatus;
        private BoilerState _boilerState = BoilerState.OFF;
        private ReliefValveState _reliefValveState = ReliefValveState.CLOSED;
        private int _waterLevel = 100;
        private int _coffeeLevel = 0;
        private bool _isPotOnWarmerPlate = true;

        public WarmerPlateStatus GetWarmerPlateStatus()
        {
            return _isPotOnWarmerPlate
                ? _coffeeLevel > 0
                    ? WarmerPlateStatus.POT_NOT_EMPTY
                    : WarmerPlateStatus.POT_EMPTY
                : WarmerPlateStatus.WARMER_EMPTY;
        }

        public BoilerStatus GetBoilerStatus()
        {
            return _waterLevel > 0 ? BoilerStatus.NOT_EMPTY : BoilerStatus.EMPTY;
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
            _warmerState = state;
        }

        public void SetIndicatorState(IndicatorState state)
        {
            _readyIndicator = state;
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

        public void EmptyCoffee()
        {
            _coffeeLevel = 0;
        }

        public void InsertPot()
        {
            _isPotOnWarmerPlate = true;
        }

        public void RemovePot()
        {
            _isPotOnWarmerPlate = false;
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

        public void Print()
        {
            Console.WriteLine();
            Console.WriteLine($"Ready indicator:     {_readyIndicator}");
            Console.WriteLine($"Warmer state:        {_warmerState}");
            Console.WriteLine($"Boiler state:        {_boilerState}");
            Console.WriteLine($"Relief valve state:  {_reliefValveState}");
            Console.WriteLine();
            Console.WriteLine($"Warmer plate status: {GetWarmerPlateStatus()}");
            Console.WriteLine($"Boiler status:       {GetBoilerStatus()}");
            Console.WriteLine();
            Console.WriteLine($"Water level:         {_waterLevel} %");
            Console.WriteLine($"Coffee level:        {_coffeeLevel} %");
            Console.WriteLine();
        }
    }
}
