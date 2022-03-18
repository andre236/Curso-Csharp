using InterfacesVSheranca.Enums;
using System;

namespace InterfacesVSheranca.Entities
{
    class Circle : AbstractShape
    {
        public double Radius { get; set; }

        public override double Area()
        {
            return Math.Pow(Radius, 2) * Math.PI;
        }

        public override string ToString()
        {
            return "Circulo da cor: "
                + Color.ToString()
                + " de áre "
                + Area().ToString();
        }
    }
}
