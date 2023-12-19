using System;

abstract class Shape
{
    public abstract double CalculateArea();
}

class Circle : Shape
{

    public double Radius = 5;
    public const double PI = 3.1415926535897931;
    public override double CalculateArea()
    {
        double A = PI * Math.Pow(Radius, 2);
        return A;
    }
}

class Square : Shape {
  public double Side = 5;
  public override double CalculateArea() {
    double B = Math.Pow(Side, 2);
    return B;
  }
}

class Program
{
    public static void Main() {
        Circle circle = new Circle();
        var area = circle.CalculateArea();
        Console.WriteLine("Area of the circle: " + area);

        Square square = new Square();
        var area2 = square.CalculateArea();
        Console.WriteLine("Area of the square: " + area2);
    }
}
