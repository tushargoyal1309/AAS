namespace Instrument
{

	[Serializable()]
	public class ClsInstrument : ICloneable
	{

		#Region " Public Functions "

		//---Default Constructor
		public ClsInstrument()
		{
			dblWavelengthCur = 0.0;
			dblCurrent = 0.0;
			dblPmtVoltage = 0.0;
			intD2Pmt = 0;
			intAverage = 0;
			dblEntrySlitPosition = 0.0;
			intLamp_Old = 0;
			intLamp_Position = 0;
			intLamp_Warm = 0;
			intMode = 0;
			intD2Current = 0;
			strElementName = "";
			intTurretPosition = 0;
			intNvStep = 0;
			intBhStep = 0;
			blnAaf = false;
			blnN2of = false;
			blnNa = false;
			blnHydride = false;
			mintInstrumentBeamType = enumInstrumentBeamType.SingleBeam;
			dblReferencePmtVoltage = 0.0;
			dblExitSlitPosition = 0.0;

			Lamp = new ClsLamp();
		}

		//---Copy Constructor
		public ClsInstrument(ClsInstrument rhs)
		{
			dblWavelengthCur = rhs.WavelengthCur;
			dblCurrent = rhs.Current;
			dblPmtVoltage = rhs.PmtVoltage;
			intD2Pmt = rhs.D2Pmt;
			intAverage = rhs.Average;
			dblEntrySlitPosition = rhs.SlitPosition;
			intLamp_Old = rhs.Lamp_Old;
			intLamp_Position = rhs.Lamp_Position;
			intLamp_Warm = rhs.Lamp_Warm;
			intMode = rhs.Mode;
			intD2Current = rhs.D2Current;
			strElementName = rhs.ElementName;
			intTurretPosition = rhs.TurretPosition;
			intNvStep = rhs.NvStep;
			intBhStep = rhs.BhStep;
			blnAaf = rhs.Aaf;
			blnN2of = rhs.N2of;
			blnNa = rhs.Na;
			blnHydride = rhs.Hydride;
			mintInstrumentBeamType = rhs.InstrumentBeamType;
			dblReferencePmtVoltage = rhs.PmtVoltageReference;
			dblExitSlitPosition = rhs.SlitPositionExit;

			Lamp = rhs.Lamp.Clone();
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the ClsInstrument
		public object System.ICloneable.Clone()
		{
			return new ClsInstrument(this);
		}

		#End Region

		#Region " Public Variables "


		public ClsLamp Lamp;
		#End Region

		#Region " Private Variables "

		private double dblWavelengthCur;
		private double dblCurrent;
		private double dblPmtVoltage;
		private int intD2Pmt;
		private int intAverage;
		private double dblEntrySlitPosition;
		private int intLamp_Old;
		private int intLamp_Position;
		private int intLamp_Warm;
		private int intMode;
		private int intD2Current;
		private string strElementName;
		private int intTurretPosition;
		private int intNvStep;
		private int intBhStep;
		private bool blnAaf;
		private bool blnN2of;
		private bool blnNa;
		private bool blnHydride;
		private AAS203Library.Instrument.enumInstrumentBeamType mintInstrumentBeamType;
		private double dblReferencePmtVoltage;

		private double dblExitSlitPosition;
		#End Region

		#Region " Public Properties "

		public double WavelengthCur {
			get { return dblWavelengthCur; }
			set { dblWavelengthCur = Value; }
		}

		public double Current {
			get { return dblCurrent; }
			set { dblCurrent = Value; }
		}

		public double PmtVoltage {
			get { return dblPmtVoltage; }
			set { dblPmtVoltage = Value; }
		}

		public int D2Pmt {
			get { return intD2Pmt; }
			set { intD2Pmt = Value; }
		}

		public int Average {
			get { return intAverage; }
			set { intAverage = Value; }
		}

		//---Return type Changed By Mangesh 
		public double SlitPosition {
			get { return dblEntrySlitPosition; }
			set { dblEntrySlitPosition = Value; }
		}

		public int Lamp_Old {
			get { return intLamp_Old; }
			set { intLamp_Old = Value; }
		}

		public int Lamp_Position {
			get { return intLamp_Position; }
			set { intLamp_Position = Value; }
		}

		public int Lamp_Warm {
			get { return intLamp_Warm; }
			set { intLamp_Warm = Value; }
		}

		public int Mode {
			get { return intMode; }
			set { intMode = Value; }
		}

		public int D2Current {
			get { return intD2Current; }
			set { intD2Current = Value; }
		}

		public string ElementName {
			get { return strElementName; }
			set { strElementName = Value; }
		}

		public int TurretPosition {
			get { return intTurretPosition; }
			set { intTurretPosition = Value; }
		}

		public int NvStep {
			get { return intNvStep; }
			set { intNvStep = Value; }
		}

		public int BhStep {
			get { return intBhStep; }
			set { intBhStep = Value; }
		}

		public bool Aaf {
			get { return blnAaf; }
			set { blnAaf = Value; }
		}

		public bool N2of {
			get { return blnN2of; }
			set { blnN2of = Value; }
		}

		public bool Na {
			get { return blnNa; }
			set { blnNa = Value; }
		}

		public bool Hydride {
			get { return blnHydride; }
			set { blnHydride = Value; }
		}

		public AAS203Library.Instrument.enumInstrumentBeamType InstrumentBeamType {
			get { return mintInstrumentBeamType; }
			set { mintInstrumentBeamType = Value; }
		}

		public double PmtVoltageReference {
			get { return dblReferencePmtVoltage; }
			set { dblReferencePmtVoltage = Value; }
		}

		public double SlitPositionExit {
			get { return dblExitSlitPosition; }
			set { dblExitSlitPosition = Value; }
		}

		#End Region

	}

	public enum enumInstrumentBeamType
	{
		SingleBeam,
		ReferenceBeam,
		DoubleBeam
	}

}



