using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();


var N = io.ReadInt();
var points = new List<Point2D<int>>(N);
for (var i = 0; i < N; i++)
{
    var (x, y) = io.ReadInt2();
    points.Add(new Point2D<int>(x, y));
}

var rnd = new Random();
for (var _ = 0; _ < 100; _++)
{
    var i = rnd.Next(0, N);
    var j = rnd.Next(0, N);
    if (i == j)
    {
        continue;
    }

    var (a, b, c) = Geometry.Line(points[i], points[j]);

    var cnt = 0;
    foreach (var p in points)
    {
        if (a * p.X + b * p.Y + c == 0)
        {
            cnt++;
        }
    }
    if (cnt >= N / 2 + 1)
    {
        io.WriteLine("Yes");
        io.WriteLine($"{a} {b} {c}");
        return;
    }
}
io.WriteLine("No");