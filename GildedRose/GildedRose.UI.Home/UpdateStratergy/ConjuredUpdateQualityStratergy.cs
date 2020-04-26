namespace GildedRose.UI.Home.UpdateStratergy
{
    public class ConjuredUpdateQualityStratergy : IUpdateQualityStratergy
    {
        public void UpdateQuality(StoreItem item)
        {
            item.SellIn--;            
            if (item.SellIn > 0)
            {
                item.Quality -= 2;
            }
            else
            {
                item.Quality -= 4;
            }
        }
    }
}
