using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var (N, M) = io.ReadInt2();

var Points = Enumerable.Repeat(0, N).ToList();
var S = new List<string>();
for (var _ = 0; _ < N; _++)
{
    S.Add(io.ReadLine());
}



for (var j = 0; j < M; j++)
{
    var v0 = 0;
    var v1 = 0;
    for (var i = 0; i < N; i++)
    {
        if (S[i][j] == '1')
        {
            v1++;
        }
        else
        {
            v0++;
        }
    }

    var win = v0 < v1 ? '0' : '1';
    if (v0 == 0) win = '1';
    if (v1 == 0) win = '0';
    for (var i = 0; i < N; i++)
    {
        if (S[i][j] == win)
        {
            Points[i]++;
        }
    }
}

var winp = Points.Max();
var winners = new List<int>();
for (var i = 0; i < N; i++)
{
    if (Points[i] == winp)
    {
        winners.Add(i + 1);
    }
}
io.WriteLine(winners);