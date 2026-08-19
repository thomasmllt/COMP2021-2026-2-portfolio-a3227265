public class UnitTest1
{
    [Fact]
    public void FullName_ReturnsExpectedFormat()
    {
        Person person = new Person("John", "Smith", 20);

        string result = person.FullName();

        Assert.Equal("Smith, John", result);
    }

    [Fact]
    public void IsAdult_ReturnsTrue_WhenAge18OrMore()
    {
        Person age18 = new Person("Alex", "Brown", 18);
        Person age30 = new Person("Mia", "Jones", 30);

        Assert.True(age18.IsAdult());
        Assert.True(age30.IsAdult());
    }
}
