﻿namespace knapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Bag : IEnumerable<Bag.Item>
    {
        List<Item> items;
        const int MaxWeightAllowed = 500000;

        public Bag()
        {
            items = new List<Item>();
        }

        void AddItem(Item i)
        {
            if ((TotalWeight + i.Weight) <= MaxWeightAllowed)
                items.Add(i);
        }

        public void Calculate(List<Item> items)
        {
            foreach (Item i in Sorte(items))
            {
                AddItem(i);
            }
        }

        List<Item> Sorte(List<Item> inputItems)
        {
            List<Item> choosenItems = new List<Item>();
            for (int i = 0; i < inputItems.Count; i++)
            {
                int j = -1;
                if (i == 0)
                {
                    choosenItems.Add(inputItems[i]);
                }
                if (i > 0)
                {
                    if (!RecursiveF(inputItems, choosenItems, i, choosenItems.Count - 1, false, ref j))
                    {
                        choosenItems.Add(inputItems[i]);
                    }
                }
            }
            return choosenItems;
        }

        bool RecursiveF(List<Item> knapsackItems, List<Item> choosenItems, int i, int lastBound, bool dec, ref int indxToAdd)
        {
            if (!(lastBound < 0))
            {
                if (knapsackItems[i].ResultWV < choosenItems[lastBound].ResultWV)
                {
                    indxToAdd = lastBound;
                }
                return RecursiveF(knapsackItems, choosenItems, i, lastBound - 1, true, ref indxToAdd);
            }
            if (indxToAdd > -1)
            {
                choosenItems.Insert(indxToAdd, knapsackItems[i]);
                return true;
            }
            return false;
        }

        #region IEnumerable<Item> Members
        IEnumerator<Item> IEnumerable<Item>.GetEnumerator()
        {
            foreach (Item i in items)
                yield return i;
        }
        #endregion

        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
        #endregion

        public decimal TotalWeight
        {
            get
            {
                var sum = 0M;
                foreach (Item i in this)
                {
                    sum += i.Weight;
                }
                return sum;
            }
        }

        public class Item
        {
            public string Name { get; set; }
            public int Weight { get; set; }
            public decimal Value { get; set; }
            public decimal ResultWV { get { return Weight - Value; } }
            public override string ToString()
            {
                return "Name : " + Name + "        Weight : " + Weight + "       Value : " + Value + "     ResultWV : " + ResultWV;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Bag.Item> knapsackItems = new List<Bag.Item>();
            // knapsackItems.Add(new Bag.Item() { Name = "Map", Weight = 9, Value = 150 });
            // knapsackItems.Add(new Bag.Item() { Name = "Water", Weight = 153, Value = 200 });
            // knapsackItems.Add(new Bag.Item() { Name = "Compass", Weight = 13, Value = 35 });
            // knapsackItems.Add(new Bag.Item() { Name = "Sandwitch", Weight = 50, Value = 160 });
            // knapsackItems.Add(new Bag.Item() { Name = "Glucose", Weight = 15, Value = 60 });
            // knapsackItems.Add(new Bag.Item() { Name = "Tin", Weight = 68, Value = 45 });
            // knapsackItems.Add(new Bag.Item() { Name = "Banana", Weight = 27, Value = 60 });
            // knapsackItems.Add(new Bag.Item() { Name = "Apple", Weight = 39, Value = 40 });
            // knapsackItems.Add(new Bag.Item() { Name = "Cheese", Weight = 23, Value = 30 });
            // knapsackItems.Add(new Bag.Item() { Name = "Beer", Weight = 52, Value = 10 });
            // knapsackItems.Add(new Bag.Item() { Name = "Suntan Cream", Weight = 11, Value = 70 });
            // knapsackItems.Add(new Bag.Item() { Name = "Camera", Weight = 32, Value = 30 });
            // knapsackItems.Add(new Bag.Item() { Name = "T-shirt", Weight = 24, Value = 15 });
            // knapsackItems.Add(new Bag.Item() { Name = "Trousers", Weight = 48, Value = 10 });
            // knapsackItems.Add(new Bag.Item() { Name = "Umbrella", Weight = 73, Value = 40 });
            // knapsackItems.Add(new Bag.Item() { Name = "WaterProof Trousers", Weight = 42, Value = 70 });
            // knapsackItems.Add(new Bag.Item() { Name = "Note-Case", Weight = 22, Value = 80 });
            // knapsackItems.Add(new Bag.Item() { Name = "Sunglasses", Weight = 7, Value = 20 });
            // knapsackItems.Add(new Bag.Item() { Name = "Towel", Weight = 18, Value = 12 });
            // knapsackItems.Add(new Bag.Item() { Name = "Socks", Weight = 4, Value = 50 });
            // knapsackItems.Add(new Bag.Item() { Name = "Book", Weight = 30, Value = 10 });
            // knapsackItems.Add(new Bag.Item() { Name = "waterproof overclothes ", Weight = 43, Value = 75 });

            knapsackItems.Add(new Bag.Item() { Name = "1", Weight = 57247, Value = 0.0887M });
            knapsackItems.Add(new Bag.Item() { Name = "2", Weight = 98732, Value = 0.1856M });
            knapsackItems.Add(new Bag.Item() { Name = "3", Weight = 134928, Value = 0.2307M });
            knapsackItems.Add(new Bag.Item() { Name = "4", Weight = 77275, Value = 0.1522M });
            knapsackItems.Add(new Bag.Item() { Name = "5", Weight = 29240, Value = 0.0532M });
            knapsackItems.Add(new Bag.Item() { Name = "6", Weight = 15440, Value = 0.0250M });
            knapsackItems.Add(new Bag.Item() { Name = "7", Weight = 70820, Value = 0.1409M });
            knapsackItems.Add(new Bag.Item() { Name = "8", Weight = 139603, Value = 0.2541M });
            knapsackItems.Add(new Bag.Item() { Name = "9", Weight = 63718, Value = 0.1147M });
            knapsackItems.Add(new Bag.Item() { Name = "10", Weight = 143807, Value = 0.2660M });
            knapsackItems.Add(new Bag.Item() { Name = "11", Weight = 190457, Value = 0.2933M });
            knapsackItems.Add(new Bag.Item() { Name = "12", Weight = 40572, Value = 0.0686M });

            Bag b = new Bag();
            b.Calculate(knapsackItems);
            b.All(x => { Console.WriteLine(x); return true; });
            Console.WriteLine(b.Sum(x => x.Weight));
            Console.WriteLine(b.Sum(x => x.Value));
            Console.ReadKey();
        }
    }
}
