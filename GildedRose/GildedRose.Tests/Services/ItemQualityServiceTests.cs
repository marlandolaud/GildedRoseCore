using FluentAssertions;
using GildedRose.UI.Home;
using GildedRose.UI.Home.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GildedRose.Tests.Services
{
    public class ItemQualityServiceTests
    {
        public ItemQualityService qualityiService;

        public ItemQualityServiceTests()
        {
            qualityiService = new ItemQualityService();
        }

        [Fact]
        public void ReduceNormalItemQualityByOne()
        {
            // Arrange            
            Item normalItem = GetNormalItem();
            int expectedQuality = normalItem.Quality -1;

            // Act
            qualityiService.UpdateItemQuality(normalItem);

            // Assert
            normalItem.Quality.Should().Be(expectedQuality);
        }

        [Fact]
        public void ReduceNormalItemSellInByOne()
        {
            // Arrange
            var normalItem = GetNormalItem();
            int expectedSellin = normalItem.SellIn - 1;

            // Act
            qualityiService.UpdateItemQuality(normalItem);

            // Assert
            normalItem.SellIn.Should().Be(expectedSellin);
        }

        private static Item GetNormalItem()
        {
            return new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
        }
    }
}
