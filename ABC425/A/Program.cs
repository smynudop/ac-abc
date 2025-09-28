using System.Diagnostics;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var sum = 0;
    var N = io.ReadInt();
    for (var i = 1; i <= N; i++)
    {
        sum += (i % 2 == 0 ? 1 : -1) * (i * i * i);
    }
    io.WriteLine(sum);
}

#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif
