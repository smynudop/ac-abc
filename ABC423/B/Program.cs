using System.Diagnostics;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var N = io.ReadInt();
    var L = io.ReadIntArray(N);
    var result = N - 1;
    for (var i = 0; i < N; i++)
    {
        if (L[i] == 0)
        {
            result--;
        }
        else
        {
            break;
        }
    }
    if (result < 0)
    {
        io.WriteLine(0);
        return;
    }
    for (var i = N - 1; i >= 0; i--)
    {
        if (L[i] == 0)
        {
            result--;
        }
        else
        {
            break;
        }
    }
    io.WriteLine(result);

}
#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif
