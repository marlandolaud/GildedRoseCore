namespace GildedRose.UI.Home.UpdateStratergy
{
    public class SulfurasUpdateQualityStratergy : IUpdateQualityStratergy
    {
        /// <summary>
        /// "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        /// </summary>
        /// <param name="item">the store item</param>
        public void UpdateQuality(StoreItem item)
        {

        }
    }
}
