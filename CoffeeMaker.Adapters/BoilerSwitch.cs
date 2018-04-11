using System;
using CoffeeMaker.Domain;
using Api = CoffeeMaker.Hardware.Api;

namespace CoffeeMaker.Adapters
{
    public class BoilerSwitch : ISwitch<BoilerState>
    {
        private readonly Api.ICoffeeMaker _api;

        public BoilerSwitch(Api.ICoffeeMaker api)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
        }

        public void Set(BoilerState state)
        {
            _api.SetBoilerState(Map(state));
        }

        private Api.BoilerState Map(BoilerState state)
        {
            switch (state)
            {
                case BoilerState.On: return Api.BoilerState.ON;
                case BoilerState.Off: return Api.BoilerState.OFF;
                default: throw new NotSupportedException();
            }
        }
    }
}
