using System;
using System.Collections.Generic;
using System.Text;

//using System.Web.Security;
namespace AngliaTemplate
{
	public class Utility
	{
		/// <summary>
		/// The user id of the person logged in.
		/// </summary>
		public static string UserID
		{
			get
			{
				string uid = System.Environment.UserName;
				if (uid.IndexOf("\\") > 0)
					return uid.Substring(uid.IndexOf("\\") + 1);
				else
					return uid;
			}
		}


		public static void LogToDBEventLog(string applicationName
			, string methodName, string description
			, string entryType)
		{
			CoreDb db = new CoreDb();
			try
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("INSERT INTO tblEventLog ([ApplicationName], MethodName, Description, EntryType) VALUES (");
				sb.Append("'" + CoreDb.SqlLiteral(applicationName)
					+ "', '" + CoreDb.SqlLiteral(methodName)
					+ "', '" + CoreDb.SqlLiteral(description)
					+ "', '" + CoreDb.SqlLiteral(entryType) + "')");
				db.SqlExecute(sb.ToString());
			}
			catch (System.Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.ToString());
			}
			finally
			{
				db.Dispose();
				db = null;
			}
		}
	}

	public class Validate
	{
		public static bool UKTelephone(string landline)
		{
			if (landline == null || landline.Length == 0)
				return false;
			if (!landline.StartsWith("0"))
				return false;
			string ch = "";
			for(int i=landline.Length-1;i>=0;i--)
			{
				ch = landline.Substring(i, 1);
				switch(ch)
				{
					case "(":
					case ")":
					case " ":
						{
							landline = landline.Substring(0, i) + (i+1<landline.Length ? landline.Substring(i+1) : "");
							break;
						}
				}
			}

			bool result = System.Text.RegularExpressions.Regex.IsMatch(landline, @"^0[123567]\d{9}$");
			return result;
		}
	}

	public class Is
	{
		public static bool Numeric(object expression)
		{

			IConvertible convertible = null;
			TypeCode typecode;
			string text;
			double num;
			bool result = false;
			char chr;

			if ((expression as IConvertible) != null)
			{
				convertible = (IConvertible)expression;
			}

			if (convertible == null)
			{
				if ((expression as char[]) != null)
				{
					expression = new string((char[])expression);
				}
				else
				{
					return false;
				}
			}

			typecode = convertible.GetTypeCode();

			if (typecode == TypeCode.String || typecode == TypeCode.Char)
			{
				text = convertible.ToString(null);

				try
				{
					for (int i = 0; i < text.Length; i++)
					{
						chr = Convert.ToChar(text.Substring(i, 1));

						if (char.IsNumber(chr))
						{
							result = true;
						}
						else if ((int)chr >= 'a' && (int)chr <= 'f')
						{
							result = true;
						}
						else if ((int)chr >= 'A' && (int)chr <= 'F')
						{
							result = true;
						}
						else
						{
							result = false;
						}

						if (result == false)
						{
							break;
						}
					}
				}
				catch (Exception)
				{
					return false;
				}

				if (result == false)
				{
					result = double.TryParse(text,
					System.Globalization.NumberStyles.Any, null, out num);
				}
			}

			if (result == false)
			{
				result = IsNumericTypeCode(typecode);
			}

			return result;
		}

		internal static bool IsNumericTypeCode(TypeCode typeCode)
		{
			bool result = false;

			switch (typeCode)
			{
				case TypeCode.Decimal:
				case TypeCode.Double:
				case TypeCode.Int16:
				case TypeCode.Int32:
				case TypeCode.Int64:
				case TypeCode.Single:
				case TypeCode.UInt16:
				case TypeCode.UInt32:
				case TypeCode.UInt64:
					result = true;
					break;

				default:
					result = false;
					break;
			}

			return result;
		}
	}


	public class Navision
	{
		/// <summary>
		/// Code from website: http://konsulent.sandelien.no/VB_help/Week/
		/// Calculates the week num based on ISO 8601
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static int WeekNumber_Entire4DayWeekRule(DateTime date)
		{
			// Updated 2004.09.27. Cleaned the code and fixed a bug. Compared the algorithm with
			// code published here . Tested code successfully against the other algorithm 
			// for all dates in all years between 1900 and 2100.
			// Thanks to Marcus Dahlberg for pointing out the deficient logic.
			// Calculates the ISO 8601 Week Number
			// In this scenario the first day of the week is monday, 
			// and the week rule states that:
			// [...] the first calendar week of a year is the one 
			// that includes the first Thursday of that year and 
			// [...] the last calendar week of a calendar year is 
			// the week immediately preceding the first 
			// calendar week of the next year.
			// The first week of the year may thus start in the 
			// preceding year

			const int JAN = 1;
			const int DEC = 12;
			const int LASTDAYOFDEC = 31;
			const int FIRSTDAYOFJAN = 1;
			const int THURSDAY = 4;
			bool ThursdayFlag = false;

			// Get the day number since the beginning of the year
			int DayOfYear = date.DayOfYear;

			// Get the numeric weekday of the first day of the 
			// year (using sunday as FirstDay)
			int StartWeekDayOfYear =
				 (int)(new DateTime(date.Year, JAN, FIRSTDAYOFJAN)).DayOfWeek;
			int EndWeekDayOfYear =
				 (int)(new DateTime(date.Year, DEC, LASTDAYOFDEC)).DayOfWeek;

			// Compensate for the fact that we are using monday
			// as the first day of the week
			if (StartWeekDayOfYear == 0)
				StartWeekDayOfYear = 7;
			if (EndWeekDayOfYear == 0)
				EndWeekDayOfYear = 7;

			// Calculate the number of days in the first and last week
			int DaysInFirstWeek = 8 - (StartWeekDayOfYear);
			int DaysInLastWeek = 8 - (EndWeekDayOfYear);

			// If the year either starts or ends on a thursday it will have a 53rd week
			if (StartWeekDayOfYear == THURSDAY || EndWeekDayOfYear == THURSDAY)
				ThursdayFlag = true;

			// We begin by calculating the number of FULL weeks between the start of the year and
			// our date. The number is rounded up, so the smallest possible value is 0.
			int FullWeeks = (int)Math.Ceiling((DayOfYear - (DaysInFirstWeek)) / 7.0);

			int WeekNumber = FullWeeks;

			// If the first week of the year has at least four days, then the actual week number for our date
			// can be incremented by one.
			if (DaysInFirstWeek >= THURSDAY)
				WeekNumber = WeekNumber + 1;

			// If week number is larger than week 52 (and the year doesn't either start or end on a thursday)
			// then the correct week number is 1. 
			if (WeekNumber > 52 && !ThursdayFlag)
				WeekNumber = 1;

			// If week number is still 0, it means that we are trying to evaluate the week number for a
			// week that belongs in the previous year (since that week has 3 days or less in our date's year).
			// We therefore make a recursive call using the last day of the previous year.
			if (WeekNumber == 0)
				WeekNumber = WeekNumber_Entire4DayWeekRule(
					 new DateTime(date.Year - 1, DEC, LASTDAYOFDEC));
			return WeekNumber;
		}



		public static string SqlNavisionTime(DateTime dt)
		{
			string strReturn;
			strReturn = "'1 JAN 1754 " + dt.ToString("HH:mm:ss", null) + "'";
			return strReturn;
		}

		public static DateTime NavisionMinDate
		{
			get
			{
				return new DateTime(1753, 1, 1);
			}
		}

		public static DateTime NavisionMinTime
		{
			get
			{
				return new DateTime(1754, 1, 1);
			}
		}

		public static DateTime NavisionTime(DateTime dt)
		{
			return new DateTime(1754, 1, 1, dt.Hour, dt.Minute, dt.Second);
		}

		public static DateTime NavisionDate(DateTime dt)
		{
			return new DateTime(dt.Year, dt.Month, dt.Day);
		}

		/// <summary>
		/// NAV starts it weeks on a Monday and uses a 1-base.
		/// </summary>
		public enum NAVDayOfWeek
		{
			/// <summary>
			/// Indicates a NAV Monday. {1}
			/// </summary>
			Monday = 1,
			/// <summary>
			/// Indicates a NAV Tuesday. {2}
			/// </summary>
			Tuesday = 2,
			/// <summary>
			/// Indicates a NAV Wednesday. {3}
			/// </summary>
			Wednesday = 3,
			/// <summary>
			/// Indicates a NAV Thursday. {4}
			/// </summary>
			Thursday = 4,
			/// <summary>
			/// Indicates a NAV Friday. {5}
			/// </summary>
			Friday = 5,
			/// <summary>
			/// Indicates a NAV Saturday. {6}
			/// </summary>
			Saturday = 6,
			/// <summary>
			/// Indicates a NAV Sunday. {7}
			/// </summary>
			Sunday = 7,
		}

		/// <summary>
		/// Get the System equivalent value of the NAV day of week.
		/// </summary>
		/// <param name="dow">The <see cref="NAVDayOfWeek"/> value.</param>
		/// <returns>A <see cref="System.DayOfWeek"/> value.</returns>
		public static System.DayOfWeek GetSystemDayOfWeek(NAVDayOfWeek dow)
		{
			switch (dow)
			{
				case NAVDayOfWeek.Monday:
					return DayOfWeek.Monday;
				case NAVDayOfWeek.Tuesday:
					return DayOfWeek.Tuesday;
				case NAVDayOfWeek.Wednesday:
					return DayOfWeek.Wednesday;
				case NAVDayOfWeek.Thursday:
					return DayOfWeek.Thursday;
				case NAVDayOfWeek.Friday:
					return DayOfWeek.Friday;
				case NAVDayOfWeek.Saturday:
					return DayOfWeek.Saturday;
				default:
					return DayOfWeek.Sunday;
			}
		}


		/// <summary>
		/// Get the NAV day of week for the given date.
		/// </summary>
		/// <param name="date">The <see cref="System.DayOfWeek"/> value to get the day of week from.</param>
		/// <returns>A NAV day of week. (Convert to int if it has to be stored in a NAV db).</returns>
		public static NAVDayOfWeek GetNAVDayOfWeek(System.DateTime date)
		{
			switch (date.DayOfWeek)
			{
				case DayOfWeek.Monday:
					return NAVDayOfWeek.Monday;
				case DayOfWeek.Tuesday:
					return NAVDayOfWeek.Tuesday;
				case DayOfWeek.Wednesday:
					return NAVDayOfWeek.Wednesday;
				case DayOfWeek.Thursday:
					return NAVDayOfWeek.Thursday;
				case DayOfWeek.Friday:
					return NAVDayOfWeek.Friday;
				case DayOfWeek.Saturday:
					return NAVDayOfWeek.Saturday;
				default:
					return NAVDayOfWeek.Sunday;
			}
		}


		/// <summary>
		/// Get the text name for a month.
		/// </summary>
		/// <param name="month">The number of the month in the year.</param>
		/// <param name="abbrev">Get the abbreviated format of the month?</param>
		/// <returns>The text name for a month (e.g. 12=Dec or 12=December).</returns>
		public static string GetMonthName(int month, bool abbrev)
		{
			DateTime date = new DateTime(1900, month, 1);
			if (abbrev) return date.ToString("MMM");
			return date.ToString("MMMM");
		}
	}


}
