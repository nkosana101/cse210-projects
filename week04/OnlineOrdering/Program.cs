using System;
using System.Collections.Generic;

/// <summary>
/// Represents a physical address.
/// </summary>
public class Address
{
    private string _street;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string street, string city, string stateProvince, string country)
    {
        _street = street;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_stateProvince}\n{_country}";
    }
}

/// <summary>
/// Represents a customer with a name and address.
/// </summary>
public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName() => _name;
    public Address GetAddress() => _address;

    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }
}

/// <summary>
/// Represents a product with name, ID, price per unit, and quantity.
/// </summary>
public class Product
{
    private string _name;
    private string _productId;
    private decimal _pricePerUnit;
    private int _quantity;

    public Product(string name, string productId, decimal pricePerUnit, int quantity)
    {
        _name = name;
        _productId = productId;
        _pricePerUnit = pricePerUnit;
        _quantity = quantity;
    }

    public string GetName() => _name;
    public string GetProductId() => _productId;
    public decimal GetTotalCost()
    {
        return _pricePerUnit * _quantity;
    }
}

/// <summary>
/// Represents an order containing a list of products and a customer.
/// </summary>
public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal productTotal = 0;
        foreach (Product product in _products)
        {
            productTotal += product.GetTotalCost();
        }

        // Shipping cost: $5 for USA, $35 otherwise
        decimal shippingCost = _customer.LivesInUSA() ? 5 : 35;
        return productTotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "PACKING LABEL\n";
        label += "--------------\n";
        foreach (Product product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "SHIPPING LABEL\n";
        label += "---------------\n";
        label += $"{_customer.GetName()}\n";
        label += _customer.GetAddress().GetFullAddress();
        return label;
    }
}

/// <summary>
/// Main program that creates orders, products, customers, and displays results.
/// </summary>
class Program
{
    static void Main()
    {
        // ----- Create addresses -----
        Address usaAddress = new Address("123 Main St", "Springfield", "IL", "USA");
        Address internationalAddress = new Address("45 Rue de Paris", "Lyon", "Rhône", "France");

        // ----- Create customers -----
        Customer customer1 = new Customer("John Doe", usaAddress);
        Customer customer2 = new Customer("Marie Curie", internationalAddress);

        // ----- Create products -----
        Product product1 = new Product("Laptop", "P1001", 799.99m, 1);
        Product product2 = new Product("Mouse", "P1002", 19.99m, 2);
        Product product3 = new Product("Keyboard", "P1003", 49.99m, 1);
        Product product4 = new Product("Monitor", "P1004", 199.99m, 1);
        Product product5 = new Product("USB Cable", "P1005", 9.99m, 3);

        // ----- Create order 1 (USA customer) with 2 products -----
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        // ----- Create order 2 (international customer) with 3 products -----
        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // ----- Display order 1 details -----
        Console.WriteLine("ORDER #1");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():0.00}\n");
        Console.WriteLine(new string('-', 40) + "\n");

        // ----- Display order 2 details -----
        Console.WriteLine("ORDER #2");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():0.00}\n");
    }
}