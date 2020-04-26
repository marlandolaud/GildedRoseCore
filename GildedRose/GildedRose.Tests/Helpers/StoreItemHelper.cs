using GildedRose.UI.Home;
using System;

namespace GildedRose.Tests.Helpers
{
    public static class StoreItemHelper
    {
        internal static StoreItem GetNormalItem(int sellin = GildedRoseTestConstants.DefaultSellinValue, int quality = GildedRoseTestConstants.DefaultQualityValue) =>
            new StoreItem(new Item 
            { 
                Name = "+5 Dexterity Vest", 
                SellIn = sellin, 
                Quality = quality 
            });

        internal static StoreItem GetAgedBrie(int sellin = GildedRoseTestConstants.DefaultSellinValue, int quality = GildedRoseTestConstants.DefaultQualityValue) =>
            new StoreItem(
                new Item 
                { 
                    Name = "Aged Brie", 
                    SellIn = sellin, 
                    Quality = quality 
                });

        internal static StoreItem GetConjuredItem(int sellin = GildedRoseTestConstants.DefaultSellinValue, int quality = GildedRoseTestConstants.DefaultQualityValue) =>
            new StoreItem(
                new Item
                {
                    Name = "Conjured",
                    SellIn = sellin,
                    Quality = quality
                });

        internal static StoreItem GetSulfuras() =>
            new StoreItem(
                new Item 
                { 
                    Name = "Sulfuras, Hand of Ragnaros", 
                    SellIn = GildedRoseTestConstants.DefaultSellinValue, 
                    Quality = GildedRoseTestConstants.DefaultQualityValue 
                });

        internal static StoreItem GetBackstage(int sellin = GildedRoseTestConstants.DefaultSellinValue, int quality = GildedRoseTestConstants.DefaultQualityValue) =>
            new StoreItem(
                new Item 
                { 
                    Name = "Backstage passes to a TAFKAL80ETC concert", 
                    SellIn = sellin, 
                    Quality = quality 
                });
    }
}
