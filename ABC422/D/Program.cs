using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

int rev(int x, int _bas)
{
    var result = 0;
    while (_bas > 0)
    {
        if ((x % 2) == 1)
        {
            result |= (1 << (_bas - 1));
        }
        x = x >> 1;
        _bas--;
    }
    return result;
}

var (N, K) = io.ReadInt2();
var total = (int)Math.Pow(2, N);
var bas = K / total;

var l = Enumerable.Repeat(bas, total).ToList();

var t = (1 << N) - 1;
for (var i = 0; i < K - bas * total; i++)
{
    l[rev(i, N)]++;
}
io.WriteLine(bas * total == K ? 0 : 1);
io.WriteLine(l);