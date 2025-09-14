using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var T = (double)io.ReadInt();
    var (L, X, Y) = io.ReadInt3();
    var Q = io.ReadInt();
    while(Q-- > 0)
    {
        var e = (double)io.ReadInt();

        var theta = e * 2 * Math.PI / T;
        var halfL = (double)L / 2;
        var b = -Math.Sin(theta) * halfL;
        var c = (-Math.Cos(theta) + 1) * halfL;

        var a = Math.Sqrt((double)X * (double)X + ((double)Y - b) * ((double)Y - b));
        var ans = Math.Atan2(c,a) / Math.PI / 2 * 360;

        io.WriteLine(ans);
    }
}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif