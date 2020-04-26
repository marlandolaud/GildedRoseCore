using FluentAssertions;
using GildedRose.Tests.Helpers;
using GildedRose.UI.Home.UpdateStratergy;
using Xunit;

namespace GildedRose.Tests.UpdateStratergy
{
    public class DefaultStratergyTests
    {
        private IUpdateQualityStratergy updateQualityStratergy;

        public DefaultStratergyTests()
        {
            updateQualityStratergy = new DefaultUpdateQualityStratergy();
        }

        [Fact]
        public void ReduceNormalItemQualityByOne()
        {
            // Arrange            
            var storeItem = StoreItemHelper.GetNormalItem();
            int expectedQuality = storeItem.Quality - 1;

            // Act
            updateQualityStratergy.UpdateQuality(storeItem);

            // Assert
            storeItem.Quality.Should().Be(expectedQuality);
        }

        [Fact]
        public void ReduceNormalItemSellInByOne()
        {
            // Arrange            
            var storeItem = StoreItemHelper.GetNormalItem();
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
            int expectedQuality = storeItem.Quality - 2;

            // Act
            updateQualityStratergy.UpdateQuality(storeItem);

            // Assert
            storeItem.Quality.Should().Be(expectedQuality);
        }

        [Fact]
        public void QualityShouldNeverBeNegative()
        {
            // Arrange            
            var storeItem = StoreItemHelper.GetNormalItem(quality: 0);

            // Act
            updateQualityStratergy.UpdateQuality(storeItem);

            // Assert
            storeItem.Quality.Should().Be(0);
        }
    }
}
