﻿/*
Sliding Window Maximum
Asked in:  
Google
Chronus
Walmart labs
Amazon
A long array A[] is given to you. There is a sliding window of size w which is moving from the very left of the array to the very right. You can only see the w numbers in the window. Each time the sliding window moves rightwards by one position. You have to find the maximum for each window. The following example will give you more clarity.

Example :

The array is [1 3 -1 -3 5 3 6 7], and w is 3.

Window position	Max
 	 
[1 3 -1] -3 5 3 6 7	3
1 [3 -1 -3] 5 3 6 7	3
1 3 [-1 -3 5] 3 6 7	5
1 3 -1 [-3 5 3] 6 7	5
1 3 -1 -3 [5 3 6] 7	6
1 3 -1 -3 5 [3 6 7]	7
Input: A long array A[], and a window width w
Output: An array B[], B[i] is the maximum value of from A[i] to A[i+w-1]
Requirement: Find a good optimal way to get B[i]

 Note: If w > length of the array, return 1 element with the max of the array. */
using System.Collections.Generic;
using System.Linq;

namespace Programming.Stacks_and_Queues
{
    public class SlidingWindowMaximum
    {
        public List<int> SlidingMaxWindow(List<int> A, int window)
        {
            var queue = new LinkedList<int>();
            var slidingWindow = new List<int>();
            for (int i = 0; i < A.Count; i++)
            {
                while (queue.Count > 0 && A[queue.Last()] <= A[i])
                    queue.RemoveLast();
                queue.AddLast(i);
                if (i - queue.First() >= window)
                    queue.RemoveFirst();
                if (i - window + 1 >= 0)
                    slidingWindow.Add(A[queue.First()]);
            }
            return slidingWindow;
        }
        /*public static void Main(string[] args)
        {
            SlidingWindowMaximum obj = new SlidingWindowMaximum();
            var result = obj.SlidingMaxWindow(new List<int> { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
        }*/
    }
}
