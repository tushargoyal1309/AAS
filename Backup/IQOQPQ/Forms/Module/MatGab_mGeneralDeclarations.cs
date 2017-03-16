
using System.Data.OleDb;
using DataObject;

public class mGeneralDeclarations
{

	public Application ObjApp;
	public ErrorHandler.ErrorHandler gobjErrorHandler = new ErrorHandler.ErrorHandler();
		//DataSet
	public dtsetExportAll gobjDataSet = new dtsetExportAll();
	//'Public gobjDataSet1 As dtsetExportAll1 'DataSet
	public frmMDI gobjfrmMdi = new frmMDI();
	public IQOQPQ.clsDataAccessLayer gobjDataAccess;
	public clsMessageAdapter gobjMessageAdapter = new clsMessageAdapter();

	public string gobjModelNo = "";
}
