using System;

public class Person
{
    public string Name;
    public int Age;

    public override string ToString()
    {
        return $"{Name}, {Age} år";
    }
}

public class PersonBuilder
{
    protected Person person = new Person();
    public PersonInfoBuilder Name => new PersonInfoBuilder(person);
    public PersonInfoBuilder Age => new PersonInfoBuilder(person);

    public static implicit operator Person(PersonBuilder pb)
    {
        return pb.person;
    }
}

public class PersonInfoBuilder : PersonBuilder
{
    public PersonInfoBuilder(Person person)
    {
        this.person = person;
    }

    public PersonInfoBuilder Is(string name)
    {
        person.Name = name;
        return this;
    }

    public PersonInfoBuilder Is(int age)
    {
        person.Age = age;
        return this;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var pb = new PersonBuilder();
        Person person = pb
            .Name
                .Is("Linus")
            .Age
                .Is(25);

        Console.WriteLine(person);
    }
}
