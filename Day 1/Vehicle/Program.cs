using System;




using Vehicle;

// kreiranje objekata

Car car = new Car(240, "BMW", "Diesel", 6.3);

Bicycle bicycle = new Bicycle("CUBE", 7, 10, 0.7);

Aeroplane plane = new Aeroplane("Boeing 747", 350, 40);

// dohvaćanje tipa prijevoznog sredstva

Console.WriteLine(car.GetVehicleType());

Console.WriteLine(bicycle.GetVehicleType());

Console.WriteLine(plane.GetVehicleType());

// korištenje metode za racunanje

Console.WriteLine(car.CalculatateFuelConsumption(250));

Console.WriteLine(car.CalculateTripTime(250));

Console.WriteLine(plane.CalculateTripTime(250));

Console.WriteLine(bicycle.CalculateTripTime(250));

Console.WriteLine(bicycle.IsPoweredByEngine());

Console.WriteLine(plane.GetWingsSpan());
// Vehicle.Vehicle kola = new Vehicle.Vehicle();  not working cause its abstract

Console.WriteLine("Unesite brzinu vozila:");
double speed = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Unesite marku vozila:");
string make = Console.ReadLine();

Console.WriteLine("Unesite vrstu goriva:");
string fuelType = Console.ReadLine();   

Console.WriteLine("Unesite potrošnju goriva (na 100 km):"); 
double fuelConsumption = Convert.ToDouble(Console.ReadLine());

// Stvaranje objekta klase Car s unesenim podacima
Car modernCar = new Car(speed, make, fuelType, fuelConsumption);

// Testiranje metoda i ispis rezultata
Console.WriteLine("Vrsta vozila: " + modernCar.GetVehicleType());





Console.WriteLine("Unesite udaljenost za izračun vremena putovanja:");
double distance = Convert.ToDouble(Console.ReadLine());
double tripTime = modernCar.CalculateTripTime(distance);
Console.WriteLine("Vrijeme putovanja: " + tripTime + " sati");

Console.WriteLine("Cijena vozila: " + modernCar.GetPrice());

Console.WriteLine("Unesite udaljenost za izračun potrošnje goriva:");
distance = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Potrošnja goriva: " + modernCar.CalculatateFuelConsumption(distance) + " litara"); //fuel consumption in litres every 100km

Console.WriteLine("Pokreće li se vozilo motorom? " + car.IsPoweredByEngine());

Console.WriteLine("Broj kotača vozila: " + car.NumberOfWheels());





