using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{

    //Exception Handling (First Question)
    //You have a class which has methods for transaction for a banking system. (created earlier)
    //Define your own methods for deposit money, withdraw money and balance in the account.
    //Write your own new application Exception class called InsuffientBalanceException.
    //This new Exception will be thrown in case of withdrawal of money from the account where customer doesn’t have sufficient balance.
    //Identify and categorize all possible checked and unchecked exception.
    class InSufficientBalanceException: ApplicationException
    {
        public InSufficientBalanceException(string message) : base(message) { }
    }
    class BankAccount
    {
        string accountHolder;
        double balance;
        public BankAccount(string name, double initialBalance)
        {
            accountHolder = name;
            balance = initialBalance;
        }
        public void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited: {amount}");
        }
        public void withdraw(double amount)
        {
            if (amount > balance)
                throw new InSufficientBalanceException("Insufficient balance for withdrawel");
            balance -= amount;
            Console.WriteLine($"Balance for {accountHolder}: {balance}");
        }
        public void DisplayBalance()
        {
            Console.WriteLine($"Balance for {accountHolder}:{balance}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount("jahnavi", 10000);
            account.Deposit(500);
            account.DisplayBalance();
            try
            {
                account.withdraw(20000);
            }
            catch(InSufficientBalanceException ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            account.DisplayBalance();
            Console.Read();
        }
    }
}
