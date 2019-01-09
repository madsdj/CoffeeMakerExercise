using System;
using System.Collections.Generic;
using System.Timers;
using CoffeeMaker.Adapters;
using CoffeeMaker.Domain;

namespace CoffeeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new CoffeeMakerSimulator();

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
            var readyIndicator = new ReadyIndicator(brewButtonSensor, waterLevelSensor, indicatorSwitch);

            var updatables = new List<IUpdatable> { brewButtonSensor, waterLevelSensor, warmerPlateSensor };

            Timer timer = new Timer(TimeSpan.FromMilliseconds(100).TotalMilliseconds);
            timer.Elapsed += (s, e) =>
            {
                api.Tick();
                updatables.ForEach(u => u.Update());
            };

            timer.Start();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "exit") break;
                if (command == "brew") api.PressBrewButton();
                if (command == "empty") api.EmptyCoffee();
                if (command == "refill") api.RefillWater();
                if (command == "insert") api.InsertPot();
                if (command == "remove") api.RemovePot();

                Console.Clear();
                api.Print();
            }
        }
    }
}
