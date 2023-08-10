using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Xml;
using invoiceSystemApp;
using Newtonsoft.Json;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static invoiceSystemApp.ShopSetting;

namespace invoiceSystemApp;
class Program
{
    static void Main(string[] args)
    {
        ShopSetting shopSetting = new ShopSetting();
        ShopManager shopManager = new ShopManager();
        InvoiceManager invoiceManager = new InvoiceManager();
        ReportGenerator reportGenerator = new ReportGenerator(invoiceManager.GetInvoices());

        while (true)
        {
            Console.WriteLine("---- Welcome to the continental ----");
            Console.WriteLine("\n1. Shop Setting");
            Console.WriteLine("2. Manage Shop Items");
            Console.WriteLine("3. Create New Invoice");
            Console.WriteLine("4. Generate Reports");
            Console.WriteLine("5. Search Invoices");
            Console.WriteLine("6. Exit");

            int choice = GetChoice();
            switch (choice)
            {
                case 1:
                    // Implement Shop Setting logic
                    shopSetting.StartMenu();
                    break;
                case 2:
                    shopManager.StartMenu();
                    break;
                case 3:
                    invoiceManager.CreateInvoice();
                    break;
                case 4:
                    // Implement Generate Reports logic
                    reportGenerator.StartMenu();
                    break;
                case 5:
                    invoiceManager.SearchInvoice();
                    break;
                case 6:
                    Console.WriteLine("Are you sure you want to exit? (Y/N)");
                    string choicee = Console.ReadLine().ToUpper();
                    if(choicee.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        Environment.Exit(0);
                        Console.WriteLine("\nThank you and take care...");
                    }
                    else
                    {
                        Main(args);
                    }
                    break;
            }
        }
    }
    private static int GetChoice()
    {
        Console.Write("\nEnter your choice: ");
        return int.Parse(Console.ReadLine());
    }
}

//the following was used in this consoleApp:

//Lists(List<T>) : In this code, lists are used to store items in the shop inventory (List<Item>),
//                               invoices (List<Invoice>),
//                               and items within each invoice (List<InvoiceItem>).

//Classes: In this code, classes such as Item, Invoice, InvoiceItem, ShopSetting, InvoiceHeader, and InvoiceManager
//         are defined to encapsulate related data and functionality.

//JSON Serialization: JSON (JavaScript Object Notation) is used to represent structured data in a human-readable format.
//                    It's used for saving and loading data from files (items.json and invoices.json).

//Exceptions and Error Handling: While not a traditional data structure, error handling mechanisms are used throughout the code.