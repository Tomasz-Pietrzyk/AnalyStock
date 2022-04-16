using System.Diagnostics.CodeAnalysis;
using System;

namespace AnalyStock {


public readonly struct PriceQuoteData : IEquatable<PriceQuoteData>, IEquatable<DateTime>
{
    private readonly long _timestamp;
    private readonly float _price;

    public readonly DateTime timestamp 
    {
        get => DateTime.FromBinary(this._timestamp);
    }
    public readonly float price 
    {
        get => this._price;
    }
    public PriceQuoteData(DateTime timestamp, float price)  
    { 
        this._timestamp = timestamp.ToUniversalTime().ToBinary();
        this._price = price > 0 ? price : throw new ArgumentException();
    }

    public bool Equals(PriceQuoteData other) => this.Equals(other.timestamp);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is not null && obj.GetType().Equals(typeof(PriceQuoteData)) ? this.Equals((PriceQuoteData)obj) : false;

    public bool Equals(DateTime other) => this._timestamp.Equals(other.ToUniversalTime().ToBinary());

    public override int GetHashCode() => HashCode.Combine<long>(this._timestamp);

    public override string ToString() => $"{this.timestamp.ToString("dd/MM/yyyyTHH:mm:fffffffK")} {this.price}";
}
}