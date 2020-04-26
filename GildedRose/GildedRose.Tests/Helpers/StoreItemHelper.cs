using GildedRose.UI.Home;

namespace GildedRose.Tests.Helpers
{
    public static class StoreItemHelper
    {
        public static StoreItem GetNormalItem(int sellin = GildedRoseTestConstants.DefaultSellinValue, int quality = GildedRoseTestConstants.DefaultQualityValue) =>
            new StoreItem(new Item { Name = "+5 Dexterity Vest", SellIn = sellin, Quality = quality });

        public static StoreItem GetAgedBrie(int sellin = GildedRoseTestConstants.DefaultSellinValue, int quality = GildedRoseTestConstants.DefaultQualityValue) =>
            new StoreItem(new Item { Name = "Aged Brie", SellIn = sellin, Quality = quality });

        public static StoreItem GetSulfuras() =>
            new StoreItem(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = GildedRoseTestConstants.DefaultSellinValue, Quality = GildedRoseTestConstants.DefaultQualityValue });

        public static StoreItem GetBackstage(int sellin = GildedRoseTestConstants.DefaultSellinValue, int quality = GildedRoseTestConstants.DefaultQualityValue) =>
            new StoreItem(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellin, Quality = quality });
    }
}
