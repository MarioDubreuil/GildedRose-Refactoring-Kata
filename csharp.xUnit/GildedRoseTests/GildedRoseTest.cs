using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void WhenAgedBrieV1()
    {
        var items = new List<Item>
        {
            new() { Name = "Aged Brie", SellIn = 12, Quality = 7 },
            new() { Name = "Aged Brie", SellIn = 12, Quality = 49 },
            new() { Name = "Aged Brie", SellIn = 12, Quality = 50 },
            new() { Name = "Aged Brie", SellIn = 1, Quality = 7 },
            new() { Name = "Aged Brie", SellIn = 0, Quality = 7 },
            new() { Name = "Aged Brie", SellIn = -4, Quality = 14 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.Equal(11, items[0].SellIn);
        Assert.Equal(8, items[0].Quality);
        
        Assert.Equal(11, items[1].SellIn);
        Assert.Equal(50, items[1].Quality);
        
        Assert.Equal(11, items[2].SellIn);
        Assert.Equal(50, items[2].Quality);
        
        Assert.Equal(0, items[3].SellIn);
        Assert.Equal(8, items[3].Quality);
        
        Assert.Equal(-1, items[4].SellIn);
        Assert.Equal(9, items[4].Quality);
        
        Assert.Equal(-5, items[5].SellIn);
        Assert.Equal(16, items[5].Quality);
    }
    
    [Theory]
    [InlineData(12, 7, 11, 8)]
    [InlineData(12, 49, 11, 50)]
    [InlineData(12, 50, 11, 50)]
    [InlineData(1, 7, 0, 8)]
    [InlineData(0, 7, -1, 9)]
    [InlineData(-4, 14, -5, 16)]
    public void WhenAgedBrieV2(int currentSellIn, int currentQuality, int nextSellIn, int nextQuality)
    {
        var items = new List<Item>
        {
            new() { Name = "Aged Brie", SellIn = currentSellIn, Quality = currentQuality }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.Equal(nextSellIn, items[0].SellIn);
        Assert.Equal(nextQuality, items[0].Quality);
    }
}