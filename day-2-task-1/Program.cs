using System;
public class Program
{
    public static void PrintShapeArea(Shape shape)
    {
        Console.WriteLine("Name: " + shape.Name);
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
