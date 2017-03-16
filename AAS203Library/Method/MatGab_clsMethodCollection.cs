using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Method
{

	[Serializable()]
	public class clsMethodCollection : System.Collections.CollectionBase, ICloneable
	{

		#Region " Public Functions "

		//---Default Constructor

		public clsMethodCollection()
		{
		}

		//---Copy Constructor
		public clsMethodCollection(clsMethodCollection rhs)
		{
			base.New();
			clsMethod item;
			foreach ( item in rhs) {
				innerlist.Add(item.Clone());
			}
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the clsMethodCollection
		public object System.ICloneable.Clone()
		{
			return new clsMethodCollection(this);
		}

		//--- you can add only data object to this collection
		public void Add(clsMethod value)
		{
			innerlist.Add(value);
		}

		#End Region

		#Region " Public Properties "

		private clsMethod this[int index] {
			get { return innerlist.Item(index); }
			set { innerlist.Item(index) = Value; }
		}

		#End Region

	}

}
