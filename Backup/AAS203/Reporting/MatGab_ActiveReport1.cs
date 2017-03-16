using System;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

public class ActiveReport1 : ActiveReport
{
	public ActiveReport1()
	{
		base.New();
		InitializeReport();
	}
	#Region "ActiveReports Designer generated code"
	private ReportHeader ReportHeader = null;
	private PageHeader PageHeader = null;
	private Detail Detail = null;
	private PageFooter PageFooter = null;
	private ReportFooter ReportFooter = null;
	private Picture pictLogo = null;
	private Label lblReportHeader = null;
	private Label lblReportHeader2 = null;
	private Label lblReportHeader3 = null;
	private Label lblReportHeader4 = null;
	private Line ReportHeaderLine = null;
	private Label lblPageHeader = null;
	private Label lblName = null;
	private Label lblID = null;
	private Label lblPageFooter = null;
	private Label lblPageNo = null;
	private Line PageFooterLine = null;
	private Label lblReportFooter = null;
	private Line ReportFooterLine = null;
	public void InitializeReport()
	{
		this.LoadLayout(this.GetType, "AAS203.ActiveReport1.rpx");
		this.ReportHeader = (DataDynamics.ActiveReports.ReportHeader)this.Sections("ReportHeader");
		this.PageHeader = (DataDynamics.ActiveReports.PageHeader)this.Sections("PageHeader");
		this.Detail = (DataDynamics.ActiveReports.Detail)this.Sections("Detail");
		this.PageFooter = (DataDynamics.ActiveReports.PageFooter)this.Sections("PageFooter");
		this.ReportFooter = (DataDynamics.ActiveReports.ReportFooter)this.Sections("ReportFooter");
		this.pictLogo = (DataDynamics.ActiveReports.Picture)this.ReportHeader.Controls(0);
		this.lblReportHeader = (DataDynamics.ActiveReports.Label)this.ReportHeader.Controls(1);
		this.lblReportHeader2 = (DataDynamics.ActiveReports.Label)this.ReportHeader.Controls(2);
		this.lblReportHeader3 = (DataDynamics.ActiveReports.Label)this.ReportHeader.Controls(3);
		this.lblReportHeader4 = (DataDynamics.ActiveReports.Label)this.ReportHeader.Controls(4);
		this.ReportHeaderLine = (DataDynamics.ActiveReports.Line)this.ReportHeader.Controls(5);
		this.lblPageHeader = (DataDynamics.ActiveReports.Label)this.PageHeader.Controls(0);
		this.lblName = (DataDynamics.ActiveReports.Label)this.Detail.Controls(0);
		this.lblID = (DataDynamics.ActiveReports.Label)this.Detail.Controls(1);
		this.lblPageFooter = (DataDynamics.ActiveReports.Label)this.PageFooter.Controls(0);
		this.lblPageNo = (DataDynamics.ActiveReports.Label)this.PageFooter.Controls(1);
		this.PageFooterLine = (DataDynamics.ActiveReports.Line)this.PageFooter.Controls(2);
		this.lblReportFooter = (DataDynamics.ActiveReports.Label)this.ReportFooter.Controls(0);
		this.ReportFooterLine = (DataDynamics.ActiveReports.Line)this.ReportFooter.Controls(1);
	}

	#End Region


	private void  // ERROR: Handles clauses are not supported in C#
Detail_Format(object sender, System.EventArgs e)
	{
	}
}
