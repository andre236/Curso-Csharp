using System.Collections.Generic;

namespace InterfacesExc.Entities
{
    class Contract
    {
        public int Number { get; set; }
        public double ContractValue { get; set; }
        public DateTime LeaseDate { get; set; }
        public List<Installment> Installments { get; set; }

        public Contract(int number, double contractValue, DateTime leaseDate, List<Installment> installments)
        {
            Number = number;
            ContractValue = contractValue;
            LeaseDate = leaseDate;
            Installments = installments;
        }

        public void AddInstallment(Installment installment)
        {
            Installments.Add(installment);
        }
    }
}
