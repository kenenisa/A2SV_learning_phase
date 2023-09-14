public class Circle : Shape
{
    public double Radius { get; set; }
    public override double CalculateArea()
    {
        return Radius * Radius * 3.142;
    }
}