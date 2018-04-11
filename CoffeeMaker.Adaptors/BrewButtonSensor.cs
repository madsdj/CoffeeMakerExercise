using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMaker.Domain;

namespace CoffeeMaker.Adaptors
{
    public class BrewButtonSensor : ISensor<BrewButtonStatus>, IUpdatable
    {
        public event EventHandler StatusChanged;
        public BrewButtonStatus Status { get; private set; }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
