using System;
using System.Collections.Generic;



namespace Project
{
    class Program
    {
        static void Main(string[] args)
		{
			//List<int> q;
			//q.AddRange

			MyList.Create(out MyList a);
			//int q = a[54]; // или так
			//a.Add(2).Add(6).Add(2).Add(5).Add(-2).Add(1).Add(3).Add(2).Add(2);
			a.Add(6).Add(5).Add(-2).Add(1).Add(3).Add(2).Add(2).Add(0);
			Console.WriteLine(a.ToString());
			a.Remove(6);

			Console.WriteLine(a.ToString());
			//a.Contains(2);
			//a.Find(7);
			//a.FindLast(7);
			//a.FindIndex(2);
			//a.FindLastIndex(3);
			//a.Clear();
			Console.WriteLine(a.ToString());

			//a.AddRange(new List<int> { 1, 2, -10, 0 });
			//a.AddRange(new int[] { 1, 2, -10, 0 });

			Console.WriteLine(a.ToString());

			a.Remove(2);

			Console.WriteLine(a.ToString());
			Console.ReadKey();
		}
	}
}
