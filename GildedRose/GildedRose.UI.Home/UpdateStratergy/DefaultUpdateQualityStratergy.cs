namespace GildedRose.UI.Home.UpdateStratergy
{
    public class DefaultUpdateQualityStratergy : IUpdateQualityStratergy
    {
        /// <summary>
        /// Once the sell by date has passed, Quality degrades twice as fast
        /// </summary>
        /// <param name="item"></param>
        public void UpdateQuality(StoreItem item)
        {
            item.Age();
            item.DecrementQuality();
            if (item.SellIn < 0)
            {
                item.DecrementQuality();
            }
        }
    }
}
