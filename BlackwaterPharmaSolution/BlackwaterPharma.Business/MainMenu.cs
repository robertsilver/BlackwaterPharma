using BlackwaterPharma.DataAccess;
using System;
using System.Collections.Generic;

namespace BlackwaterPharma.Business
{
    public class MainMenu
    {
        public static List<MainMenuData> GetMainMenu(int level, string url)
        {
            var tabs = new List<MainMenuData>();
            try
            {
                tabs = MainMenuData.GetAll(level, url);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("BlackwaterPharma.Business.GetMainMenu(): MainMenuData.GetAll() returned error: " + ex.Message);
            }

            return tabs;
        }
    }
}
