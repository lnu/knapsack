using System;
using System.Collections.Generic;
using System.Text;

namespace knapsack
{
    /// <summary>
    /// naive algorithm, O(n^2)
    /// In our case, it's really fast since the number of combinations is small
    /// </summary>
    class v2
    {
        // Returns the maximum value that can be put in a knapsack of capacity W
        static decimal knapSack(decimal W, decimal[] wt, decimal[] val, int n)
        {
            // Base Case
            if (n == 0 || W == 0)
                return 0;


            // If weight of the nth item is more than Knapsack capacity W, then
            // this item cannot be included in the optimal solution
            if (wt[n - 1] > W)
                return knapSack(W, wt, val, n - 1);

            // Return the maximum of two cases: 
            // (1) nth item included 
            // (2) not included
            else return Math.Max((val[n - 1] + knapSack(W - wt[n - 1], wt, val, n - 1)), knapSack(W, wt, val, n - 1));
        }


        // Driver program to test above function
        public static void Execute()
        {
            var wt = new decimal[] { 57247, 98732, 134928, 77275, 29240, 15440, 70820, 139603, 63718, 143807, 190457, 40572 };
            var val = new decimal[] { 0.0887M, 0.1856M, 0.2307M, 0.1522M, 0.0532M, 0.0250M, 0.1409M, 0.2541M, 0.1147M, 0.2660M, 0.2933M, 0.0686M };
            decimal W = 500000;
            int n = val.Length;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var result = knapSack(W, wt, val, n);
            sw.Stop();
            Console.WriteLine($"result:{result} total:{result + 12.5M} in {sw.ElapsedMilliseconds} ms");
        }
    }
}
