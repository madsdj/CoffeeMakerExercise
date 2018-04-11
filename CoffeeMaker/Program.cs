using System;
using System.Collections.Generic;
using System.Timers;
using CoffeeMaker.Adaptors;
using CoffeeMaker.Domain;
using Api = CoffeeMaker.Hardware.Api;

namespace CoffeeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Api.ICoffeeMaker api = new CoffeeMakerSimulator();

            var brewButtonSensor = new BrewButtonSensor(api);
            var waterLevelSensor = new WaterLevelSensor(api);
            var warmerPlateSensor = new WarmerPlateSensor(api);

            var boilerSwitch = new BoilerSwitch(api);
            var warmerPlateSwitch = new WarmerPlateSwitch(api);
            var reliefValveSwitch = new ReliefValveSwitch(api);
            var indicatorSwitch = new IndicatorSwitch(api);

            var boiler = new Boiler(brewButtonSensor, waterLevelSensor, boilerSwitch);
            var warmerPlate = new WarmerPlate(warmerPlateSensor, warmerPlateSwitch);
            var reliefValve = new ReliefValve(warmerPlateSensor, reliefValveSwitch);

            var updatables = new List<IUpdatable> { brewButtonSensor, waterLevelSensor, warmerPlateSensor };

            Timer timer = new Timer(TimeSpan.FromSeconds(1).TotalMilliseconds);
            timer.Elapsed += (s, e) => updatables.ForEach(u => u.Update());
            timer.Start();

            while (true)
            {
                string command = Console.ReadLine();
            }
        }
    }
}
