using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var (X, Y) = io.ReadLong2();

long fib(int n)
{
    if (n == 1) return X;
    if (n == 2) return Y;
    return long.Parse(new string((fib(n - 1) + fib(n - 2)).ToString().Reverse().ToArray()));
}

io.WriteLine(fib(10));