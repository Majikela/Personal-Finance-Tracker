using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonalFinanceTracker
{
    class Program
    {
        static List<Transaction> transactions = new List<Transaction>();
        static decimal budget = 0;
        static decimal savingsGoal = 0;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Personal Finance Tracker");
                Console.WriteLine("1. Add Transaction");
                Console.WriteLine("2. View Transactions");
                Console.WriteLine("3. Set Budget");
                Console.WriteLine("4. View Budget");
                Console.WriteLine("5. Set Savings Goal");
                Console.WriteLine("6. View Savings Goal");
                Console.WriteLine("7. Generate Report");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTransaction();
                        break;
                    case "2":
                        ViewTransactions();
                        break;
                    case "3":
                        SetBudget();
                        break;
                    case "4":
                        ViewBudget();
                        break;
                    case "5":
                        SetSavingsGoal();
                        break;
                    case "6":
                        ViewSavingsGoal();
                        break;
                    case "7":
                        GenerateReport();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddTransaction()
        {
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            Console.Write("Enter amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter type (income/expense): ");
            string type = Console.ReadLine().ToLower();

            transactions.Add(new Transaction { Description = description, Amount = amount, Type = type });
            Console.WriteLine("Transaction added successfully.");
        }

        static void ViewTransactions()
        {
            Console.WriteLine("Transactions:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction.Description + "\n" + transaction.Amount + "\n" + transaction.Type);
            }
        }

        static void SetBudget()
        {
            Console.Write("Enter budget amount: ");
            budget = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Budget set successfully.");
        }

        static void ViewBudget()
        {
            Console.WriteLine("Current budget: "+budget);
        }

        static void SetSavingsGoal()
        {
            Console.Write("Enter savings goal amount: ");
            savingsGoal = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Savings goal set successfully.");
        }

        static void ViewSavingsGoal()
        {
            Console.WriteLine("Current savings goal: "+savingsGoal);
        }

        static void GenerateReport()
        {
            decimal totalIncome = transactions.Where(t => t.Type == "income").Sum(t => t.Amount);
            decimal totalExpense = transactions.Where(t => t.Type == "expense").Sum(t => t.Amount);
            decimal balance = totalIncome - totalExpense;

            Console.WriteLine("Finance Report:");
            Console.WriteLine("Total Income: "+totalIncome);
            Console.WriteLine("Total Expense: "+totalExpense);
            Console.WriteLine("Balance: "+balance);
            Console.WriteLine("Budget: "+budget);
            Console.WriteLine("Savings Goal: "+savingsGoal);
        }
    }

}
