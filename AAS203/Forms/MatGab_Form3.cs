public class Form3 : System.Windows.Forms.Form
{

	#Region " Windows Form Designer generated code "

	public Form3()
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
	internal System.Windows.Forms.Label Label1;
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.Label1 = new System.Windows.Forms.Label();
		this.SuspendLayout();
		//
		//Label1
		//
		this.Label1.Location = new System.Drawing.Point(194, 86);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(66, 32);
		this.Label1.TabIndex = 0;
		this.Label1.Text = "Label1";
		//
		//Form3
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(292, 273);
		this.Controls.Add(this.Label1);
		this.Name = "Form3";
		this.Text = "Form3";
		this.ResumeLayout(false);

	}

	#End Region


	//----
	// 	if (Method->Mode!=MODE_EMISSION &&!Check_Lamp_at_Position(Method->Aas.elName,Method->Aas.LampNo)){
	//if( GetInstrument() == AA202)
	// Gerror_message_new("Method Lamp poistion and current lamp position mismatch","Method Load");
	//else
	//  Gerror_message_new("Method Lamp poistion and current turret position mismatch","Method Load");
	//----

}
