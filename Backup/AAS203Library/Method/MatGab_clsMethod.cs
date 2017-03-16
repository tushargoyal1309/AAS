
namespace Method
{
	[Serializable()]
	public class clsMethod : ICloneable
	{

		#Region " Private Variables "

		private int intMethodId;
		private string strMethodName;
		private int intOperationMode;
		private bool blnStandardAddition;
		private string strUserName;
		private string strComments;
		private DateTime CreationDate;
		private DateTime ModificationDate;
		private DateTime LastUseDate;

		private bool blnStatus;

		private clsInstrumentParameters mobjInstrumentCondition = new clsInstrumentParameters();

		private int mintSelectedElementID = 0;

		private clsQuantitativeDataCollection mobjQuantitativeDataCollection = new clsQuantitativeDataCollection();

		private AAS203Library.Instrument.enumInstrumentBeamType mintInstrumentBeamType;

		private clsAnalysisStdParametersCollection mobjStandardData = new clsAnalysisStdParametersCollection();

		private clsAnalysisSampleParametersCollection mobjSampleData;
		private clsReportParameters mobjReportParameters;

		private clsAnalysisParameters mobjAnalysisParameters;
		#End Region

		#Region " Public Variables "

		#End Region

		#Region " Public Properties "

		public int MethodID {
			get { return intMethodId; }
			set { intMethodId = Value; }
		}

		public int SelectedElementID {
			get { return mintSelectedElementID; }
			set { mintSelectedElementID = Value; }
		}

		public string MethodName {
			get { MethodName = strMethodName; }
			set { strMethodName = Value; }
		}

		public string UserName {
			get { UserName = strUserName; }
			set { strUserName = Value; }
		}

		public string Comments {
			get { Comments = strComments; }
			set { strComments = Value; }
		}

		public int OperationMode {
			get { OperationMode = intOperationMode; }
			set { intOperationMode = Value; }
		}

		public DateTime DateOfCreation {
			get { return CreationDate; }
			set { CreationDate = Value; }
		}

		public DateTime DateOfModification {
			get { return ModificationDate; }
			set { ModificationDate = Value; }
		}

		public DateTime DateOfLastUse {
			get { return LastUseDate; }
			set { LastUseDate = Value; }
		}

		public bool Status {
			get { return blnStatus; }
			set { blnStatus = Value; }
		}

		public bool StandardAddition {
			get { StandardAddition = blnStandardAddition; }
			set { blnStandardAddition = Value; }
		}

		//Public Property InstrumentConditions() As clsInstrumentParametersCollection
		//    Get
		//        Return mobjInstrumentConditions
		//    End Get
		//    Set(ByVal Value As clsInstrumentParametersCollection)
		//        mobjInstrumentConditions = New clsInstrumentParametersCollection
		//        mobjInstrumentConditions = Value
		//    End Set
		//End Property

		public clsInstrumentParameters InstrumentCondition {
			get { return mobjInstrumentCondition; }
			set { mobjInstrumentCondition = Value; }
		}

		public clsAnalysisParameters AnalysisParameters {
			get { return mobjAnalysisParameters; }
			set { mobjAnalysisParameters = Value; }
		}

		public clsReportParameters ReportParameters {
			get { return mobjReportParameters; }
			set { mobjReportParameters = Value; }
		}

		public clsAnalysisStdParametersCollection StandardDataCollection {
			get { return mobjStandardData; }
			set { mobjStandardData = Value; }
		}

		public clsAnalysisSampleParametersCollection SampleDataCollection {
			get { return mobjSampleData; }
			set { mobjSampleData = Value; }
		}

		public clsQuantitativeDataCollection QuantitativeDataCollection {
			get { return mobjQuantitativeDataCollection; }
			set { mobjQuantitativeDataCollection = Value; }
		}

		public AAS203Library.Instrument.enumInstrumentBeamType InstrumentBeamType {
			get { return mintInstrumentBeamType; }
			set { mintInstrumentBeamType = Value; }
		}

		#End Region

		#Region " Public functions "

		//---Default constructor
		public clsMethod()
		{
			intMethodId = 0;
			strMethodName = "";
			intOperationMode = 0;
			blnStandardAddition = false;
			strUserName = "";
			strComments = "";
			CreationDate = Now;
			ModificationDate = Now;
			LastUseDate = Now;
			blnStatus = false;
			mintSelectedElementID = 0;
			mobjInstrumentCondition = new clsInstrumentParameters();
			mintInstrumentBeamType = Instrument.enumInstrumentBeamType.SingleBeam;
			mobjQuantitativeDataCollection = new clsQuantitativeDataCollection();
		}

		//---Copy constructor
		public clsMethod(clsMethod rhs)
		{
			try {
				intMethodId = rhs.MethodID;
				strMethodName = rhs.MethodName;
				intOperationMode = rhs.OperationMode;
				blnStandardAddition = rhs.StandardAddition;
				strUserName = rhs.UserName;
				strComments = rhs.Comments;
				CreationDate = rhs.DateOfCreation;
				ModificationDate = rhs.DateOfModification;
				LastUseDate = rhs.DateOfLastUse;
				blnStatus = rhs.Status;
				mintSelectedElementID = rhs.SelectedElementID;
				mintInstrumentBeamType = rhs.InstrumentBeamType;

				if (!rhs.InstrumentCondition == null) {
					mobjInstrumentCondition = rhs.InstrumentCondition.Clone();
				}

				if (!rhs.QuantitativeDataCollection == null) {
					mobjQuantitativeDataCollection = rhs.QuantitativeDataCollection.Clone();
				}

				if (!rhs.AnalysisParameters == null) {
					mobjAnalysisParameters = rhs.AnalysisParameters.Clone;
				}

				if (!rhs.ReportParameters == null) {
					mobjReportParameters = rhs.ReportParameters.Clone;
				}

				if (!rhs.StandardDataCollection == null) {
					mobjStandardData = rhs.StandardDataCollection.Clone;
				}

				if (!rhs.SampleDataCollection == null) {
					mobjSampleData = rhs.SampleDataCollection.Clone;
				}
			} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			//gobjErrorHandler.ErrorDescription = ex.Message
			//gobjErrorHandler.ErrorMessage = ex.Message
			//gobjErrorHandler.WriteErrorLog(ex)
			//---------------------------------------------------------
			} finally {
				//---------------------------------------------------------
				//Writing Execution log
				//If CONST_CREATE_EXECUTION_LOG = 1 Then
				//    gobjErrorHandler.WriteExecutionLog()
				//End If
				//If Not objWait Is Nothing Then
				//    objWait.Dispose()
				//End If
				//---------------------------------------------------------
			}
		}

		public object System.ICloneable.Clone()
		{
			return new clsMethod(this);
		}

		#End Region

	}

}
