using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var N = io.ReadInt();
    var S = io.ReadLine();
    var dp = new long[N+1, 8];
    dp[0, 0] = 1;
    for( var i = 0; i < N; i++)
    {   
        for(var j = 0; j < 8; j++)
        {
            dp[i + 1, j] += dp[i, j];
            if(S[i] == 'a' && j == 0) dp[i + 1, 1] += dp[i, 0];
            if(S[i] == 't' && j == 1) dp[i + 1, 2] += dp[i, 1];
            if(S[i] == 'c' && j == 2) dp[i + 1, 3] += dp[i, 2];
            if(S[i] == 'o' && j == 3) dp[i + 1, 4] += dp[i, 3];
            if(S[i] == 'd' && j == 4) dp[i + 1, 5] += dp[i, 4];
            if(S[i] == 'e' && j == 5) dp[i + 1, 6] += dp[i, 5];
            if(S[i] == 'r' && j == 6) dp[i + 1, 7] += dp[i, 6];
            dp[i + 1, j] %= 1000000007;
        }   
    }
    io.WriteLine(dp[N, 7]);
}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif