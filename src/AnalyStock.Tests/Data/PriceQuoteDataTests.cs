using System;
using Xunit;

namespace AnalyStock.Tests;

public class PriceQuoteDataTests
{
    public DateTime timestamp = DateTime.UtcNow;
    public DateTime timestamp1 => this.timestamp.AddMilliseconds(1);
    public float price = 1f;

    public PriceQuoteData priceQuoteData { get; private init; }
    public PriceQuoteData priceQuoteDataEqual { get; private init; }
    public PriceQuoteData priceQuoteDataNotEqual { get; private init; }

    public PriceQuoteDataTests()
    {
        this.priceQuoteData = new PriceQuoteData(this.timestamp, this.price);
        this.priceQuoteDataEqual = new PriceQuoteData(this.timestamp, this.price);
        this.priceQuoteDataNotEqual = new PriceQuoteData(this.timestamp1, this.price);
    }

    [Fact]
    public void ConstructorTest()
    {
        Assert.IsType<PriceQuoteData>(this.priceQuoteData);
        Assert.Equal(timestamp, this.priceQuoteData.timestamp);
        Assert.Equal(price, this.priceQuoteData.price);
    }

    [Fact]
    public void ConstructorTestArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new PriceQuoteData(timestamp, 0f));
        Assert.Throws<ArgumentException>(() => new PriceQuoteData(timestamp, -1f));
    }

    [Fact]
    public void EqualsTest()
    {
        Assert.Equal(this.priceQuoteData.timestamp, this.priceQuoteDataEqual.timestamp);
        Assert.Equal(this.priceQuoteData, this.priceQuoteDataEqual);
        
        Assert.True(this.priceQuoteData.Equals(this.priceQuoteDataEqual));
        Assert.True(this.priceQuoteData.Equals(this.timestamp));
        Assert.True(this.priceQuoteData.Equals((object?) priceQuoteDataEqual));

        Assert.NotEqual(this.priceQuoteData.timestamp, this.priceQuoteDataNotEqual.timestamp);
        Assert.NotEqual(this.priceQuoteData, this.priceQuoteDataNotEqual);

        Assert.False(this.priceQuoteData.Equals(this.priceQuoteDataNotEqual));
        Assert.False(this.priceQuoteData.Equals(this.timestamp1));
        Assert.False(this.priceQuoteData.Equals((object?) this.priceQuoteDataNotEqual));

        Assert.False(this.priceQuoteData.Equals((object?) null));
        Assert.False(this.priceQuoteData.Equals((object?) price));
    }

    [Fact]
    public void GetHashCodeTests()
    {
        Assert.Equal(this.priceQuoteData.GetHashCode(), this.priceQuoteDataEqual.GetHashCode());
        Assert.NotEqual(this.priceQuoteData.GetHashCode(), this.priceQuoteDataNotEqual.GetHashCode());
    }

    [Fact]
    public void ToStringTests()
    {
        var expectedString = $"{this.timestamp.ToString("dd/MM/yyyyTHH:mm:fffffffK")} {this.price}";

        Assert.Equal(expectedString, this.priceQuoteData.ToString());
    }
}