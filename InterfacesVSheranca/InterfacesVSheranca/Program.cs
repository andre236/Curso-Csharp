using InterfacesVSheranca.Entities;
using InterfacesVSheranca.Enums;

namespace InterfacesVSheranca
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractShape cs = new Circle() { Radius = 2, Color = Color.Red };
            AbstractShape r = new Rectangle() { Height = 3.2, Width = 3.5, Color = Color.Black };

            Console.WriteLine(cs);
            Console.WriteLine(r);
        }
    }
}
