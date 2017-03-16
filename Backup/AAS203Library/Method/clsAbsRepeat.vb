Option Explicit On 

Namespace Method
    <Serializable()> Public Class clsAbsRepeat
        Implements ICloneable

#Region " Public Functions "

        '---Default Constructor
        Public Sub New()
            BasicStat = New clsBasicStat
            AbsRepeatData = New clsAbsRepeatDataCollection
        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As clsAbsRepeat)
            BasicStat = rhs.BasicStat.Clone()
            AbsRepeatData = rhs.AbsRepeatData.Clone()
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the clsAbsRepeat
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsAbsRepeat(Me)
        End Function

#End Region

#Region " Public Variables "

        Public BasicStat As clsBasicStat
        Public AbsRepeatData As clsAbsRepeatDataCollection

#End Region

    End Class

End Namespace

