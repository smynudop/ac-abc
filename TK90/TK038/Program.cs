using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (A, B) = io.ReadLong2();
    var gcd = GCD.gcd(A, B);
    var ans = (Int128)A * B / gcd;
    long l = 1_000_000_000_000_000_000L;
    io.WriteLine(ans > l ? "Large" : ans.ToString());
}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif