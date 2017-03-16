Option Explicit On 
Imports AAS203.Common
Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class TripleDES

#Region " class variables "

    Private key() As Byte = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24}
    Private iv() As Byte = {65, 110, 68, 26, 69, 178, 200, 219}

#End Region

#Region " String to Byte  encrypt-decrypt "

    Public Function gfuncEncrypt(ByVal plainText As String) As Byte()
        '=====================================================================
        ' Procedure Name        : gfuncEncrypt
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To encrypt the given string to byte.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try

            ' Declare a UTF8Encoding object so we may use the GetByte 
        ' method to transform the plainText into a Byte array. 
        Dim utf8encoder As UTF8Encoding = New UTF8Encoding
        Dim inputInBytes() As Byte = utf8encoder.GetBytes(plainText)

        ' Create a new TripleDES service provider 
        Dim tdesProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider

        ' The ICryptTransform interface uses the TripleDES 
        ' crypt provider along with encryption key and init vector 
        ' information 
        Dim cryptoTransform As ICryptoTransform = tdesProvider.CreateEncryptor(Me.key, Me.iv)

        ' All cryptographic functions need a stream to output the 
        ' encrypted information. Here we declare a memory stream 
        ' for this purpose. 
        Dim encryptedStream As MemoryStream = New MemoryStream
        Dim cryptStream As CryptoStream = New CryptoStream(encryptedStream, cryptoTransform, CryptoStreamMode.Write)

        ' Write the encrypted information to the stream. Flush the information 
        ' when done to ensure everything is out of the buffer. 
        cryptStream.Write(inputInBytes, 0, inputInBytes.Length)
        cryptStream.FlushFinalBlock()
        encryptedStream.Position = 0

        ' Read the stream back into a Byte array and return it to the calling 
        ' method. 
        Dim result(encryptedStream.Length - 1) As Byte
        encryptedStream.Read(result, 0, encryptedStream.Length)
        cryptStream.Close()
        Return result

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

    Public Function gfuncDecrypt(ByVal inputInBytes() As Byte) As String
        '=====================================================================
        ' Procedure Name        : gfuncDecrypt
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To decrypt the bytes to string.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            ' UTFEncoding is used to transform the decrypted Byte Array 
            ' information back into a string. 
            Dim utf8encoder As UTF8Encoding = New UTF8Encoding
            Dim tdesProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider

            ' As before we must provide the encryption/decryption key along with 
            ' the init vector. 
            Dim cryptoTransform As ICryptoTransform = tdesProvider.CreateDecryptor(Me.key, Me.iv)

            ' Provide a memory stream to decrypt information into 
            Dim decryptedStream As MemoryStream = New MemoryStream
            Dim cryptStream As CryptoStream = New CryptoStream(decryptedStream, cryptoTransform, CryptoStreamMode.Write)
            cryptStream.Write(inputInBytes, 0, inputInBytes.Length)
            cryptStream.FlushFinalBlock()
            decryptedStream.Position = 0

            ' Read the memory stream and convert it back into a string 
            Dim result(decryptedStream.Length - 1) As Byte
            decryptedStream.Read(result, 0, decryptedStream.Length)
            cryptStream.Close()
            Dim myutf As UTF8Encoding = New UTF8Encoding
        Return myutf.GetString(result)
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

#End Region

#Region " byte to byte encrypt-decrypt "

    Public Function gfuncEncryptbyte(ByVal inputbyte As Byte()) As Byte()
        '=====================================================================
        ' Procedure Name        : frmAddUser_Load
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To encrypt the byte.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        Try
            ' Declare a UTF8Encoding object so we may use the GetByte 
            ' method to transform the plainText into a Byte array. 
            'Dim utf8encoder As UTF8Encoding = New UTF8Encoding
            'Dim inputInBytes() As Byte = utf8encoder.GetBytes(plainText)

            ' Create a new TripleDES service provider 
            Dim tdesProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider

            ' The ICryptTransform interface uses the TripleDES 
            ' crypt provider along with encryption key and init vector 
            ' information 
            Dim cryptoTransform As ICryptoTransform = tdesProvider.CreateEncryptor(Me.key, Me.iv)

            ' All cryptographic functions need a stream to output the 
            ' encrypted information. Here we declare a memory stream 
            ' for this purpose. 
            Dim encryptedStream As MemoryStream = New MemoryStream
            Dim cryptStream As CryptoStream = New CryptoStream(encryptedStream, cryptoTransform, CryptoStreamMode.Write)

            ' Write the encrypted information to the stream. Flush the information 
            ' when done to ensure everything is out of the buffer. 
            'cryptStream.Write(inputInBytes, 0, inputInBytes.Length)
            cryptStream.Write(inputbyte, 0, inputbyte.Length)
            cryptStream.FlushFinalBlock()
            encryptedStream.Position = 0

            ' Read the stream back into a Byte array and return it to the calling 
            ' method. 
            Dim result(encryptedStream.Length - 1) As Byte
            encryptedStream.Read(result, 0, encryptedStream.Length)
            cryptStream.Close()
        Return result
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

    Public Function gfuncDecryptbyte(ByVal inputInBytes() As Byte) As Byte()
        '=====================================================================
        ' Procedure Name        : gfuncDecryptbyte
        ' Parameters Passed     : Object,EventArgs
        ' Returns               : None
        ' Purpose               : To decrypt the byte.
        ' Description           : 
        ' Assumptions           : 
        ' Dependencies          : 
        ' Author                : Saruabh S. 
        ' Created               : Dec, 2006
        ' Revisions             : 
        '=====================================================================
        Dim objWait As New CWaitCursor
        ' UTFEncoding is used to transform the decrypted Byte Array 
        ' information back into a string. 
        Dim utf8encoder As UTF8Encoding = New UTF8Encoding
        Dim tdesProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider

        ' As before we must provide the encryption/decryption key along with 
        ' the init vector. 
        Dim cryptoTransform As ICryptoTransform = tdesProvider.CreateDecryptor(Me.key, Me.iv)

        Try
            ' Provide a memory stream to decrypt information into 
            Dim decryptedStream As MemoryStream = New MemoryStream
            Dim cryptStream As CryptoStream = New CryptoStream(decryptedStream, cryptoTransform, CryptoStreamMode.Write)
            cryptStream.Write(inputInBytes, 0, inputInBytes.Length)
            cryptStream.FlushFinalBlock()
            decryptedStream.Position = 0

            ' Read the memory stream and convert it back into a string 
            Dim result(decryptedStream.Length - 1) As Byte
            decryptedStream.Read(result, 0, decryptedStream.Length)
            cryptStream.Close()
            'Dim myutf As UTF8Encoding = New UTF8Encoding
            'Return myutf.GetString(result)
            Return result

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

#End Region

End Class
