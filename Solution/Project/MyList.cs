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

		public void Add(int item)
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
		}


		public void Remove(int index)
		{
			IntItem removed = first;

			//remove first
			if (index == 0)
			{
				first = first.next;
				first.prev = null;
				Count--;
				return;
			}

			// remove last
			if (index == Count)
			{
				last = last.prev;
				last.next = null;
				Count--;
				return;
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
		}


		public override string ToString()
		{
			StringBuilder sb = new StringBuilder(); // он тут тебе не нужен, можно обойтись обычным стринг типом
			IntItem temp = first;
			for (int i = 0; i < Count; i++)
			{
				sb.Append(temp.value).Append(" ");
				temp = temp.next;
			}
			sb.Append("\n");
			return sb.ToString();
		}


		public void Sort()
		{
			IntItem i = first;
			while (i != last.next)
			{
				IntItem j = i.next;
				while (j !=last.next)
				{
					if (i.value > j.value)
					{
						IntItem temp = new IntItem(i.value);
						//IntItem temp = i;
						temp.next = i.next;
						temp.prev = i.prev;
						if (i.prev == null)
						{
							first = j;
						}
						if (j.next == null)
						{
							last = i;
						}
						i.next = j.next;
						i.prev = j;
						i.next.prev = i;
						j.prev.next = j; //= temp.next
						j.next = i;
						j.prev = temp.prev;


						//i.next = i.next.next;
						//i.next.prev = temp;
						//temp = i.prev;
						//i.prev = i.next.prev;
						//i.next.prev = temp;
					}
					j = j.next;
				}
				i = i.next;
			}
		}
	}
}

		// TODO: Remove(5);
		// TODO: ToString();
		// TODO: Sort();
