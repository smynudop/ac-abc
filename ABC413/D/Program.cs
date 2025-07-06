using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var T = io.ReadInt();
for (var _i = 0; _i < T; _i++)
{
    var N = io.ReadInt();
    var A = io.ReadIntList();
    var A2 = A.Select(x => ((long)x, Math.Abs(x))).OrderBy(x => x.Item2).ToList();

    if (N <= 2)
    {
        io.WriteLine("Yes");
        continue;
    }


    if (A2[0].Item2 == A2[^1].Item2)
    {
        var p = 0;
        var m = 0;
        for (var i = 0; i < A2.Count; i++)
        {
            if (A2[i].Item1 > 0) { p++; } else { m++; }
        }

        if (p == 0 || m == 0 || Math.Abs(p - m) <= 1)
        {
            io.WriteLine("Yes");
        }
        else
        {
            io.WriteLine("No");
        }
    }
    else
    {
        var flg = true;
        for (var i = 0; i < A2.Count - 2; i++)
        {
            if (A2[i].Item1 * A2[i + 2].Item1 != A2[i + 1].Item1 * A2[i + 1].Item1)
            {
                flg = false;
                break;
            }
        }
        io.WriteLine(flg ? "Yes" : "No");
    }

}