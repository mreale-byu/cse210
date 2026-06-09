class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("RED", 3));
        shapes.Add(new Rectangle("BLUE", 4, 5));
        shapes.Add(new Circle("GREEN", 6));

        Console.Clear();

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The {shape.GetColor()} shape has an area of {shape.GetArea()}.");
        }
        Console.WriteLine();

    }
}