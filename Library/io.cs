using System.Text;
using System.Runtime.CompilerServices;
namespace AtCoder.MyLib;

public class MyIO : IDisposable
{
    private TextReader reader;
    private TextWriter writer;
    public MyIO(string[] args)
    {
        if (args.Length == 2)
        {
            this.reader = new StreamReader(args[0]);
        }
        else
        {
            this.reader = new StreamReader(Console.OpenStandardInput(), Console.InputEncoding, false, 1 << 20);
        }
        this.writer = new StreamWriter(Console.OpenStandardOutput(), Console.OutputEncoding, 1 << 20) { AutoFlush = false };
    }

    public MyIO()
    {
        this.reader = new StreamReader(Console.OpenStandardInput(), Console.InputEncoding, false, 1 << 20);
        this.writer = new StreamWriter(Console.OpenStandardOutput(), Console.OutputEncoding, 1 << 20) { AutoFlush = false };
    }

    public MyIO(TextReader reader)
    {
        this.reader = reader;
        this.writer = new StreamWriter(Console.OpenStandardOutput(), Console.OutputEncoding, 1 << 20) { AutoFlush = false };
    }

    public MyIO(TextReader reader, TextWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }

    public void Flush()
    {
        writer.Flush();
    }

    public void Dispose()
    {
        writer.Flush();

        reader.Dispose();
        writer.Dispose();
    }

    public string ReadLine() => reader.ReadLine() ?? string.Empty;

    public int ReadInt() => int.Parse(reader.ReadLine() ?? "0");

    public long ReadLong() => long.Parse(reader.ReadLine() ?? "0");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public (int, int) ReadInt2() => reader.ReadLine()!.SplitAs<int, int>();

    public (long, long) ReadLong2() => reader.ReadLine()!.SplitAs<long, long>();

    public (Int128, Int128) ReadInt128_2() => reader.ReadLine()!.SplitAs<Int128, Int128>();

    public (int, int, int) ReadInt3() => reader.ReadLine()!.SplitAs<int, int, int>();

    public (long, long, long) ReadLong3() => reader.ReadLine()!.SplitAs<long, long, long>();

    public (int, int, int, int) ReadInt4() => reader.ReadLine()!.SplitAs<int, int, int, int>();

    public (long, long, long, long) ReadLong4() => reader.ReadLine()!.SplitAs<long, long, long, long>();


    public List<int> ReadIntList(int capacity = -1) => Split<int>(reader.ReadLine()!, capacity);
    public List<long> ReadLongList(int capacity = -1) => Split<long>(reader.ReadLine()!, capacity);

    /// <summary>
    /// Arrayで取得
    /// </summary>
    /// <param name="capacity"></param>
    /// <returns></returns>
    public int[] ReadIntArray(int capacity) => SplitArray<int>(reader.ReadLine()!, capacity);

    /// <summary>
    /// Arrayで取得
    /// </summary>
    /// <param name="capacity"></param>
    /// <returns></returns>
    public long[] ReadLongArray(int capacity) => SplitArray<long>(reader.ReadLine()!, capacity);

    public (int Type, string Content) ReadQuery() => reader.ReadLine()!.SplitAs<int, string>();

    public (TQuery Type, string Content) ReadQuery<TQuery>() => reader.ReadLine()!.SplitAs<TQuery, string>();


    private List<T> Split<T>(string s, int capacity = -1) where T : ISpanParsable<T>
    {
        var result = capacity >= 0 ? new List<T>(capacity) : new List<T>();
        var chars = s.AsSpan();
        var start = 0;
        for (var i = 0; i < chars.Length; i++)
        {
            if (chars[i] == ' ')
            {
                result.Add(T.Parse(chars.Slice(start, i - start), null));
                start = i + 1;
            }
        }
        if (start < chars.Length)
        {
            result.Add(T.Parse(chars.Slice(start), null));
        }
        return result;
    }

    private T[] SplitArray<T>(string s, int capacity) where T : ISpanParsable<T>
    {
        var result = new T[capacity];
        var chars = s.AsSpan();
        var start = 0;
        var index = 0;
        for (var i = 0; i < chars.Length; i++)
        {
            if (chars[i] == ' ')
            {
                result[index++] = T.Parse(chars.Slice(start, i - start), null);
                start = i + 1;
            }
        }
        if (start < chars.Length)
        {
            result[index++] = T.Parse(chars.Slice(start), null);
        }
        return result;
    }
    public void WriteLine(string s) => writer.WriteLine(s);
    public void WriteLine(object s) => writer.WriteLine(s.ToString());
    public void WriteLine(IEnumerable<int> list) => writer.WriteLine(string.Join(' ', list));
    public void WriteLine(IEnumerable<long> list) => writer.WriteLine(string.Join(' ', list));
}
