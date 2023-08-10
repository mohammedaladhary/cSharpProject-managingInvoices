using System;
using System.Collections.Generic;
using invoiceSystemApp;
using Newtonsoft.Json;
namespace invoiceSystemApp
{
    
    internal class ReportGenerator
    {
        private List<Invoice> invoices;

        public ReportGenerator(List<Invoice> invoices)
        {
            this.invoices = invoices;
        }
        
        public void StartMenu()
        {
            while (true)
            {
                Console.WriteLine("\n1. Report Statistics");
                Console.WriteLine("2. Program Statistics");
                Console.WriteLine("3. All Invoices");
                Console.WriteLine("4. Go Back");

                int choice = GetChoice();
                switch (choice)
                {
                    case 1:
                        ReportStatistics();
                        break;
                    case 2:
                        //Program Statistics
                        break;
                    case 3:
                        ReportAllInvoices();
                        break;
                    case 4:
                        return; // Go back
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
        private int GetChoice()
        {
            Console.Write("\nEnter your choice: ");
            return int.Parse(Console.ReadLine());
        }
        public void ReportStatistics()
        {
            Console.WriteLine("Program Statistics Report");
            Console.WriteLine($"Total Number of Invoices: {invoices.Count}");
            decimal totalRevenue = invoices.Sum(invoice => invoice.TotalAmount);
            Console.WriteLine($"Total Revenue: {totalRevenue:C}");
            Console.WriteLine();
        }

        public void ReportAllInvoices()
        {
            try
            {
                Console.WriteLine("Report for All Invoices");
                foreach (var invoice in invoices)
                {
                    Console.WriteLine($"Customer: {invoice.CustomerName}, Total Amount: {invoice.TotalAmount:N2} OMR");
                    Console.WriteLine("Items:");
                    foreach (var item in invoice.Items)
                    {
                        Console.WriteLine($"  - {item.ItemName}, Quantity: {item.Quantity}, Unit Price: {item.UnitPrice:N2} OMR, Total Price: {item.TotalPrice:N2} OMR");
                    }
                    Console.WriteLine();
                }
            }
            catch
            {
                // Ignore any exceptions that occur during the execution of the method
                Console.WriteLine("ERROR: Some Error Occurred");
            }
        }
    }

}


//public void ReportAllInvoices()
//{
//    Console.WriteLine("Report for All Invoices");
//    foreach (var invoice in invoices)
//    {
//        Console.WriteLine($"Customer: {invoice.CustomerName}, Total Amount: {invoice.TotalAmount:C}");
//        Console.WriteLine("Items:");
//        foreach (var item in invoice.Items)
//        {
//            Console.WriteLine($"  - {item.ItemName}, Quantity: {item.Quantity}, Unit Price: {item.UnitPrice:C}, Total Price: {item.TotalPrice:C}");
//        }
//        Console.WriteLine();
//    }
//}