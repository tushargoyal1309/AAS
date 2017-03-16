Option Explicit On 

Namespace Signature
    <Serializable()> Public Class DigitalSignature

        Dim mstrUserName As String = ""
        Dim mintUserID As Long = 0
        Dim mstrLoginPassword As String = ""
        Dim mstrFilePassword As String = ""
        Dim mdtSaveDate As DateTime
        Dim mstrFileName As String = ""
        Dim mintActivityType As Integer = 0

        '--- User Name 
        Property UserName() As String
            Get
                Return mstrUserName
            End Get
            Set(ByVal Value As String)
                mstrUserName = Value
            End Set
        End Property

        '--- User ID 
        Property UserID() As Long
            Get
                Return mintUserID
            End Get
            Set(ByVal Value As Long)
                mintUserID = Value
            End Set
        End Property

        '--- User Login Password 
        Property LoginPassword() As String
            Get
                Return mstrLoginPassword
            End Get
            Set(ByVal Value As String)
                mstrLoginPassword = Value
            End Set
        End Property

        '--- File Password 
        Property FilePassword() As String
            Get
                Return mstrFilePassword
            End Get
            Set(ByVal Value As String)
                mstrFilePassword = Value
            End Set
        End Property

        '--- File Save Date and Time
        Property SaveDate() As DateTime
            Get
                Return mdtSaveDate
            End Get
            Set(ByVal Value As DateTime)
                mdtSaveDate = Value
            End Set
        End Property

        '--- File Name
        Property FileName() As String
            Get
                Return mstrFileName
            End Get
            Set(ByVal Value As String)
                mstrFileName = Value
            End Set
        End Property

        '--- Activity Type
        Property ActivityType() As Integer
            Get
                Return mintActivityType
            End Get
            Set(ByVal Value As Integer)
                mintActivityType = Value
            End Set
        End Property

    End Class
End Namespace


