using System.Diagnostics;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (X, Y) = io.ReadLine().SplitAs<string, string>();
    var xi = X switch
    {
        "Ocelot" => 1,
        "Serval" => 2,
        "Lynx" => 3,
        _ => 0
    };
    var yi = Y switch
    {
        "Ocelot" => 1,
        "Serval" => 2,
        "Lynx" => 3,
        _ => 0
    };
    io.WriteLine(xi >= yi ? "Yes" : "No");
}

#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif
