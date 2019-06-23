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

			Console.ReadKey();
		}

		private static void WritearrayConsole(IList<int> array)
		{
          for (int i = 0; i < array.Count; i++)
			{
				Console.Write(value: $"{array[i]} ");
			}
			Console.WriteLine();
		}

		private static void ReadarrayConsole(IList<int> array)
		{
			for (int i = 0; i < array.Count; i++)
			{
				array[i] = array.Count - i;
			}
		}

		private static void Cicle()
		{
			for (int i = 99; i >= 0; i--)
			{
				Console.Write(value: $"{i}:{99 - i}{(i == 0 ? "" : " ")}");
			}
		}

		private static void Sort(IList<int> array)
		{
			for (int i = 0; i < array.Count; i++)
			{
				for (int j = 0; j < array.Count - i - 1; j++)
				{
					if (array[j] > array[j + 1])
					{
						int temp = array[j];
						array[j] = array[j + 1];
						array[j + 1] = temp;
					}
				}
				WritearrayConsole(array);
			}
		}
		private static void Newarr(int[] array)
		{

		}
	}
}
