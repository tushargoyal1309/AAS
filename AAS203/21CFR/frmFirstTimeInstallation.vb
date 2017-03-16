Imports System.Data.OleDb
Imports AAS203.Common

Public Class frmFirstTimeInstallation
    Public gobjCommProtocol As clsCommProtocolFunctions
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim objWait As New CWaitCursor

        Try

            If funcSaveNewUser() Then
                'MessageBox.Show("User Successfully")
                'txtUsername.Text = ""
                'txtPassword.Text = ""
                Me.Hide()
                Dim objfrmLogin As New frmLogin
                If objfrmLogin.ShowDialog() = DialogResult.OK Then
                    Application.DoEvents()
                    'If objfrmLogin.DialogResult = DialogResult.OK Then
                    If Not objfrmLogin.LoginSuccessfull Then
                        Exit Sub
                    End If
                Else
                    End
                    '
                End If
            End If


        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try
    End Sub

    Public Function funcSaveNewUser() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcSaveNewUser
        ' Description           :   To Save the newly created user/Edited User into database.
        ' Purpose               :   To Save the newly created user/Edited User into database.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   February, 2003 
        ' Revisions             :
        '=====================================================================
        Dim str_userid As String
        Dim objWait As New CWaitCursor
        Try

            If txtUsername.Text = "" Or txtPassword.Text = "" Then
                gobjMessageAdapter.ShowMessage(constEnterUserNamePassword)
                Return False
                Exit Function
            End If


            Call funcInsertNewUser()
            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Private Function funcInsertNewUser() As Boolean
        '=====================================================================
        ' Procedure Name        :   funcInsertNewUser
        ' Description           :   To Save the newly user created into database.
        ' Purpose               :   To Save the newly user created into database.
        ' Parameters Passed     :   None.
        ' Returns               :   None.
        ' Parameters Affected   :   None.
        ' Assumptions           :
        ' Dependencies          :
        ' Author                :   Gitesh
        ' Created               :   January, 2003 
        ' Revisions             :
        '=====================================================================
        Dim objWait As New CWaitCursor
        Dim str_sql As String
        Dim Status As Boolean
        Dim objCommand As New OleDbCommand
        Dim objTransaction As OleDbTransaction
        Dim user_id, password_id As Long
        Dim active_value As Integer

        Try
            Status = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
            If Not (Status) Then
                Return False
            End If

            '--- Generating ID for User
            user_id = gclsDBFunctions.GetNextID("Users", "UserID", gOleDBUserInfoConnection)

            Status = gclsDBFunctions.OpenConnection(gOleDBUserInfoConnection)
            If Not (Status) Then
                Return False
            End If

            password_id = gclsDBFunctions.GetNextID("Passwords", "PasswordID", gOleDBUserInfoConnection)
            active_value = 1

            objTransaction = gOleDBUserInfoConnection.BeginTransaction()

            '---  Query for Insert into Users Table
            str_sql = "Insert into Users " &
                      "(UserID ,UserName ,AliasName ,Active) " &
                      " values(?,?,?,?)"

            '--- Providing command object for Users
            With objCommand
                .Connection = gOleDBUserInfoConnection
                .CommandType = CommandType.Text
                .CommandText = str_sql
                .Transaction = objTransaction
                .Parameters.Add("UserID", OleDbType.BigInt).Value = 0
                .Parameters.Add("UserName", OleDbType.VarChar).Value = Trim(txtUsername.Text)
                .Parameters.Add("AliasName", OleDbType.VarChar).Value = Trim("Administrator")
                .Parameters.Add("Active", OleDbType.Integer).Value = active_value
                .ExecuteNonQuery()
            End With

            objCommand.Dispose()

            '-- To Encrypt the Password.
            Dim str_password As String
            str_password = gfuncEncryptString(Trim(txtPassword.Text))

            '---  Query for Insert into Password Table
            str_sql = "Insert into Passwords  " &
                      "(PasswordID ,UserID ,PasswordName) " &
                      " values(?,?,?)"
            '" values(" & password_id & ", " & user_id & " ,'" & txtPassword.Text & "' )"

            '--- Providing command object for Users
            With objCommand
                .Connection = gOleDBUserInfoConnection
                .CommandType = CommandType.Text
                .CommandText = str_sql
                .Transaction = objTransaction
                .Parameters.Add("PasswordID", OleDbType.BigInt).Value = password_id
                .Parameters.Add("UserId", OleDbType.BigInt).Value = 0
                .Parameters.Add("PasswordName", OleDbType.VarChar).Value = str_password
                .ExecuteNonQuery()
            End With

            '.Parameters.Add("PasswordName", OleDbType.VarChar).Value = Trim(txtPassword.Text)
            objCommand.Dispose()
            objTransaction.Commit()
            Return True

        Catch ex As Exception
            '---------------------------------------------------------
            'Error Handling and logging
            gobjErrorHandler.ErrorDescription = ex.Message
            gobjErrorHandler.ErrorMessage = ex.Message
            gobjErrorHandler.WriteErrorLog(ex)
            '---------------------------------------------------------
        Finally
            '---------------------------------------------------------
            'Writing Execution log
            If CONST_CREATE_EXECUTION_LOG = 1 Then
                gobjErrorHandler.WriteExecutionLog()
            End If
            If Not objWait Is Nothing Then
                objWait.Dispose()
            End If
            '---------------------------------------------------------
        End Try

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
        End
    End Sub
End Class