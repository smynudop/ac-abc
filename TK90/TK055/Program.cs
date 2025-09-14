using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (N, P, Q) = io.ReadInt3();
    var A = io.ReadIntArray(N);
    long ans = 0;
    for (var i = 0; i < N; i++) {
        for(var j = i + 1; j < N; j++)
        {
            var p1 = ((long)A[i] * A[j]) % P;
            for(var k = j + 1; k < N; k++)
            {
                var p2 = ((long)p1 * A[k]) % P;
                for(var l = k + 1; l < N; l++)
                {
                    var p3 = ((long)p2 * A[l]) % P;
                    for(var m = l + 1; m < N; m++)
                    {
                        var p4 = ((long)p3 * A[m]) % P;
                        if(p4 == Q)
                        {
                            ans++;
                        }
                    }
                }
            }
        }
    }
    io.WriteLine(ans);
}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif