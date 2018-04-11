using System;
using CoffeeMaker.Domain;
using Api = CoffeeMaker.Hardware.Api;

namespace CoffeeMaker.Adaptors
{
    public class WarmerPlateSwitch : ISwitch<WarmerPlateState>
    {
        private readonly Api.ICoffeeMaker _api;

        public WarmerPlateSwitch(Api.ICoffeeMaker api)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
        }

        public void Set(WarmerPlateState state)
        {
            _api.SetWarmerState(Map(state));
        }

        private Api.WarmerState Map(WarmerPlateState state)
        {
            switch (state)
            {
                case WarmerPlateState.On: return Api.WarmerState.ON;
                case WarmerPlateState.Off: return Api.WarmerState.OFF;
                default: throw new NotSupportedException();
            }
        }
    }
}
