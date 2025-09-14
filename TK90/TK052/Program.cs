using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var N = io.ReadInt();
    long result = 1;
    for (var i = 1; i <= N; i++)
    {
        var A = io.ReadIntArray(6);
        result = (result * A.Sum()) % 1000000007;
    }
    io.WriteLine(result);
}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif