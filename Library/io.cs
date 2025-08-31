using System.Text;

namespace AtCoder.MyLib;

public class MyIO : IDisposable
{
    private StreamReader reader;
    private StreamWriter writer;
    private string? correct = null;
    public MyIO(string[] args)
    {
        if (args.Length == 2)
        {
            this.reader = new StreamReader(args[0]);
            this.correct = File.ReadAllText(args[1]);
        }
        else
        {
            this.reader = new StreamReader(Console.OpenStandardInput(), Console.InputEncoding, false, 1 << 20);
        }
        this.writer = new StreamWriter(Console.OpenStandardOutput(), Console.OutputEncoding, 1 << 20) { AutoFlush = false };
    }

    public void Dispose()
    {
        writer.Write(builder.ToString());
        writer.Flush();

        reader.Dispose();
        writer.Dispose();

        if (this.correct == null)
        {
            return;
        }

        var correctLines = correct.Split('\n').Select(x => x.Trim()).ToList();
        var answer = builder.ToString().Split("\n").Select(x => x.Trim()).ToList();
        for (var i = 0; i < Math.Min(answer.Count, correctLines.Count); i++)
        {
            if (answer[i] != correctLines[i])
            {
                Console.Error.WriteLine($"Error at line {i + 1}: Expected '{correct[i]}', but got '{answer[i]}'");
            }
        }
    }

    public string ReadLine() => reader.ReadLine() ?? string.Empty;

    public int ReadInt() => int.Parse(reader.ReadLine() ?? "0");

    public long ReadLong() => long.Parse(reader.ReadLine() ?? "0");

    public (int, int) ReadInt2()
    {
        var line = Split<int>(reader.ReadLine()!, 2);
        return (line[0], line[1]);
    }

    public (long, long) ReadLong2()
    {
        var line = Split<long>(reader.ReadLine()!, 2);
        return (line[0], line[1]);
    }

    public (int, int, int) ReadInt3()
    {
        var line = Split<int>(reader.ReadLine()!, 3);
        return (line[0], line[1], line[2]);
    }

    public (long, long, long) ReadLong3()
    {
        var line = Split<long>(reader.ReadLine()!, 3);
        return (line[0], line[1], line[2]);
    }

    public (int, int, int, int) ReadInt4()
    {
        var line = Split<int>(reader.ReadLine()!, 4);
        return (line[0], line[1], line[2], line[3]);
    }

    public (long, long, long, long) ReadLong4()
    {
        var line = Split<long>(reader.ReadLine()!, 4);
        return (line[0], line[1], line[2], line[3]);
    }

    public List<int> ReadIntList(int capacity = -1)
    {
        return Split<int>(reader.ReadLine()!, capacity);
    }

    /// <summary>
    /// Arrayで取得
    /// </summary>
    /// <param name="capacity"></param>
    /// <returns></returns>
    public int[] ReadIntArray(int capacity)
    {
        return SplitArray<int>(reader.ReadLine()!, capacity);
    }

    /// <summary>
    /// Arrayで取得
    /// </summary>
    /// <param name="capacity"></param>
    /// <returns></returns>
    public long[] ReadLongArray(int capacity)
    {
        return SplitArray<long>(reader.ReadLine()!, capacity);
    }

    public (int Type, string Content) ReadQuery()
    {
        var chars = reader.ReadLine()!.AsSpan();
        for (var i = 0; i < chars.Length; i++)
        {
            if (chars[i] == ' ')
            {
                return (int.Parse(chars.Slice(0, i)), new string(chars.Slice(i + 1)));
            }
        }
        return (int.Parse(chars), "");
    }

    public List<long> ReadLongList(int capacity = -1)
    {
        return Split<long>(reader.ReadLine()!, capacity);
    }

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
                i++;
                start = i;
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
                i++;
                start = i;
            }
        }
        if (start < chars.Length)
        {
            result[index++] = T.Parse(chars.Slice(start), null);
        }
        return result;
    }

    public static (T1, T2) SplitAs<T1, T2>(string s)
    {
        return s.SplitAs<T1, T2>();
    }

    private StringBuilder builder = new StringBuilder();
    public void Write(object s) => builder.Append(s).Append(' ');
    public void WriteLine(string s) => builder.AppendLine(s);
    public void WriteLine(object s) => builder.AppendLine(s.ToString());
    public void WriteLine(IEnumerable<int> list) => builder.AppendLine(string.Join(' ', list));
    public void WriteLine(IEnumerable<long> list) => builder.AppendLine(string.Join(' ', list));
}
