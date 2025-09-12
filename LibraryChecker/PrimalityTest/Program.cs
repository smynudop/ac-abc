using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using AtCoder.MyLib;
SourceExpander.Expander.Expand();




void _main(MyIO io)
{
    //下準備
    var furui = new Furui(1_000_000_000);

    var Q = io.ReadInt();
    for(int _ = 0; _ < Q; _++)
    {
        var N = io.ReadLong();
        if(N == 1)
        {
            io.WriteLine("No");
            continue;
        }
        if(N == 2)
        {
            io.WriteLine("Yes");
            continue;
        }
        if(N > 2 && (N&1) == 0)
        {
            io.WriteLine("No");
            continue;
        }
        var result = true;
        for (int i = 3; i <= Math.Sqrt(N); i+=2)
        {
            if (furui.IsPrime(i))
            {
                continue;
            }

            if(N % i == 0)
            {
                result = false;
                break;
            }
        }
        io.WriteLine(result ? "Yes" : "No");
    }
}

#if DEBUG
var sw = Stopwatch.StartNew();
using var reader = new StreamReader("input.txt");
using var stringWriter = new StringWriter();

using (var io = new MyIO(reader, stringWriter))
{
    _main(io);
}
sw.Stop();
Console.Write(stringWriter.ToString());
Console.WriteLine($"elapsed: {sw.ElapsedMilliseconds}ms");

#else
    using var io = new MyIO();
    _main(io); 
#endif

class Furui
{
    uint[] list;
    public Furui(int size)
    {
        this.list = new uint[(size >> 6) + 1]; // 雑に+1

        //ふるいの準備をする
        var sqrt = (int)Math.Sqrt(size);
        for(int i = 3; i <= sqrt; i += 2)
        {
            var ii = i >> 1;
            if ((list[ii>>5] & ((uint)1 << (ii % 31))) > 0){
                continue;
            }
            for (int j = i * i; j <= size; j += i * 2)
            {
                var jj = j >> 1;
                list[jj >> 5] |= ((uint)1 << (jj & 31));
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]  
    public bool IsPrime(int n)
    {
        if(n == 2) return true;
        if ((n & 1) == 0) return false;
        n >>= 1;
        return (list[n>>5] & (uint)1 << (n & 31)) > 0;
    }
}