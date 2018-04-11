using System;

namespace CoffeeMaker.Domain
{
    public class WarmerPlate
    {
        private readonly ISensor<WarmerPlateStatus> _warmerPlateSensor;
        private readonly ISwitch<WarmerPlateState> _warmerPlateSwitch;

        public WarmerPlate(ISensor<WarmerPlateStatus> warmerPlateSensor,
                           ISwitch<WarmerPlateState> warmerPlateSwitch)
        {
            _warmerPlateSensor = warmerPlateSensor ?? throw new ArgumentNullException(nameof(warmerPlateSensor));
            _warmerPlateSwitch = warmerPlateSwitch ?? throw new ArgumentNullException(nameof(warmerPlateSwitch));

            _warmerPlateSensor.StatusChanged += (s, e) => WarmerPlateStatusChanged();
        }

        private void WarmerPlateStatusChanged()
        {
            if (_warmerPlateSensor.Status == WarmerPlateStatus.PotNotEmpty)
                _warmerPlateSwitch.Set(WarmerPlateState.On);
            else
                _warmerPlateSwitch.Set(WarmerPlateState.Off);
        }
    }
}
