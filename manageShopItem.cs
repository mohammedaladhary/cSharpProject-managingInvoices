using System;
using System.Collections.Generic;

internal class ShopManager
{
    private List<Item> items;

    public ShopManager()
    {
        items = new List<Item>();
    }

    public void StartMenu()
    {
        while (true)
        {
            Console.WriteLine("\n1. Add Item");
            Console.WriteLine("2. Delete Item");
            Console.WriteLine("3. Change Item Price");
            Console.WriteLine("4. Report All Items");
            Console.WriteLine("5. Go Back");

            int choice = GetChoice();
            switch (choice)
            {
                case 1:
                    AddItem();
                    break;
                case 2:
                    DeleteItem();
                    break;
                case 3:
                    ChangeItemPrice();
                    break;
                case 4:
                    ReportAllItems();
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

    private void AddItem()
    {
        Console.Write("Enter item name: ");
        string name = Console.ReadLine();
        Console.Write("Enter item price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        items.Add(new Item { Name = name, Price = price });
        Console.WriteLine("Item added successfully.");
    }

    private void DeleteItem()
    {
        Console.Write("Enter item name to delete: ");
        string name = Console.ReadLine();

        Item itemToRemove = items.Find(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (itemToRemove != null)
        {
            items.Remove(itemToRemove);
            Console.WriteLine("Item deleted successfully.");
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }

    private void ChangeItemPrice()
    {
        Console.Write("Enter item name to change price: ");
        string name = Console.ReadLine();

        Item itemToUpdate = items.Find(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (itemToUpdate != null)
        {
            Console.Write("Enter new price: ");
            decimal newPrice = decimal.Parse(Console.ReadLine());
            itemToUpdate.Price = newPrice;
            Console.WriteLine("Item price changed successfully.");
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }

    private void ReportAllItems()
    {
        Console.WriteLine("Shop Items:");
        foreach (var item in items)
        {
            Console.WriteLine($"Name: {item.Name}, Price: {item.Price}");
        }
    }
}