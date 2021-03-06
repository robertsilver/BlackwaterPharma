﻿using System;
using System.Collections.Generic;

namespace BlackwaterPharma.DataAccess
{
    public class CarouselData
    {
        public string TitleSection { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public List<string> CarouselText { get; set; }

        public static List<CarouselData> GetAll(string url)
        {
            var res = BlackwaterPharma.DataAccess.ReadJson.ReadTheJson<CarouselData>(url);

            return res.FindAll(f => f.DateStart <= DateTime.Now && DateTime.Now < f.DateEnd);
        }
    }
}
