using System;
using CoffeeMaker.Domain;
using Api = CoffeeMaker.Hardware.Api;

namespace CoffeeMaker.Adaptors
{
    public class ReliefValveSwitch : ISwitch<ReliefValveState>
    {
        private readonly Api.ICoffeeMaker _api;

        public ReliefValveSwitch(Api.ICoffeeMaker api)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
        }

        public void Set(ReliefValveState state)
        {
            _api.SetReliefValveState(Map(state));
        }

        private Api.ReliefValveState Map(ReliefValveState state)
        {
            switch (state)
            {
                case ReliefValveState.Open: return Api.ReliefValveState.OPEN;
                case ReliefValveState.Close: return Api.ReliefValveState.CLOSED;
                default: throw new NotSupportedException();
            }
        }
    }
}
