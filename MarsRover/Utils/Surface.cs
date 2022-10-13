namespace MarsRover.Utils
{
    public class Surface
    {
        public Surface()
        {

        }

        public Surface(Point bottomLeft, Point bottomRight, Point topLeft, Point topRight)
        {
            BottomLeft = bottomLeft;
            BottomRight = bottomRight;
            TopLeft = topLeft;
            TopRight = topRight;
        }

        public Point BottomLeft { get; set; } = new Point();
        public Point BottomRight { get; set; } = new Point();
        public Point TopLeft { get; set; } = new Point();
        public Point TopRight { get; set; } = new Point();

        public bool Contains(Point position)
        {
            return position.X >= BottomLeft.X && position.X <= BottomRight.X
                && position.Y >= BottomLeft.Y && position.Y <= TopLeft.Y;
        }

        public override string ToString()
        {
            return $"{BottomLeft}-{BottomRight}-{TopLeft}-{TopRight}";
        }
    }
}
