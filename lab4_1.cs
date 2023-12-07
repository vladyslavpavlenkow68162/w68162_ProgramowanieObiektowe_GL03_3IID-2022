using System;
using System.Collections.Generic;

public class Shape
{

    public int X { get; private set; }
    public int Y { get; private set; }
    public int Height { get; set; }
    public int Width { get; set; }


    public virtual void Draw()
    {
        Console.WriteLine("Default shape");
    }
}

public class Circle : Shape
{
    public override void Draw()
    {

        Console.WriteLine("Drawing a Circle");

    }
}
public class Rectangle : Shape
{
    public override void Draw()
    {

        Console.WriteLine("Drawing a Rectangle");

    }
}
public class Triangle : Shape
{
    public override void Draw()
    {

        Console.WriteLine("Drawing a Triangle");

    }


}


class Program
{
    public static void Main(string[] args)
    {
        var shapes = new List<Shape>
          {
              new Rectangle(),
              new Triangle(),
              new Circle()
          };

        foreach (var shape in shapes)
        {
            shape.Draw();
        }
    }
}
