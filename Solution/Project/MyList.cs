using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
	class MyList 
	{
		private IntItem last;
		private IntItem first;


		public int this[int index]
		{
			get
			{
				if (Count < index)
				{
					throw new IndexOutOfRangeException();
				}

				IntItem temp = first;
				for (int i = 0; i < index; i++)
				{
					temp = temp.next;
				}
				return temp.value;
			}
		}


		public bool IsEmpty
		{ get => Count == 0; }


		public int Count { get; set; }


		public MyList Add(int item)
		{
			IntItem temp = new IntItem(item);
			if (last != null)
			{
				last.next = temp;
				temp.prev = last;
			}
			if (IsEmpty)
			{
				first = temp;
			}
			last = temp;
			Count++;
			return this;
		}


		//public MyList Add(IntItem item)
		//{
		//	if (last != null)
		//	{
		//		last.next = item;
		//		item.prev = last;
		//	}
		//	if (IsEmpty)
		//	{
		//		first = item;
		//	}
		//	last = item;
		//	Count++;
		//	return this;
		//}


		public MyList Remove(int index)
		{
			if (Count < index)
			{
				return this;
			}

			IntItem removed = first;

			//remove first
			if (index == 0)
			{
				first = first.next;
				first.prev = null;
				Count--;
				return this;
			}

			// remove last
			if (index == Count)
			{
				last = last.prev;
				last.next = null;
				Count--;
				return this;
			}

			// remove from middle 
			for (int i = 0; i < index; i++)
			{
				removed = removed.next;
			}

			removed.prev.next = removed.next;
			removed.next.prev = removed.prev;
			removed.next = null;
			removed.prev = null;

			Count--;
			return this;
		}


		public override string ToString()
		{
			string s = "";
			IntItem temp = first;
			for (int i = 0; i < Count; i++)
			{
				if (temp != null)
				{
					s += temp.ToString() + " ";
					temp = temp.next;
				}
				else
				{
					s += "null ";
				}
			}
			s += "\n";
			return s;
		}


		public void Sort()
		{
			Console.WriteLine(this.ToString());
			IntItem i = first;

			while (i != null)
			{
				IntItem j = first;
				while (j != null && j.next != null)
				{
					if (j.value > j.next.value)
					{
						this.Swap(j, j.next);
						Console.WriteLine(this.ToString());
					}
					j = j.next;
				}
				i = i.next;
			}
		}


		private void Swap(IntItem i, IntItem j)
		{
			IntItem temp;
			if (i.prev != null)
			{
				i.prev.next = j;
			}
			else
			{
				first = j;
			}

			j.prev = i.prev;
			temp = j.next;
			j.next = i;
			i.next = temp;
			i.prev = j;

			if (temp != null)
			{
				temp.prev = i;
			}
			else
			{
				last = i;
			}
		}


		public static void Create (out MyList myList)
		{
			myList = new MyList();
		}


		public void Contains(int item)
		{
			if (IsEmpty)
			{
				Console.WriteLine("MyList is empty");
				return;
			}

			IntItem temp = first;

			for (int i = 0; i < Count; i++)
			{
				if (temp.value == item)
				{
					Console.WriteLine();
					Console.Write(value: $"item {item} inside \n");
					return;
				}
				temp = temp.next;
			}
			Console.WriteLine();
			Console.Write(value: $"item {item} is absent \n");
		}


		public void Find(int item)
		{
			if (IsEmpty)
			{
				Console.WriteLine("MyList is empty");
				return;
			}

			IntItem temp = first;
			for (int i = 0; i < Count; i++)
			{
				if (temp.value == item)
				{
					Console.WriteLine();
					Console.Write(value: $"{item} has been finded \n");
					return;
				}
				temp = temp.next;
			}
			Console.WriteLine();
			Console.Write(value: $"{item} is not found \n");
		}


		public void FindLast(int item)
		{
			if (IsEmpty)
			{
				Console.WriteLine("MyList is empty");
				return;
			}

			IntItem temp = last;
			for (int i = Count; i > 0; i--)
			{
				if (temp.value == item)
				{
					Console.WriteLine();
					Console.Write(value: $"{item} has been finded \n");
					return;
				}
				temp = temp.prev;
			}
			Console.WriteLine();
			Console.Write(value: $"{item} is not found \n");
		}


		public void FindIndex(int index)
		{
			if (IsEmpty)
			{
				Console.WriteLine("MyList is empty");
				return;
			}

			IntItem item = first;
			int count = 0;

			for (int i = 0; i < Count; i++)
			{
				if (count == index)
				{
					Console.WriteLine();
					Console.Write(value: $"inex: {index} item: {item} \n");
					return;
				}
				item = item.next;
				count++;
			}
			Console.WriteLine();
			Console.Write(value: $"index {index} not found \n");
		}


		public void FindLastIndex(int index)
		{
			if (IsEmpty)
			{
				Console.WriteLine("MyList is empty");
				return;
			}

			IntItem item = last;
			int count = Count - 1;

			for (int i = Count; i > 0; i--)
			{
				if (count == index)
				{
					Console.WriteLine();
					Console.Write(value: $"inex: {index} item: {item} \n");
					return;
				}
				item = item.prev;
				count--;
			}
			Console.WriteLine();
			Console.Write(value: $"index {index} not found \n");
		}


		//public void FindAll(int item)
		//{
		//	if (IsEmpty)
		//	{
		//		Console.WriteLine("MyList is empty");
		//		return;
		//	}

		//	IntItem temp = first;
		//	//IntItem newItem = null;
		//	//Create(out MyList myList);

		//	for (int i = 0; i < Count; i++)
		//	{
		//		if (temp.value == item)
		//		{
		//			Console.WriteLine();
		//			Console.Write(value: $"{item} has been finded \n");
					
		//		}
		//		temp = temp.next;
		//	}
		//	Console.WriteLine();
		//	Console.Write(value: $"{item} is not found \n");
		//}


		public void Clear()
		{
			if (IsEmpty)
			{
				Console.WriteLine("MyList is empty");
				return;
			}

			IntItem temp = first.next;
			first = null;
			for (int i = 0; i < Count - 1; i++)
			{
				temp.prev.next = null;
				temp.prev = null;
				temp = temp.next;
			}
		}


		public void AddRange(int index, int item)
		{
			IntItem temp = first;
			
			for (int i = 0; i < index + 1; i++)
			{
				temp.value = item;
				temp = temp.next;
			}

		}


		// TODO: AddRange(5);
		// TODO: Clear();
		// TODO: Contains(2);
		// TODO: Find(2);
		// TODO: FindIndex(-1);
		// TODO: FindLast();
		// TODO: FindLastIndex();
		// TODO: FindAll();
	}
}
