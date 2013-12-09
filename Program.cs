using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            Shuffler myShuffler = new Shuffler();

            myShuffler.Add(1);
            myShuffler.Add(2);
            myShuffler.Add(3);
            myShuffler.Add(4);
            myShuffler.Add(5);
            
            List<int> myList2 = myShuffler.DisplaceShuffleNums();
         //   Shuffler myList2 = myShuffler.NaturalShuffleNums();
            for (int i = 0; i < myList2.Count(); i++)
                System.Console.WriteLine(myList2[i]);
            System.Console.ReadLine();

        }
    }
}
