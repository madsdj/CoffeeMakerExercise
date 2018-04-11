using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMaker.Adaptors;
using CoffeeMaker.Domain;

namespace CoffeeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            ISensor<BrewButtonStatus> brewButtonSensor = new BrewButtonSensor();
            ISensor<WaterLevelStatus> waterLevelSensor = new WaterLevelSensor();
            ISensor<WarmerPlateStatus> warmerPlateSensor = new WarmerPlateSensor();
        }
    }
}
