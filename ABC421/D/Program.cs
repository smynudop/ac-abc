using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();
var (Rt, Ct, Ra, Ca) = io.ReadLong4();
if ((Math.Abs(Rt) + Math.Abs(Ct)) % 2 != (Math.Abs(Ra) + Math.Abs(Ca)) % 2)
{
    io.WriteLine(0);
    return;
}

var (N, M, L) = io.ReadLong3();
var S = new Queue<(string, long)>();
var T = new Queue<(string, long)>();

for (var _ = 0; _ < M; _++)
{
    S.Enqueue(io.ReadLine().SplitAs<string, long>());
}

for (var _ = 0; _ < L; _++)
{
    T.Enqueue(io.ReadLine().SplitAs<string, long>());
}

var (SDir, SLeft) = S.Dequeue();
var (TDir, TLeft) = T.Dequeue();

long d = 0;

long move()
{
    (long tdx, long tdy) = SDir switch
    {
        "L" => (-d, 0L),
        "R" => (d, 0L),
        "U" => (0L, -d),
        "D" => (0L, d),
        _ => (0L, 0L)
    };
    (long adx, long ady) = TDir switch
    {
        "L" => (-d, 0L),
        "R" => (d, 0L),
        "U" => (0L, -d),
        "D" => (0L, d),
        _ => (0L, 0L)
    };

    var TStart = new Point3D<long>(Ct, Rt, 0);
    var TEnd = new Point3D<long>(Ct + tdx, Rt + tdy, d);
    var AStart = new Point3D<long>(Ca, Ra, 0);
    var AEnd = new Point3D<long>(Ca + adx, Ra + ady, d);

    Ct += tdx;
    Rt += tdy;
    Ca += adx;
    Ra += ady;

    if (TStart == AStart && SDir == TDir)
    {
        return d;
    }
    else if (TEnd == AEnd)
    {
        return 1;
    }
    else
    {
        return Geometry.IsCross(TStart, TEnd, AStart, AEnd) ? 1 : 0;
    }

}


long cnt = 0;
while (true)
{
    d = Math.Min(SLeft, TLeft);
    cnt += move();
    SLeft -= d;
    if (SLeft == 0)
    {
        var ok = S.TryDequeue(out var t);
        if (!ok) break;
        (SDir, SLeft) = t;
    }
    TLeft -= d;
    if (TLeft == 0)
    {
        var ok = T.TryDequeue(out var t);
        if (!ok) break;
        (TDir, TLeft) = t;
    }
}

io.WriteLine(cnt);