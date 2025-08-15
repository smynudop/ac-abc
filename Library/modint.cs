namespace AtCoder.MyLib;


public readonly record struct ModInt : IComparable<ModInt>
{
    public const int BASE = 998244353;
    public readonly int Value;
    public ModInt(long val)
    {
        this.Value = (int)(((val % BASE) + BASE) % BASE);
    }

    public static ModInt From(long val)
    {
        return new ModInt(val);
    }

    public override string ToString() => Value.ToString();

    public static ModInt operator +(ModInt a, ModInt b) => new ModInt(a.Value + b.Value);
    public static ModInt operator -(ModInt a, ModInt b) => new ModInt(a.Value - b.Value);
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

    public int CompareTo(ModInt target)
    {
        return this.Value.CompareTo(target.Value);
    }
}