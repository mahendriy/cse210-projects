using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Customer customer = new Customer("Ava Martinez", "ava@example.com", "123 Main St, Provo, UT");

        Product laptop = new Product("Laptop", 999.99m, "Electronics");
        Product wirelessMouse = new Product("Wireless Mouse", 29.99m, "Accessories");
        Product headset = new Product("Headset", 79.50m, "Accessories");

        Order order = new Order(customer);
        order.AddItem(laptop, 1);
        order.AddItem(wirelessMouse, 2);
        order.AddItem(headset, 1);

        Console.WriteLine("Online Order Summary");
        Console.WriteLine("-------------------");
        Console.WriteLine($"Customer: {order.Customer.Name}");
        Console.WriteLine($"Email: {order.Customer.Email}");
        Console.WriteLine($"Shipping Address: {order.Customer.Address}");
        Console.WriteLine();
        Console.WriteLine("Items:");

        foreach (OrderItem item in order.Items)
        {
            Console.WriteLine($"- {item.Product.Name} x{item.Quantity}: ${item.GetSubtotal():F2}");
        }

        Console.WriteLine();
        Console.WriteLine($"Subtotal: ${order.GetSubtotal():F2}");
        Console.WriteLine($"Shipping: ${order.GetShippingCost():F2}");
        Console.WriteLine($"Total: ${order.GetTotal():F2}");
    }
}

class Customer
{
    private string _name;
    private string _email;
    private string _address;

    public Customer(string name, string email, string address)
    {
        _name = name;
        _email = email;
        _address = address;
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }
}

class Product
{
    private string _name;
    private decimal _price;
    private string _category;

    public Product(string name, decimal price, string category)
    {
        _name = name;
        _price = price;
        _category = category;
    }

    public string Name
    {
        get { return _name; }
    }

    public decimal Price
    {
        get { return _price; }
    }

    public string Category
    {
        get { return _category; }
    }
}

class OrderItem
{
    private Product _product;
    private int _quantity;

    public OrderItem(Product product, int quantity)
    {
        _product = product;
        _quantity = quantity;
    }

    public Product Product
    {
        get { return _product; }
    }

    public int Quantity
    {
        get { return _quantity; }
    }

    public decimal GetSubtotal()
    {
        return _product.Price * _quantity;
    }
}

class Order
{
    private Customer _customer;
    private List<OrderItem> _items;

    public Order(Customer customer)
    {
        _customer = customer;
        _items = new List<OrderItem>();
    }

    public Customer Customer
    {
        get { return _customer; }
    }

    public List<OrderItem> Items
    {
        get { return _items; }
    }

    public void AddItem(Product product, int quantity)
    {
        if (quantity > 0)
        {
            _items.Add(new OrderItem(product, quantity));
        }
    }

    public decimal GetSubtotal()
    {
        decimal subtotal = 0m;

        foreach (OrderItem item in _items)
        {
            subtotal += item.GetSubtotal();
        }

        return subtotal;
    }

    public decimal GetShippingCost()
    {
        if (GetSubtotal() >= 100m)
        {
            return 0m;
        }

        return 5m;
    }

    public decimal GetTotal()
    {
        return GetSubtotal() + GetShippingCost();
    }
}