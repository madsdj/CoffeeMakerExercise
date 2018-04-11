using System;
using CoffeeMaker.Domain;
using Api = CoffeeMaker.Hardware.Api;

namespace CoffeeMaker.Adapters
{
    public class WarmerPlateSensor : ISensor<WarmerPlateStatus>, IUpdatable
    {
        private readonly Api.ICoffeeMaker _api;

        public WarmerPlateSensor(Api.ICoffeeMaker api)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
        }

        public event EventHandler StatusChanged;
        public WarmerPlateStatus Status { get; private set; }

        public void Update()
        {
            var status = Map(_api.GetWarmerPlateStatus());
            if (Status != status)
            {
                Status = status;
                StatusChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private WarmerPlateStatus Map(Api.WarmerPlateStatus status)
        {
            switch (status)
            {
                case Api.WarmerPlateStatus.WARMER_EMPTY: return WarmerPlateStatus.WarmerEmpty;
                case Api.WarmerPlateStatus.POT_EMPTY: return WarmerPlateStatus.PotEmpty;
                case Api.WarmerPlateStatus.POT_NOT_EMPTY: return WarmerPlateStatus.PotNotEmpty;
                default: throw new NotSupportedException();
            }
        }
    }
}
