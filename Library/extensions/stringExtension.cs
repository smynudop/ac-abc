namespace AtCoder.MyLib;

public static class StringExtension
{
    public static (T1, T2) SplitAs<T1, T2>(this string s)
    {
        var chars = s.AsSpan();
        for (var i = 0; i < chars.Length; i++)
        {
            if (chars[i] == ' ')
            {
                T1 val1 = ParseOrString<T1>(chars.Slice(0, i));
                T2 val2 = ParseOrString<T2>(chars.Slice(i + 1));
                return (val1, val2);
            }
        }
        throw new Exception();
    }

    public static int AsInt(this string s)
    {
        return int.Parse(s);
    }

    public static int AsLong(this string s)
    {
        return int.Parse(s);
    }

    private static T ParseOrString<T>(ReadOnlySpan<char> chars)
    {
        var t = typeof(T);
        if (t == typeof(int))
        {
            return (T)(object)int.Parse(chars);
        }
        if (t == typeof(long))
        {
            return (T)(object)long.Parse(chars);
        }
        if (t == typeof(string))
        {
            return (T)(object)new string(chars);
        }
        throw new InvalidCastException("");
    }
}