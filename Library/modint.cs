using System.Numerics;

namespace AtCoder.MyLib;


public readonly record struct ModInt : IComparable<ModInt>//, INumberBase<ModInt>
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

    public static ModInt operator +(ModInt a) => a;

    public static ModInt operator -(ModInt a) => new ModInt(-a.Value);

    public static ModInt operator +(ModInt a, ModInt b) => new ModInt(a.Value + b.Value);
    public static ModInt operator ++(ModInt a) => new ModInt(a.Value + 1);

    public static ModInt operator -(ModInt a, ModInt b) => new ModInt(a.Value - b.Value);
    public static ModInt operator --(ModInt a) => new ModInt(a.Value - 1);

    public static ModInt operator *(ModInt a, ModInt b) => new ModInt((long)a.Value * b.Value);
    public static ModInt operator /(ModInt a, ModInt b) => a * Inverse(b);
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


    #region INumberBase�̎���
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

    #endregion

    public int CompareTo(ModInt target)
    {
        return this.Value.CompareTo(target.Value);
    }
}