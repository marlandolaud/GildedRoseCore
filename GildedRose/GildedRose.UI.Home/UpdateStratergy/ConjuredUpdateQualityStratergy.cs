namespace GildedRose.UI.Home.UpdateStratergy
{
    public class ConjuredUpdateQualityStratergy : IUpdateQualityStratergy
    {
        /// <summary>
        /// "Conjured" items degrade in Quality twice as fast as normal items
        /// </summary>
        /// <param name="item"></param>
        public void UpdateQuality(StoreItem item)
        {
            item.SellIn--;
            item.DecrementQuality();
            item.DecrementQuality();
            if (item.SellIn < 0)
            {
                item.DecrementQuality();
                item.DecrementQuality();
            }
        }
    }
}
