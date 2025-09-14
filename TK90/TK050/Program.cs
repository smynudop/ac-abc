using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (N, L) = io.ReadInt2();
    var dp = new long[N + 1];
    dp[0] = 1;
    for(var i = 1; i <= N; i++)
    {
        dp[i] = dp[i - 1];
        if (i - L >= 0) dp[i] += dp[i - L];
        dp[i] %= 1000000007;
    }
    io.WriteLine(dp[N]);
}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif