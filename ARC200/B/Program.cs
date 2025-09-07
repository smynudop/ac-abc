using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var Q = io.ReadInt();
var l = new SortedDictionary<int, int>();
for (var _ = 0; _ < Q; _++)
{
    var line = io.ReadLine();
    if (line[0] == '1')
    {
        var n = int.Parse(line.Substring(2));
        l[n] = l.GetValueOrDefault(n) + 1;
    }
    else
    {
        int n = -1;
        foreach (var kvp in l)
        {
            n = kvp.Key;
            if (l[n] > 0)
            {
                break;
            }
        }
        l[n]--;
        io.WriteLine(n);
    }
}