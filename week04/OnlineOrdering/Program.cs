//---------------------------------------------------------------------------------
//
// CSE210 - Program.cs
// Title: W04 Foundation Program 2: Online Ordering Program
// Author: Mauricio Reale
//
//--------------------------------------------------------------------------------

class Program
{
    static void Main(string[] args)
    {
        List<Order> orders = [];

        // Order 1 - Brazil

        Customer customer1 = new Customer("Marisa Monte", new Address("Iguatemi 1200", "Salvador", "Bahia", "Brazil"));
        List<Product> products1 = new List<Product>();
        products1.Add(new Product("Coca-Cola", "COLA", 4.50m, 3));
        products1.Add(new Product("Guarana Antarctica", "GUAR", 5.25m, 2));
        orders.Add(new Order(customer1, products1));

        // Order 2 - USA

        Customer customer2 = new Customer("Justin Chavez", new Address("742 Back Street", "Denver", "Colorado", "USA"));
        List<Product> products2 = new List<Product>();
        products2.Add(new Product("Pepsi", "PEPS", 3.95m, 4));
        products2.Add(new Product("Mountain Dew", "MNTD", 4.10m, 2));
        products2.Add(new Product("Dr Pepper", "DRPP", 4.35m, 1));
        orders.Add(new Order(customer2, products2));

        // Order 3 - USA

        Customer customer3 = new Customer("Dora Ichoa", new Address("15 Donald's Avenue", "Austin", "Texas", "USA"));
        List<Product> products3 = new List<Product>();
        products3.Add(new Product("Coca-Cola", "COLA", 4.50m, 3));
        products3.Add(new Product("Guarana Antarctica", "GUAR", 5.25m, 2));
        orders.Add(new Order(customer3, products3));

        // Processing orders
        Console.Clear();
        int orderNo = 1;
        foreach (Order order in orders)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Order {orderNo++}");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine("--------------------");
            Console.WriteLine($"Total Cost: {order.GetTotalCost():C2}");
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
        }
    }
}