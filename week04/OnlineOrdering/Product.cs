public class Product
{
    private readonly string _name;
    private readonly string _id;
    private readonly decimal _price;
    private readonly int _quantity;

    public Product(string name, string id,  decimal price, int quantity)
    {
        _name = name;
        _id = id;
        _price = price;
        _quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetId()
    {
        return _id;
    }
}