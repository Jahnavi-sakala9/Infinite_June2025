using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    //First Question
    class Accounts
    {
        int accNo;
        string customerName;
        string accountType;
        char transactionType;
        int amount;
        int balance;
        public Accounts(int accNum, string name, string accType, char transType, int amt, int initialBalance)
        {
            accNo = accNum;
            customerName = name;
            accountType = accType;
            transactionType = transType;
            amount = amt;
            balance = initialBalance;
            if (transactionType == 'd' || transactionType == 'D')
            {
                Credit(amount);
            }
            else if (transactionType == 'w' || transactionType == 'W')
            {
                Debit(amount);
            }
            else
            {
                Console.WriteLine("Invalid transaction type");
            }
        }
        public void Credit(int amount)
        {
            balance += amount;
            Console.WriteLine($"{amount} deposited successfully");
        }
        public void Debit(int amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"{amount} withdrawn successfully");
            }
            else
            {
                Console.WriteLine("Insufficient balance");
            }
        }
        public void ShowData()
        {
            Console.WriteLine("-----Account Details------");
            Console.WriteLine("Account Number: " + accNo);
            Console.WriteLine("Customer name: " + customerName);
            Console.WriteLine("Account Type: " + accountType);
            Console.WriteLine("Transaction Type: " + transactionType);
            Console.WriteLine("Amount: " + amount);
            Console.WriteLine("Balance: " + balance);
        }
        static void Main(string[] args)
        {
            Accounts acc1 = new Accounts(101, "jahnu", "savings", 'd', 5000, 2000);
            acc1.ShowData();
            Console.Read();
        }
    }
}
