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
				for (int i = 0; i < index; i++)
				{
					temp = temp.next;
				}
				return temp.value;
			}
		}


		public int Count
		{
			get
			{
				return count;
			}
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
			removed.next = null;
			removed.prev = null;

			count--;
		}


		public bool IsEmpty() // возвращает размер и проверяет пустой ли список, так как поля теперь приватные
		{
			return Count == 0;
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


		// TODO: Remove(5);
		// TODO: ToString();
		// TODO: Sort();
	}
}


