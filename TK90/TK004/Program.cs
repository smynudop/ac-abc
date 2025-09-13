using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (H, W) = io.ReadInt2();
    var l = new List<int>[H];
    for(var i = 0; i < H; i++)
    {
        l[i] = io.ReadIntList(W);
    }

    var RowSum = new int[H];
    var ColSum = new int[W];
    for (var i = 0; i < H; i++)
    {
        RowSum[i] = l[i].Sum();
    }
    for (var i = 0; i < W; i++)
    {
        ColSum[i] = l.Select(x => x[i]).Sum();
    }

    for (var i = 0; i < H; i++)
    {
        var r = new int[W];
        for(var j = 0; j < W; j++)
        {
            r[j] = RowSum[i] + ColSum[j] - l[i][j];
        }
        io.WriteLine(r);
    }
}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif