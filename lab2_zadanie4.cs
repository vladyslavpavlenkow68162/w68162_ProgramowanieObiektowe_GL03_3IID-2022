using System;

class Osoba
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Car { get; set; }

    public Osoba(string name, string surname, int age, string car)
    {
        Name = name;
        Surname = surname;
        Age = age;
        Car = car;
    }

    public void IsUnderage()
    {
        if (Age < 18)
        {
            Console.WriteLine("Osoba jest niepełnoletnia");
        }
        else
        {
            Console.WriteLine("Osoba jest pełnoletnia");
        }
    }

    public string ChangeSurname()
    {
        Console.WriteLine("Enter your new surname: ");
        string newSurname = Console.ReadLine();
        Surname = newSurname;
        Console.WriteLine("Your new surname is: " + Surname);
        return Surname;
    }

  public void ChangeOwner(string ownerName, string ownerSurname)
  {
      Console.WriteLine("Ownership has been transferred.");
      Name = ownerName;
      Car = $"{Car} (Owner: {Name} {Surname})";
      Surname = ownerSurname;
  }


    public string CarInfo()
    {
        return Car;
    }
}

class Program
{
    static void Main()
    {
      Osoba person = new Osoba("Jan", "Kowalski", 25, "Toyota");
      person.ChangeSurname(); 
      person.ChangeOwner("Anna", person.Surname); 
      Console.WriteLine("Car Information: " + person.CarInfo());

    }
}
