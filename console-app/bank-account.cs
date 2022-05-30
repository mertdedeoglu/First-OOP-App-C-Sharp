using System;
using System.Collections.Generic;
using System.Text;

namespace Mysuperbank
{
    class bankaccount
    {
        
        public string Number { get;}
        public string Owner { get; set; }  
        public decimal Balance { 
            get 
            {
                decimal balance = 0;
                foreach (var item in alltransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            } 
        }

        private static int accountNumberSeed = 123456;

        private List<transaction> alltransactions = new List<transaction>();

        public bankaccount(string name, decimal initialBalance)
        {
            this.Owner = name;

            MakeDeposit(initialBalance,DateTime.Now,"Initial Balance");

            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

        }    

        public void MakeDeposit(decimal amount,DateTime date, string note)
        {
            if (amount <= 0 )
            {
                throw new ArgumentOutOfRangeException(nameof(amount),"Amount of deposit must be positive");
            }
            var deposit = new transaction(amount,date,note);
            alltransactions.Add(deposit);
        } 

        public void MakeWithdrawal(decimal amount,DateTime date,string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount),"Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0 )
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdraw = new transaction(-amount,date,note);
            alltransactions.Add(withdraw);

        } 

        public string GetAccountHistory()
        {
            var report = new StringBuilder();
            report.AppendLine("Date\t\tAmount\tNote");
            foreach (var item in alltransactions)
            {
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
            }
            return report.ToString();
        }   
    }

    class transaction
    {
        public decimal Amount { get; }
        
        public DateTime Date { get; }

        public string Notes { get; }
        
        public transaction(decimal amount,DateTime date,string note)
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;

        }
    }
}