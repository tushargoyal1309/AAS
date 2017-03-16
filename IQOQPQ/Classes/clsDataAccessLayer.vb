Option Explicit On 
Namespace IQOQPQ

    Public Class clsDataAccessLayer
        'Private mobjDataObject As DataObject.DataObject.clsDataObject
        'Private mobjSystemData As DataObject.DataObject.clsDataObject
        Private mobjDataObject As DataObject.clsDataObject
        Private mobjSystemData As DataObject.clsDataObject
        Dim connStatus As Boolean

        Public Sub New(ByVal strDatabasePathIn As String, ByVal strDatabaseProvideIn As String, ByVal strDatabaseName As String, ByVal strUserNameIn As String, ByVal strPassWord As String)
            'mobjDataObject = New DataObject.DataObject.clsDataObject(DataObject.DataObject.clsDataObject.enumDataSourceType.Access, strDatabaseName, strDatabasePathIn, strDatabaseProvideIn, strUserNameIn, strPassWord, "")
            mobjDataObject = New DataObject.clsDataObject(DataObject.clsDataObject.enumDataSourceType.Access, strDatabaseName, strDatabasePathIn, strDatabaseProvideIn, strUserNameIn, strPassWord, "")
            mobjDataObject.OpenConnection()
        End Sub
        ''----------------IQOQPQ Table Functions---------------------------

        Public Function GetCustomerDetails() As DataTable
            Dim strQuery As String
            Dim objdtCustomer As New DataTable("CustomerDetails")
            Try
                strQuery = "Select * from CustomerDetails where CustomerID = 1 "
                'CustomerID ,Name ,Address ,Attention ,Phone ,Fax ,DoneBy ,CompleteDate
                objdtCustomer = funcGetRecord(strQuery)
                Return objdtCustomer

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdateCustomerData(ByVal objdt As DataTable) As Boolean
            Dim intRowCount As Integer
            Dim strUpdateQuery As String
            Try
                For intRowCount = 0 To objdt.Rows.Count - 1
                    strUpdateQuery = " UPDATE [CustomerDetails] SET " & _
                                     " Name= '" & CStr(objdt.Rows(intRowCount).Item("Name")) & "'," & _
                                     " Address= '" & CStr(objdt.Rows(intRowCount).Item("Address")) & "'," & _
                                     " Attention= '" & CStr(objdt.Rows(intRowCount).Item("Attention")) & "'," & _
                                     " Phone= '" & CStr(objdt.Rows(intRowCount).Item("Phone")) & "'," & _
                                     " Fax= '" & CStr(objdt.Rows(intRowCount).Item("Fax")) & "'," & _
                                     " DoneBy= '" & CStr(objdt.Rows(intRowCount).Item("DoneBy")) & "'," & _
                                     " CompleteDate= '" & CDate(objdt.Rows(intRowCount).Item("CompleteDate")) & "'" & _
                                     " WHERE [CustomerID]= 1 "

                Next intRowCount
                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetIQEquipmentListRecords() As DataTable
            Dim objDtIQEquipment As New DataTable("EquipmentList")
            Dim strQuery As String
            Try
                strQuery = "Select * from EquipmentList where CheckStatusIQOQPQ = 1 "
                'EquipmentListID ,Name ,SerialNo
                objDtIQEquipment = funcGetRecord(strQuery)
                Return objDtIQEquipment

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function
        Public Function funcGetIQModelNo() As DataTable
            'Added by Pankaj on Sat 19 May 07
            Dim objDtIQEquipment As New DataTable("ModelNo")
            Dim strQuery As String
            Try
                strQuery = "Select distinct(ModelNo)  from EquipmentList "
                'EquipmentListID ,Name ,SerialNo
                objDtIQEquipment = funcGetRecord(strQuery)
                Return objDtIQEquipment

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function
        Public Function funcInsertIQEquipmentList(ByVal strEqName As String, ByVal strSrNum As String) As Boolean
            Dim strQuery As String
            Dim mintEqID As Integer
            Try
                mintEqID = CInt(mobjDataObject.CheckRecordCount("EquipmentList"))
                mintEqID += 1

                strQuery = " Insert into EquipmentList " & _
                           " (EquipmentListID ,Name ,SerialNo ,CheckStatusIQOQPQ,ModelNo) " & _
                           " values(" & mintEqID & ",'" & strEqName & "','" & strSrNum & "'," & CSng(ENUM_IQOQPQ_STATUS.IQ) & " ,'" & gobjModelNo & "') "

                If funcInsertRecord(strQuery) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcDeleteIQEquipmentList(ByVal intEqID As Integer) As Boolean
            Dim strQuery As String
            Try
                strQuery = "DELETE * FROM EquipmentList " & _
                " where EquipmentListID = " & intEqID & " and CheckStatusIQOQPQ = 1  "

                If funcDeleteRecord(strQuery) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdateIQEquipmentList(ByVal strEqName As String, ByVal strSrNum As String, ByVal intEquipmentID As Integer) As Boolean
            Dim strUpdateQuery As String
            Try
                strUpdateQuery = " Update EquipmentList " & _
                                 " Set Name = '" & strEqName & "' ,SerialNo = '" & strSrNum & "',ModelNo= '" & gobjModelNo & "'" & _
                                 " where EquipmentListID = " & intEquipmentID & " and CheckStatusIQOQPQ = 1  "

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetIQManualListRecords() As DataTable
            Dim objDtIQMannualList As New DataTable("IQManualList")
            Dim strQuery As String
            Try
                strQuery = "Select * from IQManualList "
                'ManualListID ,Name ,PartNo , Quantity
                objDtIQMannualList = funcGetRecord(strQuery)
                Return objDtIQMannualList

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcInsertIQManualListData(ByVal strName As String, ByVal strPartNum As String, ByVal strQuantity As String) As Boolean
            Dim strQuery As String
            Dim mintManualListID As Integer
            Try
                mintManualListID = CInt(mobjDataObject.CheckRecordCount("IQManualList"))
                mintManualListID += 1
                strQuery = " Insert into IQManualList " & _
                           " (ManualListID ,Name ,PartNo ,Quantity) " & _
                           " values(" & mintManualListID & ",'" & strName & "','" & strPartNum & "','" & strQuantity & "') "

                If funcInsertRecord(strQuery) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcDeleteIQManualListData(ByVal intManuaListID As Integer) As Boolean
            Dim strQuery As String
            Try
                strQuery = " Delete * from IQManualList " & _
                          " where ManualListID = " & intManuaListID & " "

                If funcDeleteRecord(strQuery) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdateIQManualListData(ByVal strName As String, ByVal strPartNum As String, ByVal strQuantuty As String, ByVal intManualListID As Integer) As Boolean
            Dim strUpdateQuery As String
            Try
                strUpdateQuery = " Update IQManualList " & _
                          " Set Name = '" & strName & "' ,PartNo = '" & strPartNum & "' , Quantity = '" & strQuantuty & "' " & _
                          " where ManualListID = " & intManualListID & " "

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetSupplierRecords(ByVal mintMode As Integer) As DataTable
            Dim objDtRecord As New DataTable("ManufacturerRepresentative")
            Dim strQuery As String
            Try
                strQuery = "Select * from ManufacturerRepresentative where CheckStatusIQOQPQ = " & mintMode & " "
                'ManufacturerRepresentativeID ,Name ,Designation ,Company ,ManDate ,JointFunctionalArea
                objDtRecord = funcGetRecord(strQuery)
                Return objDtRecord

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcInsertSupplierData(ByVal strName As String, ByVal strDesignation As String, ByVal strCompany As String, ByVal dtManDate As DateTime, ByVal strFunctionalArea As String, ByVal mintMode As Integer) As Boolean
            Dim strQuery As String
            Dim intSupplierID As Integer
            Try
                intSupplierID = CInt(mobjDataObject.CheckRecordCount("ManufacturerRepresentative"))
                intSupplierID += 1

                strQuery = " Insert into ManufacturerRepresentative " & _
                          " (ManufacturerRepresentativeID ,Name ,Designation ,Company ,ManDate ,JointFunctionalArea ,CheckStatusIQOQPQ) " & _
                          " values(" & intSupplierID & " ,'" & strName & "','" & strDesignation & "','" & strCompany & "','" & dtManDate & "' ,'" & strFunctionalArea & "' ," & mintMode & ") "

                If funcInsertRecord(strQuery) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdateSupplierData(ByVal strName As String, ByVal strDesignation As String, ByVal strCompany As String, ByVal dtManDate As DateTime, ByVal strFunctionalArea As String, ByVal intSupplierID As Integer, ByVal mintMode As Integer) As Boolean
            Dim strUpdateQuery As String
            Try
                strUpdateQuery = " Update ManufacturerRepresentative " & _
                          " Set Name = '" & strName & "' ,Designation = '" & strDesignation & "' ,Company = '" & strCompany & "' ,JointFunctionalArea = '" & strFunctionalArea & "' ,ManDate = '" & dtManDate & "' " & _
                          " where ManufacturerRepresentativeID = " & intSupplierID & " and CheckStatusIQOQPQ = " & mintMode & "  "

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetCustomerRecords(ByVal mintMode As Integer) As DataTable
            Dim objDtRecord As New DataTable("CustomerRepresentative")
            Dim strQuery As String
            Try
                strQuery = "Select * from CustomerRepresentative where CheckStatusIQOQPQ = " & mintMode & " "
                'CustomerRepresentativeID ,Name ,Designation ,FunctionalArea ,CustDate
                objDtRecord = funcGetRecord(strQuery)
                Return objDtRecord

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcInsertCustomerData(ByVal strName As String, ByVal strDesignation As String, ByVal strFunctionalArea As String, ByVal dtCustDate As DateTime, ByVal mintMode As Integer) As Boolean
            Dim strQuery As String
            Dim intCustomerID As Integer
            Try
                intCustomerID = CInt(mobjDataObject.CheckRecordCount("CustomerRepresentative"))
                intCustomerID += 1

                strQuery = " Insert into CustomerRepresentative " & _
                          " (CustomerRepresentativeID ,Name ,Designation ,CustDate ,CheckStatusIQOQPQ ,FunctionalArea) " & _
                          " values(" & intCustomerID & ", '" & strName & "','" & strDesignation & "','" & dtCustDate & "'," & mintMode & ",'" & strFunctionalArea & "') "

                If funcInsertRecord(strQuery) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcDeleteCustomerData(ByVal intCustomerID As Integer, ByVal mintMode As Integer) As Boolean
            Dim strQuery As String
            Try
                strQuery = " Delete * from CustomerRepresentative " & _
                          " where CustomerRepresentativeID = " & intCustomerID & " and CheckStatusIQOQPQ = " & mintMode & "  "

                If funcDeleteRecord(strQuery) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdateCustomerDataApproval(ByVal strName As String, ByVal strDesignation As String, ByVal strFunctionalArea As String, ByVal dtCustDate As DateTime, ByVal intCustomerID As Integer, ByVal mintMode As Single) As Boolean
            Dim strUpdateQuery As String
            Try
                strUpdateQuery = " Update CustomerRepresentative " & _
                          " Set Name = '" & strName & "' ,Designation = '" & strDesignation & "' ,FunctionalArea = '" & strFunctionalArea & "' ,CustDate = '" & dtCustDate & "' " & _
                          " where CustomerRepresentativeID = " & intCustomerID & " and CheckStatusIQOQPQ = " & mintMode & "  "

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetIQSpecificationRecords() As DataTable
            Dim objDtRecord As New DataTable("IQSpecification")
            Dim strQuery As String
            Try
                strQuery = "Select * " & _
                             "from IQSpecification "
                'IQSpecificationID ,IQEquipmentName ,IQManufacturer , IQSerialNo ,IQSize ,IQMainpowerSupply
                objDtRecord = funcGetRecord(strQuery)
                Return objDtRecord

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetIQAccessoryRecords() As DataTable
            Dim objDtRecord As New DataTable("IQAccessory")
            Dim strQuery As String
            Try
                strQuery = " Select * " & _
                             " from IQAccessory "
                'IQAccessoryID ,Name ,Manufacturer ,SerialNo ,Specification
                objDtRecord = funcGetRecord(strQuery)
                Return objDtRecord

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcInsertIQSpecificationData(ByVal strEquipmentName As String, ByVal strManufacturer As String, ByVal strSerialNo As String, ByVal strSize As String, ByVal strMainPowerSupply As String) As Boolean
            Dim strQuery As String
            Dim intSpecificationID As Integer
            Try
                intSpecificationID = CInt(mobjDataObject.CheckRecordCount("IQSpecification"))
                intSpecificationID += 1

                strQuery = " Insert into IQSpecification " & _
                          " (IQSpecificationID, IQEquipmentName ,IQManufacturer ,IQSerialNo ,IQSize ,IQMainpowerSupply) " & _
                          " values(" & intSpecificationID & ",'" & strEquipmentName & "','" & strManufacturer & "','" & strSerialNo & "','" & strSize & "','" & strMainPowerSupply & "') "

                If funcInsertRecord(strQuery) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcDeleteIQSpecificationData(ByVal intSpecificationID As Integer) As Boolean
            Dim strQuery As String
            Try
                strQuery = " Delete * from IQSpecification " & _
                          " where IQSpecificationID = " & intSpecificationID & " "

                If funcDeleteRecord(strQuery) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdateIQSpecificationData(ByVal strEquipmentName As String, ByVal strManufacturer As String, ByVal strSerialNo As String, ByVal strSize As String, ByVal strMainPowerSupply As String, ByVal intSpecificationID As Integer) As Boolean
            Dim strUpdateQuery As String
            Try
                strUpdateQuery = " Update IQSpecification " & _
                          " Set IQEquipmentName = '" & strEquipmentName & "' ,IQManufacturer = '" & strManufacturer & "' ,IQSerialNo = '" & strSerialNo & "' ,IQSize = '" & strSize & "' ,IQMainpowerSupply = '" & strMainPowerSupply & "' " & _
                          " where IQSpecificationID = " & intSpecificationID & "  "

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcInsertIQAccessoryData(ByVal strName As String, ByVal strManufacturer As String, ByVal strSerialNo As String, ByVal strSpecification As String) As Boolean
            Dim strQuery As String
            Dim intAccessoryID As Integer
            Try
                intAccessoryID = CInt(mobjDataObject.CheckRecordCount("IQAccessory"))
                intAccessoryID += 1

                strQuery = " Insert into IQAccessory " & _
                          " (Name ,Manufacturer ,SerialNo ,Specification ,IQAccessoryID) " & _
                          " values('" & strName & "','" & strManufacturer & "','" & strSerialNo & "','" & strSpecification & "'," & intAccessoryID & ") "

                If funcInsertRecord(strQuery) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcDeleteIQAccessoryData(ByVal intAccessoryID As Integer) As Boolean
            Dim strQuery As String
            Try
                strQuery = " Delete * from IQAccessory " & _
                          " where IQAccessoryID = " & intAccessoryID & " "

                If funcDeleteRecord(strQuery) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function
        Public Function funcUpdateIQAccessoryData(ByVal strName As String, ByVal strManufacturer As String, ByVal strSerialNo As String, ByVal strSpecification As String, ByVal intAccessoryID As Integer) As Boolean
            Dim strUpdateQuery As String
            Try
                strUpdateQuery = " Update IQAccessory " & _
                          " Set Name = '" & strName & "' ,Manufacturer = '" & strManufacturer & "' ,SerialNo = '" & strSerialNo & "' ,Specification = '" & strSpecification & "' " & _
                          " where IQAccessoryID = " & intAccessoryID & " "


                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetIQTestRecords() As DataTable
            Dim strQuery As String
            Dim objdtCustomer As New DataTable("Test")
            Try
                strQuery = "Select * from Test where CheckStatusIQOQPQ = 1 "

                objdtCustomer = funcGetRecord(strQuery)
                Return objdtCustomer

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdateIQTestData(ByVal strComment As String, ByVal strConfirmity As String, ByVal intTestID As Integer) As Boolean

            Dim strUpdateQuery As String
            Try
                strUpdateQuery = " Update Test set " & _
                          "Confirmity = '" & strConfirmity & "' , Comments = '" & strComment & "' " & _
                          " where TestID = " & intTestID & " " & _
                          " and CheckStatusIQOQPQ=1 "

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetCompleteAcceptRecords(ByVal mintMode As Integer) As DataTable
            Dim strQuery As String
            Dim objdtCustomer As New DataTable("CompletedAcceptedBY")
            Try
                strQuery = " Select * " & _
                             " from CompletedAcceptedBY where CheckStatusIQOQPQ = " & mintMode & " "
                'CompletedAcceptedByID ,CompletedBy ,AcceptedBy
                objdtCustomer = funcGetRecord(strQuery)
                Return objdtCustomer

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetDeficiencyRecords(ByVal mintMode As Integer) As DataTable
            Dim strQuery As String
            Dim objdtCustomer As New DataTable("DeficiencyCorrectiveActionPlan")
            Try
                strQuery = " Select * " & _
                             " from DeficiencyCorrectiveActionPlan where CheckStatusIQOQPQ = " & mintMode & " "
                'DeficiencyCorrectiveActionPlanID ,Details ,ActionPlan , CorrectiveActionDate ,CorrectiveActionOrBy
                objdtCustomer = funcGetRecord(strQuery)
                Return objdtCustomer

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcInsertDeficiencyData(ByVal strDetails As String, ByVal strActionPlan As String, ByVal strActionBy As String, ByVal dtActionDate As DateTime, ByVal mintMode As Integer) As Boolean
            Dim strQuery As String
            Dim intDeficiencyID As Integer
            Try
                intDeficiencyID = CInt(mobjDataObject.CheckRecordCount("DeficiencyCorrectiveActionPlan"))
                intDeficiencyID += 1

                strQuery = " Insert into DeficiencyCorrectiveActionPlan " & _
                          " (DeficiencyCorrectiveActionPlanID ,Details ,ActionPlan ,CorrectiveActionDate ,CorrectiveActionOrBy ,CheckStatusIQOQPQ) " & _
                          " values(" & intDeficiencyID & ",'" & strDetails & "','" & strActionPlan & "','" & dtActionDate & "','" & strActionBy & "'," & mintMode & ") "

                If funcInsertRecord(strQuery) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcDeleteDeficiencyData(ByVal intDeficiencyID As Integer, ByVal mintMode As Integer) As Boolean
            Dim strQuery As String
            Try
                strQuery = " Delete * from DeficiencyCorrectiveActionPlan " & _
                          " where DeficiencyCorrectiveActionPlanID = " & intDeficiencyID & " and CheckStatusIQOQPQ = " & mintMode & " "

                If funcDeleteRecord(strQuery) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdateDeficiencyData(ByVal strDetails As String, ByVal strActionPlan As String, ByVal strActionBy As String, ByVal dtActionDate As DateTime, ByVal intDeficiencyID As Integer, ByVal mintMode As Integer) As Boolean
            Dim strUpdateQuery As String
            Try
                strUpdateQuery = " Update DeficiencyCorrectiveActionPlan " & _
                          " Set Details = '" & strDetails & "' ,ActionPlan = '" & strActionPlan & "' ,CorrectiveActionDate = '" & dtActionDate & "' ,CorrectiveActionOrBy = '" & strActionBy & "' " & _
                          " where DeficiencyCorrectiveActionPlanID = " & intDeficiencyID & " and CheckStatusIQOQPQ = " & mintMode & "  "


                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcInsertCompleteAcceptData(ByVal strCompletedBy As String, ByVal strAcceptedBy As String, ByVal mintMode As Single) As Boolean
            Dim strQuery As String
            Dim intCompleteAcceptID As Integer
            Try
                intCompleteAcceptID = CInt(mobjDataObject.CheckRecordCount("CompletedAcceptedBY"))
                intCompleteAcceptID += 1

                strQuery = " Insert into CompletedAcceptedBY " & _
                          " (CompletedAcceptedByID ,CompletedBy ,AcceptedBy ,CheckStatusIQOQPQ) " & _
                          " values(" & intCompleteAcceptID & ",'" & strCompletedBy & "','" & strAcceptedBy & "'," & mintMode & ") "

                If funcInsertRecord(strQuery) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdateCompleteAcceptData(ByVal strCompletedBy As String, ByVal strAcceptedBy As String, ByVal intCompleteAcceptID As Integer, ByVal mintMode As Single) As Boolean
            Dim strUpdateQuery As String
            Try
                strUpdateQuery = " Update CompletedAcceptedBY " & _
                          " Set CompletedBy = '" & strCompletedBy & "' ,AcceptedBy = '" & strAcceptedBy & "' " & _
                          " where CompletedAcceptedByID = " & intCompleteAcceptID & " and CheckStatusIQOQPQ = " & mintMode & " "

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetOQEquipmentListRecords(ByVal mintMode As Single) As DataTable
            Dim objDtEquipment As New DataTable("OQEquipmentList")
            Dim strQuery As String
            Try

                strQuery = "Select * from EquipmentList where CheckStatusIQOQPQ = " & mintMode & " "
                'EquipmentListID ,Name ,SerialNo ,CheckedBy , VerifiedBy
                objDtEquipment = funcGetRecord(strQuery)
                Return objDtEquipment

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcInsertOQEquipmentListData(ByVal strEquipmentName As String, ByVal strSerialNumber As String, ByVal strCheckedBy As String, ByVal strVerifiedBy As String, ByVal mintMode As Single) As Boolean
            Dim strQuery As String
            Dim intEquipmentID As Integer
            Try
                intEquipmentID = CInt(mobjDataObject.CheckRecordCount("EquipmentList"))
                intEquipmentID += 1

                'code commented by ; dinesh wagh on 15.2.2010
                '------------------------------------------------------
                ''strQuery = " Insert into EquipmentList " & _
                ''         " (EquipmentListID ,Name ,SerialNo ,CheckedBy , VerifiedBy ,CheckStatusIQOQPQ) " & _
                ''         " values(" & intEquipmentID & ",'" & strEquipmentName & "','" & strSerialNumber & "','" & strCheckedBy & "','" & strVerifiedBy & "'," & mintMode & ") "
                '-------------------------------------------------------


                'code added by ;dinesh wagh on 15.2.2010
                '------------------------------------------------------------------
                strQuery = " Insert into EquipmentList " & _
                          " (EquipmentListID ,Name ,SerialNo ,CheckedBy , VerifiedBy ,CheckStatusIQOQPQ,ModelNo) " & _
                          " values(" & intEquipmentID & ",'" & strEquipmentName & "','" & strSerialNumber & "','" & strCheckedBy & "','" & strVerifiedBy & "'," & mintMode & ",'" & gobjModelNo & "') "
                '--------------------------------------------------------------------


               



                If funcInsertRecord(strQuery) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcDeleteOQEquipmentListData(ByVal intEquipmentID As Integer, ByVal mintMode As Single) As Boolean
            Dim strQuery As String
            Try
                strQuery = " Delete * from EquipmentList " & _
                          " where EquipmentListID = " & intEquipmentID & " and CheckStatusIQOQPQ = " & mintMode & "  "

                If funcDeleteRecord(strQuery) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdateOQEquipmentListData(ByVal strEquipmentName As String, ByVal strSerialNumber As String, ByVal strCheckedBy As String, ByVal strVerifiedBy As String, ByVal intEquipmentID As Integer, ByVal mintMode As Single) As Boolean
            Dim strUpdateQuery As String
            Try
                'code commented by ; dinesh wagh on 15.2.2010
                '----------------------------------------------------------
                'strUpdateQuery = " Update EquipmentList " & _
                '          " Set Name = '" & strEquipmentName & "' ,SerialNo = '" & strSerialNumber & "' ,CheckedBy = '" & strCheckedBy & "' ,VerifiedBy = '" & strVerifiedBy & "' " & _
                '          " where EquipmentListID = " & intEquipmentID & " and CheckStatusIQOQPQ = " & mintMode & "  "
                '-------------------------------------------------------


                'code added by ; dinesh wagh on 15.2.2010
                '--------------------------------------------------
                strUpdateQuery = " Update EquipmentList " & _
                          " Set Name = '" & strEquipmentName & "' ,SerialNo = '" & strSerialNumber & "' ,CheckedBy = '" & strCheckedBy & "' ,VerifiedBy = '" & strVerifiedBy & "' ,ModelNo= '" & gobjModelNo & "'" & _
                          " where EquipmentListID = " & intEquipmentID & " and CheckStatusIQOQPQ = " & mintMode & "  "
                '--------------------------------------------------


                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetOQTest1Records(ByVal testID As Integer) As DataTable
            Dim objDtEquipment As New DataTable("OQTest")
            Dim strQuery As String
            Try
                strQuery = "Select * from OQTest where OQTestID = " & testID & " "
                'OQTestName ,OQObservation ,OQDemoDate ,OQVerifiedDate
                objDtEquipment = funcGetRecord(strQuery)
                Return objDtEquipment

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetOQTest1AllRecords() As DataTable
            Dim objDtEquipment As New DataTable("OQTest")
            Dim strQuery As String
            Try
                strQuery = "Select * from OQTest "
                'OQTestName ,OQObservation ,OQDemoDate ,OQVerifiedDate
                objDtEquipment = funcGetRecord(strQuery)
                Return objDtEquipment

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdateOQTest1Data(ByVal intTestID As Integer, ByVal strObservation As String, ByVal dtDemo As Date, ByVal dtVerified As Date) As Boolean
            Dim strUpdateQuery As String
            Try
                strUpdateQuery = " Update OQTest set " & _
                          " OQObservation = '" & strObservation & "' , OQDemoDate = '" & dtDemo & "' ,OQVerifiedDate = '" & dtVerified & "' " & _
                          " where OQTestID = " & intTestID & " "

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetOQUserTrainingRecords() As DataTable
            Dim objDtEquipment As New DataTable("OQUserTraining")
            Dim strQuery As String
            Try
                strQuery = "Select * from OQUserTraining "

                objDtEquipment = funcGetRecord(strQuery)
                Return objDtEquipment

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetOQUserRecords() As DataTable
            Dim objDtEquipment As New DataTable("OQUser")
            Dim strQuery As String
            Try
                strQuery = " Select * " & _
                             " from OQUser "
                'UserID ,UserName ,UserDate
                objDtEquipment = funcGetRecord(strQuery)
                Return objDtEquipment

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdateOQUserTrainingData(ByVal strTrainingType As String, ByVal strTrainingGiven As String, ByVal strTrainingComments As String, ByVal intUserTrainingID As Integer) As Boolean
            Dim strUpdateQuery As String
            Try
                strUpdateQuery = " Update OQUserTraining " & _
                          " Set TrainingType = '" & strTrainingType & "' ,TrainingGiven = '" & strTrainingGiven & "' ,TrainingComments = '" & strTrainingComments & "' " & _
                          " where TrainingID = " & intUserTrainingID & " "

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcInsertOQUserData(ByVal strUserName As String, ByVal dtUserDate As Date) As Boolean
            Dim strQuery As String
            Dim intUserID As Integer
            Try
                intUserID = CInt(mobjDataObject.CheckRecordCount("OQUser"))
                intUserID += 1

                strQuery = " Insert into OQUser " & _
                          " (UserID ,UserName ,UserDate) " & _
                          " values(" & intUserID & ",'" & strUserName & "','" & dtUserDate & "') "

                If funcInsertRecord(strQuery) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcDeleteOQUserData(ByVal intUserID As Integer) As Boolean
            Dim strQuery As String
            Try
                strQuery = " Delete * from OQUser " & _
                          " where UserID = " & intUserID & " "

                If funcDeleteRecord(strQuery) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdateOQUserData(ByVal strUserName As String, ByVal dtUserDate As String, ByVal intUserID As Integer) As Boolean
            Dim strUpdateQuery As String
            Try
                strUpdateQuery = " Update OQUser " & _
                          " Set UserName = '" & strUserName & "' ,UserDate = '" & dtUserDate & "' " & _
                          " where UserID = " & intUserID & " "


                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetPQConfirmityRecords() As DataTable
            Dim objDtEquipment As New DataTable("PQTest1")
            Dim strQuery As String
            Try
                strQuery = "Select Distinct PQTestID, PQTestName, PQPurpose, PQConformity, PQComments " & _
                            "From PQTest1 " & _
                            "Group by PQTestID, PQTestName, PQPurpose, PQConformity, PQComments "

                objDtEquipment = funcGetRecord(strQuery)
                Return objDtEquipment

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetPQTest1Records() As DataTable
            Dim objDtEquipment As New DataTable
            Dim strQuery As String
            Try
                strQuery = "Select * from PQTest11"

                objDtEquipment = funcGetRecord(strQuery)
                Return objDtEquipment

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdatePQTestData(ByVal strConfirmity As String, ByVal strComments As String, ByVal intValidationTestID As Integer) As Boolean
            Dim strUpdateQuery As String
            Try
                strUpdateQuery = " Update [PQTest1] set " & _
                      " [PQConformity] = '" & strConfirmity & "', [PQComments] = '" & strComments & "' " & _
                      " where [PQTestID] = " & intValidationTestID

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function


        Public Function funcUpdatePQTest1Records(ByVal strRemark As String, ByVal strPMTVoltage As String, ByVal strWaveLength As String, ByVal strSlitWidth As String, ByVal strBurnerHeight As String, ByVal strAbsorbance As String, ByVal strFuel As String, ByVal strLampCurrent As String, ByVal strDate As String, ByVal intSampleID As Integer) As Boolean
            Dim strUpdateQuery As String
            Try
                'strUpdateQuery = " Update [PQTest11] set " & _
                '           " [PQComments] = '" & strRemark & "' ,[Time] = " & dblWaveLength & " ," & _
                '           " [DistBySoapRing] = " & dblPMTVoltage & " ,[ActualAbsorbance] = " & dblSlitWidth & " ," & _
                '           " [PQCriteria] = " & dblBurnerHeight & " ,[RT] = " & intFuel & " ,[PeakArea] = " & dblAbsorbance & " ," & _
                '           " [PQAbsorbance] = " & intLampCurrent & " ,[Date] = #" & dtDate & "# " & _
                '           " where [ValidationTestID] = '" & intValidationTestID & "' and [PQTestID] = " & enumPQTest.PQ_Test1 & " "

                strUpdateQuery = " Update [PQTest11] set " & _
                           " [LampCurrent] = '" & strLampCurrent & "' , " & _
                           " [PMTVoltage] = '" & strPMTVoltage & "' , " & _
                           " [WaveLength] = '" & strWaveLength & "' , " & _
                           " [SlitWidth] = '" & strSlitWidth & "' ," & _
                           " [BurnerHeight] = '" & strBurnerHeight & "' , " & _
                           " [Fuel] = '" & strFuel & "' , " & _
                           " [Absorbance] = '" & strAbsorbance & "' ," & _
                           " [Remark] = '" & strRemark & "' , " & _
                           " [Date] = '" & strDate & "' " & _
                           " where [SampleID] = " & intSampleID

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try
        End Function

        Public Function funcUpdatePQTest2Records(ByVal intSampleID As Integer, ByVal strAbsorbance As String, ByVal strDeviation As String) As Boolean
            Dim strUpdateQuery As String
            Try

                'code commented by : dinesh wagh on 29.1.2010
                '-------------------------------------------------
                ''strUpdateQuery = " Update [PQTest2] set " & _
                ''          " [Absorbance] = '" & strAbsorbance & "' ," & _
                ''          " [Deviation] = '" & strDeviation & "'" & _
                ''          " where [SampleID] = " & intSampleID & " "
                '----------------------------------------------


                'code added by : dinesh wagh on 29.1.2010
                '-----------------------------------------
                strUpdateQuery = " Update [PQTest2] set " & _
                          " [Absorbance] = '" & strAbsorbance & "' ," & _
                          " [Deviation] = '" & strDeviation & "'" & _
                          " where [Repeat No] = " & intSampleID & " "
                '-------------------------------------------------


                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetPQTest2Records() As DataTable
            Dim objDtEquipment As New DataTable
            Dim strQuery As String
            Try
                strQuery = "Select * from PQTest2"

                objDtEquipment = funcGetRecord(strQuery)
                Return objDtEquipment

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetPQTest3Records() As DataTable
            Dim objDtEquipment As New DataTable
            Dim strQuery As String
            Try
                strQuery = "Select * from PQTest3"

                objDtEquipment = funcGetRecord(strQuery)
                Return objDtEquipment

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdatePQTest3Records(ByVal intSampleID As Integer, ByVal strAbsorbance As String, ByVal strConcentration As String) As Boolean
            Dim strUpdateQuery As String
            Try
                'code commented by : dinesh wagh on 29.1.2010
                '-----------------------------
                ''strUpdateQuery = " Update [PQTest3] set " & _
                ''          " [Absorbance] = '" & strAbsorbance & "' ," & _
                ''            " [Concentration] = '" & strConcentration & "'" & _
                ''          " where [SampleID] = " & intSampleID & " "
                '--------------------------


                'code added by : dinesh wagh on 29.1.2010
                '-----------------------------------------
                strUpdateQuery = " Update [PQTest3] set " & _
                          " [Absorbance] = '" & strAbsorbance & "' ," & _
                            " [Concentration] = '" & strConcentration & "'" & _
                          " where [Standard No] = " & intSampleID & " "
                '---------------------------------------------------------

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetPQTest4Records() As DataTable
            Dim objDtEquipment As New DataTable
            Dim strQuery As String
            Try
                strQuery = "Select * from PQTest1 where PQTestID = " & enumPQTest.PQ_Test4

                objDtEquipment = funcGetRecord(strQuery)
                Return objDtEquipment

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdatePQTest4Records(ByVal dblRT As Double, ByVal dblPeakArea As Double, ByVal intValidationTestID As String) As Boolean
            Dim strUpdateQuery As String
            Try
                strUpdateQuery = " Update [PQTest1] set " & _
                          " [RT] = " & dblRT & " ,[PeakArea] = " & dblPeakArea & "" & _
                          " where [ValidationTestID] = '" & intValidationTestID & "' and [PQTestID] = " & enumPQTest.PQ_Test4 & " "

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetPQTest5Records() As DataTable
            Dim objDtEquipment As New DataTable
            Dim strQuery As String
            Try
                strQuery = "Select * from PQTest1 where PQTestID = " & enumPQTest.PQ_Test5

                objDtEquipment = funcGetRecord(strQuery)
                Return objDtEquipment

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdatePQTest5Records(ByVal dblRT As Double, ByVal dblPeakArea As Double, ByVal intValidationTestID As String) As Boolean
            Dim strUpdateQuery As String
            Try
                strUpdateQuery = " Update [PQTest1] set " & _
                          " [RT] = " & dblRT & " ,[PeakArea] = " & dblPeakArea & "" & _
                          " where [ValidationTestID] = '" & intValidationTestID & "' and [PQTestID] = " & enumPQTest.PQ_Test5 & " "

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetPQTest6Records() As DataTable
            Dim objDtEquipment As New DataTable
            Dim strQuery As String
            Try
                strQuery = "Select * from PQTest1 where PQTestID = " & enumPQTest.PQ_Test6

                objDtEquipment = funcGetRecord(strQuery)
                Return objDtEquipment

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdatePQTest6Records(ByVal dblRT As Double, ByVal dblPeakArea As Double, ByVal intValidationTestID As String) As Boolean
            Dim strUpdateQuery As String
            Try
                strUpdateQuery = " Update [PQTest1] set " & _
                          " [RT] = " & dblRT & " ,[PeakArea] = " & dblPeakArea & "" & _
                          " where [ValidationTestID] = '" & intValidationTestID & "' and [PQTestID] = " & enumPQTest.PQ_Test6 & " "

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetPQTest7Records() As DataTable
            Dim objDtEquipment As New DataTable
            Dim strQuery As String
            Try
                strQuery = "Select * from PQTest1 where PQTestID = " & enumPQTest.PQ_Test7

                objDtEquipment = funcGetRecord(strQuery)
                Return objDtEquipment

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdatePQTest7Records(ByVal dblRT As Double, ByVal dblPeakArea As Double, ByVal intValidationTestID As String) As Boolean
            Dim strUpdateQuery As String
            Try
                strUpdateQuery = " Update [PQTest1] set " & _
                          " [RT] = " & dblRT & " ,[PeakArea] = " & dblPeakArea & "" & _
                          " where [ValidationTestID] = '" & intValidationTestID & "' and [PQTestID] = " & enumPQTest.PQ_Test7 & " "

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetPQTest8Records() As DataTable
            Dim objDtEquipment As New DataTable
            Dim strQuery As String
            Try
                strQuery = "Select * from PQTest1 where PQTestID = " & enumPQTest.PQ_Test8

                objDtEquipment = funcGetRecord(strQuery)
                Return objDtEquipment

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdatePQTest8Records(ByVal dblRT As Double, ByVal dblPeakArea As Double, ByVal intValidationTestID As String) As Boolean
            Dim strUpdateQuery As String
            Try
                strUpdateQuery = " Update [PQTest1] set " & _
                          " [RT] = " & dblRT & " ,[PeakArea] = " & dblPeakArea & "" & _
                          " where [ValidationTestID] = '" & intValidationTestID & "' and [PQTestID] = " & enumPQTest.PQ_Test8 & " "

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetPQTest9Records() As DataTable
            Dim objDtEquipment As New DataTable
            Dim strQuery As String
            Try
                strQuery = "Select * from PQTest1 where PQTestID = " & enumPQTest.PQ_Test9

                objDtEquipment = funcGetRecord(strQuery)
                Return objDtEquipment

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdatePQTest9Records(ByVal dblRT As Double, ByVal dblPeakArea As Double, ByVal intValidationTestID As String) As Boolean
            Dim strUpdateQuery As String
            Try
                strUpdateQuery = " Update [PQTest1] set " & _
                          " [RT] = " & dblRT & " ,[PeakArea] = " & dblPeakArea & "" & _
                          " where [ValidationTestID] = '" & intValidationTestID & "' and [PQTestID] = " & enumPQTest.PQ_Test9 & " "

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetPQAllTestRecords() As DataTable
            Dim objDtEquipment As New DataTable
            Dim strQuery As String
            Try
                strQuery = "Select * from PQTest1 "

                objDtEquipment = funcGetRecord(strQuery)
                Return objDtEquipment

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcGetPQCompleteAcceptRecords() As DataTable
            Dim objDtEquipment As New DataTable
            Dim strQuery As String
            Try
                strQuery = " Select * " & _
                             " from CompletedAcceptedBY where CheckStatusIQOQPQ = " & ENUM_IQOQPQ_STATUS.PQ & ""
                'CompletedAcceptedByID ,CompletedBy ,AcceptedBy
                objDtEquipment = funcGetRecord(strQuery)
                Return objDtEquipment

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcInsertPQCompleteAcceptData(ByVal strCompletedBy As String, ByVal strAcceptedBy As String) As Boolean
            Dim strQuery As String
            Dim intCompleteAcceptID As Integer
            Try
                intCompleteAcceptID = CInt(mobjDataObject.CheckRecordCount("CompletedAcceptedBY"))
                intCompleteAcceptID += 1

                strQuery = " Insert into CompletedAcceptedBY " & _
                          " (CompletedAcceptedByID ,CompletedBy ,AcceptedBy ,CheckStatusIQOQPQ) " & _
                          " values(" & intCompleteAcceptID & ",'" & strCompletedBy & "','" & strAcceptedBy & "'," & CSng(ENUM_IQOQPQ_STATUS.PQ) & ") "

                If funcInsertRecord(strQuery) Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdatePQCompleteAcceptData(ByVal strCompletedBy As String, ByVal strAcceptedBy As String, ByVal intCompleteAcceptID As Integer) As Boolean
            Dim strUpdateQuery As String
            Try
                If IsNothing(strCompletedBy) Then
                    strCompletedBy = " "
                End If
                If IsNothing(strAcceptedBy) Then
                    strAcceptedBy = " "
                End If
                strUpdateQuery = " Update CompletedAcceptedBY " & _
                          " Set CompletedBy = '" & strCompletedBy & "' ,AcceptedBy = '" & strAcceptedBy & "' " & _
                          " where CompletedAcceptedByID = " & intCompleteAcceptID & " and CheckStatusIQOQPQ = " & ENUM_IQOQPQ_STATUS.PQ & "  "

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdateModeLockStatus(ByVal intMode As Integer) As Boolean
            Dim strUpdateQuery As String
            Try
                Select Case intMode
                    Case ENUM_IQOQPQ_STATUS.IQ
                        strUpdateQuery = " Update CustomerDetails " &
                                  " Set IQModeLocked = 1 where CustomerID = " & 1 & " "
                    Case ENUM_IQOQPQ_STATUS.OQ
                        strUpdateQuery = " Update CustomerDetails " &
                                  " Set OQModeLocked = 1 where CustomerID = " & 1 & " "
                    Case ENUM_IQOQPQ_STATUS.PQ
                        strUpdateQuery = " Update CustomerDetails " &
                                  " Set PQModeLocked = 1 where CustomerID = " & 1 & " "
                    Case Else
                        strUpdateQuery = ""
                        Throw New Exception("Mode Selected to Lock is In-correct.")
                End Select

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdateModeUnLockStatus(ByVal intMode As Integer) As Boolean
            Dim strUpdateQuery As String
            Try
                Select Case intMode
                    Case ENUM_IQOQPQ_STATUS.IQ
                        strUpdateQuery = " Update CustomerDetails " &
                                  " Set IQModeLocked = 0 where CustomerID = " & 1 & " "
                    Case ENUM_IQOQPQ_STATUS.OQ
                        strUpdateQuery = " Update CustomerDetails " &
                                  " Set OQModeLocked = 0 where CustomerID = " & 1 & " "
                    Case ENUM_IQOQPQ_STATUS.PQ
                        strUpdateQuery = " Update CustomerDetails " &
                                  " Set PQModeLocked = 0 where CustomerID = " & 1 & " "
                    Case Else
                        strUpdateQuery = ""
                        Throw New Exception("Mode Selected to UnLock is In-correct.")
                End Select

                If funcUpdateRecord(strUpdateQuery) = True Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcCheckModeLocked(ByVal intMode As Integer) As Boolean
            Dim strQuery As String
            Dim objdt As New DataTable
            Dim intModeState As Integer
            Try
                strQuery = "Select IQModeLocked ,OQModeLocked ,PQModeLocked from CustomerDetails where CustomerID = " & 1 & " "
                connStatus = mobjDataObject.CheckConnectionStatus
                If connStatus Then
                    objdt = mobjDataObject.GetRecord(strQuery)
                End If
                Application.DoEvents()
                If IsNothing(objdt) Then
                    Return False
                Else
                    Select Case intMode
                        Case ENUM_IQOQPQ_STATUS.IQ
                            If objdt.Rows.Item(0).Item("IQModeLocked") = 1 Then
                                Return True
                            Else
                                Return False
                            End If

                        Case ENUM_IQOQPQ_STATUS.OQ
                            If objdt.Rows.Item(0).Item("OQModeLocked") = 1 Then
                                Return True
                            Else
                                Return False
                            End If

                        Case ENUM_IQOQPQ_STATUS.PQ
                            If objdt.Rows.Item(0).Item("PQModeLocked") = 1 Then
                                Return True
                            Else
                                Return False
                            End If
                        Case Else
                            Return False
                    End Select
                End If
            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try
        End Function

        Public Function funcGetRecord(ByVal strQuery As String) As DataTable
            Try
                Dim objDt As New DataTable
                connStatus = mobjDataObject.CheckConnectionStatus
                If connStatus Then
                    objDt = mobjDataObject.GetRecord(strQuery)
                Else

                End If
                If IsNothing(objDt) Then
                    Return Nothing
                Else
                    Return objDt
                End If
            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcUpdateRecord(ByVal strQuery As String) As Boolean

            Try
                connStatus = mobjDataObject.CheckConnectionStatus
                If connStatus Then
                    If mobjDataObject.BeginTransaction = True Then
                        If mobjDataObject.UpdateRecord(strQuery) = True Then
                            mobjDataObject.IsCommitTransaction = True
                            Return True
                        Else
                            mobjDataObject.IsCommitTransaction = False
                            Return False
                        End If
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcDeleteRecord(ByVal strQuery As String) As Boolean

            Try
                connStatus = mobjDataObject.CheckConnectionStatus
                If connStatus Then
                    If mobjDataObject.BeginTransaction = True Then
                        If mobjDataObject.DeleteRecord(strQuery) = True Then
                            mobjDataObject.IsCommitTransaction = True
                            Return True
                        Else
                            mobjDataObject.IsCommitTransaction = False
                            Return False
                        End If
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function

        Public Function funcInsertRecord(ByVal strQuery As String) As Boolean

            Try
                connStatus = mobjDataObject.CheckConnectionStatus
                If connStatus Then
                    If mobjDataObject.BeginTransaction = True Then
                        If mobjDataObject.InsertRecords(strQuery) = True Then
                            mobjDataObject.IsCommitTransaction = True
                            Return True
                        Else
                            mobjDataObject.IsCommitTransaction = False
                            Return False
                        End If
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If

            Catch ex As Exception
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = "Error in insertng data service logs"
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
            End Try

        End Function


#Region " Message Handler Functions"

        Public Function GetMessage(ByVal lngMessageId As Long) As DataRow
            '=====================================================================
            ' Procedure Name        : GetMessage
            ' Parameters Passed     : ID of the Message
            ' Returns               : DataRow containing message data
            ' Purpose               : To retrieve the Message from Table
            ' Description           : 
            ' Assumptions           : The table should not be empty.
            ' Dependencies          : 
            ' Author                : Mangesh Shardul
            ' Created               : 02-Sep-2004 3:45 pm
            ' Revisions             : 
            '=====================================================================
            Dim ConnStatus As Boolean = False
            Dim strQuery As String = ""
            Dim objDtMessageData As New DataTable
            Dim objDrMessageDataRow As DataRow = Nothing

            Try
                ConnStatus = mobjSystemData.CheckConnectionStatus()
                '=====================================================================
                ' Description explaning the steps followed: 
                ' 1. using global object of clsDataObject get the message data
                '    from database as DataTable
                ' 2. Set the first column as Unique Key of table
                ' 3. Set the first column as Primary Key of table
                ' 4. then find the given Message Id in the returned DataTable
                ' 5. return the DataRow for that found Message ID
                '=====================================================================
                If ConnStatus = True Then
                    strQuery = "select * from [MessageInfo] order by [MessageID]"
                    objDtMessageData = mobjSystemData.GetRecord(strQuery)
                    objDtMessageData.Columns("MessageID").Unique = True
                    ' Create the Primary Key columns.
                    Dim messagePrimaryKey(1) As DataColumn
                    messagePrimaryKey(0) = objDtMessageData.Columns("MessageID")
                    objDtMessageData.PrimaryKey = messagePrimaryKey
                    objDrMessageDataRow = objDtMessageData.Rows.Find(lngMessageId)
                Else
                    '---Connection NOT OPEN
                    objDrMessageDataRow = Nothing
                End If

                If IsNothing(objDrMessageDataRow) = False Then
                    If objDrMessageDataRow.ItemArray.Length > 0 Then
                        Return objDrMessageDataRow
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If

            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
                Return Nothing
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                If CONST_CREATE_EXECUTION_LOG = 1 Then
                    gobjErrorHandler.WriteExecutionLog()
                End If
                '---------------------------------------------------------
                objDtMessageData.Dispose()
                objDrMessageDataRow = Nothing
            End Try

        End Function

        Public Function SaveMessageInfo(ByVal lngMsgIDIn As Long, ByVal strMessageTitle As String, _
                             ByVal strMessageText As String, ByVal intModuleID As Integer, _
                             ByVal strMessageType As String, ByVal strVBFileName As String) As Boolean
            '=====================================================================
            ' Procedure Name        : SaveMessageInfo
            ' Parameters Passed     : None
            ' Returns               : True if data saved successfully; false otherwise
            ' Purpose               : To save Message Ifo into the database
            ' Description           : 
            ' Assumptions           : The table should not be empty.
            ' Dependencies          : 
            ' Author                : Mangesh Shardul
            ' Created               : 12-Sep-2004 3:30 pm
            ' Revisions             : 
            '=====================================================================
            Dim ConnStatus As Boolean = False
            Dim strInsertQuery As String = ""
            Try

                strInsertQuery = " INSERT INTO MessageInfo " & _
                     " (MessageID, ModuleID, MessageType, MessageTitle, MessageText, FileName) " & _
                     " values (" & Val(lngMsgIDIn) & "," & Val(intModuleID) & ",'" & Trim(strMessageType) & "'," & _
                     "'" & Trim(strMessageTitle) & "', '" & Trim(strMessageText) & "', '" & Trim(strVBFileName) & "')"

                ConnStatus = mobjSystemData.CheckConnectionStatus()
                If ConnStatus = True Then
                    If mobjSystemData.BeginTransaction Then
                        If mobjSystemData.InsertRecords(strInsertQuery) Then
                            mobjSystemData.IsCommitTransaction = True
                            Return True
                        Else
                            mobjSystemData.IsCommitTransaction = False
                            Return False
                        End If
                    Else
                        '---Transaction can not be started.
                        Return False
                    End If
                Else
                    '---Connection NOT OPEN
                    Return False
                End If

            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
                Return False
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                If CONST_CREATE_EXECUTION_LOG = 1 Then
                    gobjErrorHandler.WriteExecutionLog()
                End If
                '---------------------------------------------------------
            End Try

        End Function

        Public Function SaveErrorInfo(ByVal lngErrNum As Long, ByVal strErrDesc As String) As Boolean
            '=====================================================================
            ' Procedure Name        : saveErrorInfo
            ' Parameters Passed     : None
            ' Returns               : True if data saved successfully; false otherwise
            ' Purpose               : To save Error No and Descriptions into the database
            ' Description           : 
            ' Assumptions           : The table should not be empty.
            ' Dependencies          : 
            ' Author                : Mangesh Shardul
            ' Created               : 10-Sep-2004 3:30 pm
            ' Revisions             : 
            '=====================================================================
            Dim ConnStatus As Boolean = False
            Dim strInsertQuery As String = ""
            Try
                strInsertQuery = " INSERT INTO [ErrorInfo] " & _
                                 " ([ErrorNumber], [ErrorDesc]) " & _
                                 " values (" & Val(lngErrNum) & ",'" & Trim(strErrDesc) & "');"

                ConnStatus = mobjSystemData.CheckConnectionStatus()
                If ConnStatus = True Then
                    If mobjSystemData.BeginTransaction Then
                        If mobjSystemData.InsertRecords(strInsertQuery) Then
                            mobjSystemData.IsCommitTransaction = True
                            Return True
                        Else
                            mobjSystemData.IsCommitTransaction = False
                            Return False
                        End If
                    Else
                        '---Transaction can not be started
                        Return False
                    End If
                Else
                    '---Connection NOT OPEN
                    Return False
                End If

            Catch ex As Exception
                '---------------------------------------------------------
                'Error Handling and logging
                gobjErrorHandler.ErrorDescription = ex.Message
                gobjErrorHandler.ErrorMessage = ex.Message
                gobjErrorHandler.WriteErrorLog(ex)
                '---------------------------------------------------------
                Return False
            Finally
                '---------------------------------------------------------
                'Writing Execution log
                If CONST_CREATE_EXECUTION_LOG = 1 Then
                    gobjErrorHandler.WriteExecutionLog()
                End If
                '---------------------------------------------------------
            End Try

        End Function

#End Region

    End Class

End Namespace