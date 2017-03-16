using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FuelConditions
{
	[Serializable()]
	public class clsFuelDataCollection : System.Collections.CollectionBase, ICloneable
	{

		#Region " Public Function "

		//---Default Constructor

		public clsFuelDataCollection()
		{
		}

		//---Copy Constructor
		public clsFuelDataCollection(clsFuelDataCollection rhs)
		{
			base.New();
			clsFuelData item;
			foreach ( item in rhs) {
				innerlist.Add(item.Clone());
			}
		}

		public object System.ICloneable.Clone()
		{
			return new clsFuelDataCollection(this);
		}

		#End Region

		private clsFuelData this[int index] {
			get { return innerlist.Item(index); }
			set { innerlist.Item(index) = Value; }
		}

		//--- you can add only data object to this collection
		private void Add(clsFuelData value)
		{
			innerlist.Add(value);

		}
	}
}
