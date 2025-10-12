using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var T = io.ReadInt();
    while (T-- > 0)
    {
        var (TSx, TSy, TGx, TGy) = io.ReadLine().SplitAs<double, double, double, double>();
        var (ASx, ASy, AGx, AGy) = io.ReadLine().SplitAs<double, double, double, double>();

        var TS = new Point2D<double>(TSx, TSy);
        var TG = new Point2D<double>(TGx, TGy);
        var AS = new Point2D<double>(ASx, ASy);
        var AG = new Point2D<double>(AGx, AGy);

        var Vt = TG - TS;
        var Va = AG - AS;
        var Lt = Vt.Norm();
        var La = Va.Norm();
        Vt /= Lt;
        Va /= La;

        var tt = Math.Min(Lt, La);

        //ケース1 両方うごく
        var S1 = AS - TS;
        var V1 = Va - Vt;
        var VV = V1.InnerProduct(V1);
        var SV = S1.InnerProduct(V1);
        var SS = S1.InnerProduct(S1);

        var Tmin1 = -S1.InnerProduct(V1) / V1.InnerProduct(V1);
        if (Tmin1 < 0) Tmin1 = 0;
        if (Tmin1 > tt) Tmin1 = tt;
        var dmin1 = VV * tt * tt + 2 * SV * tt + SS * SS;

        //ケース2 片方だけ動いてる

    }

}

#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif

public class IntCDesc : IComparer<double>
{
    public int Compare(double a, double b)
    {
        return b.CompareTo(a);
    }
}