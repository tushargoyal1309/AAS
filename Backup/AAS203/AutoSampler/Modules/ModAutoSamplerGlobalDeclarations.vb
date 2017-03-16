Module ModAutoSamplerGlobalDeclarations

#Region "global values Declared"
    Public gstructAutoSampler As structAutoSampler

    'declared for maintaining the current position
    Public gstructAutoSamplerPosition As structAutoSamplerPosition
    Public gintCommPortSelected2 As Integer
#End Region

#Region "Structures"


    'Used only for maintaining the current positions in the grid
    'of form frmAutoSampler position

    Public Structure structAutoSampler
        Dim arrAutoSamplerPosition As ArrayList
        Dim intBaudRate As Integer
        Dim intComPort As Integer
        Dim intCoordinateX As Integer
        Dim intCoordinateY As Integer
        Dim intIntakeTime As Integer
        Dim intWashTime As Integer
        Dim intWaitingTime As Integer
        Dim intProbeTime As Integer
        Dim intPosition As Integer 'Global Variable Used While Starting AutoSampler gfuncAutoSamplerStartStatus
        Dim blnCommunication As Boolean
        Dim blnAutoSamplerInitialised As Boolean
        Dim blnHome As Boolean
        Dim blnPump As Boolean
        Dim blnProbe As Boolean
        Dim blnPumpPrev As Boolean
    End Structure

    Public Structure structAutoSamplerPosition
        Dim intSpectrumPosition As Integer
        Dim intPhotometryPosition As Integer
        Dim intQuantPosition As Integer
        Dim intMultiPosition As Integer
        Dim intKineticPosition As Integer
        Dim intTimeScanPosition As Integer
    End Structure

#End Region

End Module
