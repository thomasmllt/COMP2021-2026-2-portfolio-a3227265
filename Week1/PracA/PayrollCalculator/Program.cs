using System;

class PayrollCalculator
{
    private const double TaxRate = 0.2;

    public static double CalculatePay(double hours, double rate)
    {
        if (hours < 0 || rate < 0)
        {
            throw new ArgumentException("Hours and rate must be positive.");
        }
        
        double gross = hours * rate;
        double tax = gross * TaxRate;
        double net = gross - tax;
        return net;
    }

    static void Main()
    {
        Console.Write("Enter employee name: ");
        string? name = Console.ReadLine();

        try
        {
            Console.Write("Hours worked: ");
            if (!double.TryParse(Console.ReadLine(), out double hours))
            {
                throw new FormatException("Invalid hours input.");
            }

            Console.Write("Hourly rate: ");
            if (!double.TryParse(Console.ReadLine(), out double rate))
            {
                throw new FormatException("Invalid rate input.");
            }

            double netPay = CalculatePay(hours, rate);
            Console.WriteLine($"{name} earned ${netPay:F2} after tax.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}