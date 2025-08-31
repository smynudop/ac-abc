using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

int N = io.ReadInt();
var S = io.ReadLine();


var Bindexes = new List<int>(N);
for (var i = 0; i < N * 2; i++)
{
    if (S[i] == 'B')
    {
        Bindexes.Add(i);
    }
}

long wa1 = 0;
for (var i = 0; i < N; i++)
{
    wa1 += Math.Abs(Bindexes[i] - i * 2);
}

long wa2 = 0;
for (var i = 0; i < N; i++)
{
    wa2 += Math.Abs(Bindexes[i] - (i * 2 + 1));
}
io.WriteLine(Math.Min(wa1, wa2));