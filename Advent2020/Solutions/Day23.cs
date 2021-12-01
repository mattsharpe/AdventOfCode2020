using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2020.Solutions
{
    public class Day23
    {
       
        public string OrderAfterCup1(string input)
        {
            var linkedList = new LinkedList<int>(input.Select(x => int.Parse(x.ToString())));

            var currentCup = linkedList.First;

            for(var i = 0; i < 100; i++)
            {
                //Console.WriteLine("current cup: " + currentCup.Value);
                //Console.WriteLine("cups: " + string.Join(", ", linkedList));

                var removed = new List<LinkedListNode<int>>
                {
                    currentCup.Next ?? linkedList.First
                };

                removed.Add(removed.Last().Next ?? linkedList.First);
                removed.Add(removed.Last().Next ?? linkedList.First);

                foreach (var item in removed)
                {
                    linkedList.Remove(item);
                }
                var targetValue = currentCup.Value - 1;
                var destination = 0;

                while(targetValue > 0)
                {
                    destination = linkedList.SingleOrDefault(x => x == targetValue);

                    if(destination != 0)
                    { 
                        break; 
                    }

                    targetValue--;
                }
                
                if(destination == 0)
                {
                    destination = linkedList.Single(x => x == linkedList.Max());
                }

                //Console.WriteLine("pick up: " + string.Join(", ", removed.Select(x => x.Value)));
                //Console.WriteLine("destination: " + destination);
                var destinationCup = linkedList.Find(destination);

                linkedList.AddAfter(destinationCup!, removed[0]);
                linkedList.AddAfter(removed[0], removed[1]);
                linkedList.AddAfter(removed[1], removed[2]);

                currentCup = currentCup.Next ?? linkedList.First;
                //Console.WriteLine();
                
            }

            var node = linkedList.Find(1)?.Next;
            var sb = new StringBuilder();

            while(node!.Value != 1)
            {
                sb.Append(node.Value);
                node = node.Next ?? linkedList.First;
            }

            return sb.ToString();
        }

        public long Part2(string input)
        {
            const int totalCups = 1000000;
            var numbers = input.Select(x => int.Parse(x.ToString())).ToList();
                        
            //create a lookup for each number, this stores the value of the next
            //this lookup has the 'label' of the cup
            var lookup = Enumerable.Range(1, totalCups + 1).ToArray();

            for (var i = 0; i < numbers.Count; i++)
            {
                var next = i + 1 == numbers.Count ? numbers[0] : numbers[i + 1];
                lookup[numbers[i]] = next;
            }
            
            //find the original end point of the input and assign this to the last possible cup.
            lookup[totalCups] = lookup[numbers.Last()];

            //find the pointer for the original end value and point it at the next int the list
            lookup[numbers.Last()] = input.Length + 1;
            
            var currentCup = numbers.First();

            foreach (var unused in Enumerable.Range(0, 10_000_000))
            {
                var removed = new List<int> { lookup[currentCup] };
                removed.Add(lookup[removed.Last()]);
                removed.Add(lookup[removed.Last()]);
                
                var removed1 = lookup[currentCup];
                var removed2 = lookup[removed1];
                var removed3 = lookup[removed2];

                lookup[currentCup] = lookup[removed3];

                var destination = currentCup;

                destination = destination == 1 ? totalCups : destination - 1;

                while (removed.Contains(destination))
                {
                    destination = destination == 1 ? totalCups : destination - 1;
                }

                lookup[removed3] = lookup[destination];
                lookup[destination] = removed1;
                currentCup = lookup[currentCup];
            }

            var first = Convert.ToInt64(lookup[1]);
            var second = Convert.ToInt64(lookup[first]);

            return first * second;

        }
    }

}
