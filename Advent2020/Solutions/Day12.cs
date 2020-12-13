
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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

                state = command switch
                {
                    "F" => (state.x + state.waypointX * magnitude, state.y + state.waypointY * magnitude, state.waypointX, state.waypointY ),
                    "N" => (state.x, state.y, state.waypointX, state.waypointY + magnitude),
                    "S" => (state.x, state.y, state.waypointX, state.waypointY - magnitude),
                    "E" => (state.x, state.y, state.waypointX + magnitude, state.waypointY),
                    "W" => (state.x, state.y, state.waypointX - magnitude, state.waypointY),
                    "R" => Rotate(state, magnitude / 90),
                    "L" => Rotate(state, 4 - magnitude / 90),
                    _ =>  throw new ArgumentException($"Unknown instruction {command}")
                };
            }
            
            return Math.Abs(state.x) + Math.Abs(state.y);
        }

        private (int x, int y, int waypointX, int waypointY) Rotate((int x, int y, int waypointX, int waypointY) state, int quadrants) => 
            quadrants switch
        {
            0 => (state.x, state.y, state.waypointX, state.waypointY),
            1 => (state.x, state.y, state.waypointY, -state.waypointX),
            2 => (state.x, state.y, -state.waypointX, -state.waypointY),
            3 => (state.x, state.y, -state.waypointY, state.waypointX),
            _ => throw new ArgumentException($"Unexpected rotation {quadrants}")
            };

    }
}
