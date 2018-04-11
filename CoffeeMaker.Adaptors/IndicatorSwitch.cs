using System;
using CoffeeMaker.Domain;
using Api = CoffeeMaker.Hardware.Api;

namespace CoffeeMaker.Adaptors
{
    public class IndicatorSwitch : ISwitch<IndicatorState>
    {
        private readonly Api.ICoffeeMaker _api;

        public IndicatorSwitch(Api.ICoffeeMaker api)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
        }

        public void Set(IndicatorState state)
        {
            _api.SetIndicatorState(Map(state));
        }

        private Api.IndicatorState Map(IndicatorState state)
        {
            switch (state)
            {
                case IndicatorState.On: return Api.IndicatorState.ON;
                case IndicatorState.Off: return Api.IndicatorState.OFF;
                default: throw new NotSupportedException();
            }
        }
    }
}
