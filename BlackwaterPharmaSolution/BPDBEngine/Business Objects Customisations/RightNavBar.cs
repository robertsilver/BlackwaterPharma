using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPDBEngine
{
	public partial class TblrightnavbarAggregate
	{
		public Tblrightnavbar[] GetAllForHomePage()
		{
			StringBuilder sbsql = new StringBuilder();

			sbsql.Append("WHERE [ShowOnHomePage] = 'Y' ");
			return runsql(sbsql.ToString());
		}
	}
}
