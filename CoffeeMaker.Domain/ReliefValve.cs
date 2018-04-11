using System;

namespace CoffeeMaker.Domain
{
    public class ReliefValve
    {
        private readonly ISensor<WarmerPlateStatus> _warmerPlateSensor;
        private readonly ISwitch<ReliefValveState> _reliefValveSwitch;

        public ReliefValve(ISensor<WarmerPlateStatus> warmerPlateSensor,
                           ISwitch<ReliefValveState> reliefValveSwitch)
        {
            _warmerPlateSensor = warmerPlateSensor ?? throw new ArgumentNullException(nameof(warmerPlateSensor));
            _reliefValveSwitch = reliefValveSwitch ?? throw new ArgumentNullException(nameof(reliefValveSwitch));

            _warmerPlateSensor.StatusChanged += (s, e) => WarmerPlateStatusChanged();
        }

        private void WarmerPlateStatusChanged()
        {
            if (_warmerPlateSensor.Status == WarmerPlateStatus.WarmerEmpty)
                _reliefValveSwitch.Set(ReliefValveState.Open);
            else
                _reliefValveSwitch.Set(ReliefValveState.Close);
        }
    }
}
