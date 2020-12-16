
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2020.Solutions
{
    public class Day16
    {
        public long CountInvalidTickets(string[] input)
        {
            var fields = ParseFields(input).ToList();
            var tickets = ParseTickets(input).ToList();

            return tickets.SelectMany(x =>
                x.Numbers.Where(number => tickets.Any(ticket => fields.All(f => !f.IsValid(number))))).Sum();
        }

        public long ProductOfDepartureFields(string[] input)
        {
            var fields = ParseFields(input).ToList();
            var validTickets = ParseTickets(input)
                .Where(x => x.Numbers.All(ticketNumber => fields.Any(f => f.IsValid(ticketNumber)))).ToList();
            var myTicket = ParseMyTicket(input);
            
            var columns = Enumerable.Range(0, validTickets[0].Numbers.Count).ToList();
            while (fields.Any(x => x.Id == null))
            {
                foreach (var column in columns)
                {
                    var positionNumbers = validTickets.Select(x => x.Numbers[column]).ToList();
                    var possibleFields = fields.Where(field => field.Id == null && positionNumbers.All(field.IsValid))
                        .ToList();
                    if (possibleFields.Count == 1)
                    {
                        possibleFields.Single().Id = column;
                    }
                }
            }

            var result = fields.Where(x => x.Name.StartsWith("departure") && x.Id != null)
                .Select(x => myTicket.Numbers[x.Id.Value])
                .Aggregate(1L, (a, b) => a * b);
                
            return result;
        }

        public IEnumerable<Field> ParseFields(string[] input)
        {
            var regex = new Regex(@"(.+): (\d+)-(\d+) or (\d+)-(\d+)");

            return input.Where(x => regex.IsMatch(x)).Select(x =>
            {
                var match = regex.Match(x);
                return new Field
                {
                    Name = match.Groups[1].Value,
                    Ranges = new List<(int Lower, int Upper)>
                    {
                        (int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value)),
                        (int.Parse(match.Groups[4].Value), int.Parse(match.Groups[5].Value)),
                    }
                };
            });
        }

        public IEnumerable<Ticket> ParseTickets(string[] input)
        {
            return input.SkipWhile(x => x != "nearby tickets:").Skip(1).Select(x => x)
                .Select(x => new Ticket
                {
                    Numbers = x.Split(',').Select(long.Parse).ToList()
                });
        }

        public Ticket ParseMyTicket(string[] input)
        {
            return new Ticket
            {
                Numbers = input.SkipWhile(x => x != "your ticket:").Skip(1).Take(1).Single().Split(',')
                    .Select(long.Parse).ToList()
            };
        }
    }

    public class Field
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public List<(int Lower, int Upper)> Ranges { get; set; }

        public bool IsValid(long number) => Ranges.Any(range => range.Lower <= number && number <= range.Upper);
    }

    public class Ticket
    {
        public List<long> Numbers { get; set; }
    }
}