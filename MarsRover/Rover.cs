using MarsRover.Utils;

namespace MarsRover
{
    public class Rover
    {
        public Rover(Point position, Directions direction, DirectionsUtils directionsUtils, Surface surface)
        {
            Position = position;
            Direction = direction;
            DirectionsUtils = directionsUtils;
            Surface = surface;
            Validate();
        }

        public Point Position { get; private set; }
        public Surface Surface { get; private set; }
        public Directions Direction { get; private set; }
        public DirectionsUtils DirectionsUtils { get; }

        public void Execute(string commands)
        {
            foreach (var command in commands)
            {
                Execute(command);
            }
            Validate();
        }

        public void Execute(char command)
        {
            switch (command)
            {
                case 'L':
                    RotateLeft();
                    break;
                case 'R':
                    RotateRight();
                    break;
                case 'M':
                    Move();
                    break;
                default: throw new Exception($"Unknown action: {command}");
            }
        }

        public override string ToString()
        {
            return $"{Position}, {Direction}";
        }

        private void Move()
        {
            DirectionsUtils.Validate(Direction);

            switch (Direction)
            {
                case Directions.N:
                    Position.Y++;
                    break;
                case Directions.E:
                    Position.X++;
                    break;
                case Directions.S:
                    Position.Y--;
                    break;
                case Directions.W:
                    Position.X--;
                    break;
                default: break;
            }

            ValidatePosition();
        }

        private void Validate()
        {
            ValidatePosition();
            DirectionsUtils.Validate(Direction);
        }

        

        private void ValidatePosition()
        {
            if (!Surface.Contains(Position))
                throw new Exception($"The rover is outside the valid surface at: {Position}. Expected position inside is {Surface}");
        }

        private void RotateLeft()
        {
            DirectionsUtils.Validate(Direction);

            if (Direction == Directions.N)
                Direction = Directions.W;
            else
                Direction--;
        }

        private void RotateRight()
        {
            DirectionsUtils.Validate(Direction);

            if (Direction == Directions.W)
                Direction = Directions.N;
            else
                Direction++;
        }
    }
}
