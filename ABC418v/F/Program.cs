using AtCoder.MyLib;
using static AtCoder.MyLib.Util;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var (N, Q) = io.ReadInt2();
var Queries = new List<(int, int)>(Q);
for (var _ = 0; _ < Q; _++)
{
    Queries.Add(io.ReadInt2());
}

