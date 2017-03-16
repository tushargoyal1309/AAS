using System;

namespace AldysGraph
{
	
	/// <summary>
	/// This struct encapsulates a date and time value, and handles associated
	/// calculations and conversions between various formats.
	/// </summary>
	public struct XDate : ICloneable
	{
		// =========================================================================
		// Internal Variables
		// =========================================================================
	
		/// <summary>
		/// The actual date value in MS Excel format.  This is the only data field in
		/// the <see cref="XDate"/> struct.
		/// This format is in days since a reference date
		/// (XL date 1.0 is Jan 1, 1900 at 00:00 hrs).  Negative values are permissible, and the
		/// range of valid dates is from noon on January 1st, 4713 B.C. forward.  Internally, the
		/// date calculations are done using Astronomical Julian Day numbers.  The Astronomical Julian
		/// Day number is defined as the number of days since noon on January 1st, 4713 B.C.
		/// (also referred to as 12:00 on January 1, -4712).
		/// </summary>
		private double xlDate;
		
		/// <summary>
		/// The Astronomical Julian Day number that corresponds to XL Date 0.0
		/// </summary>
		public const double XLDay1 = 2415018.5;
		/// <summary>
		/// The number of months in a year
		/// </summary>
		public const double MonthsPerYear = 12.0;
		/// <summary>
		/// The number of hours in a day
		/// </summary>
		public const double HoursPerDay = 24.0;
		/// <summary>
		/// The number of minutes in an hour
		/// </summary>
		public const double MinutesPerHour = 60.0;
		/// <summary>
		/// The number of seconds in a minute
		/// </summary>
		public const double SecondsPerMinute = 60.0;
		/// <summary>
		/// The number of minutes in a day
		/// </summary>
		public const double MinutesPerDay = 1440.0;
		/// <summary>
		/// The number of seconds in a day
		/// </summary>
		public const double SecondsPerDay = 86400.0;
		/// <summary>
		/// The default format string to be used in <see cref="ToString"/> when
		/// no format is provided
		/// </summary>
		public const string DefaultFormatStr = "&d-&mmm-&yy &hh:&nn";
		
		// =========================================================================
		// Construtors
		// =========================================================================

		/// <summary>
		/// Construct a date class from an XL date value.
		/// </summary>
		/// <param name="xlDate">
		/// An XL Date value in floating point double format
		/// </param>
		public XDate( double xlDate )
		{
			this.xlDate = xlDate;
		}
		
		/// <summary>
		/// Construct a date class from a calendar date (year, month, day).  Assumes the time
		/// of day is 00:00 hrs
		/// </summary>
		/// <param name="year">An integer value for the year, e.g., 1995.</param>
		/// <param name="day">An integer value for the day of the month, e.g., 23.
		/// It is permissible to have day numbers outside of the 1-31 range,
		/// which will rollover to the previous or next month and year.</param>
		/// <param name="month">An integer value for the month of the year, e.g.,
		/// 8 for August.  It is permissible to have months outside of the 1-12 range,
		/// which will rollover to the previous or next year.</param>
		public XDate( int year, int month, int day )
		{
			xlDate = CalendarDateToXLDate( year, month, day, 0, 0, 0 );
		}
		
		/// <summary>
		/// Construct a date class from a calendar date and time (year, month, day, hour, minute,
		/// second). 
		/// </summary>
		/// <param name="year">An integer value for the year, e.g., 1995.</param>
		/// <param name="day">An integer value for the day of the month, e.g., 23.
		/// It is permissible to have day numbers outside of the 1-31 range,
		/// which will rollover to the previous or next month and year.</param>
		/// <param name="month">An integer value for the month of the year, e.g.,
		/// 8 for August.  It is permissible to have months outside of the 1-12 range,
		/// which will rollover to the previous or next year.</param>
		/// <param name="hour">An integer value for the hour of the day, e.g. 15.
		/// It is permissible to have hour values outside the 0-23 range, which
		/// will rollover to the previous or next day.</param>
		/// <param name="minute">An integer value for the minute, e.g. 45.
		/// It is permissible to have hour values outside the 0-59 range, which
		/// will rollover to the previous or next hour.</param>
		/// <param name="second">An integer value for the second, e.g. 35.
		/// It is permissible to have second values outside the 0-59 range, which
		/// will rollover to the previous or next minute.</param>
		public XDate( int year, int month, int day, int hour, int minute, int second )
		{
			xlDate = CalendarDateToXLDate( year, month, day, hour, minute, second );
		}
		
		/// <summary>
		/// The Copy Constructor
		/// </summary>
		/// <param name="rhs">The AldysPane object from which to copy</param>
		public XDate( XDate rhs )
		{
			xlDate = rhs.xlDate;
		}
		
		/// <summary>
		/// Deep-copy clone routine
		/// </summary>
		/// <returns>A new, independent copy of the XDate</returns>
		public object Clone()
		{ 
			return new XDate( this ); 
		}
		
		// =========================================================================
		// Properties
		// =========================================================================
	
		/// <summary>
		/// Gets or sets the date value for this item in MS Excel format.
		/// </summary>
		public double XLDate
		{
			get { return xlDate; }
			set { xlDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the date value for this item in .Net DateTime format.
		/// </summary>
		public DateTime DateTime
		{
			get { return XLDateToDateTime( this.xlDate ); }
			set { this.xlDate = DateTimeToXLDate( value ); }
		}
		
		/// <summary>
		/// Gets or sets the date value for this item in Julain day format.  This is the
		/// Astronomical Julian Day number, so a value of 0.0 corresponds to noon GMT on
		/// January 1st, -4712.  Thus, Julian Day number 2,400,000.0 corresponds to
		/// noon GMT on November 16, 1858.
		/// </summary>
		public double JulianDay
		{
			get { return XLDateToJulianDay( xlDate ); }
			set { xlDate = JulianDayToXLDate( value ); }
		}
		
		/// <summary>
		/// Gets or sets the decimal year number (i.e., 1997.345) corresponding to this item.
		/// </summary>
		public double DecimalYear
		{
			get { return XLDateToDecimalYear( xlDate ); }
			set { xlDate = DecimalYearToXLDate( value ); }
		}
		
		/// <summary>
		/// Get the calendar date (year, month, day) corresponding to this instance.
		/// </summary>
		/// <param name="year">An integer value for the year, e.g., 1995.</param>
		/// <param name="day">An integer value for the day of the month, e.g., 23.</param>
		/// <param name="month">An integer value for the month of the year, e.g.,
		/// 8 for August.</param>
		public void GetDate( out int year, out int month, out int day )
		{
			int hour, minute, second;
			
			XLDateToCalendarDate( xlDate, out year, out month, out day, out hour, out minute, out second );
		}
		
		/// <summary>
		/// Set the calendar date (year, month, day) of this instance.
		/// </summary>
		/// <param name="year">An integer value for the year, e.g., 1995.</param>
		/// <param name="day">An integer value for the day of the month, e.g., 23.</param>
		/// <param name="month">An integer value for the month of the year, e.g.,
		/// 8 for August.</param>
		public void SetDate( int year, int month, int day )
		{
			xlDate = CalendarDateToXLDate( year, month, day, 0, 0, 0 );
		}
		
		/// <summary>
		/// Get the calendar date (year, month, day, hour, minute, second) corresponding
		/// to this instance.
		/// </summary>
		/// <param name="year">An integer value for the year, e.g., 1995.</param>
		/// <param name="day">An integer value for the day of the month, e.g., 23.</param>
		/// <param name="month">An integer value for the month of the year, e.g.,
		/// 8 for August.</param>
		/// <param name="hour">An integer value for the hour of the day, e.g. 15.</param>
		/// <param name="minute">An integer value for the minute, e.g. 45.</param>
		/// <param name="second">An integer value for the second, e.g. 35.</param>
		public void GetDate( out int year, out int month, out int day,
			out int hour, out int minute, out int second )
		{
			XLDateToCalendarDate( xlDate, out year, out month, out day, out hour, out minute, out second );
		}

		/// <summary>
		/// Set the calendar date (year, month, day, hour, minute, second) of this instance.
		/// </summary>
		/// <param name="year">An integer value for the year, e.g., 1995.</param>
		/// <param name="day">An integer value for the day of the month, e.g., 23.</param>
		/// <param name="month">An integer value for the month of the year, e.g.,
		/// 8 for August.</param>
		/// <param name="hour">An integer value for the hour of the day, e.g. 15.</param>
		/// <param name="minute">An integer value for the minute, e.g. 45.</param>
		/// <param name="second">An integer value for the second, e.g. 35.</param>
		public void SetDate( int year, int month, int day, int hour, int minute, int second )
		{
			xlDate = CalendarDateToXLDate( year, month, day, hour, minute, second );
		}
		
		/// <summary>
		/// Get the day of year value (241.345 means the 241st day of the year)
		/// corresponding to this instance.
		/// </summary>
		/// <returns>The day of the year in floating point double format.</returns>
		public double GetDayOfYear()
		{
			return XLDateToDayOfYear( xlDate );
		}

		// =========================================================================
		// Conversion Routines
		// =========================================================================
	
		/// <summary>
		/// Calculate an XL Date from the specified Calendar date (year, month, day, hour, minute, second),
		/// first normalizing all input data values
		/// </summary>
		/// <param name="year">
		/// The integer year value (e.g., 1994).
		/// </param>
		/// <param name="month">
		/// The integer month value (e.g., 7 for July).
		/// </param>
		/// <param name="day">
		/// The integer day value (e.g., 19 for the 19th day of the month).
		/// </param>
		/// <param name="hour">
		/// The integer hour value (e.g., 14 for 2:00 pm).
		/// </param>
		/// <param name="minute">
		/// The integer minute value (e.g., 35 for 35 minutes past the hour).
		/// </param>
		/// <param name="second">
		/// The integer second value (e.g., 42 for 42 seconds past the minute).
		/// </param>
		/// <returns>The corresponding XL date, expressed in double floating point format</returns>
		public static double CalendarDateToXLDate( int year, int month, int day,
			int hour, int minute, int second )
		{
			// Normalize the data to allow for negative and out of range values
			// In this way, setting month to zero would be December of the previous year,
			// setting hour to 24 would be the first hour of the next day, etc.
		
			NormalizeCalendarDate( ref year, ref month, ref day, ref hour, ref minute, ref second );
		
			return _CalendarDateToXLDate( year, month, day, hour, minute, second );
		}
		
		/// <summary>
		/// Calculate an Astronomical Julian Day number from the specified Calendar date
		/// (year, month, day, hour, minute, second), first normalizing all input data values
		/// </summary>
		/// <param name="year">
		/// The integer year value (e.g., 1994).
		/// </param>
		/// <param name="month">
		/// The integer month value (e.g., 7 for July).
		/// </param>
		/// <param name="day">
		/// The integer day value (e.g., 19 for the 19th day of the month).
		/// </param>
		/// <param name="hour">
		/// The integer hour value (e.g., 14 for 2:00 pm).
		/// </param>
		/// <param name="minute">
		/// The integer minute value (e.g., 35 for 35 minutes past the hour).
		/// </param>
		/// <param name="second">
		/// The integer second value (e.g., 42 for 42 seconds past the minute).
		/// </param>
		/// <returns>The corresponding Astronomical Julian Day number, expressed in double
		/// floating point format</returns>
		public static double CalendarDateToJulianDay( int year, int month, int day,
			int hour, int minute, int second )
		{
			// Normalize the data to allow for negative and out of range values
			// In this way, setting month to zero would be December of the previous year,
			// setting hour to 24 would be the first hour of the next day, etc.
		
			NormalizeCalendarDate( ref year, ref month, ref day, ref hour, ref minute, ref second );
		
			return _CalendarDateToJulianDay( year, month, day, hour, minute, second );
		}
		
		/// <summary>
		/// Normalize a set of Calendar date values (year, month, day, hour, minute, second) to make sure
		/// that month is between 1 and 12, hour is between 0 and 23, etc.
		/// </summary>
		/// <param name="year">
		/// The integer year value (e.g., 1994).
		/// </param>
		/// <param name="month">
		/// The integer month value (e.g., 7 for July).
		/// </param>
		/// <param name="day">
		/// The integer day value (e.g., 19 for the 19th day of the month).
		/// </param>
		/// <param name="hour">
		/// The integer hour value (e.g., 14 for 2:00 pm).
		/// </param>
		/// <param name="minute">
		/// The integer minute value (e.g., 35 for 35 minutes past the hour).
		/// </param>
		/// <param name="second">
		/// The integer second value (e.g., 42 for 42 seconds past the minute).
		/// </param>
		private static void NormalizeCalendarDate( ref int year, ref int month, ref int day,
			ref int hour, ref int minute, ref int second )
		{
			// Normalize the data to allow for negative and out of range values
			// In this way, setting month to zero would be December of the previous year,
			// setting hour to 24 would be the first hour of the next day, etc.
		
			// Normalize the seconds and carry over to minutes
			int carry = (int) Math.Floor( (double) second / SecondsPerMinute );
			second -= carry * (int) SecondsPerMinute;
			minute += carry;
		
			// Normalize the minutes and carry over to hours
			carry = (int) Math.Floor( (double) minute / MinutesPerHour );
			minute -= carry * (int) MinutesPerHour;
			hour += carry;
		
			// Normalize the hours and carry over to days
			carry = (int) Math.Floor( (double) hour / HoursPerDay );
			hour -= carry * (int) HoursPerDay;
			day += carry;
		
			// Normalize the months and carry over to years
			carry = (int) Math.Floor( (double) month / MonthsPerYear );
			month -= carry * (int) MonthsPerYear;
			year += carry;
		}
		
		/// <summary>
		/// Calculate an XL date from the specified Calendar date (year, month, day, hour, minute, second).
		/// This is the internal trusted version, where all values are assumed to be legitimate
		/// ( month is between 1 and 12, minute is between 0 and 59, etc. )
		/// </summary>
		/// <param name="year">
		/// The integer year value (e.g., 1994).
		/// </param>
		/// <param name="month">
		/// The integer month value (e.g., 7 for July).
		/// </param>
		/// <param name="day">
		/// The integer day value (e.g., 19 for the 19th day of the month).
		/// </param>
		/// <param name="hour">
		/// The integer hour value (e.g., 14 for 2:00 pm).
		/// </param>
		/// <param name="minute">
		/// The integer minute value (e.g., 35 for 35 minutes past the hour).
		/// </param>
		/// <param name="second">
		/// The integer second value (e.g., 42 for 42 seconds past the minute).
		/// </param>
		/// <returns>The corresponding XL date, expressed in double floating point format</returns>
		private static double _CalendarDateToXLDate( int year, int month, int day, int hour, int minute, int second )
		{
			return JulianDayToXLDate( _CalendarDateToJulianDay( year, month, day, hour, minute, second ) );
		}
		
		/// <summary>
		/// Calculate an Astronomical Julian Day Number from the specified Calendar date
		/// (year, month, day, hour, minute, second).
		/// This is the internal trusted version, where all values are assumed to be legitimate
		/// ( month is between 1 and 12, minute is between 0 and 59, etc. )
		/// </summary>
		/// <param name="year">
		/// The integer year value (e.g., 1994).
		/// </param>
		/// <param name="month">
		/// The integer month value (e.g., 7 for July).
		/// </param>
		/// <param name="day">
		/// The integer day value (e.g., 19 for the 19th day of the month).
		/// </param>
		/// <param name="hour">
		/// The integer hour value (e.g., 14 for 2:00 pm).
		/// </param>
		/// <param name="minute">
		/// The integer minute value (e.g., 35 for 35 minutes past the hour).
		/// </param>
		/// <param name="second">
		/// The integer second value (e.g., 42 for 42 seconds past the minute).
		/// </param>
		/// <returns>The corresponding Astronomical Julian Day number, expressed in double
		/// floating point format</returns>
		private static double _CalendarDateToJulianDay( int year, int month, int day, int hour, int minute, int second )
		{
			// Taken from http://www.srrb.noaa.gov/highlights/sunrise/program.txt
			// routine calcJD()
		
			if ( month <= 2 )
			{
				year -= 1;
				month += 12;
			}
		
			double A = Math.Floor( (double) year / 100.0 );
			double B = 2 - A + Math.Floor( A / 4.0 );
		
			return	Math.Floor( 365.25 * ( (double) year + 4716.0 ) ) +
				Math.Floor( 30.6001 * (double) ( month + 1 ) ) +
				(double) day + B - 1524.5 +
				hour  / HoursPerDay + minute / MinutesPerDay + second / SecondsPerDay;
		
		}

		/// <summary>
		/// Calculate a Calendar date (year, month, day, hour, minute, second) corresponding to
		/// the specified XL date
		/// </summary>
		/// <param name="xlDate">
		/// The XL date value in floating point double format.
		/// </param>
		/// <param name="year">
		/// The integer year value (e.g., 1994).
		/// </param>
		/// <param name="month">
		/// The integer month value (e.g., 7 for July).
		/// </param>
		/// <param name="day">
		/// The integer day value (e.g., 19 for the 19th day of the month).
		/// </param>
		/// <param name="hour">
		/// The integer hour value (e.g., 14 for 2:00 pm).
		/// </param>
		/// <param name="minute">
		/// The integer minute value (e.g., 35 for 35 minutes past the hour).
		/// </param>
		/// <param name="second">
		/// The integer second value (e.g., 42 for 42 seconds past the minute).
		/// </param>
		public static void XLDateToCalendarDate( double xlDate, out int year, out int month,
			out int day, out int hour, out int minute, out int second )
		{
			double jDay = XLDateToJulianDay( xlDate );
			
			JulianDayToCalendarDate( jDay, out year, out month, out day, out hour,
				out minute, out second );
		}
		
		/// <summary>
		/// Calculate a Calendar date (year, month, day, hour, minute, second) corresponding to
		/// the Astronomical Julian Day number
		/// </summary>
		/// <param name="jDay">
		/// The Astronomical Julian Day number to be converted
		/// </param>
		/// <param name="year">
		/// The integer year value (e.g., 1994).
		/// </param>
		/// <param name="month">
		/// The integer month value (e.g., 7 for July).
		/// </param>
		/// <param name="day">
		/// The integer day value (e.g., 19 for the 19th day of the month).
		/// </param>
		/// <param name="hour">
		/// The integer hour value (e.g., 14 for 2:00 pm).
		/// </param>
		/// <param name="minute">
		/// The integer minute value (e.g., 35 for 35 minutes past the hour).
		/// </param>
		/// <param name="second">
		/// The integer second value (e.g., 42 for 42 seconds past the minute).
		/// </param>
		public static void JulianDayToCalendarDate( double jDay, out int year, out int month,
			out int day, out int hour, out int minute, out int second )
		{
			double z = Math.Floor( jDay + 0.5 );
			double f = jDay + 0.5 - z;
		
			double alpha = Math.Floor( ( z - 1867216.25 ) / 36524.25 );
			double A = z + 1.0 + alpha - Math.Floor( alpha / 4 );
			double B = A + 1524.0;
			double C = Math.Floor( ( B - 122.1 ) / 365.25 );
			double D = Math.Floor( 365.25 * C );
			double E = Math.Floor( ( B - D ) / 30.6001 );
		
			day = (int) Math.Floor( B - D - Math.Floor( 30.6001 * E ) + f );
			month = (int) ( ( E < 14.0 ) ? E - 1.0 : E - 13.0 );
			year = (int) ( ( month > 2 ) ? C - 4716 : C - 4715 );
		
			// add a half-second to the time fraction to avoid roundoff errors
			double fday =  ( jDay - 0.5 ) - Math.Floor( jDay - 0.5 ) + 0.5 / SecondsPerDay;
		
			fday = ( fday - (long) fday ) * HoursPerDay;
			hour = (int) fday;
			fday = ( fday - (long) fday ) * MinutesPerHour;
			minute = (int) fday;
			fday = ( fday - (long) fday ) * SecondsPerMinute;
			second = (int) fday;
		
		}
		
		/// <summary>
		/// Calculate an Astronomical Julian Day number corresponding to the specified XL date
		/// </summary>
		/// <param name="xlDate">
		/// The XL date value in floating point double format.
		/// </param>
		/// <returns>The corresponding Astronomical Julian Day number, expressed in double
		/// floating point format</returns>
		public static double XLDateToJulianDay( double xlDate )
		{
			return xlDate + XLDay1;
		}
		
		/// <summary>
		/// Calculate an XL Date corresponding to the specified Astronomical Julian Day number
		/// </summary>
		/// <param name="jDay">
		/// The Astronomical Julian Day number in floating point double format.
		/// </param>
		/// <returns>The corresponding XL Date, expressed in double
		/// floating point format</returns>
		public static double JulianDayToXLDate( double jDay )
		{
			return jDay - XLDay1;
		}
		
		/// <summary>
		/// Calculate a decimal year value (e.g., 1994.6523) corresponding to the specified XL date
		/// </summary>
		/// <param name="xlDate">
		/// The XL date value in floating point double format.
		/// </param>
		/// <returns>The corresponding decimal year value, expressed in double
		/// floating point format</returns>
		public static double XLDateToDecimalYear( double xlDate )
		{
			int year, month, day, hour, minute, second;
			
			XLDateToCalendarDate( xlDate, out year, out month, out day, out hour, out minute, out second );
			
			double jDay1 = CalendarDateToJulianDay( year, 1, 1, 0, 0, 0 );
			double jDay2 = CalendarDateToJulianDay( year + 1, 1, 1, 0, 0, 0 );
			double jDayMid = CalendarDateToJulianDay( year, month, day, hour, minute, second );
			
			
			return (double) year + ( jDayMid - jDay1 ) / ( jDay2 - jDay1 );
		}
		
		/// <summary>
		/// Calculate a decimal year value (e.g., 1994.6523) corresponding to the specified XL date
		/// </summary>
		/// <param name="yearDec">
		/// The decimal year value in floating point double format.
		/// </param>
		/// <returns>The corresponding XL Date, expressed in double
		/// floating point format</returns>
		public static double DecimalYearToXLDate( double yearDec )
		{
			int year = (int) yearDec;
			
			double jDay1 = CalendarDateToJulianDay( year, 1, 1, 0, 0, 0 );
			double jDay2 = CalendarDateToJulianDay( year + 1, 1, 1, 0, 0, 0 );
			
			return JulianDayToXLDate( ( yearDec - (double) year ) * ( jDay2 - jDay1 ) + jDay1 );
		}
		
		/// <summary>
		/// Calculate a day-of-year value (e.g., 241.543 corresponds to the 241st day of the year)
		/// corresponding to the specified XL date
		/// </summary>
		/// <param name="xlDate">
		/// The XL date value in floating point double format.
		/// </param>
		/// <returns>The corresponding day-of-year (DoY) value, expressed in double
		/// floating point format</returns>
		public static double XLDateToDayOfYear( double xlDate )
		{
			int year, month, day, hour, minute, second;
			XLDateToCalendarDate( xlDate, out year, out month, out day,
				out hour, out minute, out second );
			return XLDateToJulianDay( xlDate ) - CalendarDateToJulianDay( year, 1, 1, 0, 0, 0 ) + 1.0;
		}
		
		/// <summary>
		/// Calculate a day-of-week value (e.g., Sun=0, Mon=1, Tue=2, etc.)
		/// corresponding to the specified XL date
		/// </summary>
		/// <param name="xlDate">
		/// The XL date value in floating point double format.
		/// </param>
		/// <returns>The corresponding day-of-week (DoW) value, expressed in integer format</returns>
		public static int XLDateToDayOfWeek( double xlDate )
		{
			return (int) ( XLDateToJulianDay( xlDate ) + 1.5 ) % 7;
		}
		
		/// <summary>
		/// Convert an XL date format to a .Net DateTime struct
		/// </summary>
		/// <param name="xlDate">
		/// The XL date value in floating point double format.
		/// </param>
		/// <returns>The corresponding XL Date, expressed in double
		/// floating point format</returns>
		/// <returns>The corresponding date in the form of a .Net DateTime struct</returns>
		public static DateTime XLDateToDateTime( double xlDate )
		{
			int year, month, day, hour, minute, second;
			XLDateToCalendarDate( xlDate, out year, out month, out day,
				out hour, out minute, out second );
			return new DateTime( year, month, day, hour, minute, second );
		}
		
		/// <summary>
		/// Convert a .Net DateTime struct to an XL Format date
		/// </summary>
		/// <param name="dt">
		/// The date value in the form of a .Net DateTime struct
		/// </param>
		/// <returns>The corresponding XL Date, expressed in double
		/// floating point format</returns>
		public static double DateTimeToXLDate( DateTime dt )
		{
			return CalendarDateToXLDate( dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second );
		}
		
		// =========================================================================
		// Math Routines
		// =========================================================================
	
		/// <summary>
		/// Add the specified number of seconds (can be fractional) to the current XDate instance.
		/// </summary>
		/// <param name="dSeconds">
		/// The incremental number of seconds (negative or positive) in floating point double format.
		/// </param>
		public void AddSeconds( double dSeconds )
		{
			this.xlDate += dSeconds / 86400.0;
		}
		
		/// <summary>
		/// Add the specified number of minutes (can be fractional) to the current XDate instance.
		/// </summary>
		/// <param name="dMinutes">
		/// The incremental number of minutes (negative or positive) in floating point double format.
		/// </param>
		public void AddMinutes( double dMinutes )
		{
			this.xlDate += dMinutes / 1440.0;
		}
		
		/// <summary>
		/// Add the specified number of hours (can be fractional) to the current XDate instance.
		/// </summary>
		/// <param name="dHours">
		/// The incremental number of hours (negative or positive) in floating point double format.
		/// </param>
		public void AddHours( double dHours )
		{
			this.xlDate += dHours / HoursPerDay;
		}
		
		/// <summary>
		/// Add the specified number of days (can be fractional) to the current XDate instance.
		/// </summary>
		/// <param name="dDays">
		/// The incremental number of days (negative or positive) in floating point double format.
		/// </param>
		public void AddDays( double dDays )
		{
			this.xlDate += dDays;
		}
		
		/// <summary>
		/// Add the specified number of Months (can be fractional) to the current XDate instance.
		/// </summary>
		/// <param name="dMonths">
		/// The incremental number of months (negative or positive) in floating point double format.
		/// </param>
		public void AddMonths( double dMonths )
		{
			int iMon = (int) dMonths;
			double monFrac = Math.Abs( dMonths - (double) iMon );
			int sMon = Math.Sign( dMonths );
			
			int year, month, day, hour, minute, second;
			
			XLDateToCalendarDate( this.xlDate, out year, out month, out day, out hour, out minute, out second );
			if ( iMon != 0 )
			{
				month += iMon;
				this.xlDate = CalendarDateToXLDate( year, month, day, hour, minute, second );
			}
			
			if ( sMon != 0 )
			{
				double xlDate2 = CalendarDateToXLDate( year, month+sMon, day, hour, minute, second );
				this.xlDate += (xlDate2 - this.xlDate) * monFrac;
			}
		}
		
		/// <summary>
		/// Add the specified number of years (can be fractional) to the current XDate instance.
		/// </summary>
		/// <param name="dYears">
		/// The incremental number of years (negative or positive) in floating point double format.
		/// </param>
		public void AddYears( double dYears )
		{
			int iYear = (int) dYears;
			double yearFrac = Math.Abs( dYears - (double) iYear );
			int sYear = Math.Sign( dYears );
			
			int year, month, day, hour, minute, second;
			
			XLDateToCalendarDate( this.xlDate, out year, out month, out day, out hour, out minute, out second );
			if ( iYear != 0 )
			{
				year += iYear;
				this.xlDate = CalendarDateToXLDate( year, month, day, hour, minute, second );
			}
			
			if ( sYear != 0 )
			{
				double xlDate2 = CalendarDateToXLDate( year+sYear, month, day, hour, minute, second );
				this.xlDate += (xlDate2 - this.xlDate) * yearFrac;
			}
		}
		
		// =========================================================================
		// Operator Overloads
		// =========================================================================
	
		/// <summary>
		/// '-' operator overload.  When two XDates are subtracted, the number of days between dates
		/// is returned.
		/// </summary>
		/// <param name="lhs">The left-hand-side of the '-' operator (an XDate class)</param>
		/// <param name="rhs">The right-hand-side of the '-' operator (an XDate class)</param>
		/// <returns>The days between dates, expressed as a floating point double</returns>
		public static double operator -( XDate lhs, XDate rhs )
		{
			return lhs.XLDate - rhs.XLDate;
		}
		
		/// <summary>
		/// '-' operator overload.  When a double value is subtracted from an XDate, the result is a
		/// new XDate with the number of days subtracted.
		/// </summary>
		/// <param name="lhs">The left-hand-side of the '-' operator (an XDate class)</param>
		/// <param name="rhs">The right-hand-side of the '-' operator (a double value)</param>
		/// <returns>An XDate with the rhs number of days subtracted</returns>
		public static XDate operator -( XDate lhs, double rhs )
		{
			lhs.xlDate -= rhs;
			return lhs;
		}
		
		/// <summary>
		/// '+' operator overload.  When a double value is added to an XDate, the result is a
		/// new XDate with the number of days added.
		/// </summary>
		/// <param name="lhs">The left-hand-side of the '-' operator (an XDate class)</param>
		/// <param name="rhs">The right-hand-side of the '+' operator (a double value)</param>
		/// <returns>An XDate with the rhs number of days added</returns>
		public static XDate operator +( XDate lhs, double rhs )
		{
			lhs.xlDate += rhs;
			return lhs;
		}
		
		/// <summary>
		/// '++' operator overload.  Increment the date by one day.
		/// </summary>
		/// <param name="xDate">The XDate struct on which to operate</param>
		/// <returns>An XDate one day later than the specified date</returns>
		public static XDate operator ++( XDate xDate )
		{
			xDate.xlDate += 1.0;
			return xDate;
		}
		
		/// <summary>
		/// '--' operator overload.  Decrement the date by one day.
		/// </summary>
		/// <param name="xDate">The XDate struct on which to operate</param>
		/// <returns>An XDate one day prior to the specified date</returns>
		public static XDate operator --( XDate xDate )
		{
			xDate.xlDate -= 1.0;
			return xDate;
		}
		
		/// <summary>
		/// Implicit conversion from XDate to double (an XL Date).
		/// </summary>
		/// <param name="xDate">The XDate struct on which to operate</param>
		/// <returns>A double floating point value representing the XL Date</returns>
		public static implicit operator double( XDate xDate )
		{
			return xDate.xlDate;
		}
		
		// =========================================================================
		// System Stuff
		// =========================================================================

		/// <summary>
		/// Tests whether <param>obj</param> is either an <see cref="XDate"/> structure or
		/// a double floating point value that is equal to the same date as this <c>XDate</c>
		/// struct instance.
		/// </summary>
		/// <param name="obj">The object to compare for equality with this XDate instance.
		/// This object should be either a type XDate or type double.</param>
		/// <returns>Returns <c>true</c> if <param>obj</param> is the same date as this
		/// instance; otherwise, <c>false</c></returns>
		public override bool Equals( object obj )
		{
			if ( obj is XDate )
			{
				return ((XDate) obj).xlDate == this.xlDate;
			}
			else if ( obj is double )
			{
				return ((double) obj) == this.xlDate;
			}
			else
				return false;
		}
		
		/// <summary>
		/// Returns the hash code for this <see cref="XDate"/> structure.  In this case, the
		/// hash code is simply the equivalent hash code for the floating point double date value.
		/// </summary>
		/// <returns>An integer representing the hash code for this XDate value</returns>
		public override int GetHashCode()
		{
			return this.xlDate.GetHashCode();
		}
		
		// =========================================================================
		// String Formatting Routines
		// =========================================================================
	
		/// <summary>
		/// Format this XDate value using the default format string (see cref="DefaultFormatStr"/>).
		/// </summary>
		/// <param name="xlDate">
		/// The XL date value to be formatted in floating point double format.
		/// </param>
		/// <returns>A string representation of the date</returns>
		public string ToString( double xlDate )
		{
			return ToString( xlDate, DefaultFormatStr );
		}
		
		/// <summary>
		/// Format this XDate value using the default format string (see cref="DefaultFormatStr"/>).
		/// </summary>
		/// <returns>A string representation of the date</returns>
		public override string ToString()
		{
			return ToString( this.xlDate, DefaultFormatStr );
		}
		
		/// <summary>
		/// Format this XDate value using the specified format string
		/// </summary>
		/// <param name="fmtStr">
		/// The formatting string to be used for the date.  The following formatting elements
		/// will be replaced with the corresponding date values:
		/// <list type="table">
		///    <listheader>
		///       <term>Variable</term>
		///       <description>Description</description>
		///    </listheader>
		///    <item><term>&amp;mmmm</term><description>month name (e.g., January)</description></item>
		///    <item><term>&amp;mmm</term><description>month abbreviation (e.g., Apr)</description></item>
		///    <item><term>&amp;mm</term><description>padded month number (e.g. 04)</description></item>
		///    <item><term>&amp;m</term><description>non-padded month number (e.g., 4)</description></item>
		///    <item><term>&amp;dd</term><description>padded day number (e.g., 09)</description></item>
		///    <item><term>&amp;d</term><description>non-padded day number (e.g., 9)</description></item>
		///    <item><term>&amp;yyyy</term><description>4 digit year number (e.g., 1995)</description></item>
		///    <item><term>&amp;yy</term><description>two digit year number (e.g., 95)</description></item>
		///    <item><term>&amp;hh</term><description>padded 24 hour time value (e.g., 08)</description></item>
		///    <item><term>&amp;h</term><description>non-padded 12 hour time value (e.g., 8)</description></item>
		///    <item><term>&amp;nn</term><description>padded minute value (e.g, 05)</description></item>
		///    <item><term>&amp;n</term><description>non-padded minute value (e.g., 5)</description></item>
		///    <item><term>&amp;ss</term><description>padded second value (e.g., 03)</description></item>
		///    <item><term>&amp;s</term><description>non-padded second value (e.g., 3)</description></item>
		///    <item><term>&amp;a</term><description>"am" or "pm"</description></item>
		///    <item><term>&amp;wwww</term><description>day of week (e.g., Wednesday)</description></item>
		///    <item><term>&amp;www</term><description>day of week abbreviation (e.g., Wed)</description></item>
		/// </list>
		/// </param>
		/// <example>
		///   <para>"&amp;wwww, &amp;mmmm &amp;dd, &amp;yyyy &amp;h:&amp;nn &amp;a" ==> "Sunday, February 12, 1956 4:23 pm"</para>
		///   <para>"&amp;dd-&amp;mmm-&amp;yy" ==> 12-Feb-56</para>
		/// </example>
		/// <returns>A string representation of the date</returns>
		public string ToString( string fmtStr )
		{
			return ToString( this.xlDate, fmtStr );
		}
		
		/// <summary>
		/// Format the specified XL Date value using the specified format string
		/// </summary>
		/// <param name="xlDate">
		/// The XL date value to be formatted in floating point double format.
		/// </param>
		/// <param name="fmtStr">
		/// The formatting string to be used for the date.  The following formatting elements
		/// will be replaced with the corresponding date values:
		/// <list type="table">
		///    <listheader>
		///       <term>Variable</term>
		///       <description>Description</description>
		///    </listheader>
		///    <item><term>&amp;mmmm</term><description>month name (e.g., January)</description></item>
		///    <item><term>&amp;mmm</term><description>month abbreviation (e.g., Apr)</description></item>
		///    <item><term>&amp;mm</term><description>padded month number (e.g. 04)</description></item>
		///    <item><term>&amp;m</term><description>non-padded month number (e.g., 4)</description></item>
		///    <item><term>&amp;dd</term><description>padded day number (e.g., 09)</description></item>
		///    <item><term>&amp;d</term><description>non-padded day number (e.g., 9)</description></item>
		///    <item><term>&amp;yyyy</term><description>4 digit year number (e.g., 1995)</description></item>
		///    <item><term>&amp;yy</term><description>two digit year number (e.g., 95)</description></item>
		///    <item><term>&amp;hh</term><description>padded 24 hour time value (e.g., 08)</description></item>
		///    <item><term>&amp;h</term><description>non-padded 12 hour time value (e.g., 8)</description></item>
		///    <item><term>&amp;nn</term><description>padded minute value (e.g, 05)</description></item>
		///    <item><term>&amp;n</term><description>non-padded minute value (e.g., 5)</description></item>
		///    <item><term>&amp;ss</term><description>padded second value (e.g., 03)</description></item>
		///    <item><term>&amp;s</term><description>non-padded second value (e.g., 3)</description></item>
		///    <item><term>&amp;a</term><description>"am" or "pm"</description></item>
		///    <item><term>&amp;wwww</term><description>day of week (e.g., Wednesday)</description></item>
		///    <item><term>&amp;www</term><description>day of week abbreviation (e.g., Wed)</description></item>
		/// </list>
		/// </param>
		/// <example>
		///   <para>"&amp;wwww, &amp;mmmm &amp;dd, &amp;yyyy &amp;h:&amp;nn &amp;a" ==> "Sunday, February 12, 1956 4:23 pm"</para>
		///   <para>"&amp;dd-&amp;mmm-&amp;yy" ==> 12-Feb-56</para>
		/// </example>
		/// <returns>A string representation of the date</returns>
		public static string ToString( double xlDate, string fmtStr )
		{
			string[] longMonth = { "January", "February", "March", "April", "May", "June",
									 "July", "August", "September", "October", "November", "December" };
			string[] shortMonth = { "Jan", "Feb", "Mar", "Apr", "May", "Jun",
									  "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
			string[] longDoW = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday",
								   "Friday", "Saturday" };
			string[] shortDoW = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
						
			int year, month, day, hour, minute, second;
			XLDateToCalendarDate( xlDate, out year, out month, out day, out hour, out minute, out second );
			
			string resultStr = fmtStr.Replace( "&mmmm", longMonth[ month - 1 ] );
			resultStr = resultStr.Replace( "&mmm", shortMonth[ month - 1 ] );
			resultStr = resultStr.Replace( "&mm", month.ToString( "d2" ) );
			resultStr = resultStr.Replace( "&m", month.ToString( "d" ) );
			resultStr = resultStr.Replace( "&yyyy", year.ToString( "d" ) );
			resultStr = resultStr.Replace( "&yy", (year%100).ToString( "d" ) );
			resultStr = resultStr.Replace( "&dd", day.ToString( "d2" ) );
			resultStr = resultStr.Replace( "&d", day.ToString( "d" ) );
			resultStr = resultStr.Replace( "&hh", hour.ToString( "d2" ) );
			resultStr = resultStr.Replace( "&h", (((hour+11)%12)+1).ToString( "d" ) );
			resultStr = resultStr.Replace( "&nn", minute.ToString( "d2" ) );
			resultStr = resultStr.Replace( "&n", minute.ToString( "d" ) );
			resultStr = resultStr.Replace( "&ss", second.ToString( "d2" ) );
			resultStr = resultStr.Replace( "&s", second.ToString( "d" ) );
			resultStr = resultStr.Replace( "&a", (hour>=12) ? "pm" : "am" );
			resultStr = resultStr.Replace( "&wwww", longDoW[ XLDateToDayOfWeek( xlDate ) ] );
			resultStr = resultStr.Replace( "&www", shortDoW[ XLDateToDayOfWeek( xlDate ) ] );
			
			
			return resultStr;
		}
	}
}
