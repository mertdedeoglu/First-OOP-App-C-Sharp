using System;
using System.Collections.Generic;
using Mysuperbank;
namespace console_app
{
    class Program
    {
        static void Main(string[] args)
        {       
            var account= new bankaccount("Kendra",1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}.");
            
            account.MakeDeposit(150,DateTime.Now,"Earned money");
            account.MakeDeposit(300,DateTime.Now,"Gift for my friend");

            Console.WriteLine(account.GetAccountHistory());


            
        }
    }
}
