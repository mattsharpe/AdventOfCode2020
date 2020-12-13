
using System;
using System.Linq;

namespace Advent2020.Solutions
{
    class Day12
    {
        public int ManhattanDistance(string[] input)
        {
            (int x, int y, int orientation) state = (0, 0, 90);

            foreach (var change in input)
            {
                var command = change.Substring(0, 1);
                var magnitude = int.Parse(change.Split(command).Last());
                switch (command)
                {
                    case "F" when state.orientation == 0:
                    case "N":
                        state.y += magnitude;
                        break;

                    case "F" when state.orientation == 180:
                    case "S":
                        state.y -= magnitude;
                        break;

                    case "F" when state.orientation == 90:
                    case "E":
                        state.x += magnitude;
                        break;
                    
                    case "F" when state.orientation == 270:
                    case "W":
                        state.x -= magnitude;
                        break;
                    
                    case "R":
                        state.orientation = (state.orientation + magnitude) % 360;
                        break;

                    case "L":
                        state.orientation -= magnitude % 360;
                        if (state.orientation < 0) state.orientation += 360;
                        break;
                        
                    default:
                        throw new ArgumentException($"Unknown instruction {command}");
                }

                if (state.orientation == 360) state.orientation = 0;
            }
           
            return Math.Abs(state.x) + Math.Abs(state.y);
        }

        public int MovingWayPoint(string[] input)
        {
            (int x, int y, int waypointX, int waypointY) state = (0, 0, 10, 1);

            foreach (var instruction in input)
            {
                var command = instruction.Substring(0, 1);
                var magnitude = int.Parse(instruction.Split(command).Last());
                Console.WriteLine(instruction);
                switch (command)
                {
                    case "F":
                        state.x += (state.waypointX * magnitude);
                        state.y += (state.waypointY * magnitude);
                        break;
                    case "N":
                        state.waypointY += magnitude;
                        break;
                    case "S":
                        state.waypointY -= magnitude;
                        break;
                    case "E":
                        state.waypointX += magnitude;
                        break;
                    case "W":
                        state.waypointX -= magnitude;
                        break;
                    case "R":
                        var (newX, newY) = Rotate(state.waypointX, state.waypointY, magnitude / 90);
                        state.waypointX = newX;
                        state.waypointY = newY;
                        break;
                    case "L":
                        var leftResult= Rotate(state.waypointX, state.waypointY, 4 - magnitude / 90);
                        state.waypointX = leftResult.newX;
                        state.waypointY = leftResult.newY;
                        break;
                    default:
                        throw new ArgumentException($"Unknown instruction {command}");
                }

                Console.WriteLine(state);
            }
            
            return Math.Abs(state.x) + Math.Abs(state.y);
        }

        (int newX, int newY) Rotate(int x, int y, int quadrants) =>
            quadrants switch
            {
                0 => (x, y),
                1 => (y, -x),
                2 => (-x, -y),
                3 => (-y, x),
            };

    }
}
