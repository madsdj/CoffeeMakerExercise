using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMaker.Domain;

namespace CoffeeMaker.Adaptors
{
    public class WarmerPlateSensor : ISensor<WarmerPlateStatus>, IUpdatable
    {
        public event EventHandler StatusChanged;
        public WarmerPlateStatus Status { get; private set; }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
