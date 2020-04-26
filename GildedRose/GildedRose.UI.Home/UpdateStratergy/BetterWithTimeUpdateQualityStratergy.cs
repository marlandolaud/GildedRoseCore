namespace GildedRose.UI.Home.UpdateStratergy
{
    public class BetterWithTimeUpdateQualityStratergy : IUpdateQualityStratergy
    {
        /// <summary>
        /// "Aged Brie" actually increases in Quality the older it gets
        /// </summary>
        /// <param name="item"></param>
        public void UpdateQuality(StoreItem item)
        {
            item.Age();

            item.IncrementQuality();

            if (item.SellIn < 0)
            {
                item.IncrementQuality();
            }
        }
    }
}
