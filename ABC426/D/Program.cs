using System.Diagnostics;
using System.Security.Cryptography;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

List<(char c, Range r)> _f(string S)
{
    var result = new List<(char, Range)>();
    var startIndex = 0;
    var nowchar = S[0];
    for (var i = 0; i < S.Length; i++)
    {
        if (S[i] == nowchar)
        {

        }
        else
        {
            result.Add((nowchar, new Range(startIndex, i)));
            nowchar = S[i];
            startIndex = i;
        }
    }
    result.Add((nowchar, new Range(startIndex, S.Length)));
    return result;
}

void _main(MyIO io)
{
    var T = io.ReadInt();
    while (T-- > 0)
    {
        var N = io.ReadInt();
        var S = io.ReadLine();
        var l = _f(S);
        var max0 = l.Where(x => x.c == '0').OrderBy(x => x.Item2.End.Value - x.Item2.Start.Value).LastOrDefault();
        var max1 = l.Where(x => x.c == '1').OrderBy(x => x.Item2.End.Value - x.Item2.Start.Value).LastOrDefault();

        int result0 = int.MaxValue, result1 = int.MaxValue;
        if (max0.c != default(char))
        {
            //startindex~maxlen の間が操作しなくてよい
            result0 = N - (max0.Item2.End.Value - max0.Item2.Start.Value);
            for (var i = 0; i < max0.Item2.Start.Value; i++)
            {
                if (S[i] == max0.Item1)
                {
                    result0++;
                }
            }
            for (var i = max0.Item2.End.Value; i < N; i++)
            {
                if (S[i] == max0.Item1)
                {
                    result0++;
                }
            }
        }
        //startindex~maxlen の間が操作しなくてよい
        if (max1.c != default(char))
        {
            result1 = N - (max1.Item2.End.Value - max1.Item2.Start.Value);
            for (var i = 0; i < max1.Item2.Start.Value; i++)
            {
                if (S[i] == max1.Item1)
                {
                    result1++;
                }
            }
            for (var i = max1.Item2.End.Value; i < N; i++)
            {
                if (S[i] == max1.Item1)
                {
                    result1++;
                }
            }
        }
        io.WriteLine(Math.Min(result1, result0));
    }

}

#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif





