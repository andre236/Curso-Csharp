using System.Globalization;
using TratamentoExcecoesEx1.Entities;
using TratamentoExcecoesEx1.Entities.Exceptions;

namespace TratamentoExcecoesEx1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter account data: ");
            Console.Write("Number: ");
            int numberAccount = int.Parse(Console.ReadLine());
            Console.Write("Holder: ");
            string holderAccount = Console.ReadLine();
            Console.Write("Innitial Balance: ");
            double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Withdraw Limit: ");
            double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Account account = new Account(numberAccount, holderAccount, balance, withdrawLimit);
            Console.WriteLine();
            Console.Write("Enter amount for Withdraw: ");
            try
            {
                account.Withdraw(double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));
                Console.WriteLine("New balance: " + account.Balance);
            }
            catch(DomainException e)
            {
                Console.WriteLine("Withdraw error: " + e.Message);
            }



        }
    }

}