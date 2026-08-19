using System;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public Person(string firstName, string lastName, int age)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("First name cannot be null or empty.");
        }
        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Last name cannot be null or empty.");
        }
        if (age < 0)
        {
            throw new ArgumentOutOfRangeException("Age cannot be negative.");
        }

        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public string FullName() => $"{LastName}, {FirstName}";

    public bool IsAdult() => Age >= 18;
}