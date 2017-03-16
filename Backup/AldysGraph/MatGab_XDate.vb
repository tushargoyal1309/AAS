Imports System

Namespace AldysGraph

	''' <summary>
	''' This struct encapsulates a date and time value, and handles associated
	''' calculations and conversions between various formats.
	''' </summary>
	Public Structure XDate
		Implements ICloneable
		' =========================================================================
		' Internal Variables
		' =========================================================================

		''' <summary>
		''' The actual date value in MS Excel format.  This is the only data field in
		''' the <see cref="XDate"/> struct.
		''' This format is in days since a reference date
		''' (XL date 1.0 is Jan 1, 1900 at 00:00 hrs).  Negative values are permissible, and the
		''' range of valid dates is from noon on January 1st, 4713 B.C. forward.  Internally, the
		''' date calculations are done using Astronomical Julian Day numbers.  The Astronomical Julian
		''' Day number is defined as the number of days since noon on January 1st, 4713 B.C.
		''' (also referred to as 12:00 on January 1, -4712).
		''' </summary>
		Private m_xlDate As Double

		''' <summary>
		''' The Astronomical Julian Day number that corresponds to XL Date 0.0
		''' </summary>
		Public Const XLDay1 As Double = 2415018.5
		''' <summary>
		''' The number of months in a year
		''' </summary>
		Public Const MonthsPerYear As Double = 12.0
		''' <summary>
		''' The number of hours in a day
		''' </summary>
		Public Const HoursPerDay As Double = 24.0
		''' <summary>
		''' The number of minutes in an hour
		''' </summary>
		Public Const MinutesPerHour As Double = 60.0
		''' <summary>
		''' The number of seconds in a minute
		''' </summary>
		Public Const SecondsPerMinute As Double = 60.0
		''' <summary>
		''' The number of minutes in a day
		''' </summary>
		Public Const MinutesPerDay As Double = 1440.0
		''' <summary>
		''' The number of seconds in a day
		''' </summary>
		Public Const SecondsPerDay As Double = 86400.0
		''' <summary>
		''' The default format string to be used in <see cref="ToString"/> when
		''' no format is provided
		''' </summary>
		Public Const DefaultFormatStr As String = "&d-&mmm-&yy &hh:&nn"

		' =========================================================================
		' Construtors
		' =========================================================================

		''' <summary>
		''' Construct a date class from an XL date value.
		''' </summary>
		''' <param name="xlDate">
		''' An XL Date value in floating point double format
		''' </param>
		Public Sub New(xlDate As Double)
			Me.m_xlDate = xlDate
		End Sub

		''' <summary>
		''' Construct a date class from a calendar date (year, month, day).  Assumes the time
		''' of day is 00:00 hrs
		''' </summary>
		''' <param name="year">An integer value for the year, e.g., 1995.</param>
		''' <param name="day">An integer value for the day of the month, e.g., 23.
		''' It is permissible to have day numbers outside of the 1-31 range,
		''' which will rollover to the previous or next month and year.</param>
		''' <param name="month">An integer value for the month of the year, e.g.,
		''' 8 for August.  It is permissible to have months outside of the 1-12 range,
		''' which will rollover to the previous or next year.</param>
		Public Sub New(year As Integer, month As Integer, day As Integer)
			m_xlDate = CalendarDateToXLDate(year, month, day, 0, 0, 0)
		End Sub

		''' <summary>
		''' Construct a date class from a calendar date and time (year, month, day, hour, minute,
		''' second). 
		''' </summary>
		''' <param name="year">An integer value for the year, e.g., 1995.</param>
		''' <param name="day">An integer value for the day of the month, e.g., 23.
		''' It is permissible to have day numbers outside of the 1-31 range,
		''' which will rollover to the previous or next month and year.</param>
		''' <param name="month">An integer value for the month of the year, e.g.,
		''' 8 for August.  It is permissible to have months outside of the 1-12 range,
		''' which will rollover to the previous or next year.</param>
		''' <param name="hour">An integer value for the hour of the day, e.g. 15.
		''' It is permissible to have hour values outside the 0-23 range, which
		''' will rollover to the previous or next day.</param>
		''' <param name="minute">An integer value for the minute, e.g. 45.
		''' It is permissible to have hour values outside the 0-59 range, which
		''' will rollover to the previous or next hour.</param>
		''' <param name="second">An integer value for the second, e.g. 35.
		''' It is permissible to have second values outside the 0-59 range, which
		''' will rollover to the previous or next minute.</param>
		Public Sub New(year As Integer, month As Integer, day As Integer, hour As Integer, minute As Integer, second As Integer)
			m_xlDate = CalendarDateToXLDate(year, month, day, hour, minute, second)
		End Sub

		''' <summary>
		''' The Copy Constructor
		''' </summary>
		''' <param name="rhs">The AldysPane object from which to copy</param>
		Public Sub New(rhs As XDate)
			m_xlDate = rhs.xlDate
		End Sub

		''' <summary>
		''' Deep-copy clone routine
		''' </summary>
		''' <returns>A new, independent copy of the XDate</returns>
		Public Function Clone() As Object
			Return New XDate(Me)
		End Function

		' =========================================================================
		' Properties
		' =========================================================================

		''' <summary>
		''' Gets or sets the date value for this item in MS Excel format.
		''' </summary>
		Public Property XLDate() As Double
			Get
				Return m_xlDate
			End Get
			Set
				m_xlDate = value
			End Set
		End Property

		''' <summary>
		''' Gets or sets the date value for this item in .Net DateTime format.
		''' </summary>
		Public Property DateTime() As DateTime
			Get
				Return XLDateToDateTime(Me.m_xlDate)
			End Get
			Set
				Me.m_xlDate = DateTimeToXLDate(value)
			End Set
		End Property

		''' <summary>
		''' Gets or sets the date value for this item in Julain day format.  This is the
		''' Astronomical Julian Day number, so a value of 0.0 corresponds to noon GMT on
		''' January 1st, -4712.  Thus, Julian Day number 2,400,000.0 corresponds to
		''' noon GMT on November 16, 1858.
		''' </summary>
		Public Property JulianDay() As Double
			Get
				Return XLDateToJulianDay(m_xlDate)
			End Get
			Set
				m_xlDate = JulianDayToXLDate(value)
			End Set
		End Property

		''' <summary>
		''' Gets or sets the decimal year number (i.e., 1997.345) corresponding to this item.
		''' </summary>
		Public Property DecimalYear() As Double
			Get
				Return XLDateToDecimalYear(m_xlDate)
			End Get
			Set
				m_xlDate = DecimalYearToXLDate(value)
			End Set
		End Property

		''' <summary>
		''' Get the calendar date (year, month, day) corresponding to this instance.
		''' </summary>
		''' <param name="year">An integer value for the year, e.g., 1995.</param>
		''' <param name="day">An integer value for the day of the month, e.g., 23.</param>
		''' <param name="month">An integer value for the month of the year, e.g.,
		''' 8 for August.</param>
		Public Sub GetDate(ByRef year As Integer, ByRef month As Integer, ByRef day As Integer)
			Dim hour As Integer, minute As Integer, second As Integer

			XLDateToCalendarDate(m_xlDate, year, month, day, hour, minute, _
				second)
		End Sub

		''' <summary>
		''' Set the calendar date (year, month, day) of this instance.
		''' </summary>
		''' <param name="year">An integer value for the year, e.g., 1995.</param>
		''' <param name="day">An integer value for the day of the month, e.g., 23.</param>
		''' <param name="month">An integer value for the month of the year, e.g.,
		''' 8 for August.</param>
		Public Sub SetDate(year As Integer, month As Integer, day As Integer)
			m_xlDate = CalendarDateToXLDate(year, month, day, 0, 0, 0)
		End Sub

		''' <summary>
		''' Get the calendar date (year, month, day, hour, minute, second) corresponding
		''' to this instance.
		''' </summary>
		''' <param name="year">An integer value for the year, e.g., 1995.</param>
		''' <param name="day">An integer value for the day of the month, e.g., 23.</param>
		''' <param name="month">An integer value for the month of the year, e.g.,
		''' 8 for August.</param>
		''' <param name="hour">An integer value for the hour of the day, e.g. 15.</param>
		''' <param name="minute">An integer value for the minute, e.g. 45.</param>
		''' <param name="second">An integer value for the second, e.g. 35.</param>
		Public Sub GetDate(ByRef year As Integer, ByRef month As Integer, ByRef day As Integer, ByRef hour As Integer, ByRef minute As Integer, ByRef second As Integer)
			XLDateToCalendarDate(m_xlDate, year, month, day, hour, minute, _
				second)
		End Sub

		''' <summary>
		''' Set the calendar date (year, month, day, hour, minute, second) of this instance.
		''' </summary>
		''' <param name="year">An integer value for the year, e.g., 1995.</param>
		''' <param name="day">An integer value for the day of the month, e.g., 23.</param>
		''' <param name="month">An integer value for the month of the year, e.g.,
		''' 8 for August.</param>
		''' <param name="hour">An integer value for the hour of the day, e.g. 15.</param>
		''' <param name="minute">An integer value for the minute, e.g. 45.</param>
		''' <param name="second">An integer value for the second, e.g. 35.</param>
		Public Sub SetDate(year As Integer, month As Integer, day As Integer, hour As Integer, minute As Integer, second As Integer)
			m_xlDate = CalendarDateToXLDate(year, month, day, hour, minute, second)
		End Sub

		''' <summary>
		''' Get the day of year value (241.345 means the 241st day of the year)
		''' corresponding to this instance.
		''' </summary>
		''' <returns>The day of the year in floating point double format.</returns>
		Public Function GetDayOfYear() As Double
			Return XLDateToDayOfYear(m_xlDate)
		End Function

		' =========================================================================
		' Conversion Routines
		' =========================================================================

		''' <summary>
		''' Calculate an XL Date from the specified Calendar date (year, month, day, hour, minute, second),
		''' first normalizing all input data values
		''' </summary>
		''' <param name="year">
		''' The integer year value (e.g., 1994).
		''' </param>
		''' <param name="month">
		''' The integer month value (e.g., 7 for July).
		''' </param>
		''' <param name="day">
		''' The integer day value (e.g., 19 for the 19th day of the month).
		''' </param>
		''' <param name="hour">
		''' The integer hour value (e.g., 14 for 2:00 pm).
		''' </param>
		''' <param name="minute">
		''' The integer minute value (e.g., 35 for 35 minutes past the hour).
		''' </param>
		''' <param name="second">
		''' The integer second value (e.g., 42 for 42 seconds past the minute).
		''' </param>
		''' <returns>The corresponding XL date, expressed in double floating point format</returns>
		Public Shared Function CalendarDateToXLDate(year As Integer, month As Integer, day As Integer, hour As Integer, minute As Integer, second As Integer) As Double
			' Normalize the data to allow for negative and out of range values
			' In this way, setting month to zero would be December of the previous year,
			' setting hour to 24 would be the first hour of the next day, etc.

			NormalizeCalendarDate(year, month, day, hour, minute, second)

			Return _CalendarDateToXLDate(year, month, day, hour, minute, second)
		End Function

		''' <summary>
		''' Calculate an Astronomical Julian Day number from the specified Calendar date
		''' (year, month, day, hour, minute, second), first normalizing all input data values
		''' </summary>
		''' <param name="year">
		''' The integer year value (e.g., 1994).
		''' </param>
		''' <param name="month">
		''' The integer month value (e.g., 7 for July).
		''' </param>
		''' <param name="day">
		''' The integer day value (e.g., 19 for the 19th day of the month).
		''' </param>
		''' <param name="hour">
		''' The integer hour value (e.g., 14 for 2:00 pm).
		''' </param>
		''' <param name="minute">
		''' The integer minute value (e.g., 35 for 35 minutes past the hour).
		''' </param>
		''' <param name="second">
		''' The integer second value (e.g., 42 for 42 seconds past the minute).
		''' </param>
		''' <returns>The corresponding Astronomical Julian Day number, expressed in double
		''' floating point format</returns>
		Public Shared Function CalendarDateToJulianDay(year As Integer, month As Integer, day As Integer, hour As Integer, minute As Integer, second As Integer) As Double
			' Normalize the data to allow for negative and out of range values
			' In this way, setting month to zero would be December of the previous year,
			' setting hour to 24 would be the first hour of the next day, etc.

			NormalizeCalendarDate(year, month, day, hour, minute, second)

			Return _CalendarDateToJulianDay(year, month, day, hour, minute, second)
		End Function

		''' <summary>
		''' Normalize a set of Calendar date values (year, month, day, hour, minute, second) to make sure
		''' that month is between 1 and 12, hour is between 0 and 23, etc.
		''' </summary>
		''' <param name="year">
		''' The integer year value (e.g., 1994).
		''' </param>
		''' <param name="month">
		''' The integer month value (e.g., 7 for July).
		''' </param>
		''' <param name="day">
		''' The integer day value (e.g., 19 for the 19th day of the month).
		''' </param>
		''' <param name="hour">
		''' The integer hour value (e.g., 14 for 2:00 pm).
		''' </param>
		''' <param name="minute">
		''' The integer minute value (e.g., 35 for 35 minutes past the hour).
		''' </param>
		''' <param name="second">
		''' The integer second value (e.g., 42 for 42 seconds past the minute).
		''' </param>
		Private Shared Sub NormalizeCalendarDate(ByRef year As Integer, ByRef month As Integer, ByRef day As Integer, ByRef hour As Integer, ByRef minute As Integer, ByRef second As Integer)
			' Normalize the data to allow for negative and out of range values
			' In this way, setting month to zero would be December of the previous year,
			' setting hour to 24 would be the first hour of the next day, etc.

			' Normalize the seconds and carry over to minutes
			Dim carry As Integer = DirectCast(Math.Floor(DirectCast(second, Double) / SecondsPerMinute), Integer)
			second -= carry * DirectCast(SecondsPerMinute, Integer)
			minute += carry

			' Normalize the minutes and carry over to hours
			carry = DirectCast(Math.Floor(DirectCast(minute, Double) / MinutesPerHour), Integer)
			minute -= carry * DirectCast(MinutesPerHour, Integer)
			hour += carry

			' Normalize the hours and carry over to days
			carry = DirectCast(Math.Floor(DirectCast(hour, Double) / HoursPerDay), Integer)
			hour -= carry * DirectCast(HoursPerDay, Integer)
			day += carry

			' Normalize the months and carry over to years
			carry = DirectCast(Math.Floor(DirectCast(month, Double) / MonthsPerYear), Integer)
			month -= carry * DirectCast(MonthsPerYear, Integer)
			year += carry
		End Sub

		''' <summary>
		''' Calculate an XL date from the specified Calendar date (year, month, day, hour, minute, second).
		''' This is the internal trusted version, where all values are assumed to be legitimate
		''' ( month is between 1 and 12, minute is between 0 and 59, etc. )
		''' </summary>
		''' <param name="year">
		''' The integer year value (e.g., 1994).
		''' </param>
		''' <param name="month">
		''' The integer month value (e.g., 7 for July).
		''' </param>
		''' <param name="day">
		''' The integer day value (e.g., 19 for the 19th day of the month).
		''' </param>
		''' <param name="hour">
		''' The integer hour value (e.g., 14 for 2:00 pm).
		''' </param>
		''' <param name="minute">
		''' The integer minute value (e.g., 35 for 35 minutes past the hour).
		''' </param>
		''' <param name="second">
		''' The integer second value (e.g., 42 for 42 seconds past the minute).
		''' </param>
		''' <returns>The corresponding XL date, expressed in double floating point format</returns>
		Private Shared Function _CalendarDateToXLDate(year As Integer, month As Integer, day As Integer, hour As Integer, minute As Integer, second As Integer) As Double
			Return JulianDayToXLDate(_CalendarDateToJulianDay(year, month, day, hour, minute, second))
		End Function

		''' <summary>
		''' Calculate an Astronomical Julian Day Number from the specified Calendar date
		''' (year, month, day, hour, minute, second).
		''' This is the internal trusted version, where all values are assumed to be legitimate
		''' ( month is between 1 and 12, minute is between 0 and 59, etc. )
		''' </summary>
		''' <param name="year">
		''' The integer year value (e.g., 1994).
		''' </param>
		''' <param name="month">
		''' The integer month value (e.g., 7 for July).
		''' </param>
		''' <param name="day">
		''' The integer day value (e.g., 19 for the 19th day of the month).
		''' </param>
		''' <param name="hour">
		''' The integer hour value (e.g., 14 for 2:00 pm).
		''' </param>
		''' <param name="minute">
		''' The integer minute value (e.g., 35 for 35 minutes past the hour).
		''' </param>
		''' <param name="second">
		''' The integer second value (e.g., 42 for 42 seconds past the minute).
		''' </param>
		''' <returns>The corresponding Astronomical Julian Day number, expressed in double
		''' floating point format</returns>
		Private Shared Function _CalendarDateToJulianDay(year As Integer, month As Integer, day As Integer, hour As Integer, minute As Integer, second As Integer) As Double
			' Taken from http://www.srrb.noaa.gov/highlights/sunrise/program.txt
			' routine calcJD()

			If month <= 2 Then
				year -= 1
				month += 12
			End If

			Dim A As Double = Math.Floor(DirectCast(year, Double) / 100.0)
			Dim B As Double = 2 - A + Math.Floor(A / 4.0)

			Return Math.Floor(365.25 * (DirectCast(year, Double) + 4716.0)) + Math.Floor(30.6001 * DirectCast(month + 1, Double)) + DirectCast(day, Double) + B - 1524.5 + hour / HoursPerDay + minute / MinutesPerDay + second / SecondsPerDay

		End Function

		''' <summary>
		''' Calculate a Calendar date (year, month, day, hour, minute, second) corresponding to
		''' the specified XL date
		''' </summary>
		''' <param name="xlDate">
		''' The XL date value in floating point double format.
		''' </param>
		''' <param name="year">
		''' The integer year value (e.g., 1994).
		''' </param>
		''' <param name="month">
		''' The integer month value (e.g., 7 for July).
		''' </param>
		''' <param name="day">
		''' The integer day value (e.g., 19 for the 19th day of the month).
		''' </param>
		''' <param name="hour">
		''' The integer hour value (e.g., 14 for 2:00 pm).
		''' </param>
		''' <param name="minute">
		''' The integer minute value (e.g., 35 for 35 minutes past the hour).
		''' </param>
		''' <param name="second">
		''' The integer second value (e.g., 42 for 42 seconds past the minute).
		''' </param>
		Public Shared Sub XLDateToCalendarDate(xlDate As Double, ByRef year As Integer, ByRef month As Integer, ByRef day As Integer, ByRef hour As Integer, ByRef minute As Integer, _
			ByRef second As Integer)
			Dim jDay As Double = XLDateToJulianDay(xlDate)

			JulianDayToCalendarDate(jDay, year, month, day, hour, minute, _
				second)
		End Sub

		''' <summary>
		''' Calculate a Calendar date (year, month, day, hour, minute, second) corresponding to
		''' the Astronomical Julian Day number
		''' </summary>
		''' <param name="jDay">
		''' The Astronomical Julian Day number to be converted
		''' </param>
		''' <param name="year">
		''' The integer year value (e.g., 1994).
		''' </param>
		''' <param name="month">
		''' The integer month value (e.g., 7 for July).
		''' </param>
		''' <param name="day">
		''' The integer day value (e.g., 19 for the 19th day of the month).
		''' </param>
		''' <param name="hour">
		''' The integer hour value (e.g., 14 for 2:00 pm).
		''' </param>
		''' <param name="minute">
		''' The integer minute value (e.g., 35 for 35 minutes past the hour).
		''' </param>
		''' <param name="second">
		''' The integer second value (e.g., 42 for 42 seconds past the minute).
		''' </param>
		Public Shared Sub JulianDayToCalendarDate(jDay As Double, ByRef year As Integer, ByRef month As Integer, ByRef day As Integer, ByRef hour As Integer, ByRef minute As Integer, _
			ByRef second As Integer)
			Dim z As Double = Math.Floor(jDay + 0.5)
			Dim f As Double = jDay + 0.5 - z

			Dim alpha As Double = Math.Floor((z - 1867216.25) / 36524.25)
			Dim A As Double = z + 1.0 + alpha - Math.Floor(alpha / 4)
			Dim B As Double = A + 1524.0
			Dim C As Double = Math.Floor((B - 122.1) / 365.25)
			Dim D As Double = Math.Floor(365.25 * C)
			Dim E As Double = Math.Floor((B - D) / 30.6001)

			day = DirectCast(Math.Floor(B - D - Math.Floor(30.6001 * E) + f), Integer)
			month = DirectCast(If((E < 14.0), E - 1.0, E - 13.0), Integer)
			year = DirectCast(If((month > 2), C - 4716, C - 4715), Integer)

			' add a half-second to the time fraction to avoid roundoff errors
			Dim fday As Double = (jDay - 0.5) - Math.Floor(jDay - 0.5) + 0.5 / SecondsPerDay

			fday = (fday - DirectCast(fday, Long)) * HoursPerDay
			hour = DirectCast(fday, Integer)
			fday = (fday - DirectCast(fday, Long)) * MinutesPerHour
			minute = DirectCast(fday, Integer)
			fday = (fday - DirectCast(fday, Long)) * SecondsPerMinute
			second = DirectCast(fday, Integer)

		End Sub

		''' <summary>
		''' Calculate an Astronomical Julian Day number corresponding to the specified XL date
		''' </summary>
		''' <param name="xlDate">
		''' The XL date value in floating point double format.
		''' </param>
		''' <returns>The corresponding Astronomical Julian Day number, expressed in double
		''' floating point format</returns>
		Public Shared Function XLDateToJulianDay(xlDate As Double) As Double
			Return xlDate + XLDay1
		End Function

		''' <summary>
		''' Calculate an XL Date corresponding to the specified Astronomical Julian Day number
		''' </summary>
		''' <param name="jDay">
		''' The Astronomical Julian Day number in floating point double format.
		''' </param>
		''' <returns>The corresponding XL Date, expressed in double
		''' floating point format</returns>
		Public Shared Function JulianDayToXLDate(jDay As Double) As Double
			Return jDay - XLDay1
		End Function

		''' <summary>
		''' Calculate a decimal year value (e.g., 1994.6523) corresponding to the specified XL date
		''' </summary>
		''' <param name="xlDate">
		''' The XL date value in floating point double format.
		''' </param>
		''' <returns>The corresponding decimal year value, expressed in double
		''' floating point format</returns>
		Public Shared Function XLDateToDecimalYear(xlDate As Double) As Double
			Dim year As Integer, month As Integer, day As Integer, hour As Integer, minute As Integer, second As Integer

			XLDateToCalendarDate(xlDate, year, month, day, hour, minute, _
				second)

			Dim jDay1 As Double = CalendarDateToJulianDay(year, 1, 1, 0, 0, 0)
			Dim jDay2 As Double = CalendarDateToJulianDay(year + 1, 1, 1, 0, 0, 0)
			Dim jDayMid As Double = CalendarDateToJulianDay(year, month, day, hour, minute, second)


			Return DirectCast(year, Double) + (jDayMid - jDay1) / (jDay2 - jDay1)
		End Function

		''' <summary>
		''' Calculate a decimal year value (e.g., 1994.6523) corresponding to the specified XL date
		''' </summary>
		''' <param name="yearDec">
		''' The decimal year value in floating point double format.
		''' </param>
		''' <returns>The corresponding XL Date, expressed in double
		''' floating point format</returns>
		Public Shared Function DecimalYearToXLDate(yearDec As Double) As Double
			Dim year As Integer = DirectCast(yearDec, Integer)

			Dim jDay1 As Double = CalendarDateToJulianDay(year, 1, 1, 0, 0, 0)
			Dim jDay2 As Double = CalendarDateToJulianDay(year + 1, 1, 1, 0, 0, 0)

			Return JulianDayToXLDate((yearDec - DirectCast(year, Double)) * (jDay2 - jDay1) + jDay1)
		End Function

		''' <summary>
		''' Calculate a day-of-year value (e.g., 241.543 corresponds to the 241st day of the year)
		''' corresponding to the specified XL date
		''' </summary>
		''' <param name="xlDate">
		''' The XL date value in floating point double format.
		''' </param>
		''' <returns>The corresponding day-of-year (DoY) value, expressed in double
		''' floating point format</returns>
		Public Shared Function XLDateToDayOfYear(xlDate As Double) As Double
			Dim year As Integer, month As Integer, day As Integer, hour As Integer, minute As Integer, second As Integer
			XLDateToCalendarDate(xlDate, year, month, day, hour, minute, _
				second)
			Return XLDateToJulianDay(xlDate) - CalendarDateToJulianDay(year, 1, 1, 0, 0, 0) + 1.0
		End Function

		''' <summary>
		''' Calculate a day-of-week value (e.g., Sun=0, Mon=1, Tue=2, etc.)
		''' corresponding to the specified XL date
		''' </summary>
		''' <param name="xlDate">
		''' The XL date value in floating point double format.
		''' </param>
		''' <returns>The corresponding day-of-week (DoW) value, expressed in integer format</returns>
		Public Shared Function XLDateToDayOfWeek(xlDate As Double) As Integer
			Return DirectCast(XLDateToJulianDay(xlDate) + 1.5, Integer) Mod 7
		End Function

		''' <summary>
		''' Convert an XL date format to a .Net DateTime struct
		''' </summary>
		''' <param name="xlDate">
		''' The XL date value in floating point double format.
		''' </param>
		''' <returns>The corresponding XL Date, expressed in double
		''' floating point format</returns>
		''' <returns>The corresponding date in the form of a .Net DateTime struct</returns>
		Public Shared Function XLDateToDateTime(xlDate As Double) As DateTime
			Dim year As Integer, month As Integer, day As Integer, hour As Integer, minute As Integer, second As Integer
			XLDateToCalendarDate(xlDate, year, month, day, hour, minute, _
				second)
			Return New DateTime(year, month, day, hour, minute, second)
		End Function

		''' <summary>
		''' Convert a .Net DateTime struct to an XL Format date
		''' </summary>
		''' <param name="dt">
		''' The date value in the form of a .Net DateTime struct
		''' </param>
		''' <returns>The corresponding XL Date, expressed in double
		''' floating point format</returns>
		Public Shared Function DateTimeToXLDate(dt As DateTime) As Double
			Return CalendarDateToXLDate(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second)
		End Function

		' =========================================================================
		' Math Routines
		' =========================================================================

		''' <summary>
		''' Add the specified number of seconds (can be fractional) to the current XDate instance.
		''' </summary>
		''' <param name="dSeconds">
		''' The incremental number of seconds (negative or positive) in floating point double format.
		''' </param>
		Public Sub AddSeconds(dSeconds As Double)
			Me.m_xlDate += dSeconds / 86400.0
		End Sub

		''' <summary>
		''' Add the specified number of minutes (can be fractional) to the current XDate instance.
		''' </summary>
		''' <param name="dMinutes">
		''' The incremental number of minutes (negative or positive) in floating point double format.
		''' </param>
		Public Sub AddMinutes(dMinutes As Double)
			Me.m_xlDate += dMinutes / 1440.0
		End Sub

		''' <summary>
		''' Add the specified number of hours (can be fractional) to the current XDate instance.
		''' </summary>
		''' <param name="dHours">
		''' The incremental number of hours (negative or positive) in floating point double format.
		''' </param>
		Public Sub AddHours(dHours As Double)
			Me.m_xlDate += dHours / HoursPerDay
		End Sub

		''' <summary>
		''' Add the specified number of days (can be fractional) to the current XDate instance.
		''' </summary>
		''' <param name="dDays">
		''' The incremental number of days (negative or positive) in floating point double format.
		''' </param>
		Public Sub AddDays(dDays As Double)
			Me.m_xlDate += dDays
		End Sub

		''' <summary>
		''' Add the specified number of Months (can be fractional) to the current XDate instance.
		''' </summary>
		''' <param name="dMonths">
		''' The incremental number of months (negative or positive) in floating point double format.
		''' </param>
		Public Sub AddMonths(dMonths As Double)
			Dim iMon As Integer = DirectCast(dMonths, Integer)
			Dim monFrac As Double = Math.Abs(dMonths - DirectCast(iMon, Double))
			Dim sMon As Integer = Math.Sign(dMonths)

			Dim year As Integer, month As Integer, day As Integer, hour As Integer, minute As Integer, second As Integer

			XLDateToCalendarDate(Me.m_xlDate, year, month, day, hour, minute, _
				second)
			If iMon <> 0 Then
				month += iMon
				Me.m_xlDate = CalendarDateToXLDate(year, month, day, hour, minute, second)
			End If

			If sMon <> 0 Then
				Dim xlDate2 As Double = CalendarDateToXLDate(year, month + sMon, day, hour, minute, second)
				Me.m_xlDate += (xlDate2 - Me.m_xlDate) * monFrac
			End If
		End Sub

		''' <summary>
		''' Add the specified number of years (can be fractional) to the current XDate instance.
		''' </summary>
		''' <param name="dYears">
		''' The incremental number of years (negative or positive) in floating point double format.
		''' </param>
		Public Sub AddYears(dYears As Double)
			Dim iYear As Integer = DirectCast(dYears, Integer)
			Dim yearFrac As Double = Math.Abs(dYears - DirectCast(iYear, Double))
			Dim sYear As Integer = Math.Sign(dYears)

			Dim year As Integer, month As Integer, day As Integer, hour As Integer, minute As Integer, second As Integer

			XLDateToCalendarDate(Me.m_xlDate, year, month, day, hour, minute, _
				second)
			If iYear <> 0 Then
				year += iYear
				Me.m_xlDate = CalendarDateToXLDate(year, month, day, hour, minute, second)
			End If

			If sYear <> 0 Then
				Dim xlDate2 As Double = CalendarDateToXLDate(year + sYear, month, day, hour, minute, second)
				Me.m_xlDate += (xlDate2 - Me.m_xlDate) * yearFrac
			End If
		End Sub

		' =========================================================================
		' Operator Overloads
		' =========================================================================

		''' <summary>
		''' '-' operator overload.  When two XDates are subtracted, the number of days between dates
		''' is returned.
		''' </summary>
		''' <param name="lhs">The left-hand-side of the '-' operator (an XDate class)</param>
		''' <param name="rhs">The right-hand-side of the '-' operator (an XDate class)</param>
		''' <returns>The days between dates, expressed as a floating point double</returns>
		Public Shared Operator -(lhs As XDate, rhs As XDate) As Double
			Return lhs.XLDate - rhs.XLDate
		End Operator

		''' <summary>
		''' '-' operator overload.  When a double value is subtracted from an XDate, the result is a
		''' new XDate with the number of days subtracted.
		''' </summary>
		''' <param name="lhs">The left-hand-side of the '-' operator (an XDate class)</param>
		''' <param name="rhs">The right-hand-side of the '-' operator (a double value)</param>
		''' <returns>An XDate with the rhs number of days subtracted</returns>
		Public Shared Operator -(lhs As XDate, rhs As Double) As XDate
			lhs.xlDate -= rhs
			Return lhs
		End Operator

		''' <summary>
		''' '+' operator overload.  When a double value is added to an XDate, the result is a
		''' new XDate with the number of days added.
		''' </summary>
		''' <param name="lhs">The left-hand-side of the '-' operator (an XDate class)</param>
		''' <param name="rhs">The right-hand-side of the '+' operator (a double value)</param>
		''' <returns>An XDate with the rhs number of days added</returns>
		Public Shared Operator +(lhs As XDate, rhs As Double) As XDate
			lhs.xlDate += rhs
			Return lhs
		End Operator

		''' <summary>
		''' '++' operator overload.  Increment the date by one day.
		''' </summary>
		''' <param name="xDate">The XDate struct on which to operate</param>
		''' <returns>An XDate one day later than the specified date</returns>
		Public Shared Operator (xDate As XDate) As XDate
			xDate.xlDate += 1.0
			Return xDate
		End Operator

		''' <summary>
		''' '--' operator overload.  Decrement the date by one day.
		''' </summary>
		''' <param name="xDate">The XDate struct on which to operate</param>
		''' <returns>An XDate one day prior to the specified date</returns>
		Public Shared Operator (xDate As XDate) As XDate
			xDate.xlDate -= 1.0
			Return xDate
		End Operator

		''' <summary>
		''' Implicit conversion from XDate to double (an XL Date).
		''' </summary>
		''' <param name="xDate">The XDate struct on which to operate</param>
		''' <returns>A double floating point value representing the XL Date</returns>
		Public Shared Widening Operator CType(xDate As XDate) As Double
			Return xDate.xlDate
		End Operator

		' =========================================================================
		' System Stuff
		' =========================================================================

		''' <summary>
		''' Tests whether <param>obj</param> is either an <see cref="XDate"/> structure or
		''' a double floating point value that is equal to the same date as this <c>XDate</c>
		''' struct instance.
		''' </summary>
		''' <param name="obj">The object to compare for equality with this XDate instance.
		''' This object should be either a type XDate or type double.</param>
		''' <returns>Returns <c>true</c> if <param>obj</param> is the same date as this
		''' instance; otherwise, <c>false</c></returns>
		Public Overrides Function Equals(obj As Object) As Boolean
			If TypeOf obj Is XDate Then
				Return DirectCast(obj, XDate).xlDate = Me.m_xlDate
			ElseIf TypeOf obj Is Double Then
				Return DirectCast(obj, Double) = Me.m_xlDate
			Else
				Return False
			End If
		End Function

		''' <summary>
		''' Returns the hash code for this <see cref="XDate"/> structure.  In this case, the
		''' hash code is simply the equivalent hash code for the floating point double date value.
		''' </summary>
		''' <returns>An integer representing the hash code for this XDate value</returns>
		Public Overrides Function GetHashCode() As Integer
			Return Me.m_xlDate.GetHashCode()
		End Function

		' =========================================================================
		' String Formatting Routines
		' =========================================================================

		''' <summary>
		''' Format this XDate value using the default format string (see cref="DefaultFormatStr"/>).
		''' </summary>
		''' <param name="xlDate">
		''' The XL date value to be formatted in floating point double format.
		''' </param>
		''' <returns>A string representation of the date</returns>
		Public Function ToString(xlDate As Double) As String
			Return ToString(xlDate, DefaultFormatStr)
		End Function

		''' <summary>
		''' Format this XDate value using the default format string (see cref="DefaultFormatStr"/>).
		''' </summary>
		''' <returns>A string representation of the date</returns>
		Public Overrides Function ToString() As String
			Return ToString(Me.m_xlDate, DefaultFormatStr)
		End Function

		''' <summary>
		''' Format this XDate value using the specified format string
		''' </summary>
		''' <param name="fmtStr">
		''' The formatting string to be used for the date.  The following formatting elements
		''' will be replaced with the corresponding date values:
		''' <list type="table">
		'''    <listheader>
		'''       <term>Variable</term>
		'''       <description>Description</description>
		'''    </listheader>
		'''    <item><term>&amp;mmmm</term><description>month name (e.g., January)</description></item>
		'''    <item><term>&amp;mmm</term><description>month abbreviation (e.g., Apr)</description></item>
		'''    <item><term>&amp;mm</term><description>padded month number (e.g. 04)</description></item>
		'''    <item><term>&amp;m</term><description>non-padded month number (e.g., 4)</description></item>
		'''    <item><term>&amp;dd</term><description>padded day number (e.g., 09)</description></item>
		'''    <item><term>&amp;d</term><description>non-padded day number (e.g., 9)</description></item>
		'''    <item><term>&amp;yyyy</term><description>4 digit year number (e.g., 1995)</description></item>
		'''    <item><term>&amp;yy</term><description>two digit year number (e.g., 95)</description></item>
		'''    <item><term>&amp;hh</term><description>padded 24 hour time value (e.g., 08)</description></item>
		'''    <item><term>&amp;h</term><description>non-padded 12 hour time value (e.g., 8)</description></item>
		'''    <item><term>&amp;nn</term><description>padded minute value (e.g, 05)</description></item>
		'''    <item><term>&amp;n</term><description>non-padded minute value (e.g., 5)</description></item>
		'''    <item><term>&amp;ss</term><description>padded second value (e.g., 03)</description></item>
		'''    <item><term>&amp;s</term><description>non-padded second value (e.g., 3)</description></item>
		'''    <item><term>&amp;a</term><description>"am" or "pm"</description></item>
		'''    <item><term>&amp;wwww</term><description>day of week (e.g., Wednesday)</description></item>
		'''    <item><term>&amp;www</term><description>day of week abbreviation (e.g., Wed)</description></item>
		''' </list>
		''' </param>
		''' <example>
		'''   <para>"&amp;wwww, &amp;mmmm &amp;dd, &amp;yyyy &amp;h:&amp;nn &amp;a" ==> "Sunday, February 12, 1956 4:23 pm"</para>
		'''   <para>"&amp;dd-&amp;mmm-&amp;yy" ==> 12-Feb-56</para>
		''' </example>
		''' <returns>A string representation of the date</returns>
		Public Function ToString(fmtStr As String) As String
			Return ToString(Me.m_xlDate, fmtStr)
		End Function

		''' <summary>
		''' Format the specified XL Date value using the specified format string
		''' </summary>
		''' <param name="xlDate">
		''' The XL date value to be formatted in floating point double format.
		''' </param>
		''' <param name="fmtStr">
		''' The formatting string to be used for the date.  The following formatting elements
		''' will be replaced with the corresponding date values:
		''' <list type="table">
		'''    <listheader>
		'''       <term>Variable</term>
		'''       <description>Description</description>
		'''    </listheader>
		'''    <item><term>&amp;mmmm</term><description>month name (e.g., January)</description></item>
		'''    <item><term>&amp;mmm</term><description>month abbreviation (e.g., Apr)</description></item>
		'''    <item><term>&amp;mm</term><description>padded month number (e.g. 04)</description></item>
		'''    <item><term>&amp;m</term><description>non-padded month number (e.g., 4)</description></item>
		'''    <item><term>&amp;dd</term><description>padded day number (e.g., 09)</description></item>
		'''    <item><term>&amp;d</term><description>non-padded day number (e.g., 9)</description></item>
		'''    <item><term>&amp;yyyy</term><description>4 digit year number (e.g., 1995)</description></item>
		'''    <item><term>&amp;yy</term><description>two digit year number (e.g., 95)</description></item>
		'''    <item><term>&amp;hh</term><description>padded 24 hour time value (e.g., 08)</description></item>
		'''    <item><term>&amp;h</term><description>non-padded 12 hour time value (e.g., 8)</description></item>
		'''    <item><term>&amp;nn</term><description>padded minute value (e.g, 05)</description></item>
		'''    <item><term>&amp;n</term><description>non-padded minute value (e.g., 5)</description></item>
		'''    <item><term>&amp;ss</term><description>padded second value (e.g., 03)</description></item>
		'''    <item><term>&amp;s</term><description>non-padded second value (e.g., 3)</description></item>
		'''    <item><term>&amp;a</term><description>"am" or "pm"</description></item>
		'''    <item><term>&amp;wwww</term><description>day of week (e.g., Wednesday)</description></item>
		'''    <item><term>&amp;www</term><description>day of week abbreviation (e.g., Wed)</description></item>
		''' </list>
		''' </param>
		''' <example>
		'''   <para>"&amp;wwww, &amp;mmmm &amp;dd, &amp;yyyy &amp;h:&amp;nn &amp;a" ==> "Sunday, February 12, 1956 4:23 pm"</para>
		'''   <para>"&amp;dd-&amp;mmm-&amp;yy" ==> 12-Feb-56</para>
		''' </example>
		''' <returns>A string representation of the date</returns>
		Public Shared Function ToString(xlDate As Double, fmtStr As String) As String
			Dim longMonth As String() = {"January", "February", "March", "April", "May", "June", _
				"July", "August", "September", "October", "November", "December"}
			Dim shortMonth As String() = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", _
				"Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
			Dim longDoW As String() = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", _
				"Saturday"}
			Dim shortDoW As String() = {"Sun", "Mon", "Tue", "Wed", "Thu", "Fri", _
				"Sat"}

			Dim year As Integer, month As Integer, day As Integer, hour As Integer, minute As Integer, second As Integer
			XLDateToCalendarDate(xlDate, year, month, day, hour, minute, _
				second)

			Dim resultStr As String = fmtStr.Replace("&mmmm", longMonth(month - 1))
			resultStr = resultStr.Replace("&mmm", shortMonth(month - 1))
			resultStr = resultStr.Replace("&mm", month.ToString("d2"))
			resultStr = resultStr.Replace("&m", month.ToString("d"))
			resultStr = resultStr.Replace("&yyyy", year.ToString("d"))
			resultStr = resultStr.Replace("&yy", (year Mod 100).ToString("d"))
			resultStr = resultStr.Replace("&dd", day.ToString("d2"))
			resultStr = resultStr.Replace("&d", day.ToString("d"))
			resultStr = resultStr.Replace("&hh", hour.ToString("d2"))
			resultStr = resultStr.Replace("&h", (((hour + 11) Mod 12) + 1).ToString("d"))
			resultStr = resultStr.Replace("&nn", minute.ToString("d2"))
			resultStr = resultStr.Replace("&n", minute.ToString("d"))
			resultStr = resultStr.Replace("&ss", second.ToString("d2"))
			resultStr = resultStr.Replace("&s", second.ToString("d"))
			resultStr = resultStr.Replace("&a", If((hour >= 12), "pm", "am"))
			resultStr = resultStr.Replace("&wwww", longDoW(XLDateToDayOfWeek(xlDate)))
			resultStr = resultStr.Replace("&www", shortDoW(XLDateToDayOfWeek(xlDate)))


			Return resultStr
		End Function
	End Structure
End Namespace
