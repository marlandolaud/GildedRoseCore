namespace GildedRose.UI.Home.UpdateStratergy
{
    public class AgedBrieUpdateQualityStratergy : IUpdateQualityStratergy
    {
        public void UpdateQuality(StoreItem storeItem)
        {
            if (storeItem.Quality < 50)
            {
                storeItem.Quality += 1;
            }
        }
    }
}
