namespace MyCollections
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


	//class FloatItem : IItem
	//{
	//	public float value;
		
	//	public FloatItem(float value)
	//	{
	//		this.value = value;
	//	}

	//	IItem IItem.next { get; set; }
	//	IItem IItem.prev { get; set; }

	//	public override string ToString()
	//	{
	//		return value.ToString();
	//	}
	//}


	//class DoubleItem : IItem
	//{
	//	public double value;

	//	public DoubleItem(double value)
	//	{
	//		this.value = value;
	//	}

	//	IItem IItem.next { get; set; }
	//	IItem IItem.prev { get; set; }

	//	public override string ToString()
	//	{
	//		return value.ToString();
	//	}
	//}
}
