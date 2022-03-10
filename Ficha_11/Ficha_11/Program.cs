// See https://aka.ms/new-console-template for more information
using Ficha_11;

Car car = new Car();

Engine engine = new Engine(120, 1000, 80);

Car cA = new Car(5, 5, "BMW", engine, Travel.LAND);

VehicleTest vt = new VehicleTest(cA);

vt.Car.Start();

Console.WriteLine(cA.ToString);
