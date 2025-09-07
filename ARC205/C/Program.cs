using System.ComponentModel.DataAnnotations;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var N = io.ReadInt();
var l = new List<(int S, int T, int no)>(N);
for (var _ = 0; _ < N; _++)
{
    var (S, T) = io.ReadInt2();
    l.Add((S, T, _ + 1));
}

l = l.OrderBy(i => i.S).ToList();
var m = int.MinValue;
for (var i = 0; i < l.Count; i++)
{
    if (m > l[i].T)
    {
        io.WriteLine("No");
        return;
    }
    m = l[i].T;
}

io.WriteLine("Yes");
//0 : l, 1 : r
var ll = l.Select(i => i.S < i.T ? 1 : 0).ToList();
var lll = new List<int>();

var result = new List<int>(N);

var prev = ll[0];
for (var i = 0; i < N; i++)
{
    if (prev != ll[i])
    {
        if (prev == 1)
        {
            lll.Reverse();
        }
        result.AddRange(lll);
        lll.Clear();
    }
    lll.Add(l[i].no);
    prev = ll[i];
}
if (prev == 1)
{
    lll.Reverse();
}
result.AddRange(lll);


io.WriteLine(result);