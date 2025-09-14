using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var N = io.ReadInt();
    var A = io.ReadIntArray(N);
    var B = io.ReadIntArray(N); 
    var C = io.ReadIntArray(N);
    
    var AMod = new int[46];
    for (var i = 0; i < N; i++)
    {
        AMod[A[i] % 46]++;
    }
    var BMod = new int[46];
    for (var i = 0; i < N; i++)
    {
        BMod[B[i] % 46]++;
    }
    var CMod = new int[46];
    for (var i = 0; i < N; i++)
    {
        CMod[C[i] % 46]++;
    }
    long ans = 0;
    for(var i = 0; i < 46; i++)
    {
        for(var j = 0; j < 46; j++)
        {
            var k = (92 - i - j) % 46;
            ans += (long)AMod[i] * BMod[j] * CMod[k];
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