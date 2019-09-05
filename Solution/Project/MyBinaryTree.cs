using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
	class MyBinaryTree
	{
		public TreeNode Root { get; private set; }
		public int Count { get; private set; }

		public CoolBinaryTree()
		{
			Count = 0;
		}

		public void Add(IComparable item)
		{
			if (Root == null)
				Root = new TreeNode(item);
			else
				InternalAdd(item, Root);

			Count++;
		}

		private void InternalAdd(IComparable item, TreeNode node)
		{
			if (node.Value.CompareTo(item) > 0)
			{
				// Left
				if (node.Left == null)
					node.Left = new TreeNode(item);
				else
					InternalAdd(item, node.Left);
			}
			else
			{
				// Right
				if (node.Right == null)
					node.Right = new TreeNode(item);
				else
					InternalAdd(item, node.Right);
			}
		}

		public void Clear()
		{
			Root = null;
			Count = 0;
		}

		public bool Contains(IComparable item)
		{
			return ContainsInternal(item, Root);
		}

		private bool ContainsInternal(IComparable item, TreeNode root)
		{
			var compareResult = root.Value.CompareTo(item);
			if (compareResult == 0)
			{
				return true;
			}
			else if (compareResult > 0)
			{
				// Left
				if (root.Left == null)
					return false;
				return ContainsInternal(item, root.Left);
			}
			else
			{
				// Right
				if (root.Right == null)
					return false;
				return ContainsInternal(item, root.Right);
			}
		}

		public object[] ToArray()
		{
			if (Root == null)
				return new object[0];

			CoolList coolList = new CoolList();
			ToArrayInner(coolList, Root);
			return coolList.ToArray();
		}

		private void ToArrayInner(CoolList coolList, TreeNode root)
		{
			if (root.Left != null)
				ToArrayInner(coolList, root.Left);
			coolList.Add(root.Value);
			if (root.Right != null)
				ToArrayInner(coolList, root.Right);
		}
}
