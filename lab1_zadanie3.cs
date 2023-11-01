using System;

class Program
{
  public static void Main(string[] args)
  {
    int n;
    Console.WriteLine("Enter the number from 1 to 6:");

    while (true)
    {
        string input = Console.ReadLine();

        if (int.TryParse(input, out n))
        {
            if (n >= 1 && n <= 6)
            {
                break; 
            }
        }

        Console.WriteLine("Invalid input. Please enter a number from 1 to 6.");
    }

    switch (n)
    {
      case 1:
        Console.WriteLine("Zad1: ");
        isEven();
        break;
      case 2:
        Console.WriteLine("Zad2: ");
        EvenCycle();
        break;
      case 4:
        Console.WriteLine("Zad4: ");
        Factorial();
        break;
      case 5:
        Console.WriteLine("Zad5: ");
        RandomNumbers();
        break;
      case 6:
        Console.WriteLine("Zad6: ");
        Convertation();
        break;
      default:
        Console.WriteLine("Error!");
        break;
    }
  }

  public static void isEven()
  {
    int a;

    while (true) 
    {
        Console.WriteLine("Enter the number: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out a))
        {
            break; 
        }

        Console.WriteLine("Invalid input. Please enter a number.");
    }
    if (a % 2 == 0)
    {
      Console.WriteLine(a + " jest parzyste");
    }
    else
    {
      Console.WriteLine(a + " nie jest parzyste");
    }
  }

  public static void EvenCycle()
  {
    int n;

    while (true)
    {
        Console.WriteLine("Enter the number: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out n))
        {
            break; 
        }

        Console.WriteLine("Invalid input. Please enter a number.");
    }
    for (int i = 1; i <= n; i++)
    {
      if (i % 2 == 0)
      {
        Console.WriteLine(i);
      }
    }
  }

  public static void Factorial()
  {
    int a;

    while (true) 
    {
        Console.WriteLine("Enter the number: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out a))
        {
            if (a >= 1)
            {
                break; 
            }
        }

        Console.WriteLine("Invalid input. Please enter a positive number.");
    }
    
    int factorial = 1;
    for (int i = 1; i <= a; i++)
    {
      factorial *= i;
    }
    Console.WriteLine(factorial);
  }

  public static void RandomNumbers()
  {
    Random random = new Random();
    int num = random.Next(1, 10);
    int tried = 0;
    while (tried < 3)
    {
        Console.WriteLine("Enter the number: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int user))
        {
            if (user >= 1 && user <= 9)
            {
                if (num == user)
                {
                    Console.WriteLine("You're right!");
                    tried++;
                    break;
                }
                else
                {
                    Console.WriteLine("You're not right");
                    tried++;
                }
            }
            else
            {
                Console.WriteLine("Please enter a number between 1 and 9.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
        }
    }
  }

  public static void Convertation()
  {
    string chose_one = "";
    string chose_two = "";
    while (chose_one != "Fahrenheit" && chose_one != "Celsius")
    {
      Console.WriteLine("Select the unit of measurement you want to convert (Fahrenheit/Celsius): ");
      chose_one = Console.ReadLine();
    }
    while (chose_two != "Fahrenheit" && chose_two != "Celsius")
    {
      Console.WriteLine("Select the unit of measurement you want to convert to (Fahrenheit/Celsius): ");
      chose_two = Console.ReadLine();
    }

    if (chose_one == "Celsius" && chose_two == "Fahrenheit")
    {
      Console.WriteLine("Enter the Celsius: ");
      double c = Convert.ToDouble(Console.ReadLine());
      double result = ConvertationToFahrenheit(c);
      Console.WriteLine(result);
    }
    else if (chose_one == "Fahrenheit" && chose_two == "Celsius")
    {
      Console.WriteLine("Enter the Fahrenheit: ");
      double f = Convert.ToDouble(Console.ReadLine());
      double result = ConvertationToCelsius(f);
      Console.WriteLine(result);
    }
    else
    {
      Console.WriteLine("Error!");
    }
  }

  public static double ConvertationToFahrenheit(double c)
  {
    double f = c * 1.8 + 32;
    return f;
  }

  public static double ConvertationToCelsius(double f)
  {
    double c = (f - 32) * (5.0 / 9.0);
    return c;
  }
}
