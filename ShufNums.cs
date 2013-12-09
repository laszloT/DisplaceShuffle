/*This Shuffle namespace is created by Michael Laszlo Tornay to alter the order of List objects
 * containg unique int values.  It could easily be altered to contain int64 values.
 * It provides two shuffle functions.  
 * A Natural Shuffle does not restrict an item from randomly shuffling into the same space it started.
 * A Displace Shuffle guarantees that every item will surface in a different spot then where it started.
 */
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Shuffle
{
  
    public class Shuffler
    {
        private List<int> numList;
        internal List<int> NumList
        {
            //get { return numList; }
            set { 
                numList = value; 
            }  //using this will bypass the uniqueness checks
        }
        public Shuffler()
        {
            numList = new List<int>();
        }
        public Shuffler(List<int> l )
        {
            numList = l;  //using this will bypass uniqueness checks
        }


        private int DrawItem(int index)
        {
            //Draw from index position
            int tmpInt;
            tmpInt = numList[index];
            numList.RemoveAt(index);
            return tmpInt;
        }

        internal void Add(int val)
        {
            if (numList.IndexOf(val) > -1 )
                throw new ApplicationException("Duplicate Value");
            else
                numList.Add(val);
        }

        internal List<int> NaturalShuffleNums()
        {
            Random rnd = new Random();
            List<int> ShuffleList = new List<int>();
            int listSize = numList.Count();
            if (numList.Count > 1)
            {
                for (int i = 0; i < listSize; i++)
                    ShuffleList.Add(DrawItem(rnd.Next(numList.Count)));
            }
            return ShuffleList;
        }

        internal List<int> DisplaceShuffleNums()
        {
            List<int> OriginalList = new List<int>(numList);
            List<int> ShuffleList = NaturalShuffleNums();
            int priorInt =-1;
            int iniInd = -1;
            int iniInt = -1;
            bool ini = true;
            bool hitasecond = false;
            for (int i = 0; i < OriginalList.Count; i++)
            {
                if (OriginalList[i] == ShuffleList[i])
                {
                    if (ini)
                    {
                        priorInt = OriginalList[i];
                        iniInd = i;
                        iniInt = OriginalList[i];
                        ini = false;
                    }
                    else
                    {
                        if (!hitasecond)
                          hitasecond = true;
                        ShuffleList[i] = priorInt;
                        priorInt = OriginalList[i]; 
                    }
                }
                
            }

            if (!ini)
            {
                if (hitasecond)
                    ShuffleList[iniInd] = priorInt;
                else
                {
                    //need to swap with circular next;
                    int tmpInd = -1;
                    if (iniInd == OriginalList.Count - 1)
                        tmpInd = 0;
                    else 
                        tmpInd = iniInd + 1;
                   // int tmpInd = (iniInd + 1) % OriginalList.Count;
                    int tmpInt = ShuffleList[tmpInd];
                    ShuffleList[tmpInd] = priorInt;
                    ShuffleList[iniInd] = tmpInt;
                }
            }

            return ShuffleList;
        }

       
    }

    
}