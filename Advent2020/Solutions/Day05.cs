
using System;
using System.Linq;

namespace Advent2020.Solutions
{
    class Day05
    {
        public (int row, int column) FindSeat(string input)
        {
            var rowInput = input.Substring(0, 7)
                .Replace('F', '0').Replace('B', '1');
                
            var colInput = input.Substring(7, 3)
                .Replace('L', '0').Replace('R', '1');
            
            return (Convert.ToInt32(rowInput, 2), Convert.ToInt32(colInput, 2));
        }

        public int FindSeatNumber(string input)
        {
            var seat = FindSeat(input);
            return seat.row * 8 + seat.column;
        }

        public int FindHighestSeatNumber(string[] input)
        {
            return input.Max(FindSeatNumber);
        }

        public int FindEmptySeat(string[] input)
        {
            var allSeats = input.Select(FindSeatNumber).ToHashSet();
            return Enumerable.Range(allSeats.Min(), allSeats.Count).Except(allSeats).Single();
        }
    }
}
