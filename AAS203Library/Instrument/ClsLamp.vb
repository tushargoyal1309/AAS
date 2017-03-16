Namespace Instrument
    <Serializable()> Public Class ClsLamp
        Implements ICloneable

#Region " Public Functions "

        '---Default Constructor
        Public Sub New()
            dblWVZero = 0.0
            LampParametersCollection = New ClsLampParametersCollection
            EMSCondition = New ClsEMSCondition
        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As ClsLamp)
            dblWVZero = rhs.WavelengthZero
            LampParametersCollection = rhs.LampParametersCollection.Clone()
            EMSCondition = rhs.EMSCondition.Clone()
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the ClsLamp
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New ClsLamp(Me)
        End Function

#End Region

#Region " Private Variables "

        Private dblWVZero As Double
        Public LampParametersCollection As ClsLampParametersCollection
        Public EMSCondition As ClsEMSCondition

#End Region

#Region " Public Properties "

        Public Property WavelengthZero() As Double
            Get
                Return dblWVZero
            End Get
            Set(ByVal Value As Double)
                dblWVZero = Value
            End Set
        End Property

#End Region

    End Class
End Namespace

