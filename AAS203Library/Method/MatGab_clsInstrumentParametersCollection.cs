using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Method
{
	[Serializable()]
	public class clsInstrumentParametersCollection : System.Collections.CollectionBase, ICloneable
	{

		//---Default constructor

		public clsInstrumentParametersCollection()
		{
		}

		//---Copy constructor
		public clsInstrumentParametersCollection(clsInstrumentParametersCollection rhs)
		{
			base.New();
			clsInstrumentParameters item;
			foreach ( item in rhs) {
				innerlist.Add(item.Clone());
			}
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the clsInstrumentParametersCollection
		public object System.ICloneable.Clone()
		{
			return new clsInstrumentParametersCollection(this);
		}

		private clsInstrumentParameters this[int index] {
			get { return innerlist.Item(index); }
			set { innerlist.Item(index) = Value; }
		}

		//--- you can add only data object to this collection
		private void Add(clsInstrumentParameters value)
		{
			innerlist.Add(value);
		}

	}

}
