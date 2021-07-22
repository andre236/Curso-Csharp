using System;
using System.Globalization;
using ExerciciosEnumEcomposicao.Entities;
using ExerciciosEnumEcomposicao.Entities.Enums;


namespace ExerciciosEnumEcomposicao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter with Department's name: ");
            string nameDepartment = Console.ReadLine();
            Console.WriteLine("Enter Worker data: ");
            Console.Write("Name: ");
            string nameWorker = Console.ReadLine();
            Console.Write("Worker level (Junior/Medio/Senior): ");
            WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(nameDepartment);
            Worker worker = new Worker(nameWorker, workerLevel, baseSalary, dept);

            Console.WriteLine("How many contracts to this worker? ");
            int numberContract = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberContract; i++)
            {
                Console.WriteLine($"Enter #{i+1} contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerhour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerhour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income MM/YYYY: ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Name worker: "+ worker.Name);
            Console.WriteLine("Name Department: "+ worker.Department.Name);
            Console.WriteLine("Income for " + monthAndYear + ":" + worker.Income(month, year).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
