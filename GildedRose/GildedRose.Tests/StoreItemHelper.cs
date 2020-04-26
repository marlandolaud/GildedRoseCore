using GildedRose.UI.Home;

namespace GildedRose.Tests
{
    public static class StoreItemHelper
    {

        private const int DefaultSellinValue = 10;

        private const int DefaultQualityValue = 20;

        public static StoreItem GetNormalItem(int sellin = DefaultSellinValue, int quality = DefaultQualityValue) =>
            new StoreItem(new Item { Name = "+5 Dexterity Vest", SellIn = sellin, Quality = quality });

        public static StoreItem GetAgedBrie(int sellin = DefaultSellinValue, int quality = DefaultQualityValue) =>
            new StoreItem(new Item { Name = "Aged Brie", SellIn = sellin, Quality = quality });

        public static StoreItem GetSulfuras() =>
            new StoreItem(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = DefaultSellinValue, Quality = DefaultQualityValue });

        public static StoreItem GetBackstage(int sellin = DefaultSellinValue, int quality = DefaultQualityValue) =>
            new StoreItem(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellin, Quality = quality });
    }
}
