using System.Collections;

namespace Fakher.Core.DomainModel
{
	public class Rank2
	{
		public Rank2()
		{
			count = 0;
		}

		SortedList list1 = new SortedList();
		ArrayList result;
		private int count;
		public void AddPoint(double Point, object o)
		{
			count++;
			if(list1.ContainsKey(Point))
			{
				(list1[Point] as ArrayList).Add(o);
				return;
			}
			ArrayList arr = new ArrayList();
			arr.Add(o);
			list1.Add(Point, arr);
		}

		public void Calculate()
		{
			int n = 1;
			result = new ArrayList();

			for(int i = list1.Count - 1 ; i >= 0 ; i--)
			{
				ArrayList arr = (ArrayList) list1.GetByIndex(i);
				foreach (object o in arr)
					result.Add(new object[] {n, o});
				n += arr.Count;
			}
		}
		public int Count
		{
			get { return count; }
			set { count = value; }
		}

		public ArrayList Result
		{
			get { return result; }
			set { result = value; }
		}
		public SortedList SortedResult
		{
			get { return list1; }
			set { list1 = value; }
		}
	}
	public class Rank
	{
		public Rank()
		{
			count = 0;
		}

		SortedList list1 = new SortedList();
		Hashtable hash1;
		private int count;
		public void AddPoint(double Point)
		{
			count++;
			if (list1.ContainsKey(Point))
			{
				list1[Point] = ((int)(list1[Point])) + 1;
				return;
			}
			list1.Add(Point, 1);
		}

		public void Calculate()
		{
			int n = 1;
			hash1 = new Hashtable(list1.Count);
			for (int i = list1.Count - 1; i >= 0; i--)
			{
				double Point = (double)list1.GetKey(i);
				hash1.Add(Point, n);
				n += (int)list1[Point];
			}
		}
		public int GetRank(double Point)
		{
			return (int)hash1[Point];
		}

		public int Count
		{
			get { return count; }
			set { count = value; }
		}
	}
}
