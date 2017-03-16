namespace IQOQPQ
{

	public class clsDataAccessLayer
	{
		//Private mobjDataObject As DataObject.DataObject.clsDataObject
		//Private mobjSystemData As DataObject.DataObject.clsDataObject
		private DataObject.clsDataObject mobjDataObject;
		private DataObject.clsDataObject mobjSystemData;

		bool connStatus;
		public clsDataAccessLayer(string strDatabasePathIn, string strDatabaseProvideIn, string strDatabaseName, string strUserNameIn, string strPassWord)
		{
			//mobjDataObject = New DataObject.DataObject.clsDataObject(DataObject.DataObject.clsDataObject.enumDataSourceType.Access, strDatabaseName, strDatabasePathIn, strDatabaseProvideIn, strUserNameIn, strPassWord, "")
			mobjDataObject = new DataObject.clsDataObject(DataObject.clsDataObject.enumDataSourceType.Access, strDatabaseName, strDatabasePathIn, strDatabaseProvideIn, strUserNameIn, strPassWord, "");
			mobjDataObject.OpenConnection();
		}
		//'----------------IQOQPQ Table Functions---------------------------

		public DataTable GetCustomerDetails()
		{
			string strQuery;
			DataTable objdtCustomer = new DataTable("CustomerDetails");
			try {
				strQuery = "Select * from CustomerDetails where CustomerID = 1 ";
				//CustomerID ,Name ,Address ,Attention ,Phone ,Fax ,DoneBy ,CompleteDate
				objdtCustomer = funcGetRecord(strQuery);
				return objdtCustomer;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdateCustomerData(DataTable objdt)
		{
			int intRowCount;
			string strUpdateQuery;
			try {
				for (intRowCount = 0; intRowCount <= objdt.Rows.Count - 1; intRowCount++) {
					strUpdateQuery = " UPDATE [CustomerDetails] SET " + " Name= '" + (string)objdt.Rows(intRowCount).Item("Name") + "'," + " Address= '" + (string)objdt.Rows(intRowCount).Item("Address") + "'," + " Attention= '" + (string)objdt.Rows(intRowCount).Item("Attention") + "'," + " Phone= '" + (string)objdt.Rows(intRowCount).Item("Phone") + "'," + " Fax= '" + (string)objdt.Rows(intRowCount).Item("Fax") + "'," + " DoneBy= '" + (string)objdt.Rows(intRowCount).Item("DoneBy") + "'," + " CompleteDate= '" + (System.DateTime)objdt.Rows(intRowCount).Item("CompleteDate") + "'" + " WHERE [CustomerID]= 1 ";

				}
				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetIQEquipmentListRecords()
		{
			DataTable objDtIQEquipment = new DataTable("EquipmentList");
			string strQuery;
			try {
				strQuery = "Select * from EquipmentList where CheckStatusIQOQPQ = 1 ";
				//EquipmentListID ,Name ,SerialNo
				objDtIQEquipment = funcGetRecord(strQuery);
				return objDtIQEquipment;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}
		public DataTable funcGetIQModelNo()
		{
			//Added by Pankaj on Sat 19 May 07
			DataTable objDtIQEquipment = new DataTable("ModelNo");
			string strQuery;
			try {
				strQuery = "Select distinct(ModelNo)  from EquipmentList ";
				//EquipmentListID ,Name ,SerialNo
				objDtIQEquipment = funcGetRecord(strQuery);
				return objDtIQEquipment;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}
		public bool funcInsertIQEquipmentList(string strEqName, string strSrNum)
		{
			string strQuery;
			int mintEqID;
			try {
				mintEqID = (int)mobjDataObject.CheckRecordCount("EquipmentList");
				mintEqID += 1;

				strQuery = " Insert into EquipmentList " + " (EquipmentListID ,Name ,SerialNo ,CheckStatusIQOQPQ,ModelNo) " + " values(" + mintEqID + ",'" + strEqName + "','" + strSrNum + "'," + (float)ENUM_IQOQPQ_STATUS.IQ + " ,'" + gobjModelNo + "') ";

				if (funcInsertRecord(strQuery)) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcDeleteIQEquipmentList(int intEqID)
		{
			string strQuery;
			try {
				strQuery = "DELETE * FROM EquipmentList " + " where EquipmentListID = " + intEqID + " and CheckStatusIQOQPQ = 1  ";

				if (funcDeleteRecord(strQuery)) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdateIQEquipmentList(string strEqName, string strSrNum, int intEquipmentID)
		{
			string strUpdateQuery;
			try {
				strUpdateQuery = " Update EquipmentList " + " Set Name = '" + strEqName + "' ,SerialNo = '" + strSrNum + "',ModelNo= '" + gobjModelNo + "'" + " where EquipmentListID = " + intEquipmentID + " and CheckStatusIQOQPQ = 1  ";

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetIQManualListRecords()
		{
			DataTable objDtIQMannualList = new DataTable("IQManualList");
			string strQuery;
			try {
				strQuery = "Select * from IQManualList ";
				//ManualListID ,Name ,PartNo , Quantity
				objDtIQMannualList = funcGetRecord(strQuery);
				return objDtIQMannualList;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcInsertIQManualListData(string strName, string strPartNum, string strQuantity)
		{
			string strQuery;
			int mintManualListID;
			try {
				mintManualListID = (int)mobjDataObject.CheckRecordCount("IQManualList");
				mintManualListID += 1;
				strQuery = " Insert into IQManualList " + " (ManualListID ,Name ,PartNo ,Quantity) " + " values(" + mintManualListID + ",'" + strName + "','" + strPartNum + "','" + strQuantity + "') ";

				if (funcInsertRecord(strQuery)) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcDeleteIQManualListData(int intManuaListID)
		{
			string strQuery;
			try {
				strQuery = " Delete * from IQManualList " + " where ManualListID = " + intManuaListID + " ";

				if (funcDeleteRecord(strQuery)) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdateIQManualListData(string strName, string strPartNum, string strQuantuty, int intManualListID)
		{
			string strUpdateQuery;
			try {
				strUpdateQuery = " Update IQManualList " + " Set Name = '" + strName + "' ,PartNo = '" + strPartNum + "' , Quantity = '" + strQuantuty + "' " + " where ManualListID = " + intManualListID + " ";

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetSupplierRecords(int mintMode)
		{
			DataTable objDtRecord = new DataTable("ManufacturerRepresentative");
			string strQuery;
			try {
				strQuery = "Select * from ManufacturerRepresentative where CheckStatusIQOQPQ = " + mintMode + " ";
				//ManufacturerRepresentativeID ,Name ,Designation ,Company ,ManDate ,JointFunctionalArea
				objDtRecord = funcGetRecord(strQuery);
				return objDtRecord;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcInsertSupplierData(string strName, string strDesignation, string strCompany, DateTime dtManDate, string strFunctionalArea, int mintMode)
		{
			string strQuery;
			int intSupplierID;
			try {
				intSupplierID = (int)mobjDataObject.CheckRecordCount("ManufacturerRepresentative");
				intSupplierID += 1;

				strQuery = " Insert into ManufacturerRepresentative " + " (ManufacturerRepresentativeID ,Name ,Designation ,Company ,ManDate ,JointFunctionalArea ,CheckStatusIQOQPQ) " + " values(" + intSupplierID + " ,'" + strName + "','" + strDesignation + "','" + strCompany + "','" + dtManDate + "' ,'" + strFunctionalArea + "' ," + mintMode + ") ";

				if (funcInsertRecord(strQuery)) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdateSupplierData(string strName, string strDesignation, string strCompany, DateTime dtManDate, string strFunctionalArea, int intSupplierID, int mintMode)
		{
			string strUpdateQuery;
			try {
				strUpdateQuery = " Update ManufacturerRepresentative " + " Set Name = '" + strName + "' ,Designation = '" + strDesignation + "' ,Company = '" + strCompany + "' ,JointFunctionalArea = '" + strFunctionalArea + "' ,ManDate = '" + dtManDate + "' " + " where ManufacturerRepresentativeID = " + intSupplierID + " and CheckStatusIQOQPQ = " + mintMode + "  ";

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetCustomerRecords(int mintMode)
		{
			DataTable objDtRecord = new DataTable("CustomerRepresentative");
			string strQuery;
			try {
				strQuery = "Select * from CustomerRepresentative where CheckStatusIQOQPQ = " + mintMode + " ";
				//CustomerRepresentativeID ,Name ,Designation ,FunctionalArea ,CustDate
				objDtRecord = funcGetRecord(strQuery);
				return objDtRecord;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcInsertCustomerData(string strName, string strDesignation, string strFunctionalArea, DateTime dtCustDate, int mintMode)
		{
			string strQuery;
			int intCustomerID;
			try {
				intCustomerID = (int)mobjDataObject.CheckRecordCount("CustomerRepresentative");
				intCustomerID += 1;

				strQuery = " Insert into CustomerRepresentative " + " (CustomerRepresentativeID ,Name ,Designation ,CustDate ,CheckStatusIQOQPQ ,FunctionalArea) " + " values(" + intCustomerID + ", '" + strName + "','" + strDesignation + "','" + dtCustDate + "'," + mintMode + ",'" + strFunctionalArea + "') ";

				if (funcInsertRecord(strQuery)) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcDeleteCustomerData(int intCustomerID, int mintMode)
		{
			string strQuery;
			try {
				strQuery = " Delete * from CustomerRepresentative " + " where CustomerRepresentativeID = " + intCustomerID + " and CheckStatusIQOQPQ = " + mintMode + "  ";

				if (funcDeleteRecord(strQuery)) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdateCustomerDataApproval(string strName, string strDesignation, string strFunctionalArea, DateTime dtCustDate, int intCustomerID, float mintMode)
		{
			string strUpdateQuery;
			try {
				strUpdateQuery = " Update CustomerRepresentative " + " Set Name = '" + strName + "' ,Designation = '" + strDesignation + "' ,FunctionalArea = '" + strFunctionalArea + "' ,CustDate = '" + dtCustDate + "' " + " where CustomerRepresentativeID = " + intCustomerID + " and CheckStatusIQOQPQ = " + mintMode + "  ";

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetIQSpecificationRecords()
		{
			DataTable objDtRecord = new DataTable("IQSpecification");
			string strQuery;
			try {
				strQuery = "Select * " + "from IQSpecification ";
				//IQSpecificationID ,IQEquipmentName ,IQManufacturer , IQSerialNo ,IQSize ,IQMainpowerSupply
				objDtRecord = funcGetRecord(strQuery);
				return objDtRecord;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetIQAccessoryRecords()
		{
			DataTable objDtRecord = new DataTable("IQAccessory");
			string strQuery;
			try {
				strQuery = " Select * " + " from IQAccessory ";
				//IQAccessoryID ,Name ,Manufacturer ,SerialNo ,Specification
				objDtRecord = funcGetRecord(strQuery);
				return objDtRecord;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcInsertIQSpecificationData(string strEquipmentName, string strManufacturer, string strSerialNo, string strSize, string strMainPowerSupply)
		{
			string strQuery;
			int intSpecificationID;
			try {
				intSpecificationID = (int)mobjDataObject.CheckRecordCount("IQSpecification");
				intSpecificationID += 1;

				strQuery = " Insert into IQSpecification " + " (IQSpecificationID, IQEquipmentName ,IQManufacturer ,IQSerialNo ,IQSize ,IQMainpowerSupply) " + " values(" + intSpecificationID + ",'" + strEquipmentName + "','" + strManufacturer + "','" + strSerialNo + "','" + strSize + "','" + strMainPowerSupply + "') ";

				if (funcInsertRecord(strQuery)) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcDeleteIQSpecificationData(int intSpecificationID)
		{
			string strQuery;
			try {
				strQuery = " Delete * from IQSpecification " + " where IQSpecificationID = " + intSpecificationID + " ";

				if (funcDeleteRecord(strQuery)) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdateIQSpecificationData(string strEquipmentName, string strManufacturer, string strSerialNo, string strSize, string strMainPowerSupply, int intSpecificationID)
		{
			string strUpdateQuery;
			try {
				strUpdateQuery = " Update IQSpecification " + " Set IQEquipmentName = '" + strEquipmentName + "' ,IQManufacturer = '" + strManufacturer + "' ,IQSerialNo = '" + strSerialNo + "' ,IQSize = '" + strSize + "' ,IQMainpowerSupply = '" + strMainPowerSupply + "' " + " where IQSpecificationID = " + intSpecificationID + "  ";

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcInsertIQAccessoryData(string strName, string strManufacturer, string strSerialNo, string strSpecification)
		{
			string strQuery;
			int intAccessoryID;
			try {
				intAccessoryID = (int)mobjDataObject.CheckRecordCount("IQAccessory");
				intAccessoryID += 1;

				strQuery = " Insert into IQAccessory " + " (Name ,Manufacturer ,SerialNo ,Specification ,IQAccessoryID) " + " values('" + strName + "','" + strManufacturer + "','" + strSerialNo + "','" + strSpecification + "'," + intAccessoryID + ") ";

				if (funcInsertRecord(strQuery)) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcDeleteIQAccessoryData(int intAccessoryID)
		{
			string strQuery;
			try {
				strQuery = " Delete * from IQAccessory " + " where IQAccessoryID = " + intAccessoryID + " ";

				if (funcDeleteRecord(strQuery)) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}
		public bool funcUpdateIQAccessoryData(string strName, string strManufacturer, string strSerialNo, string strSpecification, int intAccessoryID)
		{
			string strUpdateQuery;
			try {
				strUpdateQuery = " Update IQAccessory " + " Set Name = '" + strName + "' ,Manufacturer = '" + strManufacturer + "' ,SerialNo = '" + strSerialNo + "' ,Specification = '" + strSpecification + "' " + " where IQAccessoryID = " + intAccessoryID + " ";


				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetIQTestRecords()
		{
			string strQuery;
			DataTable objdtCustomer = new DataTable("Test");
			try {
				strQuery = "Select * from Test where CheckStatusIQOQPQ = 1 ";

				objdtCustomer = funcGetRecord(strQuery);
				return objdtCustomer;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdateIQTestData(string strComment, string strConfirmity, int intTestID)
		{

			string strUpdateQuery;
			try {
				strUpdateQuery = " Update Test set " + "Confirmity = '" + strConfirmity + "' , Comments = '" + strComment + "' " + " where TestID = " + intTestID + " " + " and CheckStatusIQOQPQ=1 ";

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetCompleteAcceptRecords(int mintMode)
		{
			string strQuery;
			DataTable objdtCustomer = new DataTable("CompletedAcceptedBY");
			try {
				strQuery = " Select * " + " from CompletedAcceptedBY where CheckStatusIQOQPQ = " + mintMode + " ";
				//CompletedAcceptedByID ,CompletedBy ,AcceptedBy
				objdtCustomer = funcGetRecord(strQuery);
				return objdtCustomer;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetDeficiencyRecords(int mintMode)
		{
			string strQuery;
			DataTable objdtCustomer = new DataTable("DeficiencyCorrectiveActionPlan");
			try {
				strQuery = " Select * " + " from DeficiencyCorrectiveActionPlan where CheckStatusIQOQPQ = " + mintMode + " ";
				//DeficiencyCorrectiveActionPlanID ,Details ,ActionPlan , CorrectiveActionDate ,CorrectiveActionOrBy
				objdtCustomer = funcGetRecord(strQuery);
				return objdtCustomer;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcInsertDeficiencyData(string strDetails, string strActionPlan, string strActionBy, DateTime dtActionDate, int mintMode)
		{
			string strQuery;
			int intDeficiencyID;
			try {
				intDeficiencyID = (int)mobjDataObject.CheckRecordCount("DeficiencyCorrectiveActionPlan");
				intDeficiencyID += 1;

				strQuery = " Insert into DeficiencyCorrectiveActionPlan " + " (DeficiencyCorrectiveActionPlanID ,Details ,ActionPlan ,CorrectiveActionDate ,CorrectiveActionOrBy ,CheckStatusIQOQPQ) " + " values(" + intDeficiencyID + ",'" + strDetails + "','" + strActionPlan + "','" + dtActionDate + "','" + strActionBy + "'," + mintMode + ") ";

				if (funcInsertRecord(strQuery)) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcDeleteDeficiencyData(int intDeficiencyID, int mintMode)
		{
			string strQuery;
			try {
				strQuery = " Delete * from DeficiencyCorrectiveActionPlan " + " where DeficiencyCorrectiveActionPlanID = " + intDeficiencyID + " and CheckStatusIQOQPQ = " + mintMode + " ";

				if (funcDeleteRecord(strQuery)) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdateDeficiencyData(string strDetails, string strActionPlan, string strActionBy, DateTime dtActionDate, int intDeficiencyID, int mintMode)
		{
			string strUpdateQuery;
			try {
				strUpdateQuery = " Update DeficiencyCorrectiveActionPlan " + " Set Details = '" + strDetails + "' ,ActionPlan = '" + strActionPlan + "' ,CorrectiveActionDate = '" + dtActionDate + "' ,CorrectiveActionOrBy = '" + strActionBy + "' " + " where DeficiencyCorrectiveActionPlanID = " + intDeficiencyID + " and CheckStatusIQOQPQ = " + mintMode + "  ";


				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcInsertCompleteAcceptData(string strCompletedBy, string strAcceptedBy, float mintMode)
		{
			string strQuery;
			int intCompleteAcceptID;
			try {
				intCompleteAcceptID = (int)mobjDataObject.CheckRecordCount("CompletedAcceptedBY");
				intCompleteAcceptID += 1;

				strQuery = " Insert into CompletedAcceptedBY " + " (CompletedAcceptedByID ,CompletedBy ,AcceptedBy ,CheckStatusIQOQPQ) " + " values(" + intCompleteAcceptID + ",'" + strCompletedBy + "','" + strAcceptedBy + "'," + mintMode + ") ";

				if (funcInsertRecord(strQuery)) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdateCompleteAcceptData(string strCompletedBy, string strAcceptedBy, int intCompleteAcceptID, float mintMode)
		{
			string strUpdateQuery;
			try {
				strUpdateQuery = " Update CompletedAcceptedBY " + " Set CompletedBy = '" + strCompletedBy + "' ,AcceptedBy = '" + strAcceptedBy + "' " + " where CompletedAcceptedByID = " + intCompleteAcceptID + " and CheckStatusIQOQPQ = " + mintMode + " ";

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetOQEquipmentListRecords(float mintMode)
		{
			DataTable objDtEquipment = new DataTable("OQEquipmentList");
			string strQuery;

			try {
				strQuery = "Select * from EquipmentList where CheckStatusIQOQPQ = " + mintMode + " ";
				//EquipmentListID ,Name ,SerialNo ,CheckedBy , VerifiedBy
				objDtEquipment = funcGetRecord(strQuery);
				return objDtEquipment;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcInsertOQEquipmentListData(string strEquipmentName, string strSerialNumber, string strCheckedBy, string strVerifiedBy, float mintMode)
		{
			string strQuery;
			int intEquipmentID;
			try {
				intEquipmentID = (int)mobjDataObject.CheckRecordCount("EquipmentList");
				intEquipmentID += 1;

				//code commented by ; dinesh wagh on 15.2.2010
				//------------------------------------------------------
				//'strQuery = " Insert into EquipmentList " & _
				//'         " (EquipmentListID ,Name ,SerialNo ,CheckedBy , VerifiedBy ,CheckStatusIQOQPQ) " & _
				//'         " values(" & intEquipmentID & ",'" & strEquipmentName & "','" & strSerialNumber & "','" & strCheckedBy & "','" & strVerifiedBy & "'," & mintMode & ") "
				//-------------------------------------------------------


				//code added by ;dinesh wagh on 15.2.2010
				//------------------------------------------------------------------
				strQuery = " Insert into EquipmentList " + " (EquipmentListID ,Name ,SerialNo ,CheckedBy , VerifiedBy ,CheckStatusIQOQPQ,ModelNo) " + " values(" + intEquipmentID + ",'" + strEquipmentName + "','" + strSerialNumber + "','" + strCheckedBy + "','" + strVerifiedBy + "'," + mintMode + ",'" + gobjModelNo + "') ";
				//--------------------------------------------------------------------






				if (funcInsertRecord(strQuery)) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcDeleteOQEquipmentListData(int intEquipmentID, float mintMode)
		{
			string strQuery;
			try {
				strQuery = " Delete * from EquipmentList " + " where EquipmentListID = " + intEquipmentID + " and CheckStatusIQOQPQ = " + mintMode + "  ";

				if (funcDeleteRecord(strQuery)) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdateOQEquipmentListData(string strEquipmentName, string strSerialNumber, string strCheckedBy, string strVerifiedBy, int intEquipmentID, float mintMode)
		{
			string strUpdateQuery;
			try {
				//code commented by ; dinesh wagh on 15.2.2010
				//----------------------------------------------------------
				//strUpdateQuery = " Update EquipmentList " & _
				//          " Set Name = '" & strEquipmentName & "' ,SerialNo = '" & strSerialNumber & "' ,CheckedBy = '" & strCheckedBy & "' ,VerifiedBy = '" & strVerifiedBy & "' " & _
				//          " where EquipmentListID = " & intEquipmentID & " and CheckStatusIQOQPQ = " & mintMode & "  "
				//-------------------------------------------------------


				//code added by ; dinesh wagh on 15.2.2010
				//--------------------------------------------------
				strUpdateQuery = " Update EquipmentList " + " Set Name = '" + strEquipmentName + "' ,SerialNo = '" + strSerialNumber + "' ,CheckedBy = '" + strCheckedBy + "' ,VerifiedBy = '" + strVerifiedBy + "' ,ModelNo= '" + gobjModelNo + "'" + " where EquipmentListID = " + intEquipmentID + " and CheckStatusIQOQPQ = " + mintMode + "  ";
				//--------------------------------------------------


				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetOQTest1Records(int testID)
		{
			DataTable objDtEquipment = new DataTable("OQTest");
			string strQuery;
			try {
				strQuery = "Select * from OQTest where OQTestID = " + testID + " ";
				//OQTestName ,OQObservation ,OQDemoDate ,OQVerifiedDate
				objDtEquipment = funcGetRecord(strQuery);
				return objDtEquipment;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetOQTest1AllRecords()
		{
			DataTable objDtEquipment = new DataTable("OQTest");
			string strQuery;
			try {
				strQuery = "Select * from OQTest ";
				//OQTestName ,OQObservation ,OQDemoDate ,OQVerifiedDate
				objDtEquipment = funcGetRecord(strQuery);
				return objDtEquipment;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdateOQTest1Data(int intTestID, string strObservation, System.DateTime dtDemo, System.DateTime dtVerified)
		{
			string strUpdateQuery;
			try {
				strUpdateQuery = " Update OQTest set " + " OQObservation = '" + strObservation + "' , OQDemoDate = '" + dtDemo + "' ,OQVerifiedDate = '" + dtVerified + "' " + " where OQTestID = " + intTestID + " ";

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetOQUserTrainingRecords()
		{
			DataTable objDtEquipment = new DataTable("OQUserTraining");
			string strQuery;
			try {
				strQuery = "Select * from OQUserTraining ";

				objDtEquipment = funcGetRecord(strQuery);
				return objDtEquipment;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetOQUserRecords()
		{
			DataTable objDtEquipment = new DataTable("OQUser");
			string strQuery;
			try {
				strQuery = " Select * " + " from OQUser ";
				//UserID ,UserName ,UserDate
				objDtEquipment = funcGetRecord(strQuery);
				return objDtEquipment;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdateOQUserTrainingData(string strTrainingType, string strTrainingGiven, string strTrainingComments, int intUserTrainingID)
		{
			string strUpdateQuery;
			try {
				strUpdateQuery = " Update OQUserTraining " + " Set TrainingType = '" + strTrainingType + "' ,TrainingGiven = '" + strTrainingGiven + "' ,TrainingComments = '" + strTrainingComments + "' " + " where TrainingID = " + intUserTrainingID + " ";

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcInsertOQUserData(string strUserName, System.DateTime dtUserDate)
		{
			string strQuery;
			int intUserID;
			try {
				intUserID = (int)mobjDataObject.CheckRecordCount("OQUser");
				intUserID += 1;

				strQuery = " Insert into OQUser " + " (UserID ,UserName ,UserDate) " + " values(" + intUserID + ",'" + strUserName + "','" + dtUserDate + "') ";

				if (funcInsertRecord(strQuery)) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcDeleteOQUserData(int intUserID)
		{
			string strQuery;
			try {
				strQuery = " Delete * from OQUser " + " where UserID = " + intUserID + " ";

				if (funcDeleteRecord(strQuery)) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdateOQUserData(string strUserName, string dtUserDate, int intUserID)
		{
			string strUpdateQuery;
			try {
				strUpdateQuery = " Update OQUser " + " Set UserName = '" + strUserName + "' ,UserDate = '" + dtUserDate + "' " + " where UserID = " + intUserID + " ";


				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetPQConfirmityRecords()
		{
			DataTable objDtEquipment = new DataTable("PQTest1");
			string strQuery;
			try {
				strQuery = "Select Distinct PQTestID, PQTestName, PQPurpose, PQConformity, PQComments " + "From PQTest1 " + "Group by PQTestID, PQTestName, PQPurpose, PQConformity, PQComments ";

				objDtEquipment = funcGetRecord(strQuery);
				return objDtEquipment;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetPQTest1Records()
		{
			DataTable objDtEquipment = new DataTable();
			string strQuery;
			try {
				strQuery = "Select * from PQTest11";

				objDtEquipment = funcGetRecord(strQuery);
				return objDtEquipment;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdatePQTestData(string strConfirmity, string strComments, int intValidationTestID)
		{
			string strUpdateQuery;
			try {
				strUpdateQuery = " Update [PQTest1] set " + " [PQConformity] = '" + strConfirmity + "', [PQComments] = '" + strComments + "' " + " where [PQTestID] = " + intValidationTestID;

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}


		public bool funcUpdatePQTest1Records(string strRemark, string strPMTVoltage, string strWaveLength, string strSlitWidth, string strBurnerHeight, string strAbsorbance, string strFuel, string strLampCurrent, string strDate, int intSampleID)
		{
			string strUpdateQuery;
			try {
				//strUpdateQuery = " Update [PQTest11] set " & _
				//           " [PQComments] = '" & strRemark & "' ,[Time] = " & dblWaveLength & " ," & _
				//           " [DistBySoapRing] = " & dblPMTVoltage & " ,[ActualAbsorbance] = " & dblSlitWidth & " ," & _
				//           " [PQCriteria] = " & dblBurnerHeight & " ,[RT] = " & intFuel & " ,[PeakArea] = " & dblAbsorbance & " ," & _
				//           " [PQAbsorbance] = " & intLampCurrent & " ,[Date] = #" & dtDate & "# " & _
				//           " where [ValidationTestID] = '" & intValidationTestID & "' and [PQTestID] = " & enumPQTest.PQ_Test1 & " "

				strUpdateQuery = " Update [PQTest11] set " + " [LampCurrent] = '" + strLampCurrent + "' , " + " [PMTVoltage] = '" + strPMTVoltage + "' , " + " [WaveLength] = '" + strWaveLength + "' , " + " [SlitWidth] = '" + strSlitWidth + "' ," + " [BurnerHeight] = '" + strBurnerHeight + "' , " + " [Fuel] = '" + strFuel + "' , " + " [Absorbance] = '" + strAbsorbance + "' ," + " [Remark] = '" + strRemark + "' , " + " [Date] = '" + strDate + "' " + " where [SampleID] = " + intSampleID;

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}
		}

		public bool funcUpdatePQTest2Records(int intSampleID, string strAbsorbance, string strDeviation)
		{
			string strUpdateQuery;

			try {
				//code commented by : dinesh wagh on 29.1.2010
				//-------------------------------------------------
				//'strUpdateQuery = " Update [PQTest2] set " & _
				//'          " [Absorbance] = '" & strAbsorbance & "' ," & _
				//'          " [Deviation] = '" & strDeviation & "'" & _
				//'          " where [SampleID] = " & intSampleID & " "
				//----------------------------------------------


				//code added by : dinesh wagh on 29.1.2010
				//-----------------------------------------
				strUpdateQuery = " Update [PQTest2] set " + " [Absorbance] = '" + strAbsorbance + "' ," + " [Deviation] = '" + strDeviation + "'" + " where [Repeat No] = " + intSampleID + " ";
				//-------------------------------------------------


				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetPQTest2Records()
		{
			DataTable objDtEquipment = new DataTable();
			string strQuery;
			try {
				strQuery = "Select * from PQTest2";

				objDtEquipment = funcGetRecord(strQuery);
				return objDtEquipment;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetPQTest3Records()
		{
			DataTable objDtEquipment = new DataTable();
			string strQuery;
			try {
				strQuery = "Select * from PQTest3";

				objDtEquipment = funcGetRecord(strQuery);
				return objDtEquipment;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdatePQTest3Records(int intSampleID, string strAbsorbance, string strConcentration)
		{
			string strUpdateQuery;
			try {
				//code commented by : dinesh wagh on 29.1.2010
				//-----------------------------
				//'strUpdateQuery = " Update [PQTest3] set " & _
				//'          " [Absorbance] = '" & strAbsorbance & "' ," & _
				//'            " [Concentration] = '" & strConcentration & "'" & _
				//'          " where [SampleID] = " & intSampleID & " "
				//--------------------------


				//code added by : dinesh wagh on 29.1.2010
				//-----------------------------------------
				strUpdateQuery = " Update [PQTest3] set " + " [Absorbance] = '" + strAbsorbance + "' ," + " [Concentration] = '" + strConcentration + "'" + " where [Standard No] = " + intSampleID + " ";
				//---------------------------------------------------------

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetPQTest4Records()
		{
			DataTable objDtEquipment = new DataTable();
			string strQuery;
			try {
				strQuery = "Select * from PQTest1 where PQTestID = " + enumPQTest.PQ_Test4;

				objDtEquipment = funcGetRecord(strQuery);
				return objDtEquipment;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdatePQTest4Records(double dblRT, double dblPeakArea, string intValidationTestID)
		{
			string strUpdateQuery;
			try {
				strUpdateQuery = " Update [PQTest1] set " + " [RT] = " + dblRT + " ,[PeakArea] = " + dblPeakArea + "" + " where [ValidationTestID] = '" + intValidationTestID + "' and [PQTestID] = " + enumPQTest.PQ_Test4 + " ";

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetPQTest5Records()
		{
			DataTable objDtEquipment = new DataTable();
			string strQuery;
			try {
				strQuery = "Select * from PQTest1 where PQTestID = " + enumPQTest.PQ_Test5;

				objDtEquipment = funcGetRecord(strQuery);
				return objDtEquipment;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdatePQTest5Records(double dblRT, double dblPeakArea, string intValidationTestID)
		{
			string strUpdateQuery;
			try {
				strUpdateQuery = " Update [PQTest1] set " + " [RT] = " + dblRT + " ,[PeakArea] = " + dblPeakArea + "" + " where [ValidationTestID] = '" + intValidationTestID + "' and [PQTestID] = " + enumPQTest.PQ_Test5 + " ";

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetPQTest6Records()
		{
			DataTable objDtEquipment = new DataTable();
			string strQuery;
			try {
				strQuery = "Select * from PQTest1 where PQTestID = " + enumPQTest.PQ_Test6;

				objDtEquipment = funcGetRecord(strQuery);
				return objDtEquipment;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdatePQTest6Records(double dblRT, double dblPeakArea, string intValidationTestID)
		{
			string strUpdateQuery;
			try {
				strUpdateQuery = " Update [PQTest1] set " + " [RT] = " + dblRT + " ,[PeakArea] = " + dblPeakArea + "" + " where [ValidationTestID] = '" + intValidationTestID + "' and [PQTestID] = " + enumPQTest.PQ_Test6 + " ";

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetPQTest7Records()
		{
			DataTable objDtEquipment = new DataTable();
			string strQuery;
			try {
				strQuery = "Select * from PQTest1 where PQTestID = " + enumPQTest.PQ_Test7;

				objDtEquipment = funcGetRecord(strQuery);
				return objDtEquipment;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdatePQTest7Records(double dblRT, double dblPeakArea, string intValidationTestID)
		{
			string strUpdateQuery;
			try {
				strUpdateQuery = " Update [PQTest1] set " + " [RT] = " + dblRT + " ,[PeakArea] = " + dblPeakArea + "" + " where [ValidationTestID] = '" + intValidationTestID + "' and [PQTestID] = " + enumPQTest.PQ_Test7 + " ";

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetPQTest8Records()
		{
			DataTable objDtEquipment = new DataTable();
			string strQuery;
			try {
				strQuery = "Select * from PQTest1 where PQTestID = " + enumPQTest.PQ_Test8;

				objDtEquipment = funcGetRecord(strQuery);
				return objDtEquipment;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdatePQTest8Records(double dblRT, double dblPeakArea, string intValidationTestID)
		{
			string strUpdateQuery;
			try {
				strUpdateQuery = " Update [PQTest1] set " + " [RT] = " + dblRT + " ,[PeakArea] = " + dblPeakArea + "" + " where [ValidationTestID] = '" + intValidationTestID + "' and [PQTestID] = " + enumPQTest.PQ_Test8 + " ";

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetPQTest9Records()
		{
			DataTable objDtEquipment = new DataTable();
			string strQuery;
			try {
				strQuery = "Select * from PQTest1 where PQTestID = " + enumPQTest.PQ_Test9;

				objDtEquipment = funcGetRecord(strQuery);
				return objDtEquipment;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdatePQTest9Records(double dblRT, double dblPeakArea, string intValidationTestID)
		{
			string strUpdateQuery;
			try {
				strUpdateQuery = " Update [PQTest1] set " + " [RT] = " + dblRT + " ,[PeakArea] = " + dblPeakArea + "" + " where [ValidationTestID] = '" + intValidationTestID + "' and [PQTestID] = " + enumPQTest.PQ_Test9 + " ";

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetPQAllTestRecords()
		{
			DataTable objDtEquipment = new DataTable();
			string strQuery;
			try {
				strQuery = "Select * from PQTest1 ";

				objDtEquipment = funcGetRecord(strQuery);
				return objDtEquipment;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public DataTable funcGetPQCompleteAcceptRecords()
		{
			DataTable objDtEquipment = new DataTable();
			string strQuery;
			try {
				strQuery = " Select * " + " from CompletedAcceptedBY where CheckStatusIQOQPQ = " + ENUM_IQOQPQ_STATUS.PQ + "";
				//CompletedAcceptedByID ,CompletedBy ,AcceptedBy
				objDtEquipment = funcGetRecord(strQuery);
				return objDtEquipment;

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcInsertPQCompleteAcceptData(string strCompletedBy, string strAcceptedBy)
		{
			string strQuery;
			int intCompleteAcceptID;
			try {
				intCompleteAcceptID = (int)mobjDataObject.CheckRecordCount("CompletedAcceptedBY");
				intCompleteAcceptID += 1;

				strQuery = " Insert into CompletedAcceptedBY " + " (CompletedAcceptedByID ,CompletedBy ,AcceptedBy ,CheckStatusIQOQPQ) " + " values(" + intCompleteAcceptID + ",'" + strCompletedBy + "','" + strAcceptedBy + "'," + (float)ENUM_IQOQPQ_STATUS.PQ + ") ";

				if (funcInsertRecord(strQuery)) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdatePQCompleteAcceptData(string strCompletedBy, string strAcceptedBy, int intCompleteAcceptID)
		{
			string strUpdateQuery;
			try {
				if (IsNothing(strCompletedBy)) {
					strCompletedBy = " ";
				}
				if (IsNothing(strAcceptedBy)) {
					strAcceptedBy = " ";
				}
				strUpdateQuery = " Update CompletedAcceptedBY " + " Set CompletedBy = '" + strCompletedBy + "' ,AcceptedBy = '" + strAcceptedBy + "' " + " where CompletedAcceptedByID = " + intCompleteAcceptID + " and CheckStatusIQOQPQ = " + ENUM_IQOQPQ_STATUS.PQ + "  ";

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdateModeLockStatus(int intMode)
		{
			string strUpdateQuery;
			try {
				switch (intMode) {
					case ENUM_IQOQPQ_STATUS.IQ:
						strUpdateQuery = " Update CustomerDetails " + " Set IQModeLocked = 1 where CustomerID = " + 1 + " ";
					case ENUM_IQOQPQ_STATUS.OQ:
						strUpdateQuery = " Update CustomerDetails " + " Set OQModeLocked = 1 where CustomerID = " + 1 + " ";
					case ENUM_IQOQPQ_STATUS.PQ:
						strUpdateQuery = " Update CustomerDetails " + " Set PQModeLocked = 1 where CustomerID = " + 1 + " ";
					default:
						strUpdateQuery = "";
						throw new Exception("Mode Selected to Lock is In-correct.");
				}

				if (funcUpdateRecord(strUpdateQuery) == true) {
					return true;
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcCheckModeLocked(int intMode)
		{
			string strQuery;
			DataTable objdt = new DataTable();
			int intModeState;
			try {
				strQuery = "Select IQModeLocked ,OQModeLocked ,PQModeLocked from CustomerDetails where CustomerID = " + 1 + " ";
				connStatus = mobjDataObject.CheckConnectionStatus;
				if (connStatus) {
					objdt = mobjDataObject.GetRecord(strQuery);
				}
				Application.DoEvents();
				if (IsNothing(objdt)) {
					return false;
				} else {
					switch (intMode) {
						case ENUM_IQOQPQ_STATUS.IQ:
							if (objdt.Rows.Item(0).Item("IQModeLocked") == 1) {
								return true;
							} else {
								return false;

							}
						case ENUM_IQOQPQ_STATUS.OQ:
							if (objdt.Rows.Item(0).Item("OQModeLocked") == 1) {
								return true;
							} else {
								return false;

							}
						case ENUM_IQOQPQ_STATUS.PQ:
							if (objdt.Rows.Item(0).Item("PQModeLocked") == 1) {
								return true;
							} else {
								return false;
							}
						default:
							return false;
					}
				}
			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}
		}

		public DataTable funcGetRecord(string strQuery)
		{
			try {
				DataTable objDt = new DataTable();
				connStatus = mobjDataObject.CheckConnectionStatus;
				if (connStatus) {
					objDt = mobjDataObject.GetRecord(strQuery);

				} else {
				}
				if (IsNothing(objDt)) {
					return null;
				} else {
					return objDt;
				}
			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcUpdateRecord(string strQuery)
		{

			try {
				connStatus = mobjDataObject.CheckConnectionStatus;
				if (connStatus) {
					if (mobjDataObject.BeginTransaction == true) {
						if (mobjDataObject.UpdateRecord(strQuery) == true) {
							mobjDataObject.IsCommitTransaction = true;
							return true;
						} else {
							mobjDataObject.IsCommitTransaction = false;
							return false;
						}
					} else {
						return false;
					}
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcDeleteRecord(string strQuery)
		{

			try {
				connStatus = mobjDataObject.CheckConnectionStatus;
				if (connStatus) {
					if (mobjDataObject.BeginTransaction == true) {
						if (mobjDataObject.DeleteRecord(strQuery) == true) {
							mobjDataObject.IsCommitTransaction = true;
							return true;
						} else {
							mobjDataObject.IsCommitTransaction = false;
							return false;
						}
					} else {
						return false;
					}
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}

		public bool funcInsertRecord(string strQuery)
		{

			try {
				connStatus = mobjDataObject.CheckConnectionStatus;
				if (connStatus) {
					if (mobjDataObject.BeginTransaction == true) {
						if (mobjDataObject.InsertRecords(strQuery) == true) {
							mobjDataObject.IsCommitTransaction = true;
							return true;
						} else {
							mobjDataObject.IsCommitTransaction = false;
							return false;
						}
					} else {
						return false;
					}
				} else {
					return false;
				}

			} catch (Exception ex) {
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = "Error in insertng data service logs";
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
			}

		}


		#Region " Message Handler Functions"

		public DataRow GetMessage(long lngMessageId)
		{
			//=====================================================================
			// Procedure Name        : GetMessage
			// Parameters Passed     : ID of the Message
			// Returns               : DataRow containing message data
			// Purpose               : To retrieve the Message from Table
			// Description           : 
			// Assumptions           : The table should not be empty.
			// Dependencies          : 
			// Author                : Mangesh Shardul
			// Created               : 02-Sep-2004 3:45 pm
			// Revisions             : 
			//=====================================================================
			bool ConnStatus = false;
			string strQuery = "";
			DataTable objDtMessageData = new DataTable();
			DataRow objDrMessageDataRow = null;

			try {
				ConnStatus = mobjSystemData.CheckConnectionStatus();
				//=====================================================================
				// Description explaning the steps followed: 
				// 1. using global object of clsDataObject get the message data
				//    from database as DataTable
				// 2. Set the first column as Unique Key of table
				// 3. Set the first column as Primary Key of table
				// 4. then find the given Message Id in the returned DataTable
				// 5. return the DataRow for that found Message ID
				//=====================================================================
				if (ConnStatus == true) {
					strQuery = "select * from [MessageInfo] order by [MessageID]";
					objDtMessageData = mobjSystemData.GetRecord(strQuery);
					objDtMessageData.Columns("MessageID").Unique = true;
					// Create the Primary Key columns.
					DataColumn[] messagePrimaryKey = new DataColumn[0];
					messagePrimaryKey(0) = objDtMessageData.Columns("MessageID");
					objDtMessageData.PrimaryKey = messagePrimaryKey;
					objDrMessageDataRow = objDtMessageData.Rows.Find(lngMessageId);
				} else {
					//---Connection NOT OPEN
					objDrMessageDataRow = null;
				}

				if (IsNothing(objDrMessageDataRow) == false) {
					if (objDrMessageDataRow.ItemArray.Length > 0) {
						return objDrMessageDataRow;
					} else {
						return null;
					}
				} else {
					return null;
				}

			} catch (Exception ex) {
				//---------------------------------------------------------
				//Error Handling and logging
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = ex.Message;
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
				return null;
			} finally {
				//---------------------------------------------------------
				//Writing Execution log
				if (CONST_CREATE_EXECUTION_LOG == 1) {
					gobjErrorHandler.WriteExecutionLog();
				}
				//---------------------------------------------------------
				objDtMessageData.Dispose();
				objDrMessageDataRow = null;
			}

		}

		public bool SaveMessageInfo(long lngMsgIDIn, string strMessageTitle, string strMessageText, int intModuleID, string strMessageType, string strVBFileName)
		{
			//=====================================================================
			// Procedure Name        : SaveMessageInfo
			// Parameters Passed     : None
			// Returns               : True if data saved successfully; false otherwise
			// Purpose               : To save Message Ifo into the database
			// Description           : 
			// Assumptions           : The table should not be empty.
			// Dependencies          : 
			// Author                : Mangesh Shardul
			// Created               : 12-Sep-2004 3:30 pm
			// Revisions             : 
			//=====================================================================
			bool ConnStatus = false;
			string strInsertQuery = "";

			try {
				strInsertQuery = " INSERT INTO MessageInfo " + " (MessageID, ModuleID, MessageType, MessageTitle, MessageText, FileName) " + " values (" + Val(lngMsgIDIn) + "," + Val(intModuleID) + ",'" + Trim(strMessageType) + "'," + "'" + Trim(strMessageTitle) + "', '" + Trim(strMessageText) + "', '" + Trim(strVBFileName) + "')";

				ConnStatus = mobjSystemData.CheckConnectionStatus();
				if (ConnStatus == true) {
					if (mobjSystemData.BeginTransaction) {
						if (mobjSystemData.InsertRecords(strInsertQuery)) {
							mobjSystemData.IsCommitTransaction = true;
							return true;
						} else {
							mobjSystemData.IsCommitTransaction = false;
							return false;
						}
					} else {
						//---Transaction can not be started.
						return false;
					}
				} else {
					//---Connection NOT OPEN
					return false;
				}

			} catch (Exception ex) {
				//---------------------------------------------------------
				//Error Handling and logging
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = ex.Message;
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
				return false;
			} finally {
				//---------------------------------------------------------
				//Writing Execution log
				if (CONST_CREATE_EXECUTION_LOG == 1) {
					gobjErrorHandler.WriteExecutionLog();
				}
				//---------------------------------------------------------
			}

		}

		public bool SaveErrorInfo(long lngErrNum, string strErrDesc)
		{
			//=====================================================================
			// Procedure Name        : saveErrorInfo
			// Parameters Passed     : None
			// Returns               : True if data saved successfully; false otherwise
			// Purpose               : To save Error No and Descriptions into the database
			// Description           : 
			// Assumptions           : The table should not be empty.
			// Dependencies          : 
			// Author                : Mangesh Shardul
			// Created               : 10-Sep-2004 3:30 pm
			// Revisions             : 
			//=====================================================================
			bool ConnStatus = false;
			string strInsertQuery = "";
			try {
				strInsertQuery = " INSERT INTO [ErrorInfo] " + " ([ErrorNumber], [ErrorDesc]) " + " values (" + Val(lngErrNum) + ",'" + Trim(strErrDesc) + "');";

				ConnStatus = mobjSystemData.CheckConnectionStatus();
				if (ConnStatus == true) {
					if (mobjSystemData.BeginTransaction) {
						if (mobjSystemData.InsertRecords(strInsertQuery)) {
							mobjSystemData.IsCommitTransaction = true;
							return true;
						} else {
							mobjSystemData.IsCommitTransaction = false;
							return false;
						}
					} else {
						//---Transaction can not be started
						return false;
					}
				} else {
					//---Connection NOT OPEN
					return false;
				}

			} catch (Exception ex) {
				//---------------------------------------------------------
				//Error Handling and logging
				gobjErrorHandler.ErrorDescription = ex.Message;
				gobjErrorHandler.ErrorMessage = ex.Message;
				gobjErrorHandler.WriteErrorLog(ex);
				//---------------------------------------------------------
				return false;
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

	}

}
