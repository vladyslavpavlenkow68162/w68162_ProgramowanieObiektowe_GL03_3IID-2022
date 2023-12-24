using System;
using System.Collections.Generic;


public abstract class Transaction
{
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }

    public Transaction(decimal amount, DateTime transactionDate)
    {
        Amount = amount;
        TransactionDate = transactionDate;
    }

   
    public abstract void ProcessTransaction();
}


public class IncomeTransaction : Transaction
{
   
    private static decimal totalIncome = 0;

    public IncomeTransaction(decimal amount, DateTime transactionDate) : base(amount, transactionDate)
    {
    }

    public override void ProcessTransaction()
    {
        totalIncome += Amount;
    }


    public static decimal GetTotalIncome()
    {
        return totalIncome;
    }
}


public class ExpenseTransaction : Transaction
{
  
    private static decimal totalExpense = 0;

    public ExpenseTransaction(decimal amount, DateTime transactionDate) : base(amount, transactionDate)
    {
    }

    public override void ProcessTransaction()
    {
        totalExpense += Amount;
    }

 
    public static decimal GetTotalExpense()
    {
        return totalExpense;
    }
}


public class Account
{
    private List<Transaction> transactions;

    public Account()
    {
        transactions = new List<Transaction>();
    }

    
    public void AddTransaction(Transaction transaction)
    {
        transactions.Add(transaction);
        transaction.ProcessTransaction();
    }

    
    public void DisplaySummary()
    {
        decimal totalIncome = IncomeTransaction.GetTotalIncome();
        decimal totalExpense = ExpenseTransaction.GetTotalExpense();

        Console.WriteLine($"Total Income: {totalIncome}");
        Console.WriteLine($"Total Expense: {totalExpense}");
    }
}

class Program
{
    static void Main(string[] args)
    {
      
        Account myAccount = new Account();

        
        myAccount.AddTransaction(new IncomeTransaction(1000, DateTime.Now));
        myAccount.AddTransaction(new ExpenseTransaction(500, DateTime.Now));
        myAccount.AddTransaction(new IncomeTransaction(200, DateTime.Now));

        
        myAccount.DisplaySummary();
    }
}
