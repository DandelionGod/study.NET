using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
	class MyList 
	{
		private IItem last;
		private IItem first;


		public IItem this[int index]
		{
			get
			{
				if (Count < index)
				{
					throw new IndexOutOfRangeException();
				}

				IItem temp = first;
				for (int i = 0; i < index; i++)
				{
					temp = temp.next;
				}
				return temp;
			}
		}


		public bool IsEmpty
		{ get => Count == 0; }

		public int Count { get; set; }

		public MyList Add(int item)
		{
			IItem temp = new IntItem(item);
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


		public MyList Add(IItem item)
		{
			if (last != null)
			{
				last.next = item;
				item.prev = last;
			}
			if (IsEmpty)
			{
				first = item;
			}
			last = item;
			Count++;
			return this;
		}


		public MyList Remove(int index)
		{
			if (Count < index)
			{
				return this;
			}

			IItem removed = first;

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
				return (this);
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
			IItem temp = first;
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


		//public void Sort()
		//{
		//	Console.WriteLine(this.ToString());
		//	IItem i = first;

		//	while (i != null)
		//	{
		//		IItem j = first;
		//		while (j != null && j.next != null)
		//		{
		//			if (j.value > j.next.value)
		//			{
		//				this.Swap(j, j.next);
		//				Console.WriteLine(this.ToString());
		//			}
		//			j = j.next;
		//		}
		//		i = i.next;
		//	}
		//}


		private void Swap(IItem i, IItem j)
		{
			IItem temp;
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
	}
}

		// TODO: Remove(5);
		// TODO: ToString();
		// TODO: Sort();
