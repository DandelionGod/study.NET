using System;
using System.Collections.Generic;



namespace Project
{
    class Program
    {
        static void Main(string[] args)
		{
			MyList a = new MyList();
			a.Add(2);
			a.Add(-2);
			a.Add(21);
			a.Add(22);
			a.Add(123);
			a.Add(99);
			a.Add(45);
			a.Add(-7);
			Console.Write(a.ToString());
			a.Remove(4);
			Console.Write(a.ToString());
			a.Remove(0);
			Console.Write(a.ToString());
			a.Remove(123); // что если так
            int q = a[54]; // или так
            //a.Add(12).Remove(2).Add(4); // хочу так
			Console.ReadKey();
		}
	}
}
