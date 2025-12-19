using System;

class Program
{
    static void Main()
    {
        string name = "";
        int age = 0;
        int ticketType = 0;
        double price = 0;
        double finalPrice = 0;
        bool discountApplied = false;

        // Ask for user's name
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.Write("Enter your name: ");
            name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty.");
            }
        }

        // Ask for user's age
        while (age <= 0)
        {
            Console.Write("Enter your age: ");
            if (!int.TryParse(Console.ReadLine(), out age) || age <= 0)
            {
                Console.WriteLine("Please enter a valid positive age.");
                age = 0;
            }
        }

        // Ticket selection
        bool validTicket = false;
        while (!validTicket)
        {
            Console.WriteLine("\nSelect ticket type:");
            Console.WriteLine("1: Child Ticket (€5)");
            Console.WriteLine("2: Adult Ticket (€10)");
            Console.WriteLine("3: Senior Ticket (€7)");
            Console.Write("Your choice: ");

            if (!int.TryParse(Console.ReadLine(), out ticketType))
            {
                Console.WriteLine("Invalid choice.");
                continue;
            }

            if (ticketType == 1 && age < 12)
            {
                price = 5;
                validTicket = true;
            }
            else if (ticketType == 2 && age >= 12 && age <= 64)
            {
                price = 10;
                validTicket = true;
            }
            else if (ticketType == 3 && age >= 65)
            {
                price = 7;
                validTicket = true;
            }
            else
            {
                Console.WriteLine("Ticket type does not match your age. Try again.");
            }
        }

        finalPrice = price;

        // Discount code
        Console.Write("\nDo you have a discount code? (yes/no): ");
        string hasCode = Console.ReadLine().ToLower();

        while (hasCode == "yes")
        {
            Console.Write("Enter discount code: ");
            string code = Console.ReadLine();

            if (string.Equals(code, "SALE20"))
            {
                finalPrice = price * 0.8;
                discountApplied = true;
                break;
            }
            else
            {
                Console.WriteLine("Invalid discount code.");
                Console.Write("Do you want to try another code? (yes/no): ");
                hasCode = Console.ReadLine().ToLower();
            }
        }

        // Summary
        Console.WriteLine("\n----- Ticket Summary -----");
        Console.WriteLine("Name: " + name);

        if (ticketType == 1)
            Console.WriteLine("Ticket Type: Child");
        else if (ticketType == 2)
            Console.WriteLine("Ticket Type: Adult");
        else
            Console.WriteLine("Ticket Type: Senior");

        Console.WriteLine("Original Price: €" + price);

        if (discountApplied)
            Console.WriteLine("Discount Applied: 20%");
        else
            Console.WriteLine("Discount Applied: None");

        Console.WriteLine("Final Price: €" + finalPrice);
        Console.WriteLine("--------------------------");
    }
}