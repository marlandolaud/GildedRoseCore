using FluentAssertions;
using GildedRose.Tests.Helpers;
using GildedRose.UI.Home.UpdateStratergy;
using Xunit;

namespace GildedRose.Tests.UpdateStratergy
{
    public class BackStagePassUpdateQualityStratergyTests
    {
        private IUpdateQualityStratergy updateQualityStratergy;

        public BackStagePassUpdateQualityStratergyTests()
        {
            this.updateQualityStratergy = new BackStagePassUpdateQualityStratergy();
        }

        [Theory]
        [InlineData(30, GildedRoseTestConstants.DefaultQualityValue, GildedRoseTestConstants.DefaultQualityValue + 1)]
        [InlineData(20, GildedRoseTestConstants.DefaultQualityValue, GildedRoseTestConstants.DefaultQualityValue + 1)]
        [InlineData(10, GildedRoseTestConstants.DefaultQualityValue, GildedRoseTestConstants.DefaultQualityValue + 2)]
        [InlineData(9, GildedRoseTestConstants.DefaultQualityValue, GildedRoseTestConstants.DefaultQualityValue + 2)]
        [InlineData(4, GildedRoseTestConstants.DefaultQualityValue, GildedRoseTestConstants.DefaultQualityValue + 3)]
        [InlineData(5, GildedRoseTestConstants.DefaultQualityValue, GildedRoseTestConstants.DefaultQualityValue + 3)]
        [InlineData(1, GildedRoseTestConstants.DefaultQualityValue, GildedRoseTestConstants.DefaultQualityValue + 3)]
        [InlineData(0, GildedRoseTestConstants.DefaultQualityValue, 0)]
        [InlineData(-1, GildedRoseTestConstants.DefaultQualityValue, 0)]
        public void BackStagePassesQualityShouldIncreaseUntilTheConcertIsOver(int sellin, int initialQuality, int expectedQuality)
        {
            // Arrange            
            var storeItem = StoreItemHelper.GetBackstage(sellin: sellin, quality: initialQuality);

            // Act
            updateQualityStratergy.UpdateQuality(storeItem);

            // Assert
            storeItem.Quality.Should().Be(expectedQuality);
        }
    }
}
