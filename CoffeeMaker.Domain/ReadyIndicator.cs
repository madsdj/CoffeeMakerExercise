using System;

namespace CoffeeMaker.Domain
{
    public class ReadyIndicator
    {
        private readonly ISensor<BrewButtonStatus> _brewButtonSensor;
        private readonly ISensor<WaterLevelStatus> _waterLevelSensor;
        private readonly ISwitch<IndicatorState> _indicatorSwitch;

        public ReadyIndicator(ISensor<BrewButtonStatus> brewButtonSensor,
                              ISensor<WaterLevelStatus> waterLevelSensor,
                              ISwitch<IndicatorState> indicatorSwitch)
        {
            _brewButtonSensor = brewButtonSensor ?? throw new ArgumentNullException(nameof(brewButtonSensor));
            _waterLevelSensor = waterLevelSensor ?? throw new ArgumentNullException(nameof(waterLevelSensor));
            _indicatorSwitch = indicatorSwitch ?? throw new ArgumentNullException(nameof(indicatorSwitch));

            _brewButtonSensor.StatusChanged += (s, e) => BrewButtonPressed();
            _waterLevelSensor.StatusChanged += (s, e) => WaterLevelChanged();
        }

        private void BrewButtonPressed()
        {
            if (_brewButtonSensor.Status == BrewButtonStatus.Pushed)
                _indicatorSwitch.Set(IndicatorState.Off);
        }

        private void WaterLevelChanged()
        {
            if (_waterLevelSensor.Status == WaterLevelStatus.Empty)
                _indicatorSwitch.Set(IndicatorState.On);
        }
    }
}
