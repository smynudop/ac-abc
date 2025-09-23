using System.Diagnostics;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var T = io.ReadInt();
    while (T-- > 0)
    {
        var (H, W) = io.ReadInt2();
        var S = new string[H];
        foreach (var i in Enumerable.Range(0, H))
        {
            S[i] = io.ReadLine();
        }

        var ans = new HashSet<(int, int)>();
        for (var _h = 0; _h < H - 1; _h++)
        {
            for (var _w = 0; _w < W - 1; _w++)
            {
                if (S[_h][_w] == '#' && S[_h][_w + 1] == '#' && S[_h + 1][_w] == '#' && S[_h + 1][_w + 1] == '#')
                {
                    ans.Add((_h | 1, _w | 1));
                }
            }
        }
        io.WriteLine(ans.Count);
    }
}

#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif





