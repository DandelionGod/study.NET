namespace Project
{
	class IntItem : IItem
	{
		public int value;

		public IntItem(int value)
		{
			this.value = value;
		}

		IItem IItem.next { get; set; }
		IItem IItem.prev { get; set; }

		public override string ToString()
		{
			return value.ToString();
		}
	}


	class FloatItem : IItem
	{
		public float value;
		
		public FloatItem(float value)
		{
			this.value = value;
		}

		IItem IItem.next { get; set; }
		IItem IItem.prev { get; set; }

		public override string ToString()
		{
			return value.ToString();
		}
	}


	class DoubleItem : IItem
	{
		public double value;

		public DoubleItem(double value)
		{
			this.value = value;
		}

		IItem IItem.next { get; set; }
		IItem IItem.prev { get; set; }

		public override string ToString()
		{
			return value.ToString();
		}
	}


	interface IItem
	{
		IItem next { get; set; }
		IItem prev { get; set; }
	}
}
