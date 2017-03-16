using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Method
{

	[Serializable()]
	public class clsAnalysisSampleParametersCollection : System.Collections.CollectionBase, ICloneable
	{

		//---Default Constructor

		public clsAnalysisSampleParametersCollection()
		{
		}

		//---Copy Constructor
		public clsAnalysisSampleParametersCollection(clsAnalysisSampleParametersCollection rhs)
		{
			base.New();
			clsAnalysisSampleParameters item;
			foreach ( item in rhs) {
				innerlist.Add(item.Clone());
			}
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the clsAnalysisSampleParametersCollection
		public object System.ICloneable.Clone()
		{
			return new clsAnalysisSampleParametersCollection(this);
		}

		private clsAnalysisSampleParameters this[int index] {
			get { return innerlist.Item(index); }
			set { innerlist.Item(index) = Value; }
		}

		//--- you can add only data object to this collection
		private void Add(clsAnalysisSampleParameters value)
		{
			innerlist.Add(value);
		}

	}
}
