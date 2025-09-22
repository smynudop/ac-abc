using System.Diagnostics;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (X, C) = io.ReadInt2();
    int result = 0;
    for (var i = 0; i < X; i += 1)
    {
        if (i * (1000 + C) > X)
        {
            break;
        }
        result = i * 1000;
    }
    io.WriteLine(result);
}

#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif
