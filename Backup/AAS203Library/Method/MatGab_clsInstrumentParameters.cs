
namespace Method
{
	[Serializable()]
	public class clsInstrumentParameters : ICloneable
	{

		#Region " Public Functions "

		//---Default Constructor
		public clsInstrumentParameters()
		{
			mstrElementName = "";
			mintElementID = 0;
			mintTurretNumber = 0;
			mintLampNumber = 0;
			mdblLampCurrent = 0.0;
			mobjDtWavelength = new DataTable();
			mdblSlitWidth = 0.0;
			mdblPmtVoltage = 0.0;
			mdblBurnerHeight = 0.0;
			mdblFuelRatio = 0.0;
			mblnIsOptimize = false;
			mintSelectedWavelengthID = 0;
			mintD2Current = 0;
			mintInstMode = 0;
			mdblnInst = 0.0;
		}

		//---Copy Constructor
		public clsInstrumentParameters(clsInstrumentParameters rhs)
		{
			mstrElementName = rhs.ElementName;
			mintElementID = rhs.ElementID;
			mintTurretNumber = rhs.TurretNumber;
			mintLampNumber = rhs.LampNumber;
			mdblLampCurrent = rhs.LampCurrent;
			mobjDtWavelength = rhs.Wavelength.Copy();
			mdblSlitWidth = rhs.SlitWidth;
			mdblPmtVoltage = rhs.PmtVoltage;
			mdblBurnerHeight = rhs.BurnerHeight;
			mdblFuelRatio = rhs.FuelRatio;
			mblnIsOptimize = rhs.IsOptimize;
			mintSelectedWavelengthID = rhs.SelectedWavelengthID;
			mintD2Current = rhs.D2Current;
			mintInstMode = rhs.Inst_Mode;
			mdblnInst = rhs.nInst;
			EmWavelength = rhs.EmmWavelength;
		}

		//---Deep-copy clone routine
		//---Returns a new, independent copy of the clsInstrumentParameters
		public object System.ICloneable.Clone()
		{
			return new clsInstrumentParameters(this);
		}

		#End Region

		#Region " Private Variables "

		private string mstrElementName;
		private int mintElementID;
		private int mintTurretNumber;
		private int mintLampNumber;
		private double mdblLampCurrent;
		private DataTable mobjDtWavelength;
		private double mdblSlitWidth;
		private double mdblExitSlitWidth;
		private double mdblPmtVoltage;
		private double mdblRefPmtVoltage;
		private double mdblBurnerHeight;
		private double mdblFuelRatio;
		private bool mblnIsOptimize;
		private int mintSelectedWavelengthID;
		private int mintD2Current;
		private int mintInstMode;
		private double mdblnInst;

		private double EmWavelength;
		#End Region

		#Region " Public Properties "

		public string ElementName {
			get { ElementName = mstrElementName; }
			set { mstrElementName = Value; }
		}

		public int ElementID {
			get { ElementID = mintElementID; }
			set { mintElementID = Value; }
		}

		public int TurretNumber {
			get { TurretNumber = mintTurretNumber; }
			set { mintTurretNumber = Value; }
		}

		public int LampNumber {
			get { return mintLampNumber; }
			set { mintLampNumber = Value; }
		}

		public double LampCurrent {
			get { LampCurrent = mdblLampCurrent; }
			set { mdblLampCurrent = Value; }
		}

		public int SelectedWavelengthID {
			get { return mintSelectedWavelengthID; }
			set { mintSelectedWavelengthID = Value; }
		}

		public DataTable Wavelength {
			get { Wavelength = mobjDtWavelength; }
			set { mobjDtWavelength = Value; }
		}

		public double SlitWidth {
			get { SlitWidth = mdblSlitWidth; }
			set { mdblSlitWidth = Value; }
		}

		public int D2Current {
			get { return mintD2Current; }
			set { mintD2Current = Value; }
		}

		public double PmtVoltage {
			get { return mdblPmtVoltage; }
			set { mdblPmtVoltage = Value; }
		}

		public double BurnerHeight {
			get { return mdblBurnerHeight; }
			set { mdblBurnerHeight = Value; }
		}

		public double FuelRatio {
			get { return mdblFuelRatio; }
			set { mdblFuelRatio = Value; }
		}

		public bool IsOptimize {
			get { return mblnIsOptimize; }
			set { mblnIsOptimize = Value; }
		}

		public int Inst_Mode {
			get { return mintInstMode; }
			set { mintInstMode = Value; }
		}

		public double nInst {
			get { return mdblnInst; }
			set { mdblnInst = Value; }
		}

		public double RefPmtVoltage {
			get { return mdblRefPmtVoltage; }
			set { mdblRefPmtVoltage = Value; }
		}

		public double EmmWavelength {
			get { EmmWavelength = EmWavelength; }
			set { EmWavelength = Value; }
		}
		public double ExitSlitWidth {
			get { return mdblExitSlitWidth; }
			set { mdblExitSlitWidth = Value; }
		}

		#End Region

	}

}
