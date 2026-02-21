using System;

/* * Prelim Activity 01: Codac Logistics Delivery & Fuel Auditor
 * By: Marwen C. De Castro
 * Description: A simple program to track a driver's weekly fuel and distance.
 */

Console.WriteLine("=== Codac Logistics Delivery & Fuel Auditor ===");

// --- Task 1: Driver Profile ---
// I used a string here because the driver's name is just text.
Console.Write("Enter Driver's Full Name: ");
string driverName = Console.ReadLine(); 

// I chose decimal for the budget because it's the best type for money.
Console.Write("Enter Weekly Fuel Budget: ");
decimal weeklyBudget = decimal.Parse(Console.ReadLine()); 

// --- Task 1: Distance Validation ---
// I used a double for distance because it allows for decimal points (like 10.5 km).
double totalDistance = 0; 
bool isDistanceValid = false; 

// I used a while loop so the program keeps asking until the user gives a valid number.
// If I used an 'if', it would only check the number once.
while (!isDistanceValid) 
{
    Console.Write("Enter Total Distance Traveled this week (1.0 - 5000.0 km): ");
    string input = Console.ReadLine();
    
    // This checks if the input is a number and if it's within the 1.0 to 5000.0 range.
    if (double.TryParse(input, out totalDistance) && totalDistance >= 1.0 && totalDistance <= 5000.0)
    {
        isDistanceValid = true; 
    }
    else
    {
        Console.WriteLine("Error: Please enter a distance between 1.0 and 5000.0.");
    }
}

// --- Task 2: Fuel Expense Tracking ---
// I used a 1D Array to store 5 days of fuel costs in one single variable.
decimal[] fuelExpenses = new decimal[5]; 
decimal totalFuelSpent = 0;

// I used a for loop because I know exactly how many days (5) I need to ask for.
for (int i = 0; i < 5; i++) 
{
    // The (i + 1) makes it say "Day 1" instead of "Day 0" on the screen.
    Console.Write($"Enter fuel cost spent for Day {i + 1}: ");
    fuelExpenses[i] = decimal.Parse(Console.ReadLine());
    totalFuelSpent += fuelExpenses[i]; 
}


decimal averageFuelExpense = totalFuelSpent / 5;
double efficiencyRating = totalDistance / (double)totalFuelSpent;
string ratingMessage = "";


if (efficiencyRating > 15) {
    ratingMessage = "High Efficiency";
} else if (efficiencyRating >= 10) {
    ratingMessage = "Standard Efficiency";
} else {
    ratingMessage = "Low Efficiency / Maintenance Required";
}

// This prints the final report box with all the gathered data.
Console.WriteLine("\n========================================");
Console.WriteLine("        CODAC LOGISTICS AUDIT REPORT");
Console.WriteLine("========================================");
Console.WriteLine($"Driver Name: {driverName}");
Console.WriteLine($"Total Distance: {totalDistance} km");
Console.WriteLine($"Total Fuel Cost: {totalFuelSpent:C}"); 
Console.WriteLine($"Efficiency Rating: {ratingMessage}");
Console.WriteLine($"Stayed Under Budget: {totalFuelSpent <= weeklyBudget}");
Console.WriteLine("========================================");