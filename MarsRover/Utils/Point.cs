namespace MarsRover.Utils
{
    public class Point
    {
        public Point()
        {

        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}
