class Program
{
    static void Main()
    {
        Person person = new Person("Casey", "Smith", 25);

        Console.WriteLine(person.FullName());
        Console.WriteLine(person.IsAdult());
    }
}