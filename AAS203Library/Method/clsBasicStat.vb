Option Explicit On 

Namespace Method
    <Serializable()> Public Class clsBasicStat
        Implements ICloneable

#Region " Public Function "

        '---Default Constructor
        Public Sub New()
            ReDim TotData(1)
            ReDim ZAvg(1)
            ReDim ZSigma(1)
            ReDim Var(1)
            ReDim CV(1)
            ReDim Min(1)
            ReDim Max(1)
        End Sub

        '---Copy Constructor
        Public Sub New(ByVal rhs As clsBasicStat)
            TotData = rhs.TotData
            ZAvg = rhs.ZAvg
            ZSigma = rhs.ZSigma
            Var = rhs.Var
            CV = rhs.CV
            Min = rhs.Min
            Max = rhs.Max
        End Sub

        '---Deep-copy clone routine
        '---Returns a new, independent copy of the clsBasicStat
        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return New clsBasicStat(Me)
        End Function

#End Region

#Region " Public Variables "

        Public TotData() As Integer
        Public ZAvg() As Double
        Public ZSigma() As Double
        Public Var() As Double
        Public CV() As Double
        Public Min() As Double
        Public Max() As Double

#End Region

    End Class

End Namespace

