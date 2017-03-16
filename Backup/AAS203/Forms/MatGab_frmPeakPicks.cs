public class frmPeakPicks : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public frmPeakPicks()
	{
		base.New();

		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

	}

	//Form overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing)
	{
		if (disposing) {
			if (!(components == null)) {
				components.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	//Required by the Windows Form Designer

	private System.ComponentModel.IContainer components;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.
	internal GradientPanel.CustomPanel CustomPanel1;
	internal GradientPanel.CustomPanel CustomPanelPeakPick;
	internal System.Windows.Forms.DataGrid dgPeakPick;
	internal GradientPanel.CustomPanel CustomPanelPeak_Ref;
	internal System.Windows.Forms.DataGrid dgPeakPick_Ref;
	internal GradientPanel.CustomPanel CustomPanelButtons;
	internal NETXP.Controls.XPButton btnClose;
	internal NETXP.Controls.XPButton btnPrintWithSpectrum;
	internal NETXP.Controls.XPButton btnPrintWOSpectrum;
	internal System.Windows.Forms.Label lblSampleBeam;
	internal System.Windows.Forms.Label lblRefBeam;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPeakPicks));
		this.CustomPanel1 = new GradientPanel.CustomPanel();
		this.CustomPanelButtons = new GradientPanel.CustomPanel();
		this.btnClose = new NETXP.Controls.XPButton();
		this.btnPrintWithSpectrum = new NETXP.Controls.XPButton();
		this.btnPrintWOSpectrum = new NETXP.Controls.XPButton();
		this.CustomPanelPeak_Ref = new GradientPanel.CustomPanel();
		this.lblRefBeam = new System.Windows.Forms.Label();
		this.dgPeakPick_Ref = new System.Windows.Forms.DataGrid();
		this.CustomPanelPeakPick = new GradientPanel.CustomPanel();
		this.lblSampleBeam = new System.Windows.Forms.Label();
		this.dgPeakPick = new System.Windows.Forms.DataGrid();
		this.CustomPanel1.SuspendLayout();
		this.CustomPanelButtons.SuspendLayout();
		this.CustomPanelPeak_Ref.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgPeakPick_Ref).BeginInit();
		this.CustomPanelPeakPick.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgPeakPick).BeginInit();
		this.SuspendLayout();
		//
		//CustomPanel1
		//
		this.CustomPanel1.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanel1.Controls.Add(this.CustomPanelButtons);
		this.CustomPanel1.Controls.Add(this.CustomPanelPeak_Ref);
		this.CustomPanel1.Controls.Add(this.CustomPanelPeakPick);
		this.CustomPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanel1.Location = new System.Drawing.Point(0, 0);
		this.CustomPanel1.Name = "CustomPanel1";
		this.CustomPanel1.Size = new System.Drawing.Size(648, 383);
		this.CustomPanel1.TabIndex = 0;
		//
		//CustomPanelButtons
		//
		this.CustomPanelButtons.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelButtons.Controls.Add(this.btnClose);
		this.CustomPanelButtons.Controls.Add(this.btnPrintWithSpectrum);
		this.CustomPanelButtons.Controls.Add(this.btnPrintWOSpectrum);
		this.CustomPanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.CustomPanelButtons.Location = new System.Drawing.Point(0, 319);
		this.CustomPanelButtons.Name = "CustomPanelButtons";
		this.CustomPanelButtons.Size = new System.Drawing.Size(648, 64);
		this.CustomPanelButtons.TabIndex = 7;
		//
		//btnClose
		//
		this.btnClose.DialogResult = System.Windows.Forms.DialogResult.No;
		this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnClose.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnClose.Location = new System.Drawing.Point(421, 15);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(110, 38);
		this.btnClose.TabIndex = 6;
		this.btnClose.Text = "&Close";
		//
		//btnPrintWithSpectrum
		//
		this.btnPrintWithSpectrum.DialogResult = System.Windows.Forms.DialogResult.Yes;
		this.btnPrintWithSpectrum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPrintWithSpectrum.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnPrintWithSpectrum.Image = (System.Drawing.Image)resources.GetObject("btnPrintWithSpectrum.Image");
		this.btnPrintWithSpectrum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnPrintWithSpectrum.Location = new System.Drawing.Point(245, 15);
		this.btnPrintWithSpectrum.Name = "btnPrintWithSpectrum";
		this.btnPrintWithSpectrum.Size = new System.Drawing.Size(110, 38);
		this.btnPrintWithSpectrum.TabIndex = 5;
		this.btnPrintWithSpectrum.Text = "&Print";
		//
		//btnPrintWOSpectrum
		//
		this.btnPrintWOSpectrum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPrintWOSpectrum.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.btnPrintWOSpectrum.Image = (System.Drawing.Image)resources.GetObject("btnPrintWOSpectrum.Image");
		this.btnPrintWOSpectrum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnPrintWOSpectrum.Location = new System.Drawing.Point(85, 15);
		this.btnPrintWOSpectrum.Name = "btnPrintWOSpectrum";
		this.btnPrintWOSpectrum.Size = new System.Drawing.Size(110, 38);
		this.btnPrintWOSpectrum.TabIndex = 4;
		this.btnPrintWOSpectrum.Text = "Print W/&O Spectrum";
		this.btnPrintWOSpectrum.TextAlign = System.Drawing.ContentAlignment.TopLeft;
		this.btnPrintWOSpectrum.Visible = false;
		//
		//CustomPanelPeak_Ref
		//
		this.CustomPanelPeak_Ref.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelPeak_Ref.Controls.Add(this.lblRefBeam);
		this.CustomPanelPeak_Ref.Controls.Add(this.dgPeakPick_Ref);
		this.CustomPanelPeak_Ref.Dock = System.Windows.Forms.DockStyle.Fill;
		this.CustomPanelPeak_Ref.Location = new System.Drawing.Point(0, 152);
		this.CustomPanelPeak_Ref.Name = "CustomPanelPeak_Ref";
		this.CustomPanelPeak_Ref.Size = new System.Drawing.Size(648, 231);
		this.CustomPanelPeak_Ref.TabIndex = 6;
		//
		//lblRefBeam
		//
		this.lblRefBeam.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblRefBeam.Location = new System.Drawing.Point(16, 5);
		this.lblRefBeam.Name = "lblRefBeam";
		this.lblRefBeam.Size = new System.Drawing.Size(128, 24);
		this.lblRefBeam.TabIndex = 6;
		this.lblRefBeam.Text = "Reference Beam";
		//
		//dgPeakPick_Ref
		//
		this.dgPeakPick_Ref.DataMember = "";
		this.dgPeakPick_Ref.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.dgPeakPick_Ref.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgPeakPick_Ref.Location = new System.Drawing.Point(16, 34);
		this.dgPeakPick_Ref.Name = "dgPeakPick_Ref";
		this.dgPeakPick_Ref.Size = new System.Drawing.Size(616, 112);
		this.dgPeakPick_Ref.TabIndex = 5;
		//
		//CustomPanelPeakPick
		//
		this.CustomPanelPeakPick.BackColor = System.Drawing.Color.AliceBlue;
		this.CustomPanelPeakPick.Controls.Add(this.lblSampleBeam);
		this.CustomPanelPeakPick.Controls.Add(this.dgPeakPick);
		this.CustomPanelPeakPick.Dock = System.Windows.Forms.DockStyle.Top;
		this.CustomPanelPeakPick.Location = new System.Drawing.Point(0, 0);
		this.CustomPanelPeakPick.Name = "CustomPanelPeakPick";
		this.CustomPanelPeakPick.Size = new System.Drawing.Size(648, 152);
		this.CustomPanelPeakPick.TabIndex = 5;
		//
		//lblSampleBeam
		//
		this.lblSampleBeam.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.lblSampleBeam.Location = new System.Drawing.Point(16, 3);
		this.lblSampleBeam.Name = "lblSampleBeam";
		this.lblSampleBeam.Size = new System.Drawing.Size(128, 24);
		this.lblSampleBeam.TabIndex = 2;
		this.lblSampleBeam.Text = "Sample Beam";
		//
		//dgPeakPick
		//
		this.dgPeakPick.DataMember = "";
		this.dgPeakPick.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.dgPeakPick.HeaderForeColor = System.Drawing.SystemColors.ControlText;
		this.dgPeakPick.Location = new System.Drawing.Point(16, 29);
		this.dgPeakPick.Name = "dgPeakPick";
		this.dgPeakPick.Size = new System.Drawing.Size(616, 112);
		this.dgPeakPick.TabIndex = 1;
		//
		//frmPeakPicks
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
		this.ClientSize = new System.Drawing.Size(648, 383);
		this.Controls.Add(this.CustomPanel1);
		this.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmPeakPicks";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Peak Picks";
		this.CustomPanel1.ResumeLayout(false);
		this.CustomPanelButtons.ResumeLayout(false);
		this.CustomPanelPeak_Ref.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgPeakPick_Ref).EndInit();
		this.CustomPanelPeakPick.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgPeakPick).EndInit();
		this.ResumeLayout(false);

	}

	#End Region

	#Region " Private Class Variables "


	private DataGridClass mobjDataGridClass;
	#End Region

	#Region " Public functions "

	public bool funcDisplayPicPeakResults(DataTable objInDataTable)
	{
		//=====================================================================
		// Procedure Name        : funcDisplayPicPeakResults
		// Parameters Passed     : datatable
		// Returns               : boolean
		// Purpose               : To display pick peak result for sample beam
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin D.
		// Created               : 
		// Revisions             :
		//=====================================================================
		int intColumnCount;
		string strColumnName;

		try {
			//---display pick peak result in datagrid
			if (!objInDataTable == null) {
				//---Added By Mangesh on 02-Apr-2007
				mobjDataGridClass = new DataGridClass(ConstDataGridPropertiesFileName);
				mobjDataGridClass.AllowNew = false;
				mobjDataGridClass.AdjustColumnWidthToGrid = true;
				for (intColumnCount = 0; intColumnCount <= objInDataTable.Columns.Count - 1; intColumnCount++) {
					strColumnName = objInDataTable.Columns.Item(intColumnCount).ColumnName;
					mobjDataGridClass.AddDataGridColumnStyle(strColumnName, dgPeakPick, objInDataTable.DefaultView, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, strColumnName, true);
				}
				mobjDataGridClass.SetDataGridProperties(dgPeakPick, objInDataTable.DefaultView);
				//---Added By Mangesh on 02-Apr-2007
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	public bool funcDisplayPicPeakResults_Ref(DataTable objInDataTable)
	{
		//=====================================================================
		// Procedure Name        : funcDisplayPicPeakResults_Ref
		// Parameters Passed     : datatable
		// Returns               : boolean
		// Purpose               : To display pick peak result for reference beam
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin D.
		// Created               : 
		// Revisions             :
		//=====================================================================
		int intColumnCount;
		string strColumnName;

		try {
			//---display pick peak result in datagrid
			if (!objInDataTable == null) {
				//---Added By Mangesh on 02-Apr-2007
				mobjDataGridClass = new DataGridClass(ConstDataGridPropertiesFileName);
				mobjDataGridClass.AllowNew = false;
				mobjDataGridClass.AdjustColumnWidthToGrid = true;
				for (intColumnCount = 0; intColumnCount <= objInDataTable.Columns.Count - 1; intColumnCount++) {
					strColumnName = objInDataTable.Columns.Item(intColumnCount).ColumnName;
					mobjDataGridClass.AddDataGridColumnStyle(strColumnName, dgPeakPick_Ref, objInDataTable.DefaultView, DataGridClass.enumColumnType.TextBoxColumn, HorizontalAlignment.Center, strColumnName, true);
				}
				mobjDataGridClass.SetDataGridProperties(dgPeakPick_Ref, objInDataTable.DefaultView);
				//---Added By Mangesh on 02-Apr-2007
			}

		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

	#End Region

	private void  // ERROR: Handles clauses are not supported in C#
frmPeakPicks_Load(object sender, System.EventArgs e)
	{
		//=====================================================================
		// Procedure Name        : frmPeakPicks_Load
		// Parameters Passed     : object,eventargs
		// Returns               : None
		// Purpose               : To initialize pick peak form
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Sachin D.
		// Created               : 
		// Revisions             :
		//=====================================================================
		try {
			//validate instrument type & update data structure of custom panel peak ref.
			if (gintInstrumentBeamType == AAS203Library.Instrument.enumInstrumentBeamType.DoubleBeam) {
				lblSampleBeam.Visible = false;
				lblRefBeam.Visible = false;
				this.Height -= CustomPanelPeak_Ref.Height - CustomPanelButtons.Height;

				CustomPanelPeak_Ref.SendToBack();
				CustomPanelPeak_Ref.Dock = DockStyle.None;
				CustomPanelPeak_Ref.Visible = false;


				CustomPanelButtons.BringToFront();
				CustomPanelButtons.Dock = DockStyle.Top + DockStyle.Left;
				CustomPanelButtons.Anchor = AnchorStyles.Top + AnchorStyles.Left;
				CustomPanelButtons.Refresh();

			} else {
				lblSampleBeam.Visible = false;
				lblRefBeam.Visible = false;
				this.Height -= CustomPanelPeak_Ref.Height - CustomPanelButtons.Height;

				CustomPanelPeak_Ref.SendToBack();
				CustomPanelPeak_Ref.Dock = DockStyle.None;
				CustomPanelPeak_Ref.Visible = false;

				CustomPanelButtons.BringToFront();
				CustomPanelButtons.Dock = DockStyle.Top + DockStyle.Left;
				CustomPanelButtons.Anchor = AnchorStyles.Top + AnchorStyles.Left;
				CustomPanelButtons.Refresh();
			}
		} catch (Exception ex) {
			//---------------------------------------------------------
			//Error Handling and logging
			gobjErrorHandler.ErrorDescription = ex.Message;
			gobjErrorHandler.WriteErrorLog(ex);
		//---------------------------------------------------------
		} finally {
			//---------------------------------------------------------
			//Writing Execution log
			if (CONST_CREATE_EXECUTION_LOG == 1) {
				gobjErrorHandler.WriteExecutionLog();
			}
			//---------------------------------------------------------
		}
	}

}
