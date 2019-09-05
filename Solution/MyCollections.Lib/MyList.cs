using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections.Lib
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


		public bool IsEmpty => Count == 0;


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




		public MyList Remove(int value)
		{
			IntItem removed = first;



			// remove from middle
			for (int i = 0; i < Count; i++)
			{
				if (value == removed.value)
				{
					Remove(removed);
					Count--;
					return this;
				}
				removed = removed.next;
			}


			return this;
		}

		public MyList RemoveAll(int value)
		{
			IntItem removed = first;

			for (int i = 0; i < Count; i++)
			{
				IntItem temp = removed;

				if (value == removed.value)
				{
					Remove(removed);
					Count--;
					//return this;
				}
				temp = temp.next;
			}

			return this;
		}

		public MyList RemoveAt(int index)
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

			Remove(removed);

			Count--;
			return this;
		}

		private void Remove(IntItem removed)
		{
			if (removed == null)
			{
				return;
			}

			if (removed.prev == null)
			{
				first = removed.next;
			}
			else
			{
				removed.prev.next = removed.next;
			}

			if (removed.next == null)
			{
				last = removed.prev;
			}
			else
			{
				removed.next.prev = removed.prev;
			}

			removed.next = null;
			removed.prev = null;
		}

		public override string ToString()
		{
			string s = "Collection: ";
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


		public static void Create(out MyList myList)
		{
			myList = new MyList();
		}


		public bool Contains(int item)
		{
			if (IsEmpty)
			{
				return false;
			}

			IntItem temp = first;

			for (int i = 0; i < Count; i++)
			{
				if (temp.value == item)
				{
					return true;
				}
				temp = temp.next;
			}
			return false;
		}


		public int Find(int item)
		{
			if (IsEmpty)
			{
				return -1;
			}

			IntItem temp = first;
			for (int i = 0; i < Count; i++)
			{
				if (temp.value == item)
				{
					return i;
				}
				temp = temp.next;
			}
			return -1;
		}


		public int FindLast(int item)
		{
			if (IsEmpty)
			{
				return -1;
			}

			IntItem temp = last;
			for (int i = Count; i > 0; i--)
			{
				if (temp.value == item)
				{
					return i;
				}
				temp = temp.prev;
			}
			return -1;
		}


		public int FindIndex(int item)
		{
			if (IsEmpty)
			{
				return -1;
			}

			IntItem temp = first;
			for (int i = 0; i < Count; i++)
			{
				if (temp.value == item)
				{
					return i;
				}
				temp = temp.next;
			}
			return -1;
		}


		public int FindLastIndex(int item)
		{
			if (IsEmpty)
			{
				return -1;
			}

			IntItem temp = last;
			for (int i = Count; i > 0; i--)
			{
				if (temp.value == item)
				{
					return i;
				}
				temp = temp.prev;
			}
			return -1;
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


		public void AddRange(IEnumerable<int> collection)
		{
			foreach (var item in collection)
			{
				this.Add(item);
			}
		}



		// TODO: FindAll();
		// TODO: Reverse(); 
		// TODO: Remove(); удалить по значению
		// TODO: RemoveAll(); удалить все двойки
		// TODO: RemoveRange(); индекс и сколько удалить после него
		// TODO: GetRange(); индекс и сколько єлементов вернуть (возвращает коллекцию)
	}

}
