using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (N, K) = io.ReadInt2();
    var A = io.ReadIntList(N);
    var B = io.ReadIntList(N);
    var d = Geometry.SapporoDistance(A, B);
    io.WriteLine(K >= d && K % 2 == d % 2 ? "Yes" : "No");

}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif