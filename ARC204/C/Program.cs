using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var N = io.ReadInt();
int RMax = int.MinValue, RMin = int.MaxValue;
int CMax = int.MinValue, CMin = int.MaxValue;
for (var _ = 0; _ < N; _++)
{
    var (R, C) = io.ReadInt2();
    RMax = Math.Max(R, RMax);
    RMin = Math.Min(R, RMin);
    CMax = Math.Max(C, CMax);
    CMin = Math.Min(C, CMin);
}

var m = Math.Max(RMax - RMin, CMax - CMin);

io.WriteLine((int)Math.Ceiling((double)m / 2));