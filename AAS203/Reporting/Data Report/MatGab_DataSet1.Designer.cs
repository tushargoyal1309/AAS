//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------




///<summary>
///Represents a strongly typed in-memory cache of data.
///</summary>
 // ERROR: Not supported in C#: OptionDeclaration
[System.Serializable(), System.ComponentModel.DesignerCategoryAttribute("code"), System.ComponentModel.ToolboxItem(true), System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema"), System.Xml.Serialization.XmlRootAttribute("DataSet1"), System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class DataSet1 : global::System.Data.DataSet
{

	private StdSampInfoDataTable tableStdSampInfo;

	private global::System.Data.SchemaSerializationMode _schemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;

	[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public DataSet1()
	{
		base.New();
		this.BeginInit();
		this.InitClass();
		global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = this.SchemaChanged;
		base.Tables.CollectionChanged += schemaChangedHandler;
		base.Relations.CollectionChanged += schemaChangedHandler;
		this.EndInit();
	}

	[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	protected DataSet1(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
	{
		base.New(info, context, false);
		if ((this.IsBinarySerialized(info, context) == true)) {
			this.InitVars(false);
			global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = this.SchemaChanged;
			this.Tables.CollectionChanged += schemaChangedHandler1;
			this.Relations.CollectionChanged += schemaChangedHandler1;
			return;
		}
		string strSchema = (string)info.GetValue("XmlSchema", typeof(string));
		if ((this.DetermineSchemaSerializationMode(info, context) == global::System.Data.SchemaSerializationMode.IncludeSchema)) {
			global::System.Data.DataSet ds = new global::System.Data.DataSet();
			ds.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
			if ((!(ds.Tables("StdSampInfo")) == null)) {
				base.Tables.Add(new StdSampInfoDataTable(ds.Tables("StdSampInfo")));
			}
			this.DataSetName = ds.DataSetName;
			this.Prefix = ds.Prefix;
			this.Namespace = ds.Namespace;
			this.Locale = ds.Locale;
			this.CaseSensitive = ds.CaseSensitive;
			this.EnforceConstraints = ds.EnforceConstraints;
			this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
			this.InitVars();
		} else {
			this.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
		}
		this.GetSerializationData(info, context);
		global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = this.SchemaChanged;
		base.Tables.CollectionChanged += schemaChangedHandler;
		this.Relations.CollectionChanged += schemaChangedHandler;
	}

	[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), System.ComponentModel.Browsable(false), System.ComponentModel.DesignerSerializationVisibility(global::System.ComponentModel.DesignerSerializationVisibility.Content)]
	public StdSampInfoDataTable StdSampInfo {
		get { return this.tableStdSampInfo; }
	}

	[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), System.ComponentModel.BrowsableAttribute(true), System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Visible)]
	public override global::System.Data.SchemaSerializationMode SchemaSerializationMode {
		get { return this._schemaSerializationMode; }
		set { this._schemaSerializationMode = value; }
	}

	[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
	public new global::System.Data.DataTableCollection Tables {
		get { return base.Tables; }
	}

	[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
	public new global::System.Data.DataRelationCollection Relations {
		get { return base.Relations; }
	}

	[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	protected override void InitializeDerivedDataSet()
	{
		this.BeginInit();
		this.InitClass();
		this.EndInit();
	}

	[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public override global::System.Data.DataSet Clone()
	{
		DataSet1 cln = (DataSet1)base.Clone;
		cln.InitVars();
		cln.SchemaSerializationMode = this.SchemaSerializationMode;
		return cln;
	}

	[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	protected override bool ShouldSerializeTables()
	{
		return false;
	}

	[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	protected override bool ShouldSerializeRelations()
	{
		return false;
	}

	[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	protected override void ReadXmlSerializable(global::System.Xml.XmlReader reader)
	{
		if ((this.DetermineSchemaSerializationMode(reader) == global::System.Data.SchemaSerializationMode.IncludeSchema)) {
			this.Reset();
			global::System.Data.DataSet ds = new global::System.Data.DataSet();
			ds.ReadXml(reader);
			if ((!(ds.Tables("StdSampInfo")) == null)) {
				base.Tables.Add(new StdSampInfoDataTable(ds.Tables("StdSampInfo")));
			}
			this.DataSetName = ds.DataSetName;
			this.Prefix = ds.Prefix;
			this.Namespace = ds.Namespace;
			this.Locale = ds.Locale;
			this.CaseSensitive = ds.CaseSensitive;
			this.EnforceConstraints = ds.EnforceConstraints;
			this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
			this.InitVars();
		} else {
			this.ReadXml(reader);
			this.InitVars();
		}
	}

	[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	protected override global::System.Xml.Schema.XmlSchema GetSchemaSerializable()
	{
		global::System.IO.MemoryStream stream = new global::System.IO.MemoryStream();
		this.WriteXmlSchema(new global::System.Xml.XmlTextWriter(stream, null));
		stream.Position = 0;
		return global::System.Xml.Schema.XmlSchema.Read(new global::System.Xml.XmlTextReader(stream), null);
	}

	[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	internal void InitVars()
	{
		this.InitVars(true);
	}

	[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	internal void InitVars(bool initTable)
	{
		this.tableStdSampInfo = (StdSampInfoDataTable)base.Tables("StdSampInfo");
		if ((initTable == true)) {
			if ((!(this.tableStdSampInfo) == null)) {
				this.tableStdSampInfo.InitVars();
			}
		}
	}

	[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private void InitClass()
	{
		this.DataSetName = "DataSet1";
		this.Prefix = "";
		this.Namespace = "http://www.tempuri.org/DataSet1.xsd";
		this.EnforceConstraints = true;
		this.SchemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
		this.tableStdSampInfo = new StdSampInfoDataTable();
		base.Tables.Add(this.tableStdSampInfo);
	}

	[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private bool ShouldSerializeStdSampInfo()
	{
		return false;
	}

	[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	private void SchemaChanged(object sender, global::System.ComponentModel.CollectionChangeEventArgs e)
	{
		if ((e.Action == global::System.ComponentModel.CollectionChangeAction.Remove)) {
			this.InitVars();
		}
	}

	[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(global::System.Xml.Schema.XmlSchemaSet xs)
	{
		DataSet1 ds = new DataSet1();
		global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
		global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
		global::System.Xml.Schema.XmlSchemaAny any = new global::System.Xml.Schema.XmlSchemaAny();
		any.Namespace = ds.Namespace;
		sequence.Items.Add(any);
		type.Particle = sequence;
		global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable;
		if (xs.Contains(dsSchema.TargetNamespace)) {
			global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
			global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
			try {
				global::System.Xml.Schema.XmlSchema schema = null;
				dsSchema.Write(s1);
				global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator;
				while (schemas.MoveNext) {
					schema = (global::System.Xml.Schema.XmlSchema)schemas.Current;
					s2.SetLength(0);
					schema.Write(s2);
					if ((s1.Length == s2.Length)) {
						s1.Position = 0;
						s2.Position = 0;

						while (((s1.Position != s1.Length) && (s1.ReadByte == s2.ReadByte))) {


						}
						if ((s1.Position == s1.Length)) {
							return type;
						}
					}

				}
			} finally {
				if ((!(s1) == null)) {
					s1.Close();
				}
				if ((!(s2) == null)) {
					s2.Close();
				}
			}
		}
		xs.Add(dsSchema);
		return type;
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public delegate void StdSampInfoRowChangeEventHandler(object sender, StdSampInfoRowChangeEvent e);

	///<summary>
	///Represents the strongly named DataTable class.
	///</summary>
	[System.Serializable(), System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
	public partial class StdSampInfoDataTable : global::System.Data.DataTable, global::System.Collections.IEnumerable
	{

		private global::System.Data.DataColumn columnStdSamp;

		private global::System.Data.DataColumn columnWeight;

		private global::System.Data.DataColumn columnVolume;

		private global::System.Data.DataColumn columnDilution;

		private global::System.Data.DataColumn columnAbso;

		private global::System.Data.DataColumn columnConc;

		private global::System.Data.DataColumn columnConcUnit;

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public StdSampInfoDataTable()
		{
			base.New();
			this.TableName = "StdSampInfo";
			this.BeginInit();
			this.InitClass();
			this.EndInit();
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal StdSampInfoDataTable(global::System.Data.DataTable table)
		{
			base.New();
			this.TableName = table.TableName;
			if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
				this.CaseSensitive = table.CaseSensitive;
			}
			if ((table.Locale.ToString != table.DataSet.Locale.ToString)) {
				this.Locale = table.Locale;
			}
			if ((table.Namespace != table.DataSet.Namespace)) {
				this.Namespace = table.Namespace;
			}
			this.Prefix = table.Prefix;
			this.MinimumCapacity = table.MinimumCapacity;
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected StdSampInfoDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context)
		{
			base.New(info, context);
			this.InitVars();
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public global::System.Data.DataColumn StdSampColumn {
			get { return this.columnStdSamp; }
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public global::System.Data.DataColumn WeightColumn {
			get { return this.columnWeight; }
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public global::System.Data.DataColumn VolumeColumn {
			get { return this.columnVolume; }
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public global::System.Data.DataColumn DilutionColumn {
			get { return this.columnDilution; }
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public global::System.Data.DataColumn AbsoColumn {
			get { return this.columnAbso; }
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public global::System.Data.DataColumn ConcColumn {
			get { return this.columnConc; }
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public global::System.Data.DataColumn ConcUnitColumn {
			get { return this.columnConcUnit; }
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), System.ComponentModel.Browsable(false)]
		public int Count {
			get { return this.Rows.Count; }
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public StdSampInfoRow this[int index] {
			get { return (StdSampInfoRow)this.Rows(index); }
		}

		[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event StdSampInfoRowChangeEventHandler StdSampInfoRowChanging;

		[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event StdSampInfoRowChangeEventHandler StdSampInfoRowChanged;

		[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event StdSampInfoRowChangeEventHandler StdSampInfoRowDeleting;

		[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public event StdSampInfoRowChangeEventHandler StdSampInfoRowDeleted;

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void AddStdSampInfoRow(StdSampInfoRow row)
		{
			this.Rows.Add(row);
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public StdSampInfoRow AddStdSampInfoRow(string StdSamp, double Weight, double Volume, double Dilution, double Abso, double Conc, double ConcUnit)
		{
			StdSampInfoRow rowStdSampInfoRow = (StdSampInfoRow)this.NewRow;
			object[] columnValuesArray = new object[] {
				StdSamp,
				Weight,
				Volume,
				Dilution,
				Abso,
				Conc,
				ConcUnit
			};
			rowStdSampInfoRow.ItemArray = columnValuesArray;
			this.Rows.Add(rowStdSampInfoRow);
			return rowStdSampInfoRow;
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public StdSampInfoRow FindByStdSamp(string StdSamp)
		{
			return (StdSampInfoRow)this.Rows.Find(new object[] { StdSamp });
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public virtual global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.Rows.GetEnumerator;
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public override global::System.Data.DataTable Clone()
		{
			StdSampInfoDataTable cln = (StdSampInfoDataTable)base.Clone;
			cln.InitVars();
			return cln;
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override global::System.Data.DataTable CreateInstance()
		{
			return new StdSampInfoDataTable();
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal void InitVars()
		{
			this.columnStdSamp = base.Columns("StdSamp");
			this.columnWeight = base.Columns("Weight");
			this.columnVolume = base.Columns("Volume");
			this.columnDilution = base.Columns("Dilution");
			this.columnAbso = base.Columns("Abso");
			this.columnConc = base.Columns("Conc");
			this.columnConcUnit = base.Columns("ConcUnit");
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		private void InitClass()
		{
			this.columnStdSamp = new global::System.Data.DataColumn("StdSamp", typeof(string), null, global::System.Data.MappingType.Element);
			base.Columns.Add(this.columnStdSamp);
			this.columnWeight = new global::System.Data.DataColumn("Weight", typeof(double), null, global::System.Data.MappingType.Element);
			base.Columns.Add(this.columnWeight);
			this.columnVolume = new global::System.Data.DataColumn("Volume", typeof(double), null, global::System.Data.MappingType.Element);
			base.Columns.Add(this.columnVolume);
			this.columnDilution = new global::System.Data.DataColumn("Dilution", typeof(double), null, global::System.Data.MappingType.Element);
			base.Columns.Add(this.columnDilution);
			this.columnAbso = new global::System.Data.DataColumn("Abso", typeof(double), null, global::System.Data.MappingType.Element);
			base.Columns.Add(this.columnAbso);
			this.columnConc = new global::System.Data.DataColumn("Conc", typeof(double), null, global::System.Data.MappingType.Element);
			base.Columns.Add(this.columnConc);
			this.columnConcUnit = new global::System.Data.DataColumn("ConcUnit", typeof(double), null, global::System.Data.MappingType.Element);
			base.Columns.Add(this.columnConcUnit);
			this.Constraints.Add(new global::System.Data.UniqueConstraint("Constraint1", new global::System.Data.DataColumn[] { this.columnStdSamp }, true));
			this.columnStdSamp.AllowDBNull = false;
			this.columnStdSamp.Unique = true;
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public StdSampInfoRow NewStdSampInfoRow()
		{
			return (StdSampInfoRow)this.NewRow;
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override global::System.Data.DataRow NewRowFromBuilder(global::System.Data.DataRowBuilder builder)
		{
			return new StdSampInfoRow(builder);
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override global::System.Type GetRowType()
		{
			return typeof(StdSampInfoRow);
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanged(global::System.Data.DataRowChangeEventArgs e)
		{
			base.OnRowChanged(e);
			if ((!(this.StdSampInfoRowChangedEvent) == null)) {
				if (StdSampInfoRowChanged != null) {
					StdSampInfoRowChanged(this, new StdSampInfoRowChangeEvent((StdSampInfoRow)e.Row, e.Action));
				}
			}
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowChanging(global::System.Data.DataRowChangeEventArgs e)
		{
			base.OnRowChanging(e);
			if ((!(this.StdSampInfoRowChangingEvent) == null)) {
				if (StdSampInfoRowChanging != null) {
					StdSampInfoRowChanging(this, new StdSampInfoRowChangeEvent((StdSampInfoRow)e.Row, e.Action));
				}
			}
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleted(global::System.Data.DataRowChangeEventArgs e)
		{
			base.OnRowDeleted(e);
			if ((!(this.StdSampInfoRowDeletedEvent) == null)) {
				if (StdSampInfoRowDeleted != null) {
					StdSampInfoRowDeleted(this, new StdSampInfoRowChangeEvent((StdSampInfoRow)e.Row, e.Action));
				}
			}
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		protected override void OnRowDeleting(global::System.Data.DataRowChangeEventArgs e)
		{
			base.OnRowDeleting(e);
			if ((!(this.StdSampInfoRowDeletingEvent) == null)) {
				if (StdSampInfoRowDeleting != null) {
					StdSampInfoRowDeleting(this, new StdSampInfoRowChangeEvent((StdSampInfoRow)e.Row, e.Action));
				}
			}
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void RemoveStdSampInfoRow(StdSampInfoRow row)
		{
			this.Rows.Remove(row);
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(global::System.Xml.Schema.XmlSchemaSet xs)
		{
			global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
			global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
			DataSet1 ds = new DataSet1();
			global::System.Xml.Schema.XmlSchemaAny any1 = new global::System.Xml.Schema.XmlSchemaAny();
			any1.Namespace = "http://www.w3.org/2001/XMLSchema";
			any1.MinOccurs = new decimal(0);
			any1.MaxOccurs = decimal.MaxValue;
			any1.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
			sequence.Items.Add(any1);
			global::System.Xml.Schema.XmlSchemaAny any2 = new global::System.Xml.Schema.XmlSchemaAny();
			any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
			any2.MinOccurs = new decimal(1);
			any2.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
			sequence.Items.Add(any2);
			global::System.Xml.Schema.XmlSchemaAttribute attribute1 = new global::System.Xml.Schema.XmlSchemaAttribute();
			attribute1.Name = "namespace";
			attribute1.FixedValue = ds.Namespace;
			type.Attributes.Add(attribute1);
			global::System.Xml.Schema.XmlSchemaAttribute attribute2 = new global::System.Xml.Schema.XmlSchemaAttribute();
			attribute2.Name = "tableTypeName";
			attribute2.FixedValue = "StdSampInfoDataTable";
			type.Attributes.Add(attribute2);
			type.Particle = sequence;
			global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable;
			if (xs.Contains(dsSchema.TargetNamespace)) {
				global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
				global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
				try {
					global::System.Xml.Schema.XmlSchema schema = null;
					dsSchema.Write(s1);
					global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator;
					while (schemas.MoveNext) {
						schema = (global::System.Xml.Schema.XmlSchema)schemas.Current;
						s2.SetLength(0);
						schema.Write(s2);
						if ((s1.Length == s2.Length)) {
							s1.Position = 0;
							s2.Position = 0;

							while (((s1.Position != s1.Length) && (s1.ReadByte == s2.ReadByte))) {


							}
							if ((s1.Position == s1.Length)) {
								return type;
							}
						}

					}
				} finally {
					if ((!(s1) == null)) {
						s1.Close();
					}
					if ((!(s2) == null)) {
						s2.Close();
					}
				}
			}
			xs.Add(dsSchema);
			return type;
		}
	}

	///<summary>
	///Represents strongly named DataRow class.
	///</summary>
	public partial class StdSampInfoRow : global::System.Data.DataRow
	{

		private StdSampInfoDataTable tableStdSampInfo;

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		internal StdSampInfoRow(global::System.Data.DataRowBuilder rb)
		{
			base.New(rb);
			this.tableStdSampInfo = (StdSampInfoDataTable)this.Table;
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public string StdSamp {
			get { return (string)this(this.tableStdSampInfo.StdSampColumn); }
			set { this(this.tableStdSampInfo.StdSampColumn) = value; }
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public double Weight {
			get {
				try {
					return (double)this(this.tableStdSampInfo.WeightColumn);
				} catch (System.InvalidCastException e) {
					throw new global::System.Data.StrongTypingException("The value for column 'Weight' in table 'StdSampInfo' is DBNull.", e);
				}
			}
			set { this(this.tableStdSampInfo.WeightColumn) = value; }
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public double Volume {
			get {
				try {
					return (double)this(this.tableStdSampInfo.VolumeColumn);
				} catch (System.InvalidCastException e) {
					throw new global::System.Data.StrongTypingException("The value for column 'Volume' in table 'StdSampInfo' is DBNull.", e);
				}
			}
			set { this(this.tableStdSampInfo.VolumeColumn) = value; }
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public double Dilution {
			get {
				try {
					return (double)this(this.tableStdSampInfo.DilutionColumn);
				} catch (System.InvalidCastException e) {
					throw new global::System.Data.StrongTypingException("The value for column 'Dilution' in table 'StdSampInfo' is DBNull.", e);
				}
			}
			set { this(this.tableStdSampInfo.DilutionColumn) = value; }
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public double Abso {
			get {
				try {
					return (double)this(this.tableStdSampInfo.AbsoColumn);
				} catch (System.InvalidCastException e) {
					throw new global::System.Data.StrongTypingException("The value for column 'Abso' in table 'StdSampInfo' is DBNull.", e);
				}
			}
			set { this(this.tableStdSampInfo.AbsoColumn) = value; }
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public double Conc {
			get {
				try {
					return (double)this(this.tableStdSampInfo.ConcColumn);
				} catch (System.InvalidCastException e) {
					throw new global::System.Data.StrongTypingException("The value for column 'Conc' in table 'StdSampInfo' is DBNull.", e);
				}
			}
			set { this(this.tableStdSampInfo.ConcColumn) = value; }
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public double ConcUnit {
			get {
				try {
					return (double)this(this.tableStdSampInfo.ConcUnitColumn);
				} catch (System.InvalidCastException e) {
					throw new global::System.Data.StrongTypingException("The value for column 'ConcUnit' in table 'StdSampInfo' is DBNull.", e);
				}
			}
			set { this(this.tableStdSampInfo.ConcUnitColumn) = value; }
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsWeightNull()
		{
			return this.IsNull(this.tableStdSampInfo.WeightColumn);
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetWeightNull()
		{
			this(this.tableStdSampInfo.WeightColumn) = global::System.Convert.DBNull;
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsVolumeNull()
		{
			return this.IsNull(this.tableStdSampInfo.VolumeColumn);
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetVolumeNull()
		{
			this(this.tableStdSampInfo.VolumeColumn) = global::System.Convert.DBNull;
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsDilutionNull()
		{
			return this.IsNull(this.tableStdSampInfo.DilutionColumn);
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetDilutionNull()
		{
			this(this.tableStdSampInfo.DilutionColumn) = global::System.Convert.DBNull;
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsAbsoNull()
		{
			return this.IsNull(this.tableStdSampInfo.AbsoColumn);
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetAbsoNull()
		{
			this(this.tableStdSampInfo.AbsoColumn) = global::System.Convert.DBNull;
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsConcNull()
		{
			return this.IsNull(this.tableStdSampInfo.ConcColumn);
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetConcNull()
		{
			this(this.tableStdSampInfo.ConcColumn) = global::System.Convert.DBNull;
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public bool IsConcUnitNull()
		{
			return this.IsNull(this.tableStdSampInfo.ConcUnitColumn);
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public void SetConcUnitNull()
		{
			this(this.tableStdSampInfo.ConcUnitColumn) = global::System.Convert.DBNull;
		}
	}

	///<summary>
	///Row event argument class
	///</summary>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
	public class StdSampInfoRowChangeEvent : global::System.EventArgs
	{

		private StdSampInfoRow eventRow;

		private global::System.Data.DataRowAction eventAction;

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public StdSampInfoRowChangeEvent(StdSampInfoRow row, global::System.Data.DataRowAction action)
		{
			base.New();
			this.eventRow = row;
			this.eventAction = action;
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public StdSampInfoRow Row {
			get { return this.eventRow; }
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
		public global::System.Data.DataRowAction Action {
			get { return this.eventAction; }
		}
	}
}
