//using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRover.Utils;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.UnitTests
{
    // These tests use only MsTest framework

    [TestClass]
    public class RoverMsTests
    {
        [TestMethod]
        [DataRow(1, 2, Directions.N, "LMLMLMLMM", "1,3, N")]
        [DataRow(2, 3, Directions.E, "MMRMMRMRRM", "4,1, E")]
        public void Execute_ShouldGetToDestination_WhenInputIsValid(int x, int y, Directions direction, string command, string result)
        {
            var surface = new Surface(new Point(0, 0), new Point(4, 0), new Point(0, 4), new Point(4, 4));
            var directionsUtils = new DirectionsUtils();
            var systemUnderTest = new Rover(new Point(x, y), direction, directionsUtils, surface);

            systemUnderTest.Execute(command);

            Assert.AreEqual(result, systemUnderTest.ToString());
        }

        [TestMethod()]
        [DataRow(1, 2, Directions.N, "lMLMLMLMMl", "Unknown action: l")]
        [DataRow(2, 3, Directions.E, "mMRMMRMRRM", "Unknown action: m")]
        public void Execute_ShouldThrowException_WhenInvalidCommandDetected(int x, int y, Directions direction, string command, string errorMessage)
        {
            var surface = new Surface(new Point(0, 0), new Point(4, 0), new Point(0, 4), new Point(4, 4));
            var directionsUtils = new DirectionsUtils();
            var systemUnderTest = new Rover(new Point(x, y), direction, directionsUtils, surface);

            Assert.ThrowsException<Exception>(() => systemUnderTest.Execute(command), errorMessage);
        }

        [TestMethod()]
        [DataRow(1, 2, Directions.N, "MMMMM", "The rover is outside the valid surface at: 1,5. Expected position inside is 0,0-4,0-0,4-4,4")]
        [DataRow(2, 3, Directions.E, "MMRMMRMRRMM", "The rover is outside the valid surface at: 5,1. Expected position inside is 0,0-4,0-0,4-4,4")]
        public void Execute_ShouldThrowException_WhenRoverOutsideSurface(int x, int y, Directions direction, string command, string errorMessage)
        {
            var surface = new Surface(new Point(0, 0), new Point(4, 0), new Point(0, 4), new Point(4, 4));
            var directionsUtils = new DirectionsUtils();
            var systemUnderTest = new Rover(new Point(x, y), direction, directionsUtils, surface);

            Assert.ThrowsException<Exception>(() => systemUnderTest.Execute(command), errorMessage);
        }

        [TestMethod()]
        [DataRow(1, 2, (Directions)5, "Invalid direction value: 5")]
        [DataRow(2, 3, (Directions)(-1), "Invalid direction value: -1")]
        public void Execute_ShouldThrowException_WhenInvalidDirectionDetected(int x, int y, Directions direction, string errorMessage)
        {
            var surface = new Surface(new Point(0, 0), new Point(4, 0), new Point(0, 4), new Point(4, 4));
            var directionsUtils = new DirectionsUtils();

            var act = () => new Rover(new Point(x, y), direction, directionsUtils, surface);

            Assert.ThrowsException<Exception>(() => act(), errorMessage);
        }
    }
}