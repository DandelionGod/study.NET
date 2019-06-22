using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
	class MyList
	{
		IntItem last;
		IntItem first;
		public int Count;
		public int this[int index]
		{
			get
			{
				IntItem temp = first;
				for (int i = 0; i < index - 1; i++)
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
			temp.prev = last;
			if(last != null)
			{
				last.next = temp;
			}
			last = temp;
			if (Count == 0)
			{
				first = temp;
			}
			Count++;
		}


		// TODO: Remove(5);
		// TODO: ToString();
		// TODO: Sort();
	}
}
