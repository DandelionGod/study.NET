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
		private int count;
		public int this[int index]
		{
			get
			{
				IntItem temp = first;
				for (int i = 0; i < index; i++) // Раньше было (int i = 0; i < index - 1; i++) и не выводило ласт элемент
				{
					temp = temp.next;
				}
				return temp.value;
			}
			set { /* set the specified index to value here */ }
		}

		public void Add(int item)
		{
			IntItem temp = new IntItem(item);
			if(last != null)
			{
				last.next = temp;
				temp.prev = last;
			}
			if (count == 0)
			{
				first = temp;
			}
			last = temp;
			count++;
		}

		public void Remove(int index)
		{
			IntItem removed = first;
			//remove first
			if (index == 0)
			{
				first = first.next;
				first.prev = null;
				count--;
				return;
			}
			// remove last
			if (index == count)
			{
				last = last.prev;
				last.next = null;
				count--;
				return;
			}
			// remove from middle 
			for (int i = 0; i < index; i++)
			{
				removed = removed.next;
			}
			removed.prev.next = removed.next;
			removed.next.prev = removed.prev;

			count--;
		}

		public int Size()
		{
			return count;
		}

		public bool IsEmpty()
		{
			return Size() == 0;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			IntItem temp = first;
			for (int i = 0; i < Size(); i++)
			{
				sb.Append(temp.value).Append(" ");
				temp = temp.next;
			}
			sb.Append("\n");
			return sb.ToString();
		}

		// TODO: Remove(5);
		// TODO: ToString();
		// TODO: Sort();
	}
}


