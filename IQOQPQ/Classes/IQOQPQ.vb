Option Explicit On 
Namespace IQOQPQ

    Public Class IQOQPQ

        Public Enum enumView
            TreeView = 1
            ListView = 2
        End Enum

        Private mblnOpenLock As Boolean
        Private mblnSetLock As Boolean
        Private mSetView As enumView
        Private mblnShowColumnHeaders As Boolean
        Private mintDataGridColumnWidth As Integer

        Private WithEvents objfrmMDI As frmMDI
        Public Event Test_IQOQPQ_Attachment1(ByRef dtParameters As DataTable, ByVal intCounter As Integer)  'Saurabh  04.07.07
        Public Event Test_IQOQPQ_AttachmentII(ByRef dtParameters As DataTable, ByVal intCounter As Integer)  'Saurabh  07.07.07
        Public Event Test_IQOQPQ_AttachmentIII(ByRef dtParameters As DataTable, ByVal intCounter As Integer)  'Saurabh  09.07.07
        Public Event InstrumentType(ByRef strInstrumentType As String)

#Region "Methods"

        Public Function ShowIQOQPQ(ByVal strDatabasePathIn As String, ByVal strDatabaseProvideIn As String, ByVal strDatabaseName As String, ByVal strUserNameIn As String, ByVal strPassWord As String) As Boolean

            Try
                gobjDataAccess = New clsDataAccessLayer(strDatabasePathIn, strDatabaseProvideIn, strDatabaseName, strUserNameIn, strPassWord)

                '************Saurabh 04.07.07**************
                'Dim objfrmMDI As New frmMDI
                objfrmMDI = New frmMDI
                AddHandler objfrmMDI.Test_IQOQPQ_Attachment1, AddressOf EventRaiseForTest_Attachment1
                AddHandler objfrmMDI.Test_IQOQPQ_AttachmentII, AddressOf EventRaiseForTest_AttachmentII
                AddHandler objfrmMDI.Test_IQOQPQ_AttachmentIII, AddressOf EventRaiseForTest_AttachmentIII
                AddHandler objfrmMDI.InstrumentType, AddressOf EventRaiseForInstrumentType
                '************Saurabh 04.07.07**************

                objfrmMDI.ShowDialog()
                Return True
            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                Return False
            Finally

            End Try
        End Function

#End Region

#Region "Properties"

        Public Property OpenLock() As Boolean
            Get
                Return mblnOpenLock
            End Get
            Set(ByVal Value As Boolean)
                mblnOpenLock = Value
            End Set
        End Property

        Public Property SetLock() As Boolean
            Get
                Return mblnSetLock
            End Get
            Set(ByVal Value As Boolean)
                mblnSetLock = Value
            End Set
        End Property

        Public Property SetView() As enumView
            Get
                Return mSetView
            End Get
            Set(ByVal Value As enumView)
                mSetView = Value
            End Set
        End Property

        Public Property ShowColumnHeaders() As Boolean
            Get
                Return mblnShowColumnHeaders
            End Get
            Set(ByVal Value As Boolean)
                mblnShowColumnHeaders = Value
            End Set
        End Property

        Public Property DataGridColumnWidth() As Integer
            Get
                Return mintDataGridColumnWidth
            End Get
            Set(ByVal Value As Integer)
                mintDataGridColumnWidth = Value
            End Set
        End Property

#End Region

        Private Sub EventRaiseForTest_Attachment1(ByRef dtParameters As DataTable, ByVal intCounter As Integer)
            Try
                'MessageBox.Show("hi")
                RaiseEvent Test_IQOQPQ_Attachment1(dtParameters, intCounter)

            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                If CONST_CREATE_EXECUTION_LOG = 1 Then
                    gobjErrorHandler.WriteExecutionLog()
                End If
                'objWait.Dispose()
                '---------------------------------------------------------
            End Try
        End Sub

        Private Sub EventRaiseForTest_AttachmentII(ByRef dtParameters As DataTable, ByVal intCounter As Integer)
            Try
                'MessageBox.Show("hi")
                RaiseEvent Test_IQOQPQ_AttachmentII(dtParameters, intCounter)

            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                If CONST_CREATE_EXECUTION_LOG = 1 Then
                    gobjErrorHandler.WriteExecutionLog()
                End If
                'objWait.Dispose()
                '---------------------------------------------------------
            End Try
        End Sub

        Private Sub EventRaiseForTest_AttachmentIII(ByRef dtParameters As DataTable, ByVal intCounter As Integer)
            Try
                'MessageBox.Show("hi")
                RaiseEvent Test_IQOQPQ_AttachmentIII(dtParameters, intCounter)

            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                If CONST_CREATE_EXECUTION_LOG = 1 Then
                    gobjErrorHandler.WriteExecutionLog()
                End If
                'objWait.Dispose()
                '---------------------------------------------------------
            End Try
        End Sub

        Private Sub EventRaiseForInstrumentType(ByRef strInstrumentType As String)
            RaiseEvent InstrumentType(strInstrumentType)
        End Sub

    End Class

End Namespace