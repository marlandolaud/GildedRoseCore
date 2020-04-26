using GildedRose.UI.Home.UpdateStratergy;

namespace GildedRose.UI.Home
{
    public class StoreItem
    {
        private readonly Item item;

        private readonly IUpdateQualityStratergy updateQualityStratergy;

        public StoreItem(Item item)
        {
            this.item = item;

            updateQualityStratergy = new DefaultUpdateQualityStratergy();
            if (Name.Equals("Aged Brie"))
            {
                updateQualityStratergy = new BetterWithTimeUpdateQualityStratergy();
            }
            if (Name.Equals("Sulfuras, Hand of Ragnaros"))
            {
                updateQualityStratergy = new SulfurasUpdateQualityStratergy();
            }
            if (Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
            {
                updateQualityStratergy = new BackStagePassUpdateQualityStratergy();
            }
        }

        public string Name
        {
            get { return item.Name; }
        }

        public int SellIn
        {
            get { return item.SellIn; }
            private set { item.SellIn = value; }
        }

        public int Quality
        {
            get { return item.Quality; }
            private set { item.Quality = value; }
        }

        public void UpdateQuality()
        {
            updateQualityStratergy.UpdateQuality(this);
        }

        public void IncrementQuality()
        {
            if (Quality < 50)
            {
                Quality++;
            }
        }

        public void DecrementQuality()
        {
            if (Quality > 0)
            {
                Quality--;
            }
        }

        public void Age()
        {
            SellIn--;
        }

        public void Expire()
        {
            Quality = 0;
        }
    }
}
