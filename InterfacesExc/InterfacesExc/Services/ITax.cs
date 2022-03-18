namespace InterfacesExc.Services
{
    interface ITax
    {
        double Tax(double amount);
        double TaxWmonth(double amount, int months);
    }
}
