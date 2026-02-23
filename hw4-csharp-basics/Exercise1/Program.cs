// Exercise 1: Hello C#
// Doan Thien Cung Nguyen
// CSCI 6323 - Spring 2026

Console.WriteLine("=== Exercise 1: Hello C# ===");
Console.WriteLine();

// Basic output
Console.WriteLine("Hello from C#!");
Console.WriteLine($"Today's date: {DateTime.Now:yyyy-MM-dd}");
Console.WriteLine();

// Get user input
Console.Write("Enter your name: ");
string? name = Console.ReadLine();

if (!string.IsNullOrEmpty(name))
{
    Console.WriteLine($"Welcome to C#, {name}!");
}
else
{
    Console.WriteLine("Welcome to C#, mysterious stranger!");
}

// Display some basic info
Console.WriteLine();
Console.WriteLine("=== Environment Info ===");
Console.WriteLine($"OS: {Environment.OSVersion}");
Console.WriteLine($".NET Version: {Environment.Version}");
Console.WriteLine($"Current Directory: {Environment.CurrentDirectory}");