namespace invoiceSystemApp;

class Program
{
    static void Main(string[] args)
    {
        ShopSetting shopSetting = new ShopSetting();
        ShopManager shopManager = new ShopManager();
        invoice invoice = new invoice();
       
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
                    invoice.CreateInvoice();
                    break;
                case 4:
                    // Implement Generate Reports logic
                    break;
                case 5:
                    invoice.SearchInvoice();
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

