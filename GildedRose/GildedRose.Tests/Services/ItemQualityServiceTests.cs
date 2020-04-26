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
        [Fact]
        public void ReduceNormalItemQualityByOne()
        {
            // Arrange
            var qualityiService = new ItemQualityService();
            var normalItem = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };

            // Act
            qualityiService.UpdateItemQuality(normalItem);

            // Assert
            normalItem.Quality.Should().Be(19);
        }

        [Fact]
        public void ReduceNormalItemSellInByOne()
        {
            // Arrange
            var qualityiService = new ItemQualityService();
            var normalItem = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };

            // Act
            qualityiService.UpdateItemQuality(normalItem);

            // Assert
            normalItem.SellIn.Should().Be(9);
        }
    }
}
