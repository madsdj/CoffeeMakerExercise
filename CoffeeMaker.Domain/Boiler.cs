using System;

namespace CoffeeMaker.Domain
{
    public class Boiler
    {
        private readonly ISensor<BrewButtonStatus> _brewButtonSensor;
        private readonly ISensor<WaterLevelStatus> _waterLevelSensor;
        private readonly ISwitch<BoilerState> _boilerSwitch;

        public Boiler(ISensor<BrewButtonStatus> brewButtonSensor,
                      ISensor<WaterLevelStatus> waterLevelSensor,
                      ISwitch<BoilerState> boilerSwitch)
        {
            _brewButtonSensor = brewButtonSensor ?? throw new ArgumentNullException(nameof(brewButtonSensor));
            _waterLevelSensor = waterLevelSensor ?? throw new ArgumentNullException(nameof(waterLevelSensor));
            _boilerSwitch = boilerSwitch ?? throw new ArgumentNullException(nameof(boilerSwitch));

            _brewButtonSensor.StatusChanged += (s, e) => BrewButtonPressed();
            _waterLevelSensor.StatusChanged += (s, e) => WaterLevelChanged();
        }

        private void BrewButtonPressed()
        {
            if (_waterLevelSensor.Status == WaterLevelStatus.NotEmpty &&
                _brewButtonSensor.Status == BrewButtonStatus.Pushed)
                _boilerSwitch.Set(BoilerState.On);
        }

        private void WaterLevelChanged()
        {
            if (_waterLevelSensor.Status == WaterLevelStatus.Empty)
                _boilerSwitch.Set(BoilerState.Off);
        }
    }
}
