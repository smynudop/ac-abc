using AtCoder.MyLib;
using static AtCoder.MyLib.Util;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var (N, C) = io.ReadInt2();
var A = io.ReadIntList(N);

var S = A.Sum().ToModInt();

A[C - 1]++;

var Socks = A
    .Select((num, index) => (num, index))
    .OrderBy(x => x.num)
    .ToList();

var cache = ModInt.From(0);
var wa = Ruiseki(Socks.Select(x => x.num));

for (var i = Socks.Count - 1; i >= 0; i--)
{
    ModInt r = (i > 0 ? wa[i - 1] : 0).ToModInt();

    var e = (S + cache) / (S - r);
    if (Socks[i].index == C - 1)
    {
        io.WriteLine(e);
        return;
    }
    cache += e * Socks[i].num;
}