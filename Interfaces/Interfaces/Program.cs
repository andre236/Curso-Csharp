using System.Globalization;
using Interfaces.Entities;
using Interfaces.Services;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter rental data: ");
            Console.Write("Car Model: ");
            string modelCar = Console.ReadLine();
            Console.Write("Pickup (dd/MM/yyyy hh:mm) ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", new CultureInfo("pt-BR"));
            Console.Write("Return (dd/MM/yyyy hh:mm) ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", new CultureInfo("pt-BR"));

            Console.Write("Enter price per hour: ");
            double priceHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter price per day: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


            CarRental carRental = new CarRental(start, finish, new Vehicle(modelCar));

            RentalService rentalService = new RentalService(priceHour, day, new BrazilTaxService());

            rentalService.ProcessInvoice(carRental);
            Console.WriteLine("INVOICE: ");
            Console.WriteLine(carRental.Invoice);

        }
    }
}