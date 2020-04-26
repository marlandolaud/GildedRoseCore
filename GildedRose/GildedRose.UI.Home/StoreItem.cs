using GildedRose.UI.Home.UpdateStratergy;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.UI.Home
{
    public class StoreItem
    {
        private readonly Item item;

        private readonly IUpdateQualityStratergy updateQualityStratergy;

        public StoreItem()
        {

        }

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
            set { item.Name = value; }
        }

        public int SellIn
        {
            get { return item.SellIn; }
            set { item.SellIn = value; }
        }

        public int Quality
        {
            get { return item.Quality; }
            set { item.Quality = value; }
        }

        public void UpdateQuality()
        {
            updateQualityStratergy.UpdateQuality(this);
        }
    }
}
