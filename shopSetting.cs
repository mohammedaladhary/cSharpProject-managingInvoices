using System;
using System.Collections.Generic;
using invoiceSystemApp;
using System.Text.Json;
using Newtonsoft.Json;

namespace invoiceSystemApp;


internal class ShopSetting
{
    private List<Item> items;
    private List<Invoice> invoices;
    //private List<InvoiceItem> invoiceItems;

    public string ShopName { get; private set; }
    public InvoiceHeader InvoiceHeader { get; private set; }

    public ShopSetting()
    {
        items = new List<Item>();
        invoices = new List<Invoice>();
        ShopName = "Default Shop Name";
        InvoiceHeader = new InvoiceHeader();
    }

    public void StartMenu()
    {
        while (true)
        {
            Console.WriteLine("\n1. Load Data Items");
            Console.WriteLine("2. Load Data Invoices");
            Console.WriteLine("3. Set Shop Name");
            Console.WriteLine("4. Set Invoice Header");
            Console.WriteLine("5. Go Back");

            int choice = GetChoice();
            switch (choice)
            {
                case 1:
                    LoadItems(ref items);
                    break;
                case 2:
                    LoadInvoices(ref invoices);
                    break;
                case 3:
                    SetShopName();
                    break;
                case 4:
                    SetInvoiceHeader();
                    break;
                case 5:
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
    public void LoadItems(ref List<Item> items)
    {
        try
        {
                if (File.Exists("shop Setting/items.json"))
                {
                    string json = File.ReadAllText("Shop Setting/items.json");
                    items = System.Text.Json.JsonSerializer.Deserialize<List<Item>>(json);
                    Console.WriteLine("Data loaded successfully.");
                }
                else
                {
                    items = new List<Item>();
                }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading items data: {ex.Message}");
            items = new List<Item>();
        }
    }
    public void LoadInvoices(ref List<Invoice> invoices)
    {
        try
        {
                if (File.Exists("shop Setting/invoices.json"))
                {
                    string json = File.ReadAllText("Shop Setting/invoices.json");
                    invoices = System.Text.Json.JsonSerializer.Deserialize<List<Invoice>>(json);
                    Console.WriteLine("Data loaded successfully.");
                }
                else
                {
                    invoices = new List<Invoice>();
                }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading invoices data: {ex.Message}");
            invoices = new List<Invoice>();
        }
    }

    private void SetShopName()
    {
        Console.Write("Enter shop name: ");
        ShopName = Console.ReadLine();
        Console.WriteLine("Shop name set successfully.");
    }

    private void SetInvoiceHeader()
    {
        Console.Write("Enter tel: ");
        string tel = Console.ReadLine();
        Console.Write("Enter fax: ");
        string fax = Console.ReadLine();
        Console.Write("Enter email: ");
        string email = Console.ReadLine();
        Console.Write("Enter website: ");
        string website = Console.ReadLine();

        InvoiceHeader = new InvoiceHeader { Tel = tel, Fax = fax, Email = email, Website = website };
        Console.WriteLine("Invoice header set successfully.");
    }

    internal class InvoiceManager
    {
        private List<Invoice> invoices;

        public InvoiceManager()
        {
            invoices = new List<Invoice>();
        }
        public List<Invoice> GetInvoices()
        {
            return invoices;
        }
        public void CreateInvoice()
        {
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter total amount: ");
            decimal totalAmount = decimal.Parse(Console.ReadLine());

            Invoice newInvoice = new Invoice { CustomerName = customerName, TotalAmount = totalAmount };
            invoices.Add(newInvoice);

            Console.WriteLine("Invoice created successfully.");

            // Save invoices to JSON file
            SaveInvoicesToJson();
            
        }

        public void SearchInvoice()
        {
            Console.Write("Enter customer name to search: ");
            string searchName = Console.ReadLine();

            var foundInvoices = invoices.FindAll(invoice => invoice.CustomerName.Contains(searchName));
            if (foundInvoices.Count > 0)
            {
                Console.WriteLine("Found Invoices:");
                foreach (var invoice in foundInvoices)
                {
                    Console.WriteLine($"Customer: {invoice.CustomerName}, Total Amount: {invoice.TotalAmount} RO");
                }
            }
            else
            {
                Console.WriteLine("No invoices found for the given customer name.");
            }
        }

        private void SaveInvoicesToJson()
        {
            string invoicesJson = Newtonsoft.Json.JsonConvert.SerializeObject(invoices, Formatting.Indented);
            System.IO.File.WriteAllText("invoices.json", invoicesJson);
        }

    }
}

internal class Invoice
{
    public string CustomerName { get; set; }
    public List<InvoiceItem> Items { get; set; }
    //public decimal TotalAmount => Items.Sum(item => item.TotalPrice);
    public decimal TotalAmount { get; set; }
    
}

internal class InvoiceHeader
{
    public string Tel { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
}

  internal class Item
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

internal class InvoiceItem
{
    public string ItemName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
}


//private void LoadData()
//{
//    // Simulate loading data
//    items = new List<Item>
//    {
//        new Item { Name = "Rice", Price = 10.99M },
//        new Item { Name = "Milk", Price = 15.75M },
//        // Add more items
//    };

//    invoices = new List<Invoice>
//    {
//        new Invoice { CustomerName = "Mohammed", TotalAmount = 26.74M },
//        new Invoice { CustomerName = "Ahmed", TotalAmount = 42.50M },
//        // Add more invoices
//    };

//    Console.WriteLine("Data loaded successfully.");
//}

//private void LoadData()
//{
//    //try
//    //{
//    //    // Simulate loading data from JSON files
//    //    string itemsJson = System.IO.File.ReadAllText("items.json");
//    //    items = JsonConvert.DeserializeObject<List<Item>>(itemsJson);

//    //    string invoicesJson = System.IO.File.ReadAllText("invoices.json");
//    //    invoices = JsonConvert.DeserializeObject<List<Invoice>>(invoicesJson);

//    //    Console.WriteLine("Data loaded successfully.");
//    //}
//    //catch (Exception ex)
//    //{
//    //    Console.WriteLine($"An error occurred while loading data: {ex.Message}");
//    //}
//}
