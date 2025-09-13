using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    checked
    {
        var K = io.ReadInt();
        int[,] dp = new int[K + 1, 9];
        dp[0, 0] = 1;
        for (var n = 1; n <= K; n++)
        {
            for (var last = 0; last <= 8; last++)
            {
                for (var j = 1; j <= 9; j++)
                {
                    if (n - j >= 0)
                    {
                        dp[n, last] += dp[n - j, (9 + last - j) % 9];
                        dp[n, last] %= 1_000_000_007;
                    }
                }

            }
        }
        io.WriteLine(dp[K, 0]);
    }
}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif