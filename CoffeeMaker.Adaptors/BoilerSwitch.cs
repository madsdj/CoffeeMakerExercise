using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMaker.Domain;

namespace CoffeeMaker.Adaptors
{
    public class BoilerSwitch : ISwitch<BoilerState>
    {
        public void Set(BoilerState state)
        {
            throw new NotImplementedException();
        }
    }
}
