using BlackwaterPharma.DataAccess;
using System.Collections.Generic;

namespace BlackwaterPharma.Business
{
    public class Carousel
    {
        public static List<CarouselData> GetAll(string url)
        {
            return CarouselData.GetAll(url);
        }
    }
}
