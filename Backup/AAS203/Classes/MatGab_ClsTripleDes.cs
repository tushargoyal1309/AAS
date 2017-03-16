using AAS203.Common;
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

public class TripleDES
{

	#Region " class variables "

	private byte[] key = {
		1,
		2,
		3,
		4,
		5,
		6,
		7,
		8,
		9,
		10,
		11,
		12,
		13,
		14,
		15,
		16,
		17,
		18,
		19,
		20,
		21,
		22,
		23,
		24
	};
	private byte[] iv = {
		65,
		110,
		68,
		26,
		69,
		178,
		200,
		219

	};
	#End Region

	#Region " String to Byte  encrypt-decrypt "

	public byte[] gfuncEncrypt(string plainText)
	{
		//=====================================================================
		// Procedure Name        : gfuncEncrypt
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To encrypt the given string to byte.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();

		try {
			// Declare a UTF8Encoding object so we may use the GetByte 
			// method to transform the plainText into a Byte array. 
			UTF8Encoding utf8encoder = new UTF8Encoding();
			byte[] inputInBytes = utf8encoder.GetBytes(plainText);

			// Create a new TripleDES service provider 
			TripleDESCryptoServiceProvider tdesProvider = new TripleDESCryptoServiceProvider();

			// The ICryptTransform interface uses the TripleDES 
			// crypt provider along with encryption key and init vector 
			// information 
			ICryptoTransform cryptoTransform = tdesProvider.CreateEncryptor(this.key, this.iv);

			// All cryptographic functions need a stream to output the 
			// encrypted information. Here we declare a memory stream 
			// for this purpose. 
			MemoryStream encryptedStream = new MemoryStream();
			CryptoStream cryptStream = new CryptoStream(encryptedStream, cryptoTransform, CryptoStreamMode.Write);

			// Write the encrypted information to the stream. Flush the information 
			// when done to ensure everything is out of the buffer. 
			cryptStream.Write(inputInBytes, 0, inputInBytes.Length);
			cryptStream.FlushFinalBlock();
			encryptedStream.Position = 0;

			// Read the stream back into a Byte array and return it to the calling 
			// method. 
			byte[] result = new byte[encryptedStream.Length - 2];
			encryptedStream.Read(result, 0, encryptedStream.Length);
			cryptStream.Close();
			return result;

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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	public string gfuncDecrypt(byte[] inputInBytes)
	{
		//=====================================================================
		// Procedure Name        : gfuncDecrypt
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To decrypt the bytes to string.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			// UTFEncoding is used to transform the decrypted Byte Array 
			// information back into a string. 
			UTF8Encoding utf8encoder = new UTF8Encoding();
			TripleDESCryptoServiceProvider tdesProvider = new TripleDESCryptoServiceProvider();

			// As before we must provide the encryption/decryption key along with 
			// the init vector. 
			ICryptoTransform cryptoTransform = tdesProvider.CreateDecryptor(this.key, this.iv);

			// Provide a memory stream to decrypt information into 
			MemoryStream decryptedStream = new MemoryStream();
			CryptoStream cryptStream = new CryptoStream(decryptedStream, cryptoTransform, CryptoStreamMode.Write);
			cryptStream.Write(inputInBytes, 0, inputInBytes.Length);
			cryptStream.FlushFinalBlock();
			decryptedStream.Position = 0;

			// Read the memory stream and convert it back into a string 
			byte[] result = new byte[decryptedStream.Length - 2];
			decryptedStream.Read(result, 0, decryptedStream.Length);
			cryptStream.Close();
			UTF8Encoding myutf = new UTF8Encoding();
			return myutf.GetString(result);
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	#End Region

	#Region " byte to byte encrypt-decrypt "

	public byte[] gfuncEncryptbyte(byte[] inputbyte)
	{
		//=====================================================================
		// Procedure Name        : frmAddUser_Load
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To encrypt the byte.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		try {
			// Declare a UTF8Encoding object so we may use the GetByte 
			// method to transform the plainText into a Byte array. 
			//Dim utf8encoder As UTF8Encoding = New UTF8Encoding
			//Dim inputInBytes() As Byte = utf8encoder.GetBytes(plainText)

			// Create a new TripleDES service provider 
			TripleDESCryptoServiceProvider tdesProvider = new TripleDESCryptoServiceProvider();

			// The ICryptTransform interface uses the TripleDES 
			// crypt provider along with encryption key and init vector 
			// information 
			ICryptoTransform cryptoTransform = tdesProvider.CreateEncryptor(this.key, this.iv);

			// All cryptographic functions need a stream to output the 
			// encrypted information. Here we declare a memory stream 
			// for this purpose. 
			MemoryStream encryptedStream = new MemoryStream();
			CryptoStream cryptStream = new CryptoStream(encryptedStream, cryptoTransform, CryptoStreamMode.Write);

			// Write the encrypted information to the stream. Flush the information 
			// when done to ensure everything is out of the buffer. 
			//cryptStream.Write(inputInBytes, 0, inputInBytes.Length)
			cryptStream.Write(inputbyte, 0, inputbyte.Length);
			cryptStream.FlushFinalBlock();
			encryptedStream.Position = 0;

			// Read the stream back into a Byte array and return it to the calling 
			// method. 
			byte[] result = new byte[encryptedStream.Length - 2];
			encryptedStream.Read(result, 0, encryptedStream.Length);
			cryptStream.Close();
			return result;
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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}


	}

	public byte[] gfuncDecryptbyte(byte[] inputInBytes)
	{
		//=====================================================================
		// Procedure Name        : gfuncDecryptbyte
		// Parameters Passed     : Object,EventArgs
		// Returns               : None
		// Purpose               : To decrypt the byte.
		// Description           : 
		// Assumptions           : 
		// Dependencies          : 
		// Author                : Saruabh S. 
		// Created               : Dec, 2006
		// Revisions             : 
		//=====================================================================
		CWaitCursor objWait = new CWaitCursor();
		// UTFEncoding is used to transform the decrypted Byte Array 
		// information back into a string. 
		UTF8Encoding utf8encoder = new UTF8Encoding();
		TripleDESCryptoServiceProvider tdesProvider = new TripleDESCryptoServiceProvider();

		// As before we must provide the encryption/decryption key along with 
		// the init vector. 
		ICryptoTransform cryptoTransform = tdesProvider.CreateDecryptor(this.key, this.iv);

		try {
			// Provide a memory stream to decrypt information into 
			MemoryStream decryptedStream = new MemoryStream();
			CryptoStream cryptStream = new CryptoStream(decryptedStream, cryptoTransform, CryptoStreamMode.Write);
			cryptStream.Write(inputInBytes, 0, inputInBytes.Length);
			cryptStream.FlushFinalBlock();
			decryptedStream.Position = 0;

			// Read the memory stream and convert it back into a string 
			byte[] result = new byte[decryptedStream.Length - 2];
			decryptedStream.Read(result, 0, decryptedStream.Length);
			cryptStream.Close();
			//Dim myutf As UTF8Encoding = New UTF8Encoding
			//Return myutf.GetString(result)
			return result;

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
			if (!objWait == null) {
				objWait.Dispose();
			}
			//---------------------------------------------------------
		}

	}

	#End Region

}
