using FluentAssertions;
using GildedRose.Tests.Helpers;
using GildedRose.UI.Home.UpdateStratergy;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GildedRose.Tests.UpdateStratergy
{
    public class BetterWithTimeUpdateQualityStratergyTests
    {
        private IUpdateQualityStratergy agedBrieUpdateQualityStratergy;

        public BetterWithTimeUpdateQualityStratergyTests()
        {
            agedBrieUpdateQualityStratergy = new BetterWithTimeUpdateQualityStratergy();
        }

        [Fact]
        public void AigedBrieQualityShouldIncrease()
        {
            // Arrange            
            var storeItem = StoreItemHelper.GetAgedBrie();
            int expectedQuality = storeItem.Quality + 1;

            // Act
            agedBrieUpdateQualityStratergy.UpdateQuality(storeItem);

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
            agedBrieUpdateQualityStratergy.UpdateQuality(storeItem);

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
            agedBrieUpdateQualityStratergy.UpdateQuality(storeItem);

            // Assert
            storeItem.Quality.Should().Be(expectedQuality);
        }
    }
}
