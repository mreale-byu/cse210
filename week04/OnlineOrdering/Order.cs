using System.Collections.Generic;
using System.Text;

public class Order
{
    private readonly List<Product> _products;
    private readonly Customer _customer;

    public Order(Customer customer, List<Product> products)
    {
        _customer = customer;
        _products = products;
    }

    public decimal GetTotalCost()
    {
        decimal total = 0m;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        decimal shippingCost = _customer.IsUSA() ? 5m : 35m;

        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder builder = new StringBuilder();

        foreach (Product product in _products)
        {
            builder.AppendLine($"{product.GetName()} ({product.GetId()})");
        }

        return builder.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        return
            $"{_customer.GetName()}\n" +
            $"{_customer.GetAddress().GetAddress()}";
    }
}