using System.Text;

namespace ExcOrder.Entities
{
    class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }

        public OrderItem(int quantity, double price, Product product)
        {
            Quantity = quantity;
            Price = price;
            Product = product;
        }

        public double SubTotal()
        {
            double sum = Quantity * Price;
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Product.Name);
            sb.Append(", $");
            sb.Append(Product.Price);
            sb.Append(", Quantity: ");
            sb.Append(Quantity);
            sb.Append(", Subtotal: ");
            sb.Append(SubTotal().ToString());
            sb.AppendLine();


            return sb.ToString();
        }


    }
}
