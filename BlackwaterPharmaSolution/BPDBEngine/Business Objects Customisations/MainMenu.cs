using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BPDBEngine
{
	public partial class TblmainmenuAggregate
	{
		public Tblmainmenu[] GetAll(int level)
		{
			StringBuilder sbsql = new StringBuilder();

			if (level == -1)
				level = 0;

			sbsql.Append("WHERE [ParentID] = " + level + " ");
			sbsql.Append("AND [Display] = 1 ");
			return runsql(sbsql.ToString());
		}
	}
}
