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
		private int count;  // слитая каша, старайся разделять пустыми строками логические блоки твоего кода.
                            // например по 2 пустых между методами, 3 между полями и методами, по 1 между логическими блоками полей
		public int this[int index]
		{
			get
			{
				IntItem temp = first;
				for (int i = 0; i < index; i++) // согласен
				{
					temp = temp.next;
				}
				return temp.value;
			}
			set { /* set the specified index to value here */ } ///раз ты им не пользуешься то зачем это тут
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
			removed.prev.next = removed.next; // very nice!
			removed.next.prev = removed.prev; // very nice!
            // забыл еще почистить ссылки самого удаленного обхекта, что бы они указывали на ничто
			count--;
		}

		public int Size() // это можно привратить в свойство
		{
			return count;
		}

		public bool IsEmpty() // это тут для чего?
		{
			return Size() == 0;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder(); // он тут тебе не нужен, можно обойтись обычным стринг типом
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


