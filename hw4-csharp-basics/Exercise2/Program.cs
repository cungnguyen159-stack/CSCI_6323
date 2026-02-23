// Exercise 2: Types and Variables
// Doan Thien Cung Nguyen
// CSCI 6323 - Spring 2026

Console.WriteLine("=== Exercise 2: Types and Variables ===");
Console.WriteLine();

// ========================================
// Part A: Basic Types
// ========================================
Console.WriteLine("--- Part A: Basic Types ---");

// Integer types
int age = 25;
long population = 8_000_000_000L;  // Underscore for readability

// Floating point types
double price = 19.99;
decimal money = 1234.56m;  // Use 'decimal' for currency

// Boolean
bool isStudent = true;

// Character and String
char initial = 'B';
string course = "Server Web Development";

Console.WriteLine($"Age: {age} (type: {age.GetType()})");
Console.WriteLine($"Population: {population:N0} (type: {population.GetType()})");
Console.WriteLine($"Price: ${price} (type: {price.GetType()})");
Console.WriteLine($"Money: ${money} (type: {money.GetType()})");
Console.WriteLine($"Is Student: {isStudent} (type: {isStudent.GetType()})");
Console.WriteLine($"Initial: {initial} (type: {initial.GetType()})");
Console.WriteLine($"Course: {course} (type: {course.GetType()})");
Console.WriteLine();

// ========================================
// Part B: Type Conversions
// ========================================
Console.WriteLine("--- Part B: Type Conversions ---");

// Implicit conversion (safe, no data loss)
int smallNumber = 100;
long bigNumber = smallNumber;  // int → long (OK)
Console.WriteLine($"Implicit: int {smallNumber} → long {bigNumber}");

// Explicit conversion (cast, may lose data)
double decimalNumber = 123.99;
int wholeNumber = (int)decimalNumber;  // Truncates decimal
Console.WriteLine($"Explicit: double {decimalNumber} → int {wholeNumber}");

// Parsing strings to numbers
string numberText = "42";
int parsedNumber = int.Parse(numberText);
Console.WriteLine($"Parsed: string \"{numberText}\" → int {parsedNumber}");

// Safe parsing (doesn't throw exception)
string badText = "not a number";
if (int.TryParse(badText, out int result))
{
    Console.WriteLine($"Successfully parsed: {result}");
}
else
{
    Console.WriteLine($"Failed to parse: \"{badText}\"");
}
Console.WriteLine();

// ========================================
// Part C: var Keyword (Type Inference)
// ========================================
Console.WriteLine("--- Part C: Type Inference with var ---");

var inferredInt = 42;           // Compiler infers int
var inferredString = "Hello";   // Compiler infers string
var inferredDouble = 3.14;      // Compiler infers double

Console.WriteLine($"inferredInt is type: {inferredInt.GetType()}");
Console.WriteLine($"inferredString is type: {inferredString.GetType()}");
Console.WriteLine($"inferredDouble is type: {inferredDouble.GetType()}");
Console.WriteLine();

// ========================================
// Part D: JavaScript vs C# Comparison
// ========================================
Console.WriteLine("--- Part D: JavaScript vs C# ---");
Console.WriteLine();
Console.WriteLine("JavaScript (dynamic typing):");
Console.WriteLine("  let x = 5;        // x is a number");
Console.WriteLine("  x = 'hello';      // Now x is a string (OK!)");
Console.WriteLine();
Console.WriteLine("C# (static typing):");
Console.WriteLine("  int x = 5;        // x is an int");
Console.WriteLine("  x = 'hello';      // ERROR! Cannot assign string to int");
Console.WriteLine();
Console.WriteLine("Benefits of static typing:");
Console.WriteLine("  ✓ Catches errors at compile time");
Console.WriteLine("  ✓ Better IntelliSense/autocomplete");
Console.WriteLine("  ✓ Clearer code intent");
Console.WriteLine("  ✓ Better performance");