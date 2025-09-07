using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var (N, Q) = io.ReadInt2();
var S = new List<string>(N);
for (var _ = 0; _ < N; _++)
{
    S.Add(io.ReadLine());
}

var Ruiseki = new List<List<int>>(N);

for (var r = 0; r < N - 1; r++)
{
    var l = new List<int>(N);
    var wa = 0;
    l.Add(wa);
    for (var c = 0; c < N - 1; c++)
    {
        if (S[r][c] == '.'
        && S[r][c + 1] == '.'
        && S[r + 1][c] == '.'
        && S[r + 1][c + 1] == '.')
        {
            wa++;
        }
        l.Add(wa);
    }
    Ruiseki.Add(l);
}

for (var _ = 0; _ < Q; _++)
{
    var (U, D, L, R) = io.ReadInt4();

    var ans = 0;
    for (var c = U - 1; c < D - 1; c++)
    {
        ans += Ruiseki[c][R - 1] - Ruiseki[c][L - 1];
    }
    io.WriteLine(ans);
}