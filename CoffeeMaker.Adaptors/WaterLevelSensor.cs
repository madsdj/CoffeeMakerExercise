using System;
using CoffeeMaker.Domain;
using Api = CoffeeMaker.Hardware.Api;

namespace CoffeeMaker.Adaptors
{
    public class WaterLevelSensor : ISensor<WaterLevelStatus>, IUpdatable
    {
        private readonly Api.ICoffeeMaker _api;

        public WaterLevelSensor(Api.ICoffeeMaker api)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
        }

        public event EventHandler StatusChanged;
        public WaterLevelStatus Status { get; private set; }

        public void Update()
        {
            var status = Map(_api.GetBoilerStatus());
            if (Status != status)
            {
                Status = status;
                StatusChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private WaterLevelStatus Map(Api.BoilerStatus status)
        {
            switch (status)
            {
                case Api.BoilerStatus.EMPTY: return WaterLevelStatus.Empty;
                case Api.BoilerStatus.NOT_EMPTY: return WaterLevelStatus.NotEmpty;
                default: throw new NotSupportedException();
            }
        }
    }
}
