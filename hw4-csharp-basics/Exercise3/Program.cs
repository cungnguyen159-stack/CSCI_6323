// Exercise 3: Collections and LINQ
// Doan Thien Cung Nguyen
// CSCI 6323 - Spring 2026

Console.WriteLine("=== Exercise 3: Collections and LINQ ===");
Console.WriteLine();

// ========================================
// Part A: Working with Lists
// ========================================
Console.WriteLine("--- Part A: Lists ---");

// Create a list of strings
List<string> courses = new List<string>
{
    "Server Web Development",
    "Database Systems",
    "Software Engineering",
    "Algorithms",
    "Computer Networks"
};

Console.WriteLine($"We have {courses.Count} courses:");
foreach (var course in courses)
{
    Console.WriteLine($"  - {course}");
}
Console.WriteLine();

// Add, remove, check
courses.Add("Machine Learning");
Console.WriteLine($"Added a course. Total: {courses.Count}");

if (courses.Contains("Database Systems"))
{
    Console.WriteLine("Database Systems is in the list!");
}
Console.WriteLine();

// ========================================
// Part B: Working with Dictionaries
// ========================================
Console.WriteLine("--- Part B: Dictionaries ---");

// Dictionary<TKey, TValue>
Dictionary<string, int> studentGrades = new Dictionary<string, int>
{
    { "Alice", 95 },
    { "Bob", 87 },
    { "Charlie", 92 },
    { "Diana", 88 }
};

Console.WriteLine("Student Grades:");
foreach (var kvp in studentGrades)
{
    Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
}
Console.WriteLine();

// Access by key
Console.WriteLine($"Bob's grade: {studentGrades["Bob"]}");

// Safe access
if (studentGrades.TryGetValue("Eve", out int grade))
{
    Console.WriteLine($"Eve's grade: {grade}");
}
else
{
    Console.WriteLine("Eve not found in dictionary");
}
Console.WriteLine();

// ========================================
// Part C: LINQ Queries
// ========================================
Console.WriteLine("--- Part C: LINQ Queries ---");

// Sample data: list of numbers
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Filter: Get even numbers
var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
Console.WriteLine($"Even numbers: {string.Join(", ", evenNumbers)}");

// Transform: Square each number
var squares = numbers.Select(n => n * n).ToList();
Console.WriteLine($"Squares: {string.Join(", ", squares)}");

// Aggregate: Sum all numbers
int sum = numbers.Sum();
Console.WriteLine($"Sum: {sum}");

// Chain operations
var sumOfEvenSquares = numbers
    .Where(n => n % 2 == 0)   // Filter: only even numbers
    .Select(n => n * n)        // Transform: square them
    .Sum();                    // Aggregate: sum the results
Console.WriteLine($"Sum of even squares: {sumOfEvenSquares}");
Console.WriteLine();

// ========================================
// Part D: LINQ with Objects
// ========================================
Console.WriteLine("--- Part D: LINQ with Objects ---");

// Create a simple Product class inline
var products = new List<dynamic>
{
    new { Id = 1, Name = "Laptop", Price = 999.99, InStock = true },
    new { Id = 2, Name = "Mouse", Price = 24.99, InStock = true },
    new { Id = 3, Name = "Keyboard", Price = 79.99, InStock = false },
    new { Id = 4, Name = "Monitor", Price = 299.99, InStock = true },
    new { Id = 5, Name = "Webcam", Price = 59.99, InStock = false }
};

Console.WriteLine("All products:");
foreach (var p in products)
{
    Console.WriteLine($"  {p.Name}: ${p.Price} (In Stock: {p.InStock})");
}
Console.WriteLine();

// Query: Get products in stock
var inStockProducts = products.Where(p => p.InStock).ToList();
Console.WriteLine($"Products in stock ({inStockProducts.Count}):");
foreach (var p in inStockProducts)
{
    Console.WriteLine($"  - {p.Name}");
}
Console.WriteLine();

// Query: Get products under $100
var affordableProducts = products.Where(p => p.Price < 100).ToList();
Console.WriteLine($"Products under $100 ({affordableProducts.Count}):");
foreach (var p in affordableProducts)
{
    Console.WriteLine($"  - {p.Name}: ${p.Price}");
}
Console.WriteLine();

// Query: Get product names only, sorted
var productNames = products
    .OrderBy(p => p.Name)
    .Select(p => p.Name)
    .ToList();
Console.WriteLine($"Product names (sorted): {string.Join(", ", productNames)}");
Console.WriteLine();

// ========================================
// Part E: JavaScript Array Methods vs LINQ
// ========================================
Console.WriteLine("--- Part E: JavaScript vs LINQ ---");
Console.WriteLine();
Console.WriteLine("JavaScript:");
Console.WriteLine("  const evens = numbers.filter(n => n % 2 === 0);");
Console.WriteLine("  const squares = numbers.map(n => n * n);");
Console.WriteLine("  const sum = numbers.reduce((a, b) => a + b, 0);");
Console.WriteLine();
Console.WriteLine("C# LINQ:");
Console.WriteLine("  var evens = numbers.Where(n => n % 2 == 0).ToList();");
Console.WriteLine("  var squares = numbers.Select(n => n * n).ToList();");
Console.WriteLine("  var sum = numbers.Sum();");
Console.WriteLine();
Console.WriteLine("LINQ is like JavaScript array methods on steroids!");
