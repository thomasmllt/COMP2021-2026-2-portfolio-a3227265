class Program
{
    private const decimal DefaultTaxRate = 0.2m;

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
            if (!decimal.TryParse(Console.ReadLine(), out decimal rate))
            {
                throw new FormatException("Invalid rate input.");
            }

            Payroll payroll = new Payroll(hours, rate, DefaultTaxRate);
            payroll.ChangeTaxRate(DefaultTaxRate);
            decimal netPay = payroll.CalculateNetPay();

            Console.WriteLine($"{name} earned ${netPay:F2} after tax.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
