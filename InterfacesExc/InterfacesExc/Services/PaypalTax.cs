
namespace InterfacesExc.Services
{
    class PaypalTax: ITax
    {
        public double Tax(double amount)
        {
            return 0;
        }

        public double TaxWmonth(double amount, int month)
        {
            double totalPerMonth = amount / month;
            double total = 0;
            double adjustment = month * 0.01;
            double result = totalPerMonth + (adjustment * totalPerMonth);

            return total += result + (result * 0.02);
        }
    }
}
