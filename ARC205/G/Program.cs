using System.Buffers;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var (H, W, K) = io.ReadInt3();
var black = new List<long>(K);
for (var i = 0; i < K; i++)
{
    var _p = io.ReadInt2();
    black.Add(((long)_p.Item2 << 32) + _p.Item1);
}
var left = new HashSet<long>(black);


var neighbor = new List<(int, int)> {
    (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1)
};

for (var i = 0; i < black.Count; i++)
{
    var start = black[i];
    if (!left.Contains(start))
    {
        continue;
    }

    var topright = false;
    var leftbottom = false;

    var stc = new Stack<long>();
    stc.Push(start);
    left.Remove(start);

    while (stc.Count > 0)
    {
        var p = stc.Pop();

        var X = p >> 32;
        var Y = p & ((1L << 32) - 1);

        if (Y == 1 || X == W)
        {
            topright = true;
        }
        if (X == 1 || Y == H)
        {
            leftbottom = true;
        }

        for (var j = 0; j < neighbor.Count; j++)
        {
            var (_x, _y) = neighbor[j];
            var _p = ((X + _x) << 32) + (Y + _y);
            if (left.Contains(_p))
            {
                stc.Push(_p);
                left.Remove(_p);
            }
        }
    }

    if (topright && leftbottom)
    {
        io.WriteLine("No");
        return;
    }
}

io.WriteLine("Yes");
