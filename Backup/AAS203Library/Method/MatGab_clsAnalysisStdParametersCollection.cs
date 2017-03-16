
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Method
{
	[Serializable()]
	public class clsAnalysisStdParametersCollection : System.Collections.CollectionBase, ICloneable
	{

		//---Default Constructor

		public clsAnalysisStdParametersCollection()
		{
		}

		//---Copy Constructor
		public clsAnalysisStdParametersCollection(clsAnalysisStdParametersCollection rhs)
		{
			base.New();
			clsAnalysisStdParameters item;
			foreach ( item in rhs) {
				innerlist.Add(item.Clone());
			}
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the clsAnalysisStdParametersCollection
		public object System.ICloneable.Clone()
		{
			return new clsAnalysisStdParametersCollection(this);
		}

		private clsAnalysisStdParameters this[int index] {
			get { return innerlist.Item(index); }
			set { innerlist.Item(index) = Value; }
		}

		//--- you can add only data object to this collection
		private void Add(clsAnalysisStdParameters value)
		{
			innerlist.Add(value);
		}


	}
}
