// See https://aka.ms/new-console-template for more information
using MarsRover;
using MarsRover.Utils;

var surface = new Surface(new Point(0, 0), new Point(4, 0), new Point(0, 4), new Point(4, 4));
var directionsUtils = new DirectionsUtils();
var rover1 = new Rover(new Point(1, 2), Directions.N, directionsUtils, surface);
var rover2 = new Rover(new Point(2, 3), Directions.E, directionsUtils, surface);

var command1 = "LMLMLMLMM";
var command2 = "MMRMMRMRRM";

rover1.Execute(command1);
rover2.Execute(command2);

Console.WriteLine(rover1);
Console.WriteLine(rover2);

Console.ReadKey();