using FluentAssertions;
using GildedRose.UI.Home;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GildedRose.Tests
{
    public class StoreItemTests
    {
        private const int MaxQuality = 50;

        private const int DefaultSellinValue = 10;

        private const int DefaultQualityValue = 20;      

        [Fact]
        public void ReduceNormalItemQualityByOne()
        {
            // Arrange            
            var storeItem = new StoreItem(GetNormalItem());
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
            var storeItem = new StoreItem(GetNormalItem());
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
            var storeItem = new StoreItem(GetNormalItem(sellin: 0));
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
            var storeItem = new StoreItem(GetNormalItem(quality: 0));

            // Act
            storeItem.UpdateQuality();

            // Assert
            storeItem.Quality.Should().Be(0);
        }

        [Fact]
        public void AigedBrieQualityShouldIncrease()
        {
            // Arrange            
            var storeItem = new StoreItem(GetAgedBrie());
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
            var storeItem = new StoreItem(GetAgedBrie(quality: MaxQuality));
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
            var storeItem = new StoreItem(GetAgedBrie(sellin: 0));
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
            var storeItem = new StoreItem(GetSulfuras());
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
            var storeItem = new StoreItem(GetSulfuras());
            int expectedSellIn = storeItem.SellIn;

            // Act
            storeItem.UpdateQuality();

            // Assert
            storeItem.SellIn.Should().Be(expectedSellIn);
        }

        [Theory]
        [InlineData(30, DefaultQualityValue, DefaultQualityValue + 1)]
        [InlineData(20, DefaultQualityValue, DefaultQualityValue + 1)]
        [InlineData(10, DefaultQualityValue, DefaultQualityValue + 2)]
        [InlineData(9, DefaultQualityValue, DefaultQualityValue + 2)]
        [InlineData(5, DefaultQualityValue, DefaultQualityValue + 3)]
        [InlineData(4, DefaultQualityValue, DefaultQualityValue + 3)]
        [InlineData(0, DefaultQualityValue, 0)]
        [InlineData(-1, DefaultQualityValue, 0)]
        public void BackStagePassesQualityShouldIncreaseUntilTheConcertIsOver(int sellin, int initialQuality, int expectedQuality)
        {
            // Arrange            
            var storeItem = new StoreItem(GetBackstage(sellin: sellin, quality: initialQuality));

            // Act
            storeItem.UpdateQuality();

            // Assert
            storeItem.Quality.Should().Be(expectedQuality);
        }

        private static Item GetNormalItem(int sellin = DefaultSellinValue, int quality = DefaultQualityValue) =>
            new Item { Name = "+5 Dexterity Vest", SellIn = sellin, Quality = quality };

        private static Item GetAgedBrie(int sellin = DefaultSellinValue, int quality = DefaultQualityValue) =>
            new Item { Name = "Aged Brie", SellIn = sellin, Quality = quality };

        private static Item GetSulfuras() =>
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = DefaultSellinValue, Quality = DefaultQualityValue };

        private static Item GetBackstage(int sellin = DefaultSellinValue, int quality = DefaultQualityValue) =>
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellin, Quality = quality };
    }
}
