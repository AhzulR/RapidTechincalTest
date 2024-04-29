using System;
using System.IO;
using System.Reflection;
using CsvHelper;

class ArrayRotation
{
    // Function to rotate an array by a specified number of positions (d)
    public static void RotateArray(int[] arr, int d)
    {
        // Handle cases where d is greater than or equal to array length
        d = d % arr.Length;

        // Efficient in-place array reversal using two-pointer approach
        int left = 0, right = arr.Length - 1;
        while (left < right)
        {
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
            left++;
            right--;
        }

        // Reverse the first d elements and the remaining elements separately
        left = 0;
        right = d - 1;
        while (left < right)
        {
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
            left++;
            right--;
        }

        left = d;
        right = arr.Length - 1;
        while (left < right)
        {
            int temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
            left++;
            right--;
        }
    }
}

class SequentialPrinter
{
    public static void PrintSequentially(int input)
    {
        // Start from the input value and iterate downwards indefinitely
        for (int num = 1; num <= input; num++)
        {
            if (num % 2 == 0 && num % 3 == 0)
            {
                Console.WriteLine("TwoThree");
            }
            else if (num % 2 == 0)
            {
                Console.WriteLine("Two");
            }
            else if (num % 3 == 0)
            {
                Console.WriteLine("Three");
            }
            else
            {
                Console.WriteLine(num);
            }
        }
    }
}

class CanRabbitsMeet 
{
    public static string PrintCanRabbitsMeet(int rabbit1Start, int rabbit1Velocity, int rabbit2Start, int rabbit2Velocity)
    {
        // If the velocities are the same, the rabbits will never meet

        if ((rabbit1Start > rabbit2Start && (rabbit2Velocity - rabbit1Velocity) % (rabbit1Start - rabbit2Start) == 0) || (rabbit2Start > rabbit1Start && (rabbit1Velocity - rabbit2Velocity) % (rabbit2Start - rabbit1Start) == 0))
        {
            return "YES";
        }
        else
        {
            return "NO";
        }
    }
}

class CustomerOrder
{
    public class Customer
    { 
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        public Customer(int customerId, string firstName, string lastName, int age, string country)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Country = country;
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string Item { get; set; }
        public int Amount { get; set; }
        public int CustomerId { get; set; }

        public Order(int orderId, string item, int amount, int customerId)
        {
            OrderId = orderId;
            Item = item;
            Amount = amount;
            CustomerId = customerId;
        }
    }
}

public class CombinedProgram
{
    public static void Main(string[] args)
    {
        // Welcome message
        Console.WriteLine("Welcome to the Combined Program!\n");
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Array Rotation");
        Console.WriteLine("2. Sequential Printing");
        Console.WriteLine("3. Rabbit Meeting");
        Console.WriteLine("4. Min Total Amount of Orders >= 500");
        Console.WriteLine("5. Oldest to Youngest Customers with Country Name");
        Console.WriteLine("6. Exit");
        Console.Write("Enter your choice: ");
        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Input tidak valid. Silakan masukkan angka 1, 2, atau 3.\n");
            return;
        }
        if (choice == 1)
        {
            ArrayRotationMain(args);
        }
        else if (choice == 2)
        {
            SequentialPrinterMain(args);
        }
        else if (choice == 3)
        {
            RabbitMeetingMain(args);
        }
        else if (choice == 4)
        {
            QuerryCustomer500(args);
        }
        else if (choice == 5)
        {
            OldtoYoungCustomersMain(args);
        }
        else if (choice == 6)
        {
            Console.WriteLine("Terima kasih telah menggunakan program ini. Sampai jumpa lagi!");
        }
        else
        {
            Console.WriteLine("Pilihan tidak valid. Silakan pilih sesuai pillihan yang ada.\n");
        }
    }
    public static void ArrayRotationMain(string[] args) 
    {
        // Welcome message
        Console.WriteLine("** Array Rotation **");
        int[] nums = { 1, 2, 3, 4, 5};
        Console.WriteLine("\nArray Asli: [{0}]", string.Join(", ", nums));

        Console.Write("Masukkan jumlah rotasi (angka positif): ");
        int rotations;

            // Validate user input for positive integer
        while (!int.TryParse(Console.ReadLine(), out rotations) || rotations < 0)
        {
            Console.WriteLine("Input tidak valid. Silakan masukkan angka positif.\n");
            Console.Write("Masukkan jumlah rotasi (angka positif): ");
        }

            // Rotate the array
        ArrayRotation.RotateArray(nums, rotations);

        Console.WriteLine("\nArray Setelah di Rotasi [{0}]\n", string.Join(", ", nums));
    }
        // Array rotation section

    public static void SequentialPrinterMain(string[] args) 
    {
            // Sequential printing section
        Console.WriteLine("** Sequential Printing **");
        Console.Write("Masukkan bilangan bulat: ");
        int input;

            // Validate user input for positive integer
        while (!int.TryParse(Console.ReadLine(), out input) || input <= 0)
        {
            Console.WriteLine("Input tidak valid. Silakan masukkan bilangan bulat positif.\n");
            Console.Write("Masukkan bilangan bulat: ");
        }

            // Print numbers sequentially
        SequentialPrinter.PrintSequentially(input);
    }

    public static void RabbitMeetingMain(string[] args)
    {
        Console.WriteLine("** Rabbit Meeting **");
        Console.Write("Enter starting point for Rabbit 1: ");
        int rabbit1Start = int.Parse(Console.ReadLine());

        Console.Write("Enter velocity for Rabbit 1: ");
        int rabbit1Velocity = int.Parse(Console.ReadLine());

        Console.Write("Enter starting point for Rabbit 2: ");
        int rabbit2Start = int.Parse(Console.ReadLine());

        Console.Write("Enter velocity for Rabbit 2: ");
        int rabbit2Velocity = int.Parse(Console.ReadLine());

        string meetingResult = CanRabbitsMeet.PrintCanRabbitsMeet(rabbit1Start, rabbit1Velocity, rabbit2Start, rabbit2Velocity);
        Console.WriteLine(meetingResult);
    }

    public static void QuerryCustomer500(string[] args)
    {
        // Read CSV file section
        Console.WriteLine("** Query 500 Orders **");
        string customersFilePath = @"D:\Rapid\customers.csv";
        string ordersFilePath = @"D:\Rapid\orders.csv";
        
        int minTotalAmount = 500;
        
        try
        {
            List<CustomerOrder.Customer> customers = new List<CustomerOrder.Customer>();
            using (var reader = new StreamReader(customersFilePath)) // Open the file for reading
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture)) // Create a CsvReader using the StreamReader
            {
                csv.Read(); // Skip the header row (if any
                while (csv.Read()) // Read each line of the CSV data
                {
                    int customerId = csv.GetField<int>(0);
                    string firstName = csv.GetField<string>(1);
                    string lastName = csv.GetField<string>(2);
                    int age = csv.GetField<int>(3);
                    string country = csv.GetField<string>(4);

                    customers.Add(new CustomerOrder.Customer(customerId, firstName, lastName, age, country));
                }
            }

            List<CustomerOrder.Order> orders = new List<CustomerOrder.Order>();
            using (var reader = new StreamReader(ordersFilePath)) // Open the file for reading
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture)) // Create a CsvReader using the StreamReader
            {
                csv.Read(); // Skip the header row (if any)
                while (csv.Read()) // Read each line of the CSV data
                {
                    int orderId = csv.GetField<int>(0);
                    string item = csv.GetField<string>(1);
                    int amount = csv.GetField<int>(2);
                    int customerId = csv.GetField<int>(3);

                    orders.Add(new CustomerOrder.Order(orderId, item, amount, customerId));
                }
            }

            var query = from customer in customers
                        join order in orders on customer.CustomerId equals order.CustomerId
                        group new { customer, order } by new { customer.CustomerId, customer.FirstName, customer.LastName } into g
                        where g.Sum(x => x.order.Amount) >= minTotalAmount
                        select new
                        {
                            customerName = g.Key.FirstName + " " + g.Key.LastName,
                            totalOrders = g.Count(),
                            totalAmountOrders = g.Sum(x => x.order.Amount)
                        };
            
            foreach (var result in query)
            {
                Console.WriteLine($"Customer Name: {result.customerName}, Total Orders: {result.totalOrders}, Total Amount of Orders: {result.totalAmountOrders}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing data: {ex.Message}");
        }
    
    }

    public static void OldtoYoungCustomersMain (string[] args)
    {
        // Read CSV file section
        Console.WriteLine("** Oldest to Youngest Customers with Country Name **");
        string customersFilePath = @"D:\Rapid\customers.csv";
        string ordersFilePath = @"D:\Rapid\orders.csv";
        
        Dictionary<string, string> countryMap = new Dictionary<string, string>()
        {
            { "USA", "United States" },
            { "UK", "United Kingdom" },
            { "UAE", "United Arab Emirates" },
            // Add more mappings as needed
        };

        try
        {
            List<CustomerOrder.Customer> customers = new List<CustomerOrder.Customer>();
            using (var reader = new StreamReader(customersFilePath)) // Open the file for reading
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture)) // Create a CsvReader using the StreamReader
            {
                csv.Read(); // Skip the header row (if any
                while (csv.Read()) // Read each line of the CSV data
                {
                    int customerId = csv.GetField<int>(0);
                    string firstName = csv.GetField<string>(1);
                    string lastName = csv.GetField<string>(2);
                    int age = csv.GetField<int>(3);
                    string country = csv.GetField<string>(4);

                    customers.Add(new CustomerOrder.Customer(customerId, firstName, lastName, age, country));
                }
            }

            var query = from customer in customers
                        orderby customer.Age descending
                        select new
                        {
                            customerName = customer.FirstName + " " + customer.LastName,
                            customerAge = customer.Age,
                            customerCountry = countryMap.GetValueOrDefault(customer.Country)
                        };
            
            foreach (var result in query)
            {
                Console.WriteLine($"Customer Name: {result.customerName}, Age: {result.customerAge}, Country: {result.customerCountry}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing data: {ex.Message}");
        }
    }
}
