using System;
using CoffeeMaker.Domain;
using Api = CoffeeMaker.Hardware.Api;

namespace CoffeeMaker.Adapters
{
    public class BrewButtonSensor : ISensor<BrewButtonStatus>, IUpdatable
    {
        private readonly Api.ICoffeeMaker _api;

        public BrewButtonSensor(Api.ICoffeeMaker api)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
        }

        public event EventHandler StatusChanged;
        public BrewButtonStatus Status { get; private set; }

        public void Update()
        {
            var status = Map(_api.GetBrewButtonStatus());
            if (Status != status)
            {
                Status = status;
                StatusChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private BrewButtonStatus Map(Api.BrewButtonStatus status)
        {
            switch (status)
            {
                case Api.BrewButtonStatus.PUSHED: return BrewButtonStatus.Pushed;
                case Api.BrewButtonStatus.NOT_PUSHED: return BrewButtonStatus.NotPushed;
                default: throw new NotSupportedException();
            }
        }
    }
}
