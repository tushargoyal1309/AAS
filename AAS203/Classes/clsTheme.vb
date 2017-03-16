Public Class clsTheme

#Region " Constants "

    Public Enum GradientStyles
        Horizontal = 1
        Vertical = 2
        ForwardDiagonal = 3
        BackwardDiagonal = 4
        None = 5
    End Enum

#End Region

#Region " Private Variables "

    Private objHeading1 As New AAS203.clsText
    Private objHeading2 As New AAS203.clsText
    Private objHeading3 As New AAS203.clsText
    Private objHeading4 As New AAS203.clsText
    Private objDesc1 As New AAS203.clsText
    Private objDesc2 As New AAS203.clsText

    Private intGradientStyle As GradientStyles
    Private objScreenBackColor1 As Color
    Private objScreenBackColor2 As Color
    Private objButtonBackColor As Color
    Private objButtonForeColor As Color
    Private intButtonTextSize As Integer
    Private strButtonTextStyle As String
    Private strButtonTextFont As String
    Private strLabelFontName As String
    Private intLabelFontSize As Integer
    Private objLabelForeColor As Color
    Private strLabelFontStyle As String

#End Region

#Region " Public Properties "

    Public Property Heading1() As AAS203.clsText
        Get
            Return objHeading1
        End Get
        Set(ByVal Value As AAS203.clsText)
            objHeading1 = Value
        End Set
    End Property

    Public Property Heading2() As AAS203.clsText
        Get
            Return objHeading2
        End Get
        Set(ByVal Value As AAS203.clsText)
            objHeading2 = Value
        End Set
    End Property

    Public Property Heading3() As AAS203.clsText
        Get
            Return objHeading3
        End Get
        Set(ByVal Value As AAS203.clsText)
            objHeading3 = Value
        End Set
    End Property

    Public Property Heading4() As AAS203.clsText
        Get
            Return objHeading4
        End Get
        Set(ByVal Value As AAS203.clsText)
            objHeading4 = Value
        End Set
    End Property

    Public Property Description1() As AAS203.clsText
        Get
            Return objDesc1
        End Get
        Set(ByVal Value As AAS203.clsText)
            objDesc1 = Value
        End Set
    End Property

    Public Property Description2() As AAS203.clsText
        Get
            Return objDesc2
        End Get
        Set(ByVal Value As AAS203.clsText)
            objDesc2 = Value
        End Set
    End Property

    Public Property Screen_Gradient_Style() As GradientStyles
        Get
            Return intGradientStyle
        End Get
        Set(ByVal Value As GradientStyles)
            intGradientStyle = Value
        End Set
    End Property

    Public Property Screen_BackColor1() As Color
        Get
            Return objScreenBackColor1
        End Get
        Set(ByVal Value As Color)
            objScreenBackColor1 = Value
        End Set
    End Property

    Public Property Screen_BackColor2() As Color
        Get
            Return objScreenBackColor2
        End Get
        Set(ByVal Value As Color)
            objScreenBackColor2 = Value
        End Set
    End Property

    Public Property Button_BackColor() As Color
        Get
            Return objButtonBackColor
        End Get
        Set(ByVal Value As Color)
            objButtonBackColor = Value
        End Set
    End Property

    Public Property Button_ForeColor() As Color
        Get
            Return objButtonForeColor
        End Get
        Set(ByVal Value As Color)
            objButtonForeColor = Value
        End Set
    End Property

    Public Property Button_TextSize() As Integer
        Get
            Return intButtonTextSize
        End Get
        Set(ByVal Value As Integer)
            intButtonTextSize = Value
        End Set
    End Property

    Public Property Button_TextStyle() As String
        Get
            Return strButtonTextStyle
        End Get
        Set(ByVal Value As String)
            strButtonTextStyle = Value
        End Set
    End Property

    Public Property Button_TextFont() As String
        Get
            Return strButtonTextFont
        End Get
        Set(ByVal Value As String)
            strButtonTextFont = Value
        End Set
    End Property

    Public Property Label_ForeColor() As Color
        Get
            Return objLabelForeColor
        End Get
        Set(ByVal Value As Color)
            objLabelForeColor = Value
        End Set
    End Property

    Public Property Label_FontSize() As Integer
        Get
            Return intLabelFontSize
        End Get
        Set(ByVal Value As Integer)
            intLabelFontSize = Value
        End Set
    End Property

    Public Property Label_FontName() As String
        Get
            Return strLabelFontName
        End Get
        Set(ByVal Value As String)
            strLabelFontName = Value
        End Set
    End Property

    Public Property Label_FontStyle() As String
        Get
            Return strLabelFontStyle
        End Get
        Set(ByVal Value As String)
            strLabelFontStyle = Value
        End Set
    End Property

#End Region

End Class
