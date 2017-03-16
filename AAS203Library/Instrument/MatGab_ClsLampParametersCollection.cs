using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Instrument
{

	[Serializable()]
	public class ClsLampParametersCollection : System.Collections.CollectionBase, ICloneable
	{

		//---Default Constructor

		public ClsLampParametersCollection()
		{
		}

		//---Copy Constructor
		public ClsLampParametersCollection(ClsLampParametersCollection rhs)
		{
			base.New();
			ClsLampParameters item;
			foreach ( item in rhs) {
				innerlist.Add(item.Clone());
			}
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the ClsLampParametersCollection
		public object System.ICloneable.Clone()
		{
			return new ClsLampParametersCollection(this);
		}

		private ClsLampParameters this[int index] {
			get { return innerlist.Item(index); }
			set { innerlist.Item(index) = Value; }
		}

		//--- you can add only data object to this collection
		private void Add(ClsLampParameters value)
		{
			innerlist.Add(value);
		}

	}
}

