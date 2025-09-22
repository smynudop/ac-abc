namespace AtCoder.MyLib;

public static class GCD
{

    /// <summary>
    /// 最大公約数を求めます。
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static int gcd(int a, int b)
    {
        if (b == 0)
        {
            return a;
        }
        return gcd(b, a % b);
    }

    /// <summary>
    /// 最大公約数を求めます。
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static long gcd(long a, long b)
    {
        if (b == 0)
        {
            return a;
        }
        return gcd(b, a % b);
    }

    /// <summary>
    /// 最小公倍数を求めます。桁溢れした場合は-1を返します。
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static long lcm(long a, long b)
    {
        var _gcd = gcd(a,b);
        var _lcm = a / _gcd * b;
        return _lcm < 0 ? -1 : _lcm;
    }

    /// <summary>
    /// 最小公倍数を求めます。桁溢れした場合はoverflowの値を返します。
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static long lcm_checked(long a, long b, long overflow)
    {
        long _gcd = gcd(a, b);
        long x = a/ _gcd;
        if(b != 0 && x > overflow / b)
        {
            return overflow;
        }
        return x * b;
    }

    /// <summary>
    /// ax + by = c なるx, yの1つを返します
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    public static (int x, int y) gcdex(int a, int b, int c)
    {
        var d = gcd(a, b);
        var (x, y) = _gcdex(a / d, b / d);
        return (x * (c / d), y * (c / d));
    }

    /// <summary>
    /// ax + by = gcd(a,b) なるx, yの1つを返します
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    private static (int x, int y) _gcdex(int a, int b)
    {
        if (b == 0)
        {
            return (1, 0);
        }
        var (xx, yy) = _gcdex(b, a % b);
        return (yy, xx - (a / b) * yy);
    }
}