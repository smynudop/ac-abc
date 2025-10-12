using System.Diagnostics;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var S = io.ReadLine();
    io.WriteLine(S.Substring(0, S.Length / 2) + S.Substring(S.Length / 2 + 1, S.Length / 2));
}

#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif
