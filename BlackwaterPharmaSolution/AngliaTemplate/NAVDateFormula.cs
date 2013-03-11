using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace AngliaTemplate
{


	/// <summary>
	/// This class provides same abilities as the NAV data formulas.
	/// </summary>
	/// <remarks>
	/// NAV uses codes such as CW to return the current week (end of week).
	/// More complex formulas such as CW+1Y+3M can be used. This example
	/// will take the end of the current week, add 1 year, and add 3 months.
	/// </remarks>
	public class NAVDateFormula
	{

		///// <summary>
		///// NOT IMPLEMENTED: Set the start of week offset for formulas to use.
		///// Defaults to Monday.
		///// </summary>
		//public System.DayOfWeek StartOfWeek
		//{
		//    //TODO: implement the SOW functionality.
		//    get { return startOfWeek; }
		//    set { startOfWeek = value; }
		//}
		//private System.DayOfWeek startOfWeek = DayOfWeek.Monday;


		///// <summary>
		///// NOT IMPLEMENTED: Set the start of year offset for formulas to use.
		///// Defaults to 1 Jan.
		///// </summary>
		//public System.DateTime StartOfYear
		//{
		//    get { return startOfYear; }
		//    set { startOfYear = value; }
		//}
		//private System.DateTime startOfYear = new DateTime(DateTime.Today.Year, 1, 1);

		/// <summary>
		/// Apply the NAV date formula.
		/// </summary>
		/// <param name="baseDate">The date to apply the formula to.</param>
		/// <param name="formula">The NAV date formula (e.g. "CD+1M+3D" to add 1 month and 3 days to the current date).</param>
		/// <returns>The calculated date.</returns>
		public static DateTime Apply(System.DateTime baseDate, string formula)
		{
			if (formula == null || formula.Length == 0)
				return baseDate;
			System.DateTime returnDate = AngliaTemplate.CoreDb.NavisionMinDate;
			#region Split formula into units
			//split the formula into units into this node collection so they can be processed separately.
			System.Collections.Generic.List<string> nodes = new List<string>();
			bool flgOk = true;
			int currentPos = 0;
			int nextPos = 0;
			if (!(formula.StartsWith("+") || formula.StartsWith("-")))		//the formula will be forced to begin with a sign. No sign indicates a "+".
				formula = "+" + formula;
			while (flgOk && currentPos < formula.Length)
			{
				nextPos = formula.IndexOfAny(new char[] { '+', '-' }, currentPos + (currentPos == 0 ? 1 : 0));
				if (nextPos >= 0)
				{
					nodes.Add(formula.Substring((currentPos > 0 ? currentPos - 1 : currentPos), nextPos - (currentPos > 0 ? currentPos - 1 : currentPos)));
					currentPos = nextPos + 1;
				}
				else
				{
					nodes.Add(formula.Substring((currentPos > 0 ? currentPos - 1 : currentPos)));
					flgOk = false;
				}
			}
			#endregion Split formula into units

			try
			{
				returnDate = calculate(baseDate, nodes);	//now process the units individually
			}
			catch { }
			return returnDate;
		}

		/*
 * Examples:
-12D 	minus 12 days
+4M		plus 4 months
30D		30 days
2W		2 weeks
CM+10D	Current month plus 10 days 
CM+1M	Current month plus one month 
CQ+1M+20D	Current quarter plus one month plus 20 days 
CW+1W	Current week plus one week 
D15		On the 15th of each month 
M12		on the 12th month
CW		Current Week
CM		Current Month
10D		10 days from today
2W		2 weeks from today
D10		The next 10th day of a month
WD4		The next 4th day of a week (Thursday)
CM+10D	Current month + 10 days
-1Y		1 year ago from today
		 * 
		 * Think of the formulas as being not other than offsets (e.g. CM is the end of the current month. -CM is the beginning of the current month).
		 * Always have a starting date. Use this to apply the offsets to.
		 * Should always have a sign. If none, then + is assumed. (+ is inserted if sign is missing when the nodes collection is created).
		 * 
		 * +CD|M|Q|Y is for end of period.
		 * -CD|M|Q|Y is for start of period.
 */

		/// <summary>
		/// Process the current period formula (CD|CM|CQ|CY).
		/// </summary>
		/// <param name="date">The base date.</param>
		/// <param name="formula">The formula to process.</param>
		/// <returns>The date against which the formula was processed.</returns>
		private static DateTime processCurrentPeriod(DateTime date, string formula)
		{
			/*
			 * +CD|CM|CQ|CY is for end of period.
			 * -CD|CM|CQ|CY is for start of period.
			 * 
			 * Example: +CD is for the end of current day.
			 *			+CM is the the last day in this month.
			 *			-CM is for the first day in this month.
			 */
			bool flgEndOfPeriod = (formula.Substring(0, 1) == "+");		//+ is end of period | - is beginning of period.
			switch (formula.ToUpper().Substring(2, 1))
			{
				case "D":	//CD will in effect do nothing.
					{
						break;
					}
				case "W":
					{
						int currentDOW = Convert.ToInt32(date.DayOfWeek);
						if (flgEndOfPeriod)	//show the last day of the week
						{
							if (currentDOW == 0)	//0 in .Net is a Sunday
								break;
							else
								date = date.AddDays(7 - (currentDOW));
						}
						else				//show the first day of the week
						{
							if (currentDOW == 1)
								break;
							else
								date = date.AddDays(-((currentDOW == 0) ? 6 : currentDOW - 1));
						}
						break;
					}
				case "M":	//CM = end of current month
					{
						if (flgEndOfPeriod)
						{
							date = new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
						}
						else
							date = new DateTime(date.Year, date.Month, 1);
						break;
					}
				case "Q":	//CQ = end of current quarter
					{
						throw new NotImplementedException(".Net library does not calculate the company financial periods.");
						//if (flgEndOfPeriod)
						//{

						//}
						//break;
					}
				case "Y":	//-CY = beginning of current year
					{
						if (flgEndOfPeriod)
						{
							date = new DateTime(date.Year, 12, 31);
						}
						else
						{
							date = new DateTime(date.Year, 1, 1);
						}
						break;
					}
			}
			return date;
		}

		private static DateTime calculate(DateTime date, System.Collections.Generic.List<string> nodes)
		{

			for (int i = 0; i < nodes.Count; i++)
			{
				Debug.WriteLine(nodes[i], i.ToString());
				bool flgEndOfPeriod = (nodes[i].Substring(0, 1) == "+");		//+ is end of period | - is beginning of period.

				#region Advanced date calcs (CD/D1/etc)
				switch (nodes[i].Substring(1, 1).ToUpper())	//look at the first char in the node item.
				{

					case "C":		//current period
						{
							date = processCurrentPeriod(date, nodes[i]);
							break;
						}
					case "D":		//e.g. +D10 = The next 10th day of a month
						{
							int day = Convert.ToInt32(nodes[i].Substring(2));
							int currentMonthDay = date.Day;
							if (flgEndOfPeriod)
							{
								if (day > currentMonthDay)
									date = new DateTime(date.Year, date.Month, day);
								else
								{
									if (date.Month == 12)	//move into the next year
										date = new DateTime(date.Year + 1, 1, day);
									else
										date = new DateTime(date.Year, date.Month + 1, day);	// date.AddMonths(1).AddDays(currentMonthDay - day);
								}
							}
							else
							{
								if (day < date.Day)
									date = new DateTime(date.Year, date.Month, day);
								else
								{
									if (date.Month == 1)	//move into the previous year
										date = new DateTime(date.Year - 1, 12, day);
									else
										date = new DateTime(date.Year, date.Month - 1, day);	// date.AddMonths(-1).AddDays(currentMonthDay - day);
								}
							}
							break;
						}
					case "W":		//+WD4 = The next 4th day of a week (Thursday)
						{
							int dayOfWeek = Convert.ToInt32(nodes[i].Substring(3));		//NAV day of week starts on Monday=1. dotNet starts on Sunday=0.
							int dateDOW = (int)date.DayOfWeek;
							if (dateDOW == 0)
								dateDOW = 7;
							if (flgEndOfPeriod)
							{
								//if (dateDOW == dayOfWeek)
								//    date = date.AddDays(7);
								if (dateDOW < dayOfWeek)
									date = date.AddDays(dayOfWeek - dateDOW);
								else
									date = date.AddDays(7 + (dayOfWeek - dateDOW));
							}
							else
							{
								if (dateDOW > dayOfWeek)
									date = date.AddDays(dayOfWeek - dateDOW);
								else
									date = date.AddDays(-7 + (dayOfWeek - dateDOW));
							}
							break;
						}
					case "M":	//+M12 = on the 12th month
						{
							int month = Convert.ToInt32(nodes[i].Substring(2));
							if (flgEndOfPeriod)
								date = new DateTime(date.Year, month, 1).AddMonths(1).AddDays(-1);	//end of the month
							else
								date = new DateTime(date.Year, month, 1);							//beginning of the month.
							break;
						}
					case "Q":	//Q4 = end of the 4th quarter
						{
							throw new NotImplementedException(".Net library does not calculate the company financial periods.");
							//break;
						}
					//case "Y":
					//    {
					//        if (flgEndOfPeriod)
					//            date = new DateTime(date.Year, 12, 31);	//end of year
					//        else
					//            date = new DateTime(date.Year, 1, 1);	//beginning of year
					//        break; 
					//    }
					default:
						{
							date = addFormula(nodes[i], date);
							break;
						}
				}
				#endregion Advanced date calcs (CD/D1/etc)

				Debug.WriteLine(date.ToShortDateString(), i.ToString());

			}
			return date;
		}

		private static DateTime addFormula(string forumlaItem, DateTime date)
		{
			#region Do the 1D/1M/1Y type calcs
			switch (forumlaItem.Substring(forumlaItem.Length - 1).ToUpper())
			{
				case "D":	//e.g. +10D = add 10 days
					{
						date = date.AddDays(Convert.ToDouble(forumlaItem.Substring(0, forumlaItem.Length - 1)));
						break;
					}
				case "M":	//e.g. +2M = add 2 months
					{
						date = date.AddMonths(Convert.ToInt32(forumlaItem.Substring(0, forumlaItem.Length - 1)));
						break;
					}
				case "W":	//e.g. +2W = add 2 weeks
					{
						date = date.AddDays(Convert.ToDouble(forumlaItem.Substring(0, forumlaItem.Length - 1)) * 7);
						break;
					}
				case "Q":	//e.g. +1Q = add 1 quarter (i.e. 3 months)
					{
						throw new NotImplementedException(".Net library does not calculate the company financial periods.");
						//int quarters = Convert.ToInt32(forumlaItem.Substring(0, forumlaItem.Length - 1));
						//date = date.AddMonths(quarters * 3);
						//break;
					}
				case "Y":	//e.g. -3Y = subtract 3 years
					{
						date = date.AddYears(Convert.ToInt32(forumlaItem.Substring(0, forumlaItem.Length - 1)));
						break;
					}
			}
			#endregion Do the 1D/1M/1Y type calcs
			return date;
		}

	}
}
