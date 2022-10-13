using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Utils
{
    public enum Directions
    {
        N = 0,
        E = 1,
        S = 2,
        W = 3,
    }

    public class DirectionsUtils
    {
        public void Validate(Directions direction)
        {
            if (direction < Directions.N || direction > Directions.W)
                throw new Exception($"Invalid direction value: {direction}");
        }
    }
}
