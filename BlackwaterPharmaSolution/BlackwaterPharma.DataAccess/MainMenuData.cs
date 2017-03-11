
using System.Collections.Generic;

namespace BlackwaterPharma.DataAccess
{
    public class MainMenuData
    {
        public int? B2BCustomer { get; set; }
        public string Description { get; set; }
        public bool Display { get; set; }
        public int? Distributor { get; set; }
        public int? Everyone { get; set; }
        public int MenuId { get; set; }
        public int ParentId { get; set; }
        public bool? SpecialAccount { get; set; }
        public bool? SuperUser { get; set; }
        public string Text { get; set; }
        public string URL { get; set; }
        public int? Vendor { get; set; }
        public string WhoCanView { get; set; }

        public static List<MainMenuData> GetAll(int level, string url)
        {
            if (level == -1 )
                level = 0;

            var res = BlackwaterPharma.DataAccess.ReadJson.ReadTheJson<MainMenuData>(url);

            return res.FindAll(f => f.ParentId == level && f.Display);
        }
    }
}
