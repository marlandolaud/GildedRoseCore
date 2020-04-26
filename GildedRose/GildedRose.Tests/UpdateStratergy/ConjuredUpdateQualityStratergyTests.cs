using FluentAssertions;
using GildedRose.Tests.Helpers;
using GildedRose.UI.Home.UpdateStratergy;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GildedRose.Tests.UpdateStratergy
{
    public class ConjuredUpdateQualityStratergyTests
    {
        private IUpdateQualityStratergy updateQualityStratergy;

        public ConjuredUpdateQualityStratergyTests()
        {
            this.updateQualityStratergy = new ConjuredUpdateQualityStratergy();
        }

        [Fact]
        public void ShouldDegrageInQualityTwiceAsFastAsNormalItems()
        {
            // Arrange            
            var storeItem = StoreItemHelper.GetConjuredItem(sellin: 10);
            int expectedQuality = storeItem.Quality - 2;

            // Act
            updateQualityStratergy.UpdateQuality(storeItem);

            // Assert
            storeItem.Quality.Should().Be(expectedQuality);
        }

        [Fact]
        public void ReduceNormalItemSellInByOne()
        {
            // Arrange            
            var storeItem = StoreItemHelper.GetConjuredItem();
            int expectedSellIn = storeItem.SellIn - 1;

            // Act
            updateQualityStratergy.UpdateQuality(storeItem);

            // Assert
            storeItem.SellIn.Should().Be(expectedSellIn);
        }

        [Fact]
        public void ReduceNormalItemQualityByTwoWhenSellInLessThanOne()
        {
            // Arrange            
            var storeItem = StoreItemHelper.GetNormalItem(sellin: 0);
            int expectedQuality = storeItem.Quality - 4;

            // Act
            updateQualityStratergy.UpdateQuality(storeItem);

            // Assert
            storeItem.Quality.Should().Be(expectedQuality);
        }

        [Fact]
        public void QualityShouldNeverBeNegative()
        {
            // Arrange            
            var storeItem = StoreItemHelper.GetConjuredItem(quality: 0);

            // Act
            updateQualityStratergy.UpdateQuality(storeItem);

            // Assert
            storeItem.Quality.Should().Be(0);
        }
    }
}
