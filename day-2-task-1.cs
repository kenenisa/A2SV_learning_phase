using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;



public class Shape
{
    public String name;
    public virtual double CalculateArea()
    {
        return 0;
    }

}
public class Circle : Shape
{
    public double Radius;
    public override double CalculateArea()
    {
        return Radius * Radius * 3.142;
    }
}
public class Rectangle : Shape
{
    public double Width;
    public double Height;
    public override double CalculateArea()
    {
        return Width * Height;
    }
}
public class Triangle : Shape
{
    public double Base;
    public double Height;
    public override double CalculateArea()
    {
        return 0.5 * Base * Height;
    }
}
public class Program
{
    public static void PrintShapeArea(Shape shape)
    {
        Console.WriteLine("Name: " + shape.name);
        Console.WriteLine("Area: " + shape.CalculateArea());
    }
    public static void Main()
    {
        Circle circle = new Circle();
        circle.Radius = 5.0;
        PrintShapeArea(circle);

        Rectangle rect = new Rectangle();
        rect.Width = 5.0;
        rect.Height = 2.0;
        PrintShapeArea(rect);

        Triangle trig = new Triangle();
        trig.Base = 5.0;
        trig.Height = 3.0;
        PrintShapeArea(trig);
    }
}
