using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
public class clsHardwareLock_LPT
{

	#Region "DLL's"
	[DllImport("sentrydll5.dll")]
	private static int win_xread_nt95(ref Int16 rbuff, ref byte pass)
	{
		//Long
	}
	[DllImport("sentrydll5.dll")]
	private static int win_xwrite_nt95(ref Int16 rbuff, ref Int16 wbuff, ref byte pass)
	{
		//Long
	}
	#End Region

	#Region "Public Functions"

	public bool WriteHardwareKey(string strKey)
	{
		Int16[] rbuff = new Int16[10];
		Int16[] int16Signature = new Int16[10];
		Int32 int32TempSignature;

		Int32 temp;
		byte[] pass = new byte[2];
		int stat;
		byte[] strTemp = new byte[19];
		string strString;
		string[] strSignature = new string[22];

		char[] chrKey = new char[22];

		int i;
		int intCounter;

		for (intCounter = 0; intCounter <= 23; intCounter++) {
			chrKey(intCounter) = strKey.Chars(intCounter);
		}
		for (intCounter = 0; intCounter <= 23; intCounter += 2) {
			strSignature(intCounter / 2) = "&H" + Hex(Asc(chrKey(intCounter))) + Hex(Asc(chrKey(intCounter + 1)));
			int32TempSignature = (Int32)strSignature(intCounter / 2);

			if (int32TempSignature > 32767) {
				int16Signature(intCounter / 2) = int32TempSignature - 65536;
			} else {
				int16Signature(intCounter / 2) = int32TempSignature;
			}
		}

		pass(0) = 78;
		pass(1) = 80;
		pass(2) = 67;
		pass(3) = 72;

		for (i = 0; i <= 11; i++) {
			rbuff(i) = 0;
		}

		rbuff(0) = 21334;
		rbuff(1) = 13910;
		rbuff(2) = 17232;
		rbuff(3) = 18477;
		rbuff(4) = 22097;
		rbuff(5) = 14645;
		rbuff(6) = 11600;
		rbuff(7) = 13622;
		rbuff(8) = 19274;
		rbuff(9) = 13874;
		rbuff(10) = 8224;
		rbuff(11) = 8224;

		stat = win_xwrite_nt95(rbuff(0), int16Signature(0), pass(0));
		switch (stat) {
			case 0:
				//            Text5.Text = "Lock Found! Data written Successfully, the one assigned to Signature varibale!!!"
				gobjMessageAdapter.ShowMessage("Lock Found! Key set successfully!!!", "Hardware Lock Check", EnumMessageType.Information);
				return true;
			case -1:
				// Text5.Text = "Sentry Hardware Lock NOT installed OR the one installed is not bearing proper identity"
				//gFuncShowMessage("Hardware Lock Error", "Hardware lock not installed OR " & vbCrLf & " The installed one is not having proper identity", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage("Hardware lock not installed OR " + vbCrLf + " The installed one is not having proper identity", "Hardware Lock Error", EnumMessageType.Information);
				return false;
			case -2:
				//Text5.Text = "The Password you have issued is not matching with the one assigned for the Lock attached !"
				//gFuncShowMessage("Hardware Lock Error", "The Password you have issued is not matching with the one assigned for the Lock attached !", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage("The Password you have issued is not matching with the one assigned for the Lock attached !", "Hardware Lock Error", EnumMessageType.Information);
				return false;
			case -3:
				//Text5.Text = "Sentrymsp.vxd is not found in the current path  "
				//gFuncShowMessage("Hardware Lock Error", "Sentrymsp.vxd is not found in the current path  ", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage("Sentrymsp.vxd is not found in the current path  ", "Hardware Lock Error", EnumMessageType.Information);
				return false;
			case -5:
				//Text5.Text = "Sentry.sys is not started or not installed on the Win NT/2000 machine!"
				//gFuncShowMessage("Hardware Lock Error", "Sentry.sys is not started or not installed on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage("Sentry.sys is not started or not installed on the Win NT/2000 machine!", "Hardware Lock Error", EnumMessageType.Information);
				return false;
			case -6:
				//Text5.Text = " Sentry.sys could not close its operations on the Win NT/2000 machine!"
				//gFuncShowMessage("Hardware Lock Error", " Sentry.sys could not close its operations on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(" Sentry.sys could not close its operations on the Win NT/2000 machine!", "Hardware Lock Error", EnumMessageType.Information);
				return false;
			case -7:
				//Text5.Text = " The memory location index entered is out of range (0-29)!"
				//gFuncShowMessage("Hardware Lock Error", " The memory location index entered is out of range (0-29)!", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(" The memory location index entered is out of range (0-29)!", "Hardware Lock Error", EnumMessageType.Information);
				return false;
			case -8:
				//Text5.Text = " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !"
				//gFuncShowMessage("Hardware Lock Error", " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(" The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", "Hardware Lock Error", EnumMessageType.Information);
				return false;
			case -9:
				//Text5.Text = " Cannot work on Win3.1!"
				//gFuncShowMessage("Hardware Lock Error", " Cannot work on Win3.1!", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(" Cannot work on Win3.1!", "Hardware Lock Error", EnumMessageType.Information);
				return false;
			case -10:
				//Text5.Text = " The KEY passed with this function is not made for the lock attached to the machine !"
				//gFuncShowMessage("Hardware Lock Error", " The KEY passed with this function is not made for the lock attached to the machine !", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(" The KEY passed with this function is not made for the lock attached to the machine !", "Hardware Lock Error", EnumMessageType.Information);
				return false;
		}

	}

	public bool ReadHardwareKey(string strKey)
	{
		Int16[] rbuff = new Int16[10];
		Int16[] int16Signature = new Int16[10];
		Int32 int32TempSignature;

		Int32 temp;
		byte[] pass = new byte[2];
		int stat;
		//eger 'Long
		byte[] strTemp = new byte[19];
		string strString;
		string[] strSignature = new string[22];

		char[] chrKey = new char[22];

		int i;
		int intCounter;

		for (intCounter = 0; intCounter <= 23; intCounter++) {
			chrKey(intCounter) = strKey.Chars(intCounter);
		}
		for (intCounter = 0; intCounter <= 23; intCounter += 2) {
			strSignature(intCounter / 2) = "&H" + Hex(Asc(chrKey(intCounter))) + Hex(Asc(chrKey(intCounter + 1)));
			int32TempSignature = (Int32)strSignature(intCounter / 2);

			if (int32TempSignature > 32767) {
				int16Signature(intCounter / 2) = int32TempSignature - 65536;
			} else {
				int16Signature(intCounter / 2) = int32TempSignature;
			}
		}

		// Fill pass array with your password, which should be hex, refer keyxxxx.txt

		pass(0) = 78;
		pass(1) = 80;
		pass(2) = 67;
		pass(3) = 72;

		for (i = 0; i <= 11; i++) {
			rbuff(i) = 0;
		}

		//Fill rbuff with your  key (refer keyxxxx.txt)

		rbuff(0) = 21334;
		rbuff(1) = 13910;
		rbuff(2) = 17232;
		rbuff(3) = 18477;
		rbuff(4) = 22097;
		rbuff(5) = 14645;
		rbuff(6) = 11600;
		rbuff(7) = 13622;
		rbuff(8) = 19274;
		rbuff(9) = 13874;
		rbuff(10) = 8224;
		rbuff(11) = 8224;

		stat = win_xread_nt95(rbuff(0), pass(0));

		switch (stat) {
			case 0:

				for (i = 0; i <= 11; i++) {
					if ((rbuff(i) != int16Signature(i))) {
						i = 0;
						break; // TODO: might not be correct. Was : Exit For
					}
				}

				if ((i < 11)) {
					//gFuncShowMessage("Hardware Lock Error", "Lock Found! Data read from the lock is not matching with the one assigned to hardware key!", modConstants.EnumMessageType.Information)
					gobjMessageAdapter.ShowMessage("Lock Found! Data read from the lock is not matching with the one assigned to hardware key!", "Hardware Lock Error", EnumMessageType.Information);
					return false;
				} else {
					// gFuncShowMessage("Hardware Lock", "Lock Found! Data Read from the lock is matching with the one assigned to Signature varibale!!!", modConstants.EnumMessageType.Information)
					return true;

				}
			case -1:
				// Text5.Text = "Sentry Hardware Lock NOT installed OR the one installed is not bearing proper identity"
				//gFuncShowMessage("Hardware Lock Error", "Hardware Lock not installed OR the installed one is not bearing proper identity", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage("Hardware Lock not installed OR the installed one is not bearing proper identity", "Hardware Lock Error", EnumMessageType.Information);
				return false;
			case -2:
				//Text5.Text = "The Password you have issued is not matching with the one assigned for the Lock attached !"
				//gFuncShowMessage("Hardware Lock Error", "The Password you have issued is not matching with the one assigned for the Lock attached !", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage("The Password you have issued is not matching with the one assigned for the Lock attached !", "Hardware Lock Error", EnumMessageType.Information);
				return false;
			case -3:
				//Text5.Text = "Sentrymsp.vxd is not found in the current path  "
				//gFuncShowMessage("Hardware Lock Error", "Sentrymsp.vxd is not found in the current path  ", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage("Sentrymsp.vxd is not found in the current path  ", "Hardware Lock Error", EnumMessageType.Information);
				return false;
			case -5:
				//Text5.Text = "Sentry.sys is not started or not installed on the Win NT/2000 machine!"
				//gFuncShowMessage("Hardware Lock Error", "Sentry.sys is not started or not installed on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage("Sentry.sys is not started or not installed on the Win NT/2000 machine!", "Hardware Lock Error", EnumMessageType.Information);
				return false;
			case -6:
				//Text5.Text = " Sentry.sys could not close its operations on the Win NT/2000 machine!"
				//gFuncShowMessage("Hardware Lock Error", " Sentry.sys could not close its operations on the Win NT/2000 machine!", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(" Sentry.sys could not close its operations on the Win NT/2000 machine!", "Hardware Lock Error", EnumMessageType.Information);
				return false;
			case -7:
				//Text5.Text = " The memory location index entered is out of range (0-29)!"
				//gFuncShowMessage("Hardware Lock Error", " The memory location index entered is out of range (0-29)!", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(" The memory location index entered is out of range (0-29)!", "Hardware Lock Error", EnumMessageType.Information);
				return false;
			case -8:
				//Text5.Text = " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !"
				//gFuncShowMessage("Hardware Lock Error", " The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(" The Sentrymsp.vxd or sentry.sys found belongs to earlier  version, Update with the latest !", "Hardware Lock Error", EnumMessageType.Information);
				return false;
			case -9:
				//Text5.Text = " Cannot work on Win3.1!"
				//gFuncShowMessage("Hardware Lock Error", " Cannot work on Win3.1!", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(" Cannot work on Win3.1!", "Hardware Lock Error", EnumMessageType.Information);
				return false;
			case -10:
				//Text5.Text = " The KEY passed with this function is not made for the lock attached to the machine !"
				//gFuncShowMessage("Hardware Lock Error", " The KEY passed with this function is not made for the lock attached to the machine !", modConstants.EnumMessageType.Information)
				gobjMessageAdapter.ShowMessage(" The KEY passed with this function is not made for the lock attached to the machine !", "Hardware Lock Error", EnumMessageType.Information);
				return false;
		}


	}


	#End Region


}
