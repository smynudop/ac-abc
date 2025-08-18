using System.Text;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var (N, M) = io.ReadInt2();
var S = io.ReadLine();
var T = io.ReadLine();

var list = Enumerable.Repeat(0, N + 1).ToList();
for (var _ = 0; _ < M; _++)
{
    var (L, R) = io.ReadInt2();
    list[L - 1]++;
    list[R]--;
}

var result = new StringBuilder(N);
var n = 0;
for (var i = 0; i < N; i++)
{
    n += list[i];
    result.Append(n % 2 == 0 ? S[i] : T[i]);
}

io.WriteLine(result.ToString());