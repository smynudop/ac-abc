namespace AtCoder.MyLib;

public static class StringExtension
{
    public static (T1, T2) SplitAs<T1, T2>(this string s)
        where T1 : ISpanParsable<T1>
        where T2 : ISpanParsable<T2>
    {
        var chars = s.AsSpan();
        Span<Range> ranges = stackalloc Range[2];
        var cnt = chars.Split(ranges, ' ');
        if(cnt != 2) ThorwSplitException();
        T1 val1 = T1.Parse(chars[ranges[0]], null);
        T2 val2 = T2.Parse(chars[ranges[1]], null);
        return (val1, val2);
    }

    public static (T1, T2, T3) SplitAs<T1, T2, T3>(this string s)
        where T1 : ISpanParsable<T1>
        where T2 : ISpanParsable<T2>
        where T3 : ISpanParsable<T3>
    {
        var chars = s.AsSpan();
        Span<Range> ranges = stackalloc Range[3];
        var cnt = chars.Split(ranges, ' ');
        if (cnt != 3) ThorwSplitException();
        T1 val1 = T1.Parse(chars[ranges[0]], null);
        T2 val2 = T2.Parse(chars[ranges[1]], null);
        T3 val3 = T3.Parse(chars[ranges[2]], null);
        return (val1, val2, val3);
    }

    public static (T1, T2, T3, T4) SplitAs<T1, T2, T3, T4>(this string s)
        where T1 : ISpanParsable<T1>
        where T2 : ISpanParsable<T2>
        where T3 : ISpanParsable<T3>
        where T4 : ISpanParsable<T4>
    {
        var chars = s.AsSpan();
        Span<Range> ranges = stackalloc Range[4];
        var cnt = chars.Split(ranges, ' ');
        if (cnt != 4) ThorwSplitException();
        T1 val1 = T1.Parse(chars[ranges[0]], null);
        T2 val2 = T2.Parse(chars[ranges[1]], null);
        T3 val3 = T3.Parse(chars[ranges[2]], null);
        T4 val4 = T4.Parse(chars[ranges[3]], null);
        return (val1, val2, val3, val4);
    }

    public static int AsInt(this string s)
    {
        return int.Parse(s);
    }

    public static long AsLong(this string s)
    {
        return long.Parse(s);
    }

    private static void ThorwSplitException()
    {
        throw new InvalidOperationException("Split failed");
    }
}