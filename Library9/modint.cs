using System.Globalization;
using System.Numerics;

namespace AtCoder.MyLib;


public readonly record struct ModInt : IComparable<ModInt>, INumber<ModInt>
{
    public const int BASE = 998244353;
    public readonly int Value;
    public static ModInt Zero { get; } = new ModInt(0);
    public static ModInt One { get; } = new ModInt(1);
    public static int Radix { get; } = 998244353;

    public ModInt(long val)
    {
        this.Value = (int)(((val % BASE) + BASE) % BASE);
    }

    public static ModInt From(long val)
    {
        return new ModInt(val);
    }

    public override string ToString() => Value.ToString();
    public string ToString(string? format, IFormatProvider? provider) => Value.ToString(format, provider);

    public static ModInt operator +(ModInt a) => a;

    public static ModInt operator -(ModInt a) => new ModInt(-a.Value);

    public static ModInt operator +(ModInt a, ModInt b) => new ModInt(a.Value + b.Value);
    public static ModInt operator ++(ModInt a) => new ModInt(a.Value + 1);

    public static ModInt operator -(ModInt a, ModInt b) => new ModInt(a.Value - b.Value);
    public static ModInt operator --(ModInt a) => new ModInt(a.Value - 1);

    public static ModInt operator *(ModInt a, ModInt b) => new ModInt((long)a.Value * b.Value);
    public static ModInt operator /(ModInt a, ModInt b) => a * Inverse(b);
    public static bool operator >(ModInt a, ModInt b) => a.Value > b.Value;
    public static bool operator >=(ModInt a, ModInt b) => a.Value >= b.Value;
    public static bool operator <(ModInt a, ModInt b) => a.Value < b.Value;
    public static bool operator <=(ModInt a, ModInt b) => a.Value <= b.Value;
    public static ModInt operator %(ModInt a, ModInt b) => new ModInt(a.Value % b.Value);

    public static ModInt Inverse(ModInt num) => Pow(num, BASE - 2);

    public static ModInt Pow(ModInt num, int exp)
    {
        var result = new ModInt(1);
        while (exp > 0)
        {
            if ((exp & 1) > 0)
            {
                result *= num;
            }
            num *= num;
            exp >>= 1;
        }
        return result;
    }

    public static implicit operator ModInt(int i) => new ModInt(i);
    public static implicit operator ModInt(long i) => new ModInt(i);


    #region INumberBase
    public static ModInt Abs(ModInt num) => num;
    public static bool IsCanonical(ModInt num) => true;
    public static bool IsComplexNumber(ModInt num) => false;
    public static bool IsEvenInteger(ModInt num) => false;
    public static bool IsFinite(ModInt num) => true;
    public static bool IsImaginaryNumber(ModInt num) => false;
    public static bool IsInfinity(ModInt num) => false;
    public static bool IsInteger(ModInt num) => true;
    public static bool IsNaN(ModInt num) => false;
    public static bool IsNegative(ModInt num) => false;
    public static bool IsNegativeInfinity(ModInt num) => false;
    public static bool IsNormal(ModInt num) => true;
    public static bool IsOddInteger(ModInt num) => false;
    public static bool IsPositive(ModInt num) => true;
    public static bool IsPositiveInfinity(ModInt num) => false;
    public static bool IsRealNumber(ModInt num) => true;
    public static bool IsSubnormal(ModInt num) => false;
    public static bool IsZero(ModInt num) => num.Value == 0;
    public static ModInt MaxMagnitude(ModInt a, ModInt b) => a.Value > b.Value ? a : b;
    public static ModInt MaxMagnitudeNumber(ModInt a, ModInt b) => a.Value > b.Value ? a : b;
    public static ModInt MinMagnitude(ModInt a, ModInt b) => a.Value < b.Value ? a : b;
    public static ModInt MinMagnitudeNumber(ModInt a, ModInt b) => a.Value < b.Value ? a : b;
    public static ModInt Parse(ReadOnlySpan<char> chars, NumberStyles styles, IFormatProvider? formatProvider)
    {
        return new ModInt(long.Parse(chars, styles, formatProvider));
    }
    public static ModInt Parse(ReadOnlySpan<char> chars, IFormatProvider? formatProvider)
    {
        return new ModInt(long.Parse(chars, formatProvider));
    }
    public static ModInt Parse(string str, NumberStyles styles, IFormatProvider? formatProvider)
    {
        return new ModInt(long.Parse(str, styles, formatProvider));
    }
    public static ModInt Parse(string str, IFormatProvider? formatProvider)
    {
        return new ModInt(long.Parse(str, formatProvider));
    }
    public static bool TryParse(ReadOnlySpan<char> chars, NumberStyles styles, IFormatProvider? formatProvider, out ModInt value)
    {
        var success = long.TryParse(chars, styles, formatProvider, out var result);
        value = success ? new ModInt(result) : new ModInt(0);
        return success;
    }
    public static bool TryParse(ReadOnlySpan<char> chars, IFormatProvider? formatProvider, out ModInt value)
    {
        var success = long.TryParse(chars, formatProvider, out var result);
        value = success ? new ModInt(result) : new ModInt(0);
        return success;
    }
    public static bool TryParse(string? str, NumberStyles styles, IFormatProvider? formatProvider, out ModInt value)
    {
        var success = long.TryParse(str, formatProvider, out var result);
        value = success ? new ModInt(result) : new ModInt(0);
        return success;
    }
    public static bool TryParse(string? str, IFormatProvider? formatProvider, out ModInt value)
    {
        var success = long.TryParse(str, formatProvider, out var result);
        value = success ? new ModInt(result) : new ModInt(0);
        return success;
    }
    private static bool TryConvertInternal<TOther>(TOther other, out ModInt result) where TOther : INumberBase<TOther>
    {
        if (other is null)
        {
            result = new ModInt(0);
            return false;
        }
        if (typeof(TOther) == typeof(int))
        {
            result = new ModInt((int)(object)other);
            return true;
        }
        if (typeof(TOther) == typeof(long))
        {
            result = new ModInt((long)(object)other);
            return true;
        }
        result = new ModInt(0);
        return false;
    }
    public static bool TryConvertFromChecked<TOther>(TOther other, out ModInt result) where TOther : INumberBase<TOther>
    {
        return TryConvertInternal<TOther>(other, out result);
    }
    public static bool TryConvertFromSaturating<TOther>(TOther other, out ModInt result) where TOther : INumberBase<TOther>
    {
        return TryConvertInternal<TOther>(other, out result);
    }
    public static bool TryConvertFromTruncating<TOther>(TOther other, out ModInt result) where TOther : INumberBase<TOther>
    {
        return TryConvertInternal<TOther>(other, out result);
    }
    private static bool TryConvertToInternal<TOther>(ModInt value, out TOther result) where TOther : INumberBase<TOther>
    {
        if (typeof(TOther) == typeof(int))
        {
            result = (TOther)(object)value.Value;
            return true;
        }
        if (typeof(TOther) == typeof(long))
        {
            result = (TOther)(object)(long)value.Value;
            return true;
        }
        result = default!;
        return false;
    }
    public static bool TryConvertToChecked<TOther>(ModInt value, out TOther result) where TOther : INumberBase<TOther>
    {
        return TryConvertToInternal<TOther>(value, out result);
    }
    public static bool TryConvertToSaturating<TOther>(ModInt value, out TOther result) where TOther : INumberBase<TOther>
    {
        return TryConvertToInternal<TOther>(value, out result);
    }
    public static bool TryConvertToTruncating<TOther>(ModInt value, out TOther result) where TOther : INumberBase<TOther>
    {
        return TryConvertToInternal<TOther>(value, out result);
    }
    public static ModInt AdditiveIdentity => ModInt.Zero;
    public static ModInt MultiplicativeIdentity => ModInt.One;
    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    #endregion

    public int CompareTo(ModInt target)
    {
        return this.Value.CompareTo(target.Value);
    }

    public int CompareTo(object? target)
    {
        if(target is  ModInt mi)
        {
            return CompareTo(mi);
        }
        throw new ArgumentException("target is not ModInt.");
    }
}