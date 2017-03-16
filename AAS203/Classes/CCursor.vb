Namespace Common
    ''this are the class for cursor wait.
    Friend Class CCursor
        Implements IDisposable

        Private saved As Cursor

        Public Sub New(ByVal newCursor As Cursor)
            saved = Cursor.Current
            Cursor.Current = newCursor
        End Sub

        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            Cursor.Current = saved
        End Sub

    End Class

    Friend Class CWaitCursor
        Inherits CCursor

        Sub New()
            MyBase.New(Cursors.WaitCursor)
        End Sub

    End Class

End Namespace

