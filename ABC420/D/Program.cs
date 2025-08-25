using System.Text;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var (N, M) = io.ReadInt2();
var S = io.ReadLine();
var T = io.ReadLine();

var im = new Imos(N);
for (var _ = 0; _ < M; _++)
{
    var (L, R) = io.ReadInt2();
    im.Add(L - 1, R);
}

var result = new StringBuilder(N);
var r = im.Result;
for (var i = 0; i < N; i++)
{
    result.Append(r[i] % 2 == 0 ? S[i] : T[i]);
}

io.WriteLine(result.ToString());