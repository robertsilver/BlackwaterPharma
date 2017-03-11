
using BlackwaterPharma.DataAccess;
using System.Collections.Generic;

namespace BlackwaterPharma.Business
{
    public class RightBar
    {
        public static RightBarData GetOneRecord(int Id, string url)
        {
            return RightBarData.GetSingle(Id, url);
        }

        public static List<RightBarData> GetMainMenu(string url)
        {
            return RightBarData.GetAllForHomePage(url);
        }
    }
}
