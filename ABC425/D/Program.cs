using System.Diagnostics;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (H, W) = io.ReadInt2();
    var S = new List<char[]>(H);
    for (var i = 0; i < H; i++)
    {
        S.Add(io.ReadLine().ToCharArray());
    }

    var edges = new HashSet<(int, int)>();
    var result = 0;
    for (var y = 0; y < H; y++)
    {
        for (var x = 0; x < W; x++)
        {
            if (S[y][x] == '#')
            {
                result++;
                if (y > 0 && S[y - 1][x] == '.') edges.Add((y - 1, x));
                if (y < H - 1 && S[y + 1][x] == '.') edges.Add((y + 1, x));
                if (x > 0 && S[y][x - 1] == '.') edges.Add((y, x - 1));
                if (x < W - 1 && S[y][x + 1] == '.') edges.Add((y, x + 1));
            }
        }
    }

    while (edges.Count > 0)
    {
        var next = new HashSet<(int, int)>();
        foreach (var (y, x) in edges)
        {
            var black = 0;
            if (y > 0 && S[y - 1][x] == '#') black++;
            if (y < H - 1 && S[y + 1][x] == '#') black++;
            if (x > 0 && S[y][x - 1] == '#') black++;
            if (x < W - 1 && S[y][x + 1] == '#') black++;
            if (black == 1)
            {
                next.Add((y, x));
            }
        }
        if (next.Count == 0)
        {
            break;
        }
        foreach (var (y, x) in next)
        {
            result++;
            S[y][x] = '#';
        }

        var nextedges = new HashSet<(int, int)>();
        foreach (var (y, x) in next)
        {
            if (y > 0 && S[y - 1][x] == '.') nextedges.Add((y - 1, x));
            if (y < H - 1 && S[y + 1][x] == '.') nextedges.Add((y + 1, x));
            if (x > 0 && S[y][x - 1] == '.') nextedges.Add((y, x - 1));
            if (x < W - 1 && S[y][x + 1] == '.') nextedges.Add((y, x + 1));
        }
        edges = nextedges;
    }
    io.WriteLine(result);
}

#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif





