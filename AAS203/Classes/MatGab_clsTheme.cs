public class clsTheme
{

	#Region " Constants "

	public enum GradientStyles
	{
		Horizontal = 1,
		Vertical = 2,
		ForwardDiagonal = 3,
		BackwardDiagonal = 4,
		None = 5
	}

	#End Region

	#Region " Private Variables "

	private AAS203.clsText objHeading1 = new AAS203.clsText();
	private AAS203.clsText objHeading2 = new AAS203.clsText();
	private AAS203.clsText objHeading3 = new AAS203.clsText();
	private AAS203.clsText objHeading4 = new AAS203.clsText();
	private AAS203.clsText objDesc1 = new AAS203.clsText();

	private AAS203.clsText objDesc2 = new AAS203.clsText();
	private GradientStyles intGradientStyle;
	private Color objScreenBackColor1;
	private Color objScreenBackColor2;
	private Color objButtonBackColor;
	private Color objButtonForeColor;
	private int intButtonTextSize;
	private string strButtonTextStyle;
	private string strButtonTextFont;
	private string strLabelFontName;
	private int intLabelFontSize;
	private Color objLabelForeColor;

	private string strLabelFontStyle;
	#End Region

	#Region " Public Properties "

	public AAS203.clsText Heading1 {
		get { return objHeading1; }
		set { objHeading1 = Value; }
	}

	public AAS203.clsText Heading2 {
		get { return objHeading2; }
		set { objHeading2 = Value; }
	}

	public AAS203.clsText Heading3 {
		get { return objHeading3; }
		set { objHeading3 = Value; }
	}

	public AAS203.clsText Heading4 {
		get { return objHeading4; }
		set { objHeading4 = Value; }
	}

	public AAS203.clsText Description1 {
		get { return objDesc1; }
		set { objDesc1 = Value; }
	}

	public AAS203.clsText Description2 {
		get { return objDesc2; }
		set { objDesc2 = Value; }
	}

	public GradientStyles Screen_Gradient_Style {
		get { return intGradientStyle; }
		set { intGradientStyle = Value; }
	}

	public Color Screen_BackColor1 {
		get { return objScreenBackColor1; }
		set { objScreenBackColor1 = Value; }
	}

	public Color Screen_BackColor2 {
		get { return objScreenBackColor2; }
		set { objScreenBackColor2 = Value; }
	}

	public Color Button_BackColor {
		get { return objButtonBackColor; }
		set { objButtonBackColor = Value; }
	}

	public Color Button_ForeColor {
		get { return objButtonForeColor; }
		set { objButtonForeColor = Value; }
	}

	public int Button_TextSize {
		get { return intButtonTextSize; }
		set { intButtonTextSize = Value; }
	}

	public string Button_TextStyle {
		get { return strButtonTextStyle; }
		set { strButtonTextStyle = Value; }
	}

	public string Button_TextFont {
		get { return strButtonTextFont; }
		set { strButtonTextFont = Value; }
	}

	public Color Label_ForeColor {
		get { return objLabelForeColor; }
		set { objLabelForeColor = Value; }
	}

	public int Label_FontSize {
		get { return intLabelFontSize; }
		set { intLabelFontSize = Value; }
	}

	public string Label_FontName {
		get { return strLabelFontName; }
		set { strLabelFontName = Value; }
	}

	public string Label_FontStyle {
		get { return strLabelFontStyle; }
		set { strLabelFontStyle = Value; }
	}

	#End Region

}
