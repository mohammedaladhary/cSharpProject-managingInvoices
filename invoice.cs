using System;
namespace invoiceSystemApp
{
    internal class invoice
    {
        private List<Invoice> invoices;

        public invoice()
        {
            invoices = new List<Invoice>();
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

        //public void StartMenu()
        //{
        //    while (true)
        //    {
        //        Console.WriteLine("\n1. Create New Invoice");
        //        Console.WriteLine("2. Search Invoice");
        //        Console.WriteLine("3. Back to Main Menu");

        //        int choice = GetChoice();
        //        switch (choice)
        //        {
        //            case 1:
        //                CreateInvoice();
        //                break;
        //            case 2:
        //                SearchInvoice();
        //                break;
        //            case 3:
        //                return;
        //            default:
        //                Console.WriteLine("\nInvalid choice. Please select a valid option.");
        //                break;
        //        }
        //    }

    }
}

