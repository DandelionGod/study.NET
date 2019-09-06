using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections.Lib
{

	//interface IItem
	//{
	//	IItem next { get; set; }
	//	IItem prev { get; set; }
	//}


	class Item
	{
		public Item prev;
		public Item next;
		public object value;

		public Item(object value)
		{
			this.value = value;
		}

		//IItem IItem.next { get; set; }
		//IItem IItem.prev { get; set; }

		public override string ToString()
		{
			return value.ToString();
		}
	}


	public class MyList
	{
		private Item last;
		private Item first;


		public object this[int index]
		{
			get
			{
				if (Count < index)
				{
					throw new IndexOutOfRangeException();
				}

				Item temp = first;
				for (int i = 0; i < index; i++)
				{
					temp = temp.next;
				}
				return temp.value;
			}
		}


		public bool IsEmpty => Count == 0;


		public int Count { get; set; }


		public MyList Add(object item)
		{
			Item temp = new Item(item);
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




		public MyList Remove(object value)
		{
			Item removed = first;



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

		public MyList RemoveAll(object value)
		{
			Item removed = first;

			for (int i = 0; i < Count; i++)
			{
				Item temp = removed;

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

			Item removed = first;

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

		private void Remove(Item removed)
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
			Item temp = first;
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
			Item i = first;

			while (i != null)
			{
				Item j = first;
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


		private void Swap(Item i, Item j)
		{
			Item temp;
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


		public bool Contains(object item)
		{
			if (IsEmpty)
			{
				return false;
			}

			Item temp = first;

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


		public object Find(object item)
		{
			if (IsEmpty)
			{
				return -1;
			}

			Item temp = first;
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


		public object FindLast(object item)
		{
			if (IsEmpty)
			{
				return -1;
			}

			Item temp = last;
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


		public object FindIndex(object item)
		{
			if (IsEmpty)
			{
				return -1;
			}

			Item temp = first;
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


		public object FindLastIndex(object item)
		{
			if (IsEmpty)
			{
				return -1;
			}

			Item temp = last;
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


		//public void FindAll(object item)
		//{
		//	if (IsEmpty)
		//	{
		//		Console.WriteLine("MyList is empty");
		//		return;
		//	}

		//	Item temp = first;
		//	//Item newItem = null;
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

			Item temp = first.next;
			first = null;
			for (int i = 0; i < Count - 1; i++)
			{
				temp.prev.next = null;
				temp.prev = null;
				temp = temp.next;
			}
		}


		public void AddRange(IEnumerable<object> collection)
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
