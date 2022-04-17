#region License
// Copyright (c) 2007 James Newton-King
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion
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