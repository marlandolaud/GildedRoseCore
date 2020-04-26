using FluentAssertions;
using GildedRose.Tests.Helpers;
using GildedRose.UI.Home.UpdateStratergy;
using Xunit;

namespace GildedRose.Tests.UpdateStratergy
{
    public class SulfurasUpdateQualityStratergyTests
    {
        private IUpdateQualityStratergy updateQualityStratergy;

        public SulfurasUpdateQualityStratergyTests()
        {
            this.updateQualityStratergy = new SulfurasUpdateQualityStratergy();
        }

        [Fact]
        public void SulfurasQualityShouldNotChange()
        {
            // Arrange            
            var storeItem = StoreItemHelper.GetSulfuras();
            int expectedQuality = storeItem.Quality;

            // Act
            updateQualityStratergy.UpdateQuality(storeItem);

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
            updateQualityStratergy.UpdateQuality(storeItem);

            // Assert
            storeItem.SellIn.Should().Be(expectedSellIn);
        }
    }
}
