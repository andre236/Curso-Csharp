using System.Globalization;

namespace InterfacesExc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Valor de entrada: ");
            double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Numero de Parcelas: ");
            int parcelas = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            
            
        }
    }
}

