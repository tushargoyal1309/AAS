
namespace Signature
{
	[Serializable()]
	public class DigitalSignature
	{

		string mstrUserName = "";
		long mintUserID = 0;
		string mstrLoginPassword = "";
		string mstrFilePassword = "";
		DateTime mdtSaveDate;
		string mstrFileName = "";

		int mintActivityType = 0;
		//--- User Name 
		private string UserName {
			get { return mstrUserName; }
			set { mstrUserName = Value; }
		}

		//--- User ID 
		private long UserID {
			get { return mintUserID; }
			set { mintUserID = Value; }
		}

		//--- User Login Password 
		private string LoginPassword {
			get { return mstrLoginPassword; }
			set { mstrLoginPassword = Value; }
		}

		//--- File Password 
		private string FilePassword {
			get { return mstrFilePassword; }
			set { mstrFilePassword = Value; }
		}

		//--- File Save Date and Time
		private DateTime SaveDate {
			get { return mdtSaveDate; }
			set { mdtSaveDate = Value; }
		}

		//--- File Name
		private string FileName {
			get { return mstrFileName; }
			set { mstrFileName = Value; }
		}

		//--- Activity Type
		private int ActivityType {
			get { return mintActivityType; }
			set { mintActivityType = Value; }
		}

	}
}


