using FluentAssertions;
using GildedRose.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GildedRose.Tests
{
    public partial class StoreItemTests
    {

        [Fact]
        public void ReduceNormalItemQualityByOne()
        {
            // Arrange            
            var storeItem = StoreItemHelper.GetNormalItem();
            int expectedQuality = storeItem.Quality - 1;

            // Act
            storeItem.UpdateQuality();

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
            storeItem.UpdateQuality();

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
            storeItem.UpdateQuality();

            // Assert
            storeItem.Quality.Should().Be(expectedQuality);
        }

        [Fact]
        public void QualityShouldNeverBeNegative()
        {
            // Arrange            
            var storeItem = StoreItemHelper.GetNormalItem(quality: 0);

            // Act
            storeItem.UpdateQuality();

            // Assert
            storeItem.Quality.Should().Be(0);
        }

        [Fact]
        public void AigedBrieQualityShouldIncrease()
        {
            // Arrange            
            var storeItem = StoreItemHelper.GetAgedBrie();
            int expectedQuality = storeItem.Quality + 1;

            // Act
            storeItem.UpdateQuality();

            // Assert
            storeItem.Quality.Should().Be(expectedQuality);
        }

        [Fact]
        public void ShouldNotIncreseQualityOfAgedBriePast50()
        {
            // Arrange            
            var storeItem = StoreItemHelper.GetAgedBrie(quality: GildedRoseTestConstants.MaxQuality);
            int expectedQuality = storeItem.Quality;

            // Act
            storeItem.UpdateQuality();

            // Assert
            storeItem.Quality.Should().Be(expectedQuality);
        }

        [Fact]
        public void ShouldIncreaseQualityOfAgedBrieBy2AfterSellin()
        {

            // Arrange            
            var storeItem = StoreItemHelper.GetAgedBrie(sellin: 0);
            int expectedQuality = storeItem.Quality + 2;

            // Act
            storeItem.UpdateQuality();

            // Assert
            storeItem.Quality.Should().Be(expectedQuality);
        }

        [Fact]
        public void SulfurasQualityShouldNotChange()
        {
            // Arrange            
            var storeItem = StoreItemHelper.GetSulfuras();
            int expectedQuality = storeItem.Quality;

            // Act
            storeItem.UpdateQuality();

            // Assert
            storeItem.Quality.Should().Be(expectedQuality);
        }

        [Fact]
        public void SulfurasSellInShouldNotChange()
        {
            // Arrange            
            var storeItem = StoreItemHelper.GetSulfuras();
            int expectedSellIn = storeItem.SellIn;

            // Act
            storeItem.UpdateQuality();

            // Assert
            storeItem.SellIn.Should().Be(expectedSellIn);
        }

        [Theory]
        [InlineData(30, GildedRoseTestConstants.DefaultQualityValue, GildedRoseTestConstants.DefaultQualityValue + 1)]
        [InlineData(20, GildedRoseTestConstants.DefaultQualityValue, GildedRoseTestConstants.DefaultQualityValue + 1)]
        [InlineData(10, GildedRoseTestConstants.DefaultQualityValue, GildedRoseTestConstants.DefaultQualityValue + 2)]
        [InlineData(9, GildedRoseTestConstants.DefaultQualityValue, GildedRoseTestConstants.DefaultQualityValue + 2)]
        [InlineData(4, GildedRoseTestConstants.DefaultQualityValue, GildedRoseTestConstants.DefaultQualityValue + 3)]
        [InlineData(5, GildedRoseTestConstants.DefaultQualityValue, GildedRoseTestConstants.DefaultQualityValue + 3)]
        [InlineData(0, GildedRoseTestConstants.DefaultQualityValue, 0)]
        [InlineData(-1, GildedRoseTestConstants.DefaultQualityValue, 0)]
        public void BackStagePassesQualityShouldIncreaseUntilTheConcertIsOver(int sellin, int initialQuality, int expectedQuality)
        {
            // Arrange            
            var storeItem = StoreItemHelper.GetBackstage(sellin: sellin, quality: initialQuality);

            // Act
            storeItem.UpdateQuality();

            // Assert
            storeItem.Quality.Should().Be(expectedQuality);
        }
    }
}
