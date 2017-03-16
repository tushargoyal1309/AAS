
namespace Method
{

	[Serializable()]
	public class clsQuantitativeDataCollection : CollectionBase, ICloneable, IDisposable
	{
		//**********************************************************************
		// File Header       
		// File Name 		:   clsQuantitativeDataCollection.vb
		// Author			:   Mangesh Shardul
		// Date/Time			:   25-Jan-2007 05:30 pm
		// Description		:   Class to hold Quantitative Analysis Data of 
		//                       Standards and Samples, Analysis & Report Parameters
		// Assumptions       :	
		// Dependencies      :   clsMethod, clsAnalysisParameters, clsReportParameters
		//                       clsAnalysisStdParametersCollection, clsAnalysisSampleParametersCollection
		//**********************************************************************

		#Region " Public Properties "

		public clsQuantitativeData this[int index] {
			get { return innerlist.Item(index); }
			set { innerlist.Item(index) = Value; }
		}

		#End Region

		#Region " Public Functions "

		//---Default constructor
		public clsQuantitativeDataCollection()
		{

		}

		//---Copy constructor
		public clsQuantitativeDataCollection(clsQuantitativeDataCollection rhs)
		{
			base.New();
			clsQuantitativeData item;
			foreach ( item in rhs) {
				innerlist.Add(item.Clone());
			}
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the clsQuantitativeDataCollection
		public object System.ICloneable.Clone()
		{
			return new clsQuantitativeDataCollection(this);
		}

		public void System.IDisposable.Dispose()
		{
			innerlist.Clear();
		}

		public void Add(clsQuantitativeData value)
		{
			innerlist.Add(value);
		}

		#End Region

	}

}
