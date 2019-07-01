using System;
using System.Collections.Generic;



namespace Project
{
    class Program
    {
        static void Main(string[] args)
		{
			//List<int> q;
			

			MyList.Create(out MyList a);
			//int q = a[54]; // или так
			Console.Write(a.ToString());
			a.Add(6).Add(2).Add(5).Add(-2).Add(1).Add(3).Add(2).Add(2);
			Console.Write(a.ToString());
			a.Contains(2);
			a.Find(7);
			a.FindLast(7);
			a.FindIndex(2);
			a.FindLastIndex(3);
			//a.Clear();
			//Console.Write(a.ToString());

			a.AddRange(2, 10);
			
			Console.Write(a.ToString());

			Console.ReadKey();
		}
	}
}
