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

            for(int i = 0; i < 100; i++)
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

                linkedList.AddAfter(destinationCup, removed[0]);
                linkedList.AddAfter(removed[0], removed[1]);
                linkedList.AddAfter(removed[1], removed[2]);

                currentCup = currentCup.Next ?? linkedList.First;
                //Console.WriteLine();
                
            }

            var node = linkedList.Find(1).Next;
            var sb = new StringBuilder();

            while(node.Value != 1)
            {
                sb.Append(node.Value);
                node = node.Next ?? linkedList.First;
            }

            return sb.ToString();
        }

        

    }

    public record Cup
    {
        public int Label { get;set; }
    }

}
