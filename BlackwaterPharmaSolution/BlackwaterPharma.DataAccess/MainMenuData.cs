
using System.Collections.Generic;

namespace BlackwaterPharma.DataAccess
{
    public class MainMenuData
    {
        private int B2BCustomer { get; set; }
        private string Description { get; set; }
        private bool Display { get; set; }
        private int Distributor { get; set; }
        private int Everyone { get; set; }
        private int MenuId { get; set; }
        private int ParentId { get; set; }
        private bool? SpecialAccount { get; set; }
        private bool? SuperUser { get; set; }
        private string Text;
        private string URL { get; set; }
        private int Vendor { get; set; }
        private string WhoCanView { get; set; }

        public static List<MainMenuData> GetAll(int level, string url)
        {
            if (level == -1 )
                level = 0;

            var res = BlackwaterPharma.DataAccess.ReadJson.ReadTheJson<MainMenuData>(url);

            return res.FindAll(f => f.ParentId == level && f.Display);
        }
    }
}
