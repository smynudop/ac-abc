using System.Diagnostics;
using System.Reflection.Metadata;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    long f(long num)
    {
        return num.ToString().Select(c => int.Parse(c.ToString())).Sum();
    }
    var N = io.ReadInt();
    long A = 1;
    long S = 0;
    for (var i = 1; i <= N; i++)
    {
        var fa = f(A);
        A = S + fa;
        S += fa;
    }
    io.WriteLine(A);
}
#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif
