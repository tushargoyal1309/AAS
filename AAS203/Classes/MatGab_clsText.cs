public class clsText
{

	#Region " Private Variables "

	private string mobjFontName;
	private Color mobjFontColor;
	private int mobjFontSize;

	private string mobjFontWeight;
	#End Region

	#Region " Public Properties "

	public string FontName {
		get { return mobjFontName; }
		set { mobjFontName = Value; }
	}

	public Color FontColor {
		get { return mobjFontColor; }
		set { mobjFontColor = Value; }
	}

	public int FontSize {
		get { return mobjFontSize; }
		set { mobjFontSize = Value; }
	}

	public string FontWeight {
		get { return mobjFontWeight; }
		set { mobjFontWeight = Value; }
	}

	#End Region

}
