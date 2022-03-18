using TratamentoExcecoesEx1.Entities.Exceptions;

namespace TratamentoExcecoesEx1.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithDrawLimit { get; set; }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithDrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            if(amount <= 0)
            {
                throw new DomainException("A quantia não pode ser menor ou igual a 0");
            }
            Balance += amount;
        }
        public void Withdraw(double amount)
        {
            if(amount <= 0)
            {
                throw new DomainException("A quantia solicitada não pode ser menor ou igual a 0");
            }

            if (amount > WithDrawLimit)
            {
                throw new DomainException("A quantia solicidata não pode ser maior que o limite de saque.");
            }

            if (amount > Balance)
            {
                throw new DomainException("A quantia solicitada não pode ser maior que o saldo disponível.");
            }
           
            Balance -= amount;
        }
    }
}
