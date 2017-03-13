
using System.Collections.Generic;

namespace BlackwaterPharma.DataAccess
{
    public class RightBarData
    {
        public string AltText { get; set; }
        public string BodyText { get; set; }
        public string CategoryIds { get; set; }
        public string HeaderText { get; set; }
        public int? Height { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string ShowOnHomepage { get; set; }
        public string Url { get; set; }
        public int? Weight { get; set; }
        public int? Width { get; set; }

        public static List<RightBarData> GetAllForHomePage(string url)
        {
            var res = BlackwaterPharma.DataAccess.ReadJson.ReadTheJson<RightBarData>(url);

            return res.FindAll(f => f.ShowOnHomepage == "Y");
        }

        public static RightBarData GetSingle(int Id, string url)
        {
            var res = BlackwaterPharma.DataAccess.ReadJson.ReadTheJson<RightBarData>(url);

            return res.Find(f => f.Id == Id);
        }
    }
}
