using System.Diagnostics;
using System.Security.Cryptography;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var T = io.ReadInt();
    while (T-- > 0)
    {
        var (N, M, K) = io.ReadInt3();
        var S = io.ReadLine().ToCharArray();
        var graph = new List<int>[N];
        for (var i = 0; i < N; i++)
        {
            graph[i] = new List<int>();
        }
        for (var i = 0; i < M; i++)
        {
            var (U, V) = io.ReadInt2();
            graph[U - 1].Add(V - 1);
        }

        var dp = new char[N, K * 2 + 1];
        for (var i = 0; i < N; i++)
        {
            dp[i, K * 2] = S[i];
        }
        for (var t = K - 1; t >= 0; t--)
        {
            for (var i = 0; i < N; i++)
            {
                bool win = false;
                foreach (var node in graph[i])
                {
                    if (dp[node, t * 2 + 2] == 'B')
                    {
                        win = true;
                        break;
                    }
                }
                dp[i, t * 2 + 1] = win ? 'B' : 'A';
            }
            for (var i = 0; i < N; i++)
            {
                bool win = false;
                foreach (var node in graph[i])
                {
                    if (dp[node, t * 2 + 1] == 'A')
                    {
                        win = true;
                        break;
                    }
                }
                dp[i, t * 2] = win ? 'A' : 'B';
            }
        }
        io.WriteLine(dp[0, 0] == 'A' ? "Alice" : "Bob");
    }

}

#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif





