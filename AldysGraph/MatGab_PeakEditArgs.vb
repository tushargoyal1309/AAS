Imports System
Imports System.Drawing

Namespace AldysGraph
	''' <summary>
	''' Summary description for PeakEditArgs.
	''' </summary>


	Public Class PeakEditArgs
		Inherits EventArgs
		Public ReadOnly X As Double
		Public ReadOnly Y As Double

		Public Sub New(x__1 As Double, y__2 As Double)
			X = x__1
			Y = y__2
		End Sub

	End Class

	Public Class CurveStatus
		Inherits EventArgs
		Public ReadOnly status As Integer


		Public Sub New(nstatus As Integer)
			status = nstatus
		End Sub

	End Class



	Public Enum PenStyles
		PS_SOLID = 0
		PS_DASH = 1
		PS_DOT = 2
		PS_DASHDOT = 3
		PS_DASHDOTDOT = 4
	End Enum

	Public Class RubberbandRectangle
		' These values come from the larger set of defines in WinGDI.h,
		' but are all that are needed for this application.  If this class
		' is expanded for more generic rectangle drawing, they should be
		' replaced by enums from those sets of defones.
		Private NULL_BRUSH As Integer = 5
		Private R2_XORPEN As Integer = 7
		Private m_penStyle As PenStyles
		Private BLACK_PEN As Integer = 0

		' Default contructor - sets member fields
		Public Sub New()
			m_penStyle = PenStyles.PS_DOT
		End Sub

		' penStyles property get/set.
		Public Property PenStyle() As PenStyles
			Get
				Return m_penStyle
			End Get
			Set
				m_penStyle = value
			End Set
		End Property

		Public Sub DrawXORRectangle(grp As Graphics, X1 As Integer, Y1 As Integer, X2 As Integer, Y2 As Integer)
			' Extract the Win32 HDC from the Graphics object supplied.
			Dim hdc As IntPtr = grp.GetHdc()

			' Create a pen with a dotted style to draw the border of the
			' rectangle.
			Dim gdiPen As IntPtr = CreatePen(m_penStyle, 1, BLACK_PEN)

			' Set the ROP cdrawint mode to XOR.
			SetROP2(hdc, R2_XORPEN)

			' Select the pen into the device context.
			Dim oldPen As IntPtr = SelectObject(hdc, gdiPen)

			' Create a stock NULL_BRUSH brush and select it into the device
			' context so that the rectangle isn't filled.
			Dim oldBrush As IntPtr = SelectObject(hdc, GetStockObject(NULL_BRUSH))

			' Now XOR the hollow rectangle on the Graphics object with
			' a dotted outline.
			Rectangle(hdc, X1, Y1, X2, Y2)

			' Put the old stuff back where it was.
			SelectObject(hdc, oldBrush)
			' no need to delete a stock object
			SelectObject(hdc, oldPen)
			DeleteObject(gdiPen)
			' but we do need to delete the pen
			' Return the device context to Windows.
			grp.ReleaseHdc(hdc)
		End Sub

		' Use Interop to call the corresponding Win32 GDI functions
		' Handle to a Win32 device context
		<System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")> _
		Private Shared Function SetROP2(hdc As IntPtr, enDrawMode As Integer) As Integer
			' Drawing mode
		End Function
		' Pen style from enum PenStyles
		' Width of pen
		<System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")> _
		Private Shared Function CreatePen(enPenStyle As PenStyles, nWidth As Integer, crColor As Integer) As IntPtr
			' Color of pen
		End Function
		<System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")> _
		Private Shared Function DeleteObject(hObject As IntPtr) As Boolean
			' Win32 GDI handle to object to delete
		End Function
		' Win32 GDI device context
		<System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")> _
		Private Shared Function SelectObject(hdc As IntPtr, hObject As IntPtr) As IntPtr
			' Win32 GDI handle to object to select
		End Function
		' Handle to a Win32 device context
		' x-coordinate of top left corner
		' y-cordinate of top left corner
		' x-coordinate of bottom right corner
		<System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")> _
		Private Shared Sub Rectangle(hdc As IntPtr, X1 As Integer, Y1 As Integer, X2 As Integer, Y2 As Integer)
			' y-coordinate of bottm right corner
		End Sub
		<System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")> _
		Private Shared Function GetStockObject(brStyle As Integer) As IntPtr
			' Selected from the WinGDI.h BrushStyles enum
		End Function

		' C# version of Win32 RGB macro
		Private Shared Function RGB(R As Integer, G As Integer, B As Integer) As Integer
			Return (R Or (G << 8) Or (B << 16))
		End Function
	End Class

End Namespace
