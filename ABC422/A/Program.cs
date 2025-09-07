using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var N = io.ReadInt();
var l = new List<string>(N + 1);
l.Add("");
for (var _ = 0; _ < N; _++)
{
    l.Add(io.ReadLine());
}

var (X, Y) = io.ReadQuery();
io.WriteLine(l[X] == Y ? "Yes" : "No");