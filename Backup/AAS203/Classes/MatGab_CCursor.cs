namespace Common
{
	//'this are the class for cursor wait.
	internal class CCursor : IDisposable
	{


		private Cursor saved;
		public CCursor(Cursor newCursor)
		{
			saved = Cursor.Current;
			Cursor.Current = newCursor;
		}

		public void IDisposable.Dispose()
		{
			Cursor.Current = saved;
		}

	}

	internal class CWaitCursor : CCursor
	{

		private CWaitCursor()
		{
			base.New(Cursors.WaitCursor);
		}

	}

}

