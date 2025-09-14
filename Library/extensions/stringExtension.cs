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

    public static (T1, T2, T3) SplitAs<T1, T2, T3>(this string s)
    {
        var chars = s.AsSpan();
        int[] spaces = new int[2];
        var j = 0;
        for (var i = 0; i < chars.Length; i++)
        {
            if (chars[i] == ' ')
            {
                spaces[j++] = i;
                if (j == 2) break;
            }
        }
        if (j == 2)
        {
            T1 v1 = ParseOrString<T1>(chars.Slice(0, spaces[0]));
            T2 v2 = ParseOrString<T2>(chars.Slice(spaces[0] + 1, spaces[1] - spaces[0] - 1));
            T3 v3 = ParseOrString<T3>(chars.Slice(spaces[1] + 1));
            return (v1, v2, v3);
        }
        throw new Exception();
    }

    public static (T1, T2, T3, T4) SplitAs<T1, T2, T3, T4>(this string s)
    {
        var chars = s.AsSpan();
        int[] spaces = new int[3];
        var j = 0;
        for (var i = 0; i < chars.Length; i++)
        {
            if (chars[i] == ' ')
            {
                spaces[j++] = i;
                if (j == 3) break;
            }
        }
        if (j == 3)
        {
            T1 v1 = ParseOrString<T1>(chars.Slice(0, spaces[0]));
            T2 v2 = ParseOrString<T2>(chars.Slice(spaces[0] + 1, spaces[1] - spaces[0] - 1));
            T3 v3 = ParseOrString<T3>(chars.Slice(spaces[1] + 1, spaces[2] - spaces[1] - 1));
            T4 v4 = ParseOrString<T4>(chars.Slice(spaces[2] + 1));
            return (v1, v2, v3, v4);
        }
        throw new Exception();
    }

    public static int AsInt(this string s)
    {
        return int.Parse(s);
    }

    public static long AsLong(this string s)
    {
        return long.Parse(s);
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