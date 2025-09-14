using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var N = io.ReadInt();
    var arr = new int[1001, 1001];
    for (var i = 0; i < N; i++)
    {
        var (x1, y1, x2, y2) = io.ReadInt4();
        arr[x1, y1]++;
        arr[x1, y2]--;
        arr[x2 ,y1]--;
        arr[x2 ,y2]++;
    }

    var l = new int[1000];

    var result = new int[N + 1];
    for (var x = 0; x < 1000; x++)
    {
        var d = 0;
        for (var y = 0; y < 1000; y++)
        {
            d += arr[x, y];
            l[y] += d;
            result[l[y]]++;
        }
    }
    for (var i = 1; i <= N; i++)
    {
        io.WriteLine(result[i]);
    }
}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif