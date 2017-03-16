using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Method
{

	[Serializable()]
	public class clsAbsRepeatDataCollection : System.Collections.CollectionBase, ICloneable
	{

		#Region " Public Function "

		//---Default Constructor

		public clsAbsRepeatDataCollection()
		{
		}

		//---Copy Constructor
		public clsAbsRepeatDataCollection(clsAbsRepeatDataCollection rhs)
		{
			base.New();
			clsAbsRepeatData item;
			foreach ( item in rhs) {
				innerlist.Add(item.Clone());
			}
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the clsAbsRepeat
		public object System.ICloneable.Clone()
		{
			return new clsAbsRepeatDataCollection(this);
		}

		#End Region

		private clsAbsRepeatData this[int index] {
			get { return innerlist.Item(index); }
			set { innerlist.Item(index) = Value; }
		}

		//--- you can add only data object to this collection
		private void Add(clsAbsRepeatData value)
		{
			innerlist.Add(value);
		}

	}
}

