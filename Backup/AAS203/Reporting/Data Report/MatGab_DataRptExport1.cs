//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------


 // ERROR: Not supported in C#: OptionDeclaration
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System;
using System.ComponentModel;


public class DataRptExport : ReportClass
{

	public DataRptExport()
	{
		base.New();
	}

	public override string ResourceName {
		get { return "DataRptExport.rpt"; }
			//Do nothing
		set { }
	}

	[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
	public CrystalDecisions.CrystalReports.Engine.Section Section1 {
		get { return this.ReportDefinition.Sections(0); }
	}

	[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
	public CrystalDecisions.CrystalReports.Engine.Section Section14 {
		get { return this.ReportDefinition.Sections(1); }
	}

	[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
	public CrystalDecisions.CrystalReports.Engine.Section Section15 {
		get { return this.ReportDefinition.Sections(2); }
	}

	[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
	public CrystalDecisions.CrystalReports.Engine.Section Section16 {
		get { return this.ReportDefinition.Sections(3); }
	}

	[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
	public CrystalDecisions.CrystalReports.Engine.Section Section18 {
		get { return this.ReportDefinition.Sections(4); }
	}

	[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
	public CrystalDecisions.CrystalReports.Engine.Section Section19 {
		get { return this.ReportDefinition.Sections(5); }
	}

	[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
	public CrystalDecisions.CrystalReports.Engine.Section Section20 {
		get { return this.ReportDefinition.Sections(6); }
	}

	[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
	public CrystalDecisions.CrystalReports.Engine.Section Section10 {
		get { return this.ReportDefinition.Sections(7); }
	}

	[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
	public CrystalDecisions.CrystalReports.Engine.Section Section3 {
		get { return this.ReportDefinition.Sections(8); }
	}

	[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
	public CrystalDecisions.CrystalReports.Engine.Section Section4 {
		get { return this.ReportDefinition.Sections(9); }
	}

	[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
	public CrystalDecisions.CrystalReports.Engine.Section Section13 {
		get { return this.ReportDefinition.Sections(10); }
	}

	[Browsable(false), DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
	public CrystalDecisions.CrystalReports.Engine.Section Section5 {
		get { return this.ReportDefinition.Sections(11); }
	}
}

[System.Drawing.ToolboxBitmapAttribute(typeof(CrystalDecisions.Shared.ExportOptions), "report.bmp")]
public class CachedDataRptExport : Component, ICachedReport
{

	public CachedDataRptExport()
	{
		base.New();
	}

	public virtual bool CrystalDecisions.ReportSource.ICachedReport.IsCacheable {
		get { return true; }
			//
		set { }
	}

	public virtual bool CrystalDecisions.ReportSource.ICachedReport.ShareDBLogonInfo {
		get { return false; }
			//
		set { }
	}

	public virtual System.TimeSpan CrystalDecisions.ReportSource.ICachedReport.CacheTimeOut {
		get { return CachedReportConstants.DEFAULT_TIMEOUT; }
			//
		set { }
	}

	public virtual CrystalDecisions.CrystalReports.Engine.ReportDocument CrystalDecisions.ReportSource.ICachedReport.CreateReport()
	{
		DataRptExport rpt = new DataRptExport();
		rpt.Site = this.Site;
		return rpt;
	}

	public virtual string CrystalDecisions.ReportSource.ICachedReport.GetCustomizedCacheKey(RequestContext request)
	{
		String key = null;
		//// The following is the code used to generate the default
		//// cache key for caching report jobs in the ASP.NET Cache.
		//// Feel free to modify this code to suit your needs.
		//// Returning key == null causes the default cache key to
		//// be generated.
		//
		//key = RequestContext.BuildCompleteCacheKey(
		//    request,
		//    null,       // sReportFilename
		//    this.GetType(),
		//    this.ShareDBLogonInfo );
		return key;
	}
}
