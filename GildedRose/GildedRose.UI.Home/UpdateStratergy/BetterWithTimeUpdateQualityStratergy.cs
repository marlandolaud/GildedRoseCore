namespace GildedRose.UI.Home.UpdateStratergy
{
    public class BetterWithTimeUpdateQualityStratergy : IUpdateQualityStratergy
    {
        public void UpdateQuality(StoreItem storeItem)
        {
            if (storeItem.Quality < 50)
            {
                if (storeItem.SellIn > 0)
                {
                    storeItem.Quality += 1;
                }
                else
                {
                    storeItem.Quality += 2;
                }
            }
            storeItem.SellIn -= 1;

            if (storeItem.SellIn < 0)
            {
                storeItem.SellIn++;
            }
        }
    }
}
