using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Theory]
    [InlineData(12,  7, 11,  8)]
    [InlineData(12, 49, 11, 50)]
    [InlineData(12, 50, 11, 50)]
    [InlineData( 1,  7,  0,  8)]
    [InlineData( 0,  7, -1,  9)]
    [InlineData(-4, 14, -5, 16)]
    public void WhenAgedBrie(int currentSellIn, int currentQuality, int nextSellIn, int nextQuality)
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
    
    [Theory]
    [InlineData(-4,  7, -5, 0)]
    [InlineData( 0,  7, -1, 0)]
    [InlineData( 1, 12,  0, 15)]
    [InlineData( 5, 12,  4, 15)]
    [InlineData( 1, 47,  0, 50)]
    [InlineData( 5, 48,  4, 50)]
    [InlineData( 6, 12,  5, 14)]
    [InlineData(10, 12,  9, 14)]
    [InlineData( 6, 48,  5, 50)]
    [InlineData(10, 49,  9, 50)]
    [InlineData(11, 12, 10, 13)]
    [InlineData(11, 49, 10, 50)]
    [InlineData(11, 50, 10, 50)]
    public void WhenBackstage(int currentSellIn, int currentQuality, int nextSellIn, int nextQuality)
    {
        var items = new List<Item>
        {
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = currentSellIn, Quality = currentQuality }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.Equal(nextSellIn, items[0].SellIn);
        Assert.Equal(nextQuality, items[0].Quality);
    }
    
    [Theory]
    [InlineData(12, 80, 12, 80)]
    [InlineData( 0, 80,  0, 80)]
    [InlineData(-5, 80, -5, 80)]
    public void WhenSulfuras(int currentSellIn, int currentQuality, int nextSellIn, int nextQuality)
    {
        var items = new List<Item>
        {
            new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = currentSellIn, Quality = currentQuality }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.Equal(nextSellIn, items[0].SellIn);
        Assert.Equal(nextQuality, items[0].Quality);
    }
    
    [Theory]
    [InlineData(12, 37, 11, 36)]
    [InlineData(12,  1, 11,  0)]
    [InlineData(12,  0, 11,  0)]
    [InlineData( 0, 37, -1, 35)]
    [InlineData( 0,  1, -1,  0)]
    [InlineData( 0,  0, -1,  0)]
    [InlineData(-1, 37, -2, 35)]
    public void WhenOther(int currentSellIn, int currentQuality, int nextSellIn, int nextQuality)
    {
        var items = new List<Item>
        {
            new() { Name = "Other", SellIn = currentSellIn, Quality = currentQuality }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        
        Assert.Equal(nextSellIn, items[0].SellIn);
        Assert.Equal(nextQuality, items[0].Quality);
    }
}