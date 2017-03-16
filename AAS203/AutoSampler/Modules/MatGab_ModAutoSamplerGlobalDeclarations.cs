class ModAutoSamplerGlobalDeclarations
{

	#Region "global values Declared"

	public structAutoSampler gstructAutoSampler;
	//declared for maintaining the current position
	public structAutoSamplerPosition gstructAutoSamplerPosition;
		#End Region
	public int gintCommPortSelected2;

	#Region "Structures"


	//Used only for maintaining the current positions in the grid
	//of form frmAutoSampler position

	public struct structAutoSampler
	{
		ArrayList arrAutoSamplerPosition;
		int intBaudRate;
		int intComPort;
		int intCoordinateX;
		int intCoordinateY;
		int intIntakeTime;
		int intWashTime;
		int intWaitingTime;
		int intProbeTime;
			//Global Variable Used While Starting AutoSampler gfuncAutoSamplerStartStatus
		int intPosition;
		bool blnCommunication;
		bool blnAutoSamplerInitialised;
		bool blnHome;
		bool blnPump;
		bool blnProbe;
		bool blnPumpPrev;
	}

	public struct structAutoSamplerPosition
	{
		int intSpectrumPosition;
		int intPhotometryPosition;
		int intQuantPosition;
		int intMultiPosition;
		int intKineticPosition;
		int intTimeScanPosition;
	}

	#End Region

}
