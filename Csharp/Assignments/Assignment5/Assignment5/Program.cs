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
        public InSufficientBalanceException(string message) : base(message) 
        {
            
        }
    }
    class BankAccount
    {
        string accountHolderName;
        double balance;
        public BankAccount(string name, double initialBalance)
        {
            accountHolderName = name;
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
            Console.WriteLine($"Balance for {accountHolderName}: {balance}");
        }
        public void DisplayBalance()
        {
            Console.WriteLine($"Balance for {accountHolderName}:{balance}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Account Holder Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Initial Balance: ");
            double initialbalance = Convert.ToDouble(Console.ReadLine());
            BankAccount account = new BankAccount(name,initialbalance);
            Console.WriteLine("Enter Amount to deposit: ");
            double deposit = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Amount to withdraw: ");
            double withdraw = Convert.ToDouble(Console.ReadLine());
           
            try
            {
                account.withdraw(withdraw);
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
