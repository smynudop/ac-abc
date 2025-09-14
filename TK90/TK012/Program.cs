using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var(H, W) = io.ReadInt2();
    var Q = io.ReadInt();
    var uf = new UnionFind(H * W);
    var grid = new bool[H, W];
    while (Q-- > 0)
    {
        var q = io.ReadQuery();
        if(q.Type == 1)
        {
            var (r, c) = q.Content.SplitAs<int, int>();
            r--; c--;
            var id = r * W + c;
            grid[r,c] = true;
            if(r > 0 && grid[r - 1, c]) uf.Union(id, (r - 1) * W + c);
            if(r < H - 1 && grid[r + 1, c]) uf.Union(id, (r + 1) * W + c);
            if(c > 0 && grid[r, c - 1]) uf.Union(id, r * W + (c - 1));
            if(c < W - 1 && grid[r, c + 1]) uf.Union(id, r * W + (c + 1));
        } else
        {
            var(ra, ca, rb, cb) = q.Content.SplitAs<int, int, int, int>();
            ra--; ca--; rb--; cb--;
            if(grid[ra, ca] && grid[rb, cb] && uf.Same(ra * W + ca, rb * W + cb))
            {
                io.WriteLine("Yes");
            } else
            {
                io.WriteLine("No");
            }
        }
    }
}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif