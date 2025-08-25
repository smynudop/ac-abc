using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

checked
{
    var (N, Q) = io.ReadInt2();
    var A = io.ReadIntList();
    var B = io.ReadIntList();

    var Mins = new List<int>(N);
    for (var i = 0; i < N; i++)
    {
        Mins.Add(Math.Min(A[i], B[i]));
    }

    long sum = Mins.Sum();

    for (var _ = 0; _ < Q; _++)
    {
        var query = io.ReadLine();
        var cs = query.Split(' ');
        var c = cs[0];
        var xi = int.Parse(cs[1]) - 1;
        var v = int.Parse(cs[2]);

        if (c == "A")
        {
            A[xi] = v;
        }
        else
        {
            B[xi] = v;
        }

        sum -= Mins[xi];
        Mins[xi] = Math.Min(A[xi], B[xi]);
        sum += Mins[xi];
        io.WriteLine(sum);
    }
}
