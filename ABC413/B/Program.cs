using System.Security.Cryptography;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var N = io.ReadInt();
var S = new List<string>(N);
for (var i = 0; i < N; i++)
{
    S.Add(io.ReadLine());
}

var set = new HashSet<string>();
for (var i = 0; i < N; i++)
{
    for (var j = 0; j < N; j++)
    {
        if (i == j)
        {
            continue;
        }
        set.Add(S[i] + S[j]);
    }
}
io.WriteLine(set.Count);