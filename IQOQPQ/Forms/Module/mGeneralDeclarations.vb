Option Explicit On 

Imports System.Data.OleDb
Imports DataObject

Public Module mGeneralDeclarations

    Public ObjApp As Application
    Public gobjErrorHandler As New ErrorHandler.ErrorHandler
    Public gobjDataSet As New dtsetExportAll 'DataSet
    ''Public gobjDataSet1 As dtsetExportAll1 'DataSet
    Public gobjfrmMdi As New frmMDI
    Public gobjDataAccess As IQOQPQ.clsDataAccessLayer
    Public gobjMessageAdapter As New clsMessageAdapter
    Public gobjModelNo As String = ""

End Module
