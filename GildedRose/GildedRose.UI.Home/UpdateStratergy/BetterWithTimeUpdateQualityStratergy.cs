namespace GildedRose.UI.Home.UpdateStratergy
{
    public class BetterWithTimeUpdateQualityStratergy : IUpdateQualityStratergy
    {
        /// <summary>
        /// "Aged Brie" actually increases in Quality the older it gets
        /// </summary>
        /// <param name="storeItem"></param>
        public void UpdateQuality(StoreItem storeItem)
        {
            storeItem.SellIn--;
            storeItem.IncrementQuality();
            if (storeItem.SellIn < 0)
            {
                storeItem.IncrementQuality();
            }
        }
    }
}
