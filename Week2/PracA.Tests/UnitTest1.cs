namespace PracA.Tests;

public class UnitTest1
{
    [Fact]
    public void Constructor_WithValidValues_SetsPropertiesAndCalculatesNetPay()
    {
        var payroll = new Payroll(40, 25m, 0.2m);

        Assert.Equal(40, payroll.Hours);
        Assert.Equal(25m, payroll.Rate);
        Assert.Equal(0.2m, payroll.TaxRate);
        Assert.Equal(800m, payroll.CalculateNetPay());
    }

    [Fact]
    public void Constructor_WithNegativeHours_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Payroll(-1, 25m, 0.2m));
    }

    [Fact]
    public void Constructor_WithNegativeRate_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Payroll(40, -25m, 0.2m));
    }

    [Fact]
    public void Constructor_WithNegativeTaxRate_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Payroll(40, 25m, -0.1m));
    }

    [Fact]
    public void Constructor_WithTaxRateAboveOne_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Payroll(40, 25m, 1.1m));
    }

    [Fact]
    public void HoursSetter_WithNegativeValue_ThrowsArgumentException()
    {
        var payroll = new Payroll(40, 25m, 0.2m);

        Assert.Throws<ArgumentException>(() => payroll.Hours = -5);
    }

    [Fact]
    public void RateSetter_WithNegativeValue_ThrowsArgumentException()
    {
        var payroll = new Payroll(40, 25m, 0.2m);

        Assert.Throws<ArgumentException>(() => payroll.Rate = -10m);
    }

    [Fact]
    public void TaxRateSetter_WithNegativeValue_ThrowsArgumentException()
    {
        var payroll = new Payroll(40, 25m, 0.2m);

        Assert.Throws<ArgumentException>(() => payroll.TaxRate = -0.1m);
    }

    [Fact]
    public void TaxRateSetter_WithValueGreaterThanOne_ThrowsArgumentException()
    {
        var payroll = new Payroll(40, 25m, 0.2m);

        Assert.Throws<ArgumentException>(() => payroll.TaxRate = 1.1m);
    }

    [Fact]
    public void ChangeTaxRate_WithValidValue_UpdatesTaxRateAndNetPay()
    {
        var payroll = new Payroll(40, 25m, 0.2m);

        payroll.ChangeTaxRate(0.3m);

        Assert.Equal(0.3m, payroll.TaxRate);
        Assert.Equal(700m, payroll.CalculateNetPay());
    }

    [Fact]
    public void ChangeTaxRate_WithNegativeValue_ThrowsArgumentException()
    {
        var payroll = new Payroll(40, 25m, 0.2m);

        Assert.Throws<ArgumentException>(() => payroll.ChangeTaxRate(-0.1m));
    }

    [Fact]
    public void ChangeTaxRate_WithValueGreaterThanOne_ThrowsArgumentException()
    {
        var payroll = new Payroll(40, 25m, 0.2m);

        Assert.Throws<ArgumentException>(() => payroll.ChangeTaxRate(1.1m));
    }
}
