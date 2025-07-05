using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var N = io.ReadInt();
var cnt = 0;
for (var i = 0; i < N; i++)
{
    var (A, B) = io.ReadInt2();
    if (A < B)
    {
        cnt++;
    }
}
io.WriteLine(cnt);
