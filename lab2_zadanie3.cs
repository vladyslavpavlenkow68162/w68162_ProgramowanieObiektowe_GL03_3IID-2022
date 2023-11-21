using System;

class Samochod
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public int Rok { get; set; }
    private int Speed { get; set; }
    private int Mileage { get; set; }
    private string EngineStatus { get; set; }

    public Samochod(string marka, string model, int rok)
    {
        Marka = marka;
        Model = model;
        Rok = rok;
        Speed = 0;
        Mileage = 0;
        EngineStatus = "Stopped";
    }

    public void StartEngine()
    {
        EngineStatus = "Running";
        Console.WriteLine("Engine is started.");
    }

    public void StopEngine()
    {
        EngineStatus = "Stopped";
        Console.WriteLine("Engine is stopped.");
    }

    public void IncreaseSpeed(int increment)
    {
        if (EngineStatus == "Running")
        {
            Speed += increment;
        }
        else
        {
            Console.WriteLine("Engine is not running.");
        }
    }

    public void DecreaseSpeed(int decrement)
    {
        if (EngineStatus == "Running")
        {
            Speed -= decrement;
        }
        else
        {
            Console.WriteLine("Engine is not running.");
        }
    }

    public double CalculateTime(int distance)
    {
        if (Speed != 0)
        {
            return (double)distance / Speed;
        }
        else
        {
            Console.WriteLine("Speed is zero. Cannot calculate time.");
            return 0;
        }
    }

    public string RepairEngine()
    {
        EngineStatus = "Repaired";
        return EngineStatus;
    }

    public string CheckEngine()
    {
        if (Mileage > 1000)
        {
            EngineStatus = "Check engine";
        }
        else
        {
            EngineStatus = "Ok";
        }
        return EngineStatus;
    }

  public void DisplayCarInfo()
  {
      Console.WriteLine($"Marka: {Marka}");
      Console.WriteLine($"Model: {Model}");
      Console.WriteLine($"Rok: {Rok}");
      Console.WriteLine($"Aktualna prędkość: {Speed} km/h");
      Console.WriteLine($"Stan silnika: {EngineStatus}");
  }


  
}

class Program
{
    static void Main()
    {
        Samochod car = new Samochod("Toyota", "Corolla", 2020);
        car.DisplayCarInfo();
        car.StartEngine();
        car.IncreaseSpeed(30);
        double time = car.CalculateTime(150);
        Console.WriteLine("Time to cover 150 km: " + time + " hours");
        car.StopEngine();
    }
}
