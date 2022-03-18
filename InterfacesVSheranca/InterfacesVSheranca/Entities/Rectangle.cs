using InterfacesVSheranca.Enums;

namespace InterfacesVSheranca.Entities
{
    class Rectangle : AbstractShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double Area()
        {
            return Width * Height;
        }

        public override string ToString()
        {
            return "Retangulo da cor: "
                + Color.ToString()
                + " de áre "
                + Area().ToString();
        }
    }
}
