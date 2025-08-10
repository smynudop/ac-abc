using System.Drawing;
using System.Net.Mail;
using System.Text.Json.Nodes;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

int gcd(int a, int b)
{
    var aa = Math.Abs(a);
    var bb = Math.Abs(b);
    return aa > bb ? _gcd(aa, bb) : _gcd(bb, aa);
}

int _gcd(int a, int b)
{
    return b == 0 ? a : _gcd(b, a % b);
}

var N = io.ReadInt();
var Points = new List<(int, int)>(N);
for (var _ = 0; _ < N; _++)
{
    Points.Add(io.ReadInt2());
}

var dic = new Dictionary<(int, int), Dictionary<(int, int), int>>();

for (var i = 0; i < N; i++)
{
    for (var j = i + 1; j < N; j++)
    {
        var a = Points[i];
        var b = Points[j];
        var y = b.Item2 - a.Item2;
        var x = b.Item1 - a.Item1;

        var origvec = (0, 0);
        var vec = (0, 0);
        if (x == 0)
        {
            origvec = (0, Math.Abs(y));
            vec = (0, 1);
        }
        else if (y == 0)
        {
            origvec = (Math.Abs(x), 0);
            vec = (1, 0);
        }
        else
        {
            var sign = Math.Sign(x);
            origvec = (x * sign, y * sign);
            var g = gcd(x, y);
            vec = (x * sign / g, y * sign / g);
        }

        if (!dic.ContainsKey(vec))
        {
            dic[vec] = new();
        }

        var dd = dic[vec];

        if (dd.ContainsKey(origvec))
        {
            dd[origvec]++;
        }
        else
        {
            dd[origvec] = 1;
        }
    }
}

double result = 0;
foreach (var kvp in dic)
{
    var ddd = kvp.Value;
    var s = 0;
    double ss = 0;
    foreach (var kvp2 in ddd)
    {
        s += kvp2.Value;
        ss += (kvp2.Value * (kvp2.Value - 1)) / 2;
    }
    result += s * (s - 1) / 2;
    result -= (ss / 2);
}

io.WriteLine((int)result);