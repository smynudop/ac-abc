using System.Diagnostics;
using System.Numerics;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    checked
    {
        var (N, M, Y) = io.ReadLine().SplitAs<int, int, long>();
        var A = io.ReadLongArray(N);

        var lcm = new long[1 << N];
        var zeta = new long[1 << N];
        lcm[0] = 1;
        zeta[0] = Y;
        for (var b = 0; b < N; b++)
        {
            var bit = 1 << b;
            for (var i = 0; i < (1 << N); i++)
            {
                if ((i & bit) != 0 && lcm[i ^ bit] > 0)
                {
                    var _lcm = GCD.lcm_checked(lcm[i ^ bit], A[b], Y+1);
                    lcm[i] = _lcm;
                    zeta[i] = Y / lcm[i];
                }
            }
        }
        //mebios
        for (var b = 0; b < N; b++)
        {
            var bit = 1 << b;
            for (var i = 0; i < (1 << N); i++)
            {
                if ((i & bit) != 0)
                {
                    zeta[i ^ bit] -= zeta[i];
                }
            }
        }
        long result = 0;
        for (var i = 0; i < (1 << N); i++)
        {
            if (i.PopCount() == M)
            {
                result += zeta[i];
            }
        }
        io.WriteLine(result);
    }
}

#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif
