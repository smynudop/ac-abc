using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var N = io.ReadInt();
var Points = new List<(int, int)>(N);
for (var _ = 0; _ < N; _++)
{
    Points.Add(io.ReadInt2());
}

var dic = new Dictionary<Vec2D, Dictionary<Vec2D, int>>();

for (var i = 0; i < N; i++)
{
    for (var j = i + 1; j < N; j++)
    {
        var origvec = Vec2D.FromPoints(Points[i], Points[j]);
        var vec = origvec.NormalizeGcd();

        if (!dic.ContainsKey(vec))
        {
            dic[vec] = new();
        }

        var dd = dic[vec];
        dd[origvec] = dd.GetValueOrDefault(origvec, 0) + 1;
    }
}

double result = 0;
foreach (var kvp in dic)
{
    var ddd = kvp.Value;
    var s = 0;
    double ss = 0;
    foreach (var kvp2 in ddd)
    {
        s += kvp2.Value;
        ss += (kvp2.Value * (kvp2.Value - 1)) / 2;
    }
    result += s * (s - 1) / 2;
    result -= (ss / 2);
}

io.WriteLine((int)result);