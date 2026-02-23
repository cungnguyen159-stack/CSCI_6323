// Exercise 4: Classes and Objects
// Doan Thien Cung Nguyen
// CSCI 6323 - Spring 2026

Console.WriteLine("=== Exercise 4: Classes and Objects ===");
Console.WriteLine();

// Create a product inventory
var inventory = new ProductInventory();

// Add some products
inventory.AddProduct(new Product
{
    Id = 1,
    Name = "Laptop",
    Price = 999.99m,
    Stock = 5,
    Category = "Electronics"
});

inventory.AddProduct(new Product
{
    Id = 2,
    Name = "Mouse",
    Price = 24.99m,
    Stock = 15,
    Category = "Electronics"
});

inventory.AddProduct(new Product
{
    Id = 3,
    Name = "Desk Chair",
    Price = 199.99m,
    Stock = 0,
    Category = "Furniture"
});

inventory.AddProduct(new Product
{
    Id = 4,
    Name = "Monitor",
    Price = 299.99m,
    Stock = 8,
    Category = "Electronics"
});

// Display all products
Console.WriteLine("=== Product Inventory ===");
inventory.DisplayAllProducts();
Console.WriteLine();

// Search for a product
Console.WriteLine("=== Search by ID ===");
var product = inventory.GetProductById(2);
if (product != null)
{
    product.DisplayInfo();
}
Console.WriteLine();

// Get products by category
Console.WriteLine("=== Electronics Category ===");
var electronics = inventory.GetProductsByCategory("Electronics");
Console.WriteLine($"Found {electronics.Count} electronics:");
foreach (var p in electronics)
{
    Console.WriteLine($"  - {p.Name}: ${p.Price}");
}
Console.WriteLine();

// Get in-stock products
Console.WriteLine("=== In-Stock Products ===");
var inStock = inventory.GetInStockProducts();
Console.WriteLine($"Found {inStock.Count} products in stock:");
foreach (var p in inStock)
{
    Console.WriteLine($"  - {p.Name} ({p.Stock} available)");
}
Console.WriteLine();

// Calculate total inventory value
Console.WriteLine("=== Inventory Statistics ===");
decimal totalValue = inventory.CalculateTotalValue();
Console.WriteLine($"Total inventory value: ${totalValue:N2}");
Console.WriteLine($"Total products: {inventory.GetProductCount()}");
Console.WriteLine($"Average price: ${inventory.GetAveragePrice():N2}");

// ============================================
// Product Class Definition
// ============================================
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Category { get; set; } = string.Empty;

    // Computed property
    public bool IsInStock => Stock > 0;

    // Method to display product info
    public void DisplayInfo()
    {
        Console.WriteLine($"Product #{Id}: {Name}");
        Console.WriteLine($"  Price: ${Price}");
        Console.WriteLine($"  Stock: {Stock} units");
        Console.WriteLine($"  Category: {Category}");
        Console.WriteLine($"  Status: {(IsInStock ? "In Stock" : "Out of Stock")}");
    }
}

// ============================================
// ProductInventory Class Definition
// ============================================
public class ProductInventory
{
    private List<Product> _products = new List<Product>();

    // Add a product
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Get product by ID
    public Product? GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    // Get products by category
    public List<Product> GetProductsByCategory(string category)
    {
        return _products
            .Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    // Get in-stock products
    public List<Product> GetInStockProducts()
    {
        return _products.Where(p => p.IsInStock).ToList();
    }

    // Display all products
    public void DisplayAllProducts()
    {
        foreach (var product in _products)
        {
            Console.WriteLine($"#{product.Id} - {product.Name} (${product.Price}) - Stock: {product.Stock}");
        }
    }

    // Calculate total inventory value
    public decimal CalculateTotalValue()
    {
        return _products.Sum(p => p.Price * p.Stock);
    }

    // Get product count
    public int GetProductCount()
    {
        return _products.Count;
    }

    // Get average price
    public decimal GetAveragePrice()
    {
        return _products.Count > 0 ? _products.Average(p => p.Price) : 0;
    }
}