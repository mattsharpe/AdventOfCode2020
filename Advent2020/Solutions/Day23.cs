using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2020.Solutions
{
    public class Day23
    {
       
        public string OrderAfterCup1(string input)
        {
            var linkedList = new LinkedList<int>(input.Select(x => int.Parse(x.ToString())));

            Console.WriteLine(linkedList.Count);

            var currentIndex = 0;
            var currentCup = linkedList.First;

            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine("cups: " + string.Join(", ", linkedList));

                var removed = new[]
                {
                    currentCup.Next,
                    currentCup.Next.Next,
                    currentCup.Next.Next.Next,
                };

                foreach (var item in removed)
                {
                    linkedList.Remove(item);
                }

                var next = linkedList.SingleOrDefault(x => x == currentCup.Value - 1);
                if(next == 0)
                {
                    next = linkedList.Single(x => x == linkedList.Max());
                }

                Console.WriteLine("pick up: " + string.Join(", ", removed.Select(x => x.Value)));
                Console.WriteLine("destination: " + next);
                currentCup = linkedList.Find(next);

                linkedList.AddAfter(currentCup.Next, removed[0]);
                linkedList.AddAfter(removed[0], removed[1]);
                linkedList.AddAfter(removed[1], removed[2]);


                Console.WriteLine();
                
            }

           

            throw new NotImplementedException();
        }

        

    }

    public record Cup
    {
        public int Label { get;set; }
    }

}
