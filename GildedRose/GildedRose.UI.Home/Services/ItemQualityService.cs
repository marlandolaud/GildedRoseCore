using System.Collections.Generic;

namespace GildedRose.UI.Home.Services
{
    public class ItemQualityService
    {
        public void UpdateQuality(IList<Item> items)
        {
            foreach (var item in items)
            {
                var storeItem = new StoreItem(item);
                storeItem.UpdateQuality();
            }
        }     
    }
}
