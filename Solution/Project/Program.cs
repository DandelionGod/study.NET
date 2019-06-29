using System;
using System.Collections.Generic;



namespace Project
{
    class Program
    {
        static void Main(string[] args)
		{
			List<int> q;
			

			MyList.Create(out MyList a);
			//int q = a[54]; // или так
			Console.Write(a.ToString());
			a.Add(12).Remove(2).Add(4);
			a.Add(new FloatItem(-32.34f)).Add(new DoubleItem(32.5));
			Console.Write(a.ToString());

			Console.ReadKey();
		}
	}
}
