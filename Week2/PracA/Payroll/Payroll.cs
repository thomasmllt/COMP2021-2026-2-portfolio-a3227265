public class Payroll
{
    private double hours;
    private decimal rate;
    private decimal taxRate;

    public Payroll(double hours, decimal rate, decimal taxRate)
    {
        if (hours < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(hours), "Hours must be zero or greater.");
        }

        if (rate < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(rate), "Rate must be zero or greater.");
        }

        if (taxRate < 0 || taxRate > 1)
        {
            throw new ArgumentOutOfRangeException(nameof(taxRate), "Tax rate must be between 0 and 1.");
        }

        this.hours = hours;
        this.rate = rate;
        this.taxRate = taxRate;
    }

    public decimal CalculateNetPay()
    {
        decimal gross = (decimal)hours * rate;
        decimal tax = gross * taxRate;
        return gross - tax;
    }

    public void ChangeTaxRate(decimal newTaxRate)
    {
        if (newTaxRate < 0 || newTaxRate > 1)
        {
            throw new ArgumentOutOfRangeException(nameof(newTaxRate), "Tax rate must be between 0 and 1.");
        }

        taxRate = newTaxRate;
    }
}
