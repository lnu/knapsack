using System;
using System.Collections.Generic;
using System.Text;

namespace knapsack
{
    /// <summary>
    /// dynamic programming algorithm, O(nW)
    /// In our case, it's really fast since the number of combinations is small
    /// </summary>
    class v3
    {
        // Returns the maximum value that can be put in a knapsack of capacity W
        static decimal knapSack(decimal W, decimal[] wt, decimal[] val, int n)
        {
            int i, w;
            decimal[][] K = new decimal[n + 1][];
            for (var x = 0; x < K.Length; x++)
            {
                K[x] = new decimal[(int)W + 1];
            }

            // Build table K[][] in bottom up manner
            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i][w] = 0;
                    else if (wt[i - 1] <= w)
                        K[i][w] = Math.Max(val[i - 1] + K[i - 1][w - (int)wt[i - 1]], K[i - 1][w]);
                    else
                        K[i][w] = K[i - 1][w];
                }
            }

            return K[n][(int)W];
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
