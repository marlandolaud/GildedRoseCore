namespace GildedRose.UI.Home.UpdateStratergy
{
    public class BackStagePassUpdateQualityStratergy : IUpdateQualityStratergy
    {
        /// <summary>
        /// "Backstage passes", like aged brie, increases in Quality as it's SellIn value approaches; 
        /// Quality increases by 2 when there are 10 days or less and by 3 
        /// when there are 5 days or less but 
        /// Quality drops to 0 after the concert
        /// </summary>
        /// <param name="item">the store item</param>
        public void UpdateQuality(StoreItem item)
        {
            item.Age();
            item.IncrementQuality();            
            if (item.SellIn < 10)
            {
                item.IncrementQuality();
            }            
            if (item.SellIn < 5)
            {
                item.IncrementQuality();
            }
            if (item.SellIn < 0)
            {
                item.Expire();
            }
        }
    }
}
