namespace IQOQPQ
{

	public class IQOQPQ
	{

		public enum enumView
		{
			TreeView = 1,
			ListView = 2
		}

		private bool mblnOpenLock;
		private bool mblnSetLock;
		private enumView mSetView;
		private bool mblnShowColumnHeaders;

		private int mintDataGridColumnWidth;
		private frmMDI objfrmMDI;
		public event  Test_IQOQPQ_Attachment1;
		//Saurabh  04.07.07
		public event  Test_IQOQPQ_AttachmentII;
		//Saurabh  07.07.07
		public event  Test_IQOQPQ_AttachmentIII;
		//Saurabh  09.07.07
		public event  InstrumentType;

		#Region "Methods"

		public bool ShowIQOQPQ(string strDatabasePathIn, string strDatabaseProvideIn, string strDatabaseName, string strUserNameIn, string strPassWord)
		{

			try {
				gobjDataAccess = new clsDataAccessLayer(strDatabasePathIn, strDatabaseProvideIn, strDatabaseName, strUserNameIn, strPassWord);

				//************Saurabh 04.07.07**************
				//Dim objfrmMDI As New frmMDI
				objfrmMDI = new frmMDI();
				objfrmMDI.Test_IQOQPQ_Attachment1 += EventRaiseForTest_Attachment1;
				objfrmMDI.Test_IQOQPQ_AttachmentII += EventRaiseForTest_AttachmentII;
				objfrmMDI.Test_IQOQPQ_AttachmentIII += EventRaiseForTest_AttachmentIII;
				objfrmMDI.InstrumentType += EventRaiseForInstrumentType;
				//************Saurabh 04.07.07**************

				objfrmMDI.ShowDialog();
				return true;
			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = ex.Message;
				gobjErrorHandler.WriteErrorLog(ex);
				return false;

			} finally {
			}
		}

		#End Region

		#Region "Properties"

		public bool OpenLock {
			get { return mblnOpenLock; }
			set { mblnOpenLock = Value; }
		}

		public bool SetLock {
			get { return mblnSetLock; }
			set { mblnSetLock = Value; }
		}

		public enumView SetView {
			get { return mSetView; }
			set { mSetView = Value; }
		}

		public bool ShowColumnHeaders {
			get { return mblnShowColumnHeaders; }
			set { mblnShowColumnHeaders = Value; }
		}

		public int DataGridColumnWidth {
			get { return mintDataGridColumnWidth; }
			set { mintDataGridColumnWidth = Value; }
		}

		#End Region

		private void EventRaiseForTest_Attachment1(ref DataTable dtParameters, int intCounter)
		{
			try {
				//MessageBox.Show("hi")
				if (Test_IQOQPQ_Attachment1 != null) {
					Test_IQOQPQ_Attachment1(dtParameters, intCounter);
				}

			} catch (Exception ex) {
				//---------------------------------------------------------
				//Error Handling and logging
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = ex.Message;
				gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			} finally {
				//---------------------------------------------------------
				//Writing Execution log
				if (CONST_CREATE_EXECUTION_LOG == 1) {
					gobjErrorHandler.WriteExecutionLog();
				}
				//objWait.Dispose()
				//---------------------------------------------------------
			}
		}

		private void EventRaiseForTest_AttachmentII(ref DataTable dtParameters, int intCounter)
		{
			try {
				//MessageBox.Show("hi")
				if (Test_IQOQPQ_AttachmentII != null) {
					Test_IQOQPQ_AttachmentII(dtParameters, intCounter);
				}

			} catch (Exception ex) {
				//---------------------------------------------------------
				//Error Handling and logging
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = ex.Message;
				gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			} finally {
				//---------------------------------------------------------
				//Writing Execution log
				if (CONST_CREATE_EXECUTION_LOG == 1) {
					gobjErrorHandler.WriteExecutionLog();
				}
				//objWait.Dispose()
				//---------------------------------------------------------
			}
		}

		private void EventRaiseForTest_AttachmentIII(ref DataTable dtParameters, int intCounter)
		{
			try {
				//MessageBox.Show("hi")
				if (Test_IQOQPQ_AttachmentIII != null) {
					Test_IQOQPQ_AttachmentIII(dtParameters, intCounter);
				}

			} catch (Exception ex) {
				//---------------------------------------------------------
				//Error Handling and logging
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = ex.Message;
				gobjErrorHandler.WriteErrorLog(ex);
			//---------------------------------------------------------
			} finally {
				//---------------------------------------------------------
				//Writing Execution log
				if (CONST_CREATE_EXECUTION_LOG == 1) {
					gobjErrorHandler.WriteExecutionLog();
				}
				//objWait.Dispose()
				//---------------------------------------------------------
			}
		}

		private void EventRaiseForInstrumentType(ref string strInstrumentType)
		{
			if (InstrumentType != null) {
				InstrumentType(strInstrumentType);
			}
		}

	}

}
