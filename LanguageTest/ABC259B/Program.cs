using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using AtCoder.MyLib;
SourceExpander.Expander.Expand();




void _main(MyIO io)
{
    var (a, b, d) = io.ReadLine().SplitAs<double, double, double>();
    var rad = d * Math.PI / 180.0;
    var x = a * Math.Cos(rad) - b * Math.Sin(rad);
    var y = a * Math.Sin(rad) + b * Math.Cos(rad);
    io.WriteLine([x, y]);
}

#if DEBUG
MyDebugger.Run(_main);
#else
    using var io = new MyIO();
    _main(io); 
#endif
