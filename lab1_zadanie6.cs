using System;

class Program {
  public static void Main (string[] args) {
    string chose_one = "";
    string chose_two = "";
    while (chose_one != "Fahrenheit" && chose_one != "Celsius") {
      Console.WriteLine("Select the unit of measurement you want to convert (Fahrenheit/Celsius): ");
      chose_one = Console.ReadLine();
    }
    while (chose_two != "Fahrenheit" && chose_two != "Celsius") {
      Console.WriteLine("Select the unit of measurement you want to convert to (Fahrenheit/Celsius): ");
      chose_two = Console.ReadLine();
    }

    if (chose_one == "Celsius" && chose_two == "Fahrenheit") {
      Console.WriteLine("Enter the Celsius: ");
      double c = Convert.ToDouble(Console.ReadLine());
      double result = ConvertationToFahrenheit(c);
      Console.WriteLine(result);
    }
    else if (chose_one == "Fahrenheit" && chose_two == "Celsius") {
      Console.WriteLine("Enter the Fahrenheit: ");
      double f = Convert.ToDouble(Console.ReadLine());
      double result = ConvertationToCelsius(f);
      Console.WriteLine(result);
    }
    else {
      Console.WriteLine("Error!");
    }
  }

  public static double ConvertationToFahrenheit(double c) {
    double f = c * 1.8 + 32;
    return f;
  }

  public static double ConvertationToCelsius(double f) {
    double c = (f - 32) * (5.0 / 9.0);
    return c;
  }
}
