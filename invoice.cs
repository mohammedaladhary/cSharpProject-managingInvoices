//using System;
//using Newtonsoft.Json;
//namespace invoiceSystemApp;
//using System.Collections.Generic;



//internal class InvoiceManager
//{
//    private List<Invoice> invoices;

//    public InvoiceManager()
//    {
//        invoices = new List<Invoice>();
//    }

//    public void CreateInvoice()
//    {
//        Console.Write("Enter customer name: ");
//        string customerName = Console.ReadLine();
//        Console.Write("Enter total amount: ");
//        decimal totalAmount = decimal.Parse(Console.ReadLine());

//        Invoice newInvoice = new Invoice { CustomerName = customerName, TotalAmount = totalAmount };
//        invoices.Add(newInvoice);

//        Console.WriteLine("Invoice created successfully.");

//        // Save invoices to JSON file
//        SaveInvoicesToJson();
//    }

//    public void SearchInvoice()
//    {
//        Console.Write("Enter customer name to search: ");
//        string searchName = Console.ReadLine();

//        var foundInvoices = invoices.FindAll(invoice => invoice.CustomerName.Contains(searchName));
//        if (foundInvoices.Count > 0)
//        {
//            Console.WriteLine("Found Invoices:");
//            foreach (var invoice in foundInvoices)
//            {
//                Console.WriteLine($"Customer: {invoice.CustomerName}, Total Amount: {invoice.TotalAmount} RO");
//            }
//        }
//        else
//        {
//            Console.WriteLine("No invoices found for the given customer name.");
//        }
//    }

//    private void SaveInvoicesToJson()
//    {
//        string invoicesJson = JsonConvert.SerializeObject(invoices, Formatting.Indented);
//        System.IO.File.WriteAllText("invoices.json", invoicesJson);
//    }
//}