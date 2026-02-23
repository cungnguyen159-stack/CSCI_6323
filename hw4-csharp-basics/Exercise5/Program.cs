// Exercise 5: Async Programming
// Doan Thien Cung Nguyen
// CSCI 6323 - Spring 2026

using System.Diagnostics;

Console.WriteLine("=== Exercise 5: Async Programming ===");
Console.WriteLine();

// ========================================
// Part A: Understanding Async/Await
// ========================================
Console.WriteLine("--- Part A: Basic Async/Await ---");
await DemonstrateAsyncAwait();
Console.WriteLine();

// ========================================
// Part B: Sequential vs Parallel
// ========================================
Console.WriteLine("--- Part B: Sequential vs Parallel ---");
await CompareSequentialVsParallel();
Console.WriteLine();

// ========================================
// Part C: Real-world Simulation
// ========================================
Console.WriteLine("--- Part C: Simulated API Calls ---");
await SimulateApiCalls();

// ============================================
// Method Definitions
// ============================================

static async Task DemonstrateAsyncAwait()
{
    Console.WriteLine("Starting async operation...");

    string result = await FetchDataAsync("Product-123");

    Console.WriteLine($"Result: {result}");
    Console.WriteLine("Async operation completed!");
}

static async Task<string> FetchDataAsync(string id)
{
    Console.WriteLine($"  Fetching data for {id}...");

    // Simulate network delay
    await Task.Delay(2000);  // Wait 2 seconds

    return $"Data for {id}";
}

static async Task CompareSequentialVsParallel()
{
    // Sequential: One after another
    Console.WriteLine("SEQUENTIAL EXECUTION:");
    var sw1 = Stopwatch.StartNew();

    await FetchDataAsync("Item-1");
    await FetchDataAsync("Item-2");
    await FetchDataAsync("Item-3");

    sw1.Stop();
    Console.WriteLine($"Sequential total time: {sw1.ElapsedMilliseconds}ms");
    Console.WriteLine();

    // Parallel: All at once
    Console.WriteLine("PARALLEL EXECUTION:");
    var sw2 = Stopwatch.StartNew();

    Task<string> task1 = FetchDataAsync("Item-1");
    Task<string> task2 = FetchDataAsync("Item-2");
    Task<string> task3 = FetchDataAsync("Item-3");

    // Wait for all to complete
    await Task.WhenAll(task1, task2, task3);

    sw2.Stop();
    Console.WriteLine($"Parallel total time: {sw2.ElapsedMilliseconds}ms");
    Console.WriteLine();
    Console.WriteLine($"Parallel is {sw1.ElapsedMilliseconds / sw2.ElapsedMilliseconds}x faster!");
}

static async Task SimulateApiCalls()
{
    var apiClient = new ApiClient();

    Console.WriteLine("Fetching user data...");
    var user = await apiClient.GetUserAsync(1);
    Console.WriteLine($"User: {user.Name} ({user.Email})");
    Console.WriteLine();

    Console.WriteLine("Fetching multiple products in parallel...");
    var products = await apiClient.GetProductsAsync();
    Console.WriteLine($"Retrieved {products.Count} products:");
    foreach (var product in products)
    {
        Console.WriteLine($"  - {product.Name}: ${product.Price}");
    }
}

// ============================================
// Supporting Classes
// ============================================

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

public class ApiClient
{
    // Simulate fetching a user
    public async Task<User> GetUserAsync(int id)
    {
        Console.WriteLine($"  API: Fetching user {id}...");
        await Task.Delay(1000);  // Simulate network delay

        return new User
        {
            Id = id,
            Name = "John Doe",
            Email = "john.doe@example.com"
        };
    }

    // Simulate fetching multiple products
    public async Task<List<Product>> GetProductsAsync()
    {
        // Start all fetches in parallel
        Task<Product> task1 = FetchProductAsync(1, "Laptop", 999.99m);
        Task<Product> task2 = FetchProductAsync(2, "Mouse", 24.99m);
        Task<Product> task3 = FetchProductAsync(3, "Keyboard", 79.99m);

        // Wait for all to complete
        Product[] results = await Task.WhenAll(task1, task2, task3);

        return results.ToList();
    }

    private async Task<Product> FetchProductAsync(int id, string name, decimal price)
    {
        Console.WriteLine($"    API: Fetching product {id}...");
        await Task.Delay(1500);  // Simulate network delay

        return new Product { Id = id, Name = name, Price = price };
    }
}