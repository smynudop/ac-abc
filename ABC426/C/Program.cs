using System.Diagnostics;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (N, Q) = io.ReadInt2();
    while (Q-- > 0)
    {
        var (X, Y) = io.ReadInt2();
    }
}

#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif





