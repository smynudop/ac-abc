using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var (Rt, Ct, Ra, Ca) = io.ReadLong4();
if ((Rt + Ct) % 2 != (Ra + Ca) % 2)
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
    long encount = 0;
    (long tdx, long tdy) = SDir switch
    {
        "U" => (0L, -d),
        "D" => (0L, d),
        "L" => (-d, 0L),
        "R" => (d, 0L),
        _ => (0L, 0L)
    };
    (long adx, long ady) = TDir switch
    {
        "U" => (0L, -d),
        "D" => (0L, d),
        "L" => (-d, 0L),
        "R" => (d, 0L),
        _ => (0L, 0L)
    };
    var Rt2 = Rt + tdy;
    var Ct2 = Ct + tdx;
    var Ra2 = Ra + ady;
    var Ca2 = Ca + adx;

    if (SDir == TDir)
    {
        encount = ((Rt == Ra) && (Ct == Ca)) ? d : 0;
    }
    else if ((SDir == "R" && TDir == "L") || (SDir == "L" && TDir == "R"))
    {
        encount = (Rt == Ra) && (Ct2 == Ca2 || (Ct.CompareTo(Ca) * Ct2.CompareTo(Ca2) < 0)) ? 1 : 0;
    }
    else if ((SDir == "U" && TDir == "D") || (SDir == "D" && TDir == "U"))
    {
        encount = (Ct == Ca) && (Rt2 == Ra2 || (Rt.CompareTo(Ra) * Ct2.CompareTo(Ra2) < 0)) ? 1 : 0;
    }
    else
    {
        if (Rt + Ct == Ra + Ca || Rt - Ct == Ra + Ca)
        {

        }
    }

    Rt = Rt2;
    Ct = Ct2;
    Ra = Ra2;
    Ca = Ca2;


    return encount;
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