using System;

namespace SuikaLike.GameFeatures;

public readonly struct SuikaId : IEquatable<SuikaId>
{
    public readonly int Value;

    public SuikaId(int value)
    {
        Value = value;
    }

    public bool Equals(SuikaId other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is SuikaId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value;
    }

    public static bool operator ==(SuikaId left, SuikaId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(SuikaId left, SuikaId right)
    {
        return !left.Equals(right);
    }
}
