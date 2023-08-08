using System;
using System.Collections.Generic;

internal class ShopSetting
{
    private List<Item> items;
    private List<Invoice> invoices;

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
            Console.WriteLine("\n1. Load Data (Items and Invoices)");
            Console.WriteLine("2. Set Shop Name");
            Console.WriteLine("3. Set Invoice Header");
            Console.WriteLine("4. Go Back");

            int choice = GetChoice();
            switch (choice)
            {
                case 1:
                    LoadData();
                    break;
                case 2:
                    SetShopName();
                    break;
                case 3:
                    SetInvoiceHeader();
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

    private void LoadData()
    {
        // Simulate loading data
        items = new List<Item>
        {
            new Item { Name = "Item 1", Price = 10.99M },
            new Item { Name = "Item 2", Price = 15.75M },
            // Add more items
        };

        invoices = new List<Invoice>
        {
            new Invoice { CustomerName = "Customer 1", TotalAmount = 26.74M },
            new Invoice { CustomerName = "Customer 2", TotalAmount = 42.50M },
            // Add more invoices
        };

        Console.WriteLine("Data loaded successfully.");
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

internal class Invoice
{
    public string CustomerName { get; set; }
    public decimal TotalAmount { get; set; }
}