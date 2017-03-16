Imports System
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class ActiveReport1
Inherits ActiveReport
	Public Sub New()
	MyBase.New()
		InitializeReport()
	End Sub
	#Region "ActiveReports Designer generated code"
    Private WithEvents ReportHeader As ReportHeader = Nothing
    Private WithEvents PageHeader As PageHeader = Nothing
    Private WithEvents Detail As Detail = Nothing
    Private WithEvents PageFooter As PageFooter = Nothing
    Private WithEvents ReportFooter As ReportFooter = Nothing
	Private pictLogo As Picture = Nothing
	Private lblReportHeader As Label = Nothing
	Private lblReportHeader2 As Label = Nothing
	Private lblReportHeader3 As Label = Nothing
	Private lblReportHeader4 As Label = Nothing
	Private ReportHeaderLine As Line = Nothing
	Private lblPageHeader As Label = Nothing
	Private lblName As Label = Nothing
	Private lblID As Label = Nothing
	Private lblPageFooter As Label = Nothing
	Private lblPageNo As Label = Nothing
	Private PageFooterLine As Line = Nothing
	Private lblReportFooter As Label = Nothing
	Private ReportFooterLine As Line = Nothing
	Public Sub InitializeReport()
		Me.LoadLayout(Me.GetType, "AAS203.ActiveReport1.rpx")
		Me.ReportHeader = CType(Me.Sections("ReportHeader"),DataDynamics.ActiveReports.ReportHeader)
		Me.PageHeader = CType(Me.Sections("PageHeader"),DataDynamics.ActiveReports.PageHeader)
		Me.Detail = CType(Me.Sections("Detail"),DataDynamics.ActiveReports.Detail)
		Me.PageFooter = CType(Me.Sections("PageFooter"),DataDynamics.ActiveReports.PageFooter)
		Me.ReportFooter = CType(Me.Sections("ReportFooter"),DataDynamics.ActiveReports.ReportFooter)
		Me.pictLogo = CType(Me.ReportHeader.Controls(0),DataDynamics.ActiveReports.Picture)
		Me.lblReportHeader = CType(Me.ReportHeader.Controls(1),DataDynamics.ActiveReports.Label)
		Me.lblReportHeader2 = CType(Me.ReportHeader.Controls(2),DataDynamics.ActiveReports.Label)
		Me.lblReportHeader3 = CType(Me.ReportHeader.Controls(3),DataDynamics.ActiveReports.Label)
		Me.lblReportHeader4 = CType(Me.ReportHeader.Controls(4),DataDynamics.ActiveReports.Label)
		Me.ReportHeaderLine = CType(Me.ReportHeader.Controls(5),DataDynamics.ActiveReports.Line)
		Me.lblPageHeader = CType(Me.PageHeader.Controls(0),DataDynamics.ActiveReports.Label)
		Me.lblName = CType(Me.Detail.Controls(0),DataDynamics.ActiveReports.Label)
		Me.lblID = CType(Me.Detail.Controls(1),DataDynamics.ActiveReports.Label)
		Me.lblPageFooter = CType(Me.PageFooter.Controls(0),DataDynamics.ActiveReports.Label)
		Me.lblPageNo = CType(Me.PageFooter.Controls(1),DataDynamics.ActiveReports.Label)
		Me.PageFooterLine = CType(Me.PageFooter.Controls(2),DataDynamics.ActiveReports.Line)
		Me.lblReportFooter = CType(Me.ReportFooter.Controls(0),DataDynamics.ActiveReports.Label)
		Me.ReportFooterLine = CType(Me.ReportFooter.Controls(1),DataDynamics.ActiveReports.Line)
	End Sub

	#End Region

    Private Sub Detail_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail.Format

    End Sub
End Class
