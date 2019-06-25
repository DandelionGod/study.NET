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
			a.Add(1);
			a.Add(3);
			a.Add(99);
			a.Add(45);
			a.Add(10000);
			//a.Remove(123); // что если так
			//int q = a[54]; // или так
			//a.Add(12).Remove(2).Add(4); // хочу так
			a.Sort();
			Console.Write(a.ToString());


			Console.ReadKey();
		}
	}
}
