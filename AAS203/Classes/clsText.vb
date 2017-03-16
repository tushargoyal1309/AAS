Public Class clsText

#Region " Private Variables "

    Private mobjFontName As String
    Private mobjFontColor As Color
    Private mobjFontSize As Integer
    Private mobjFontWeight As String

#End Region

#Region " Public Properties "

    Public Property FontName() As String
        Get
            Return mobjFontName
        End Get
        Set(ByVal Value As String)
            mobjFontName = Value
        End Set
    End Property

    Public Property FontColor() As Color
        Get
            Return mobjFontColor
        End Get
        Set(ByVal Value As Color)
            mobjFontColor = Value
        End Set
    End Property

    Public Property FontSize() As Integer
        Get
            Return mobjFontSize
        End Get
        Set(ByVal Value As Integer)
            mobjFontSize = Value
        End Set
    End Property

    Public Property FontWeight() As String
        Get
            Return mobjFontWeight
        End Get
        Set(ByVal Value As String)
            mobjFontWeight = Value
        End Set
    End Property

#End Region

End Class
