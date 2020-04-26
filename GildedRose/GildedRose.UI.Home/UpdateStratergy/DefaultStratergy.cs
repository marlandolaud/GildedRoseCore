using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.UI.Home.UpdateStratergy
{
    public class DefaultStratergy : IUpdateQualityStratergy
    {
        public void UpdateQuality(StoreItem item)
        {
            if (item.Quality > 0)
            {
                if (item.SellIn > 0)
                {
                    item.Quality--;
                }
                else
                {
                    item.Quality -= 2;
                }
            }
            if (item.SellIn > 0)
            {
                item.SellIn--;
            }
        }
    }
}
