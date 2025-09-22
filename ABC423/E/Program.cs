using System.Diagnostics;
using System.Numerics;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (N, Q) = io.ReadInt2();
    var A = io.ReadLongArray(N);
    while (Q-- > 0)
    {
        var (L, R) = io.ReadInt2();
        L--;
        R--;
        int D = R - L + 1;
        var B = new long[D];
        for (long j = 0; j < D; j++)
        {
            B[j] = (j + 1) * (D - j);
        }
        var vecSize = Vector<long>.Count;
        int i = 0;
        long result = 0;
        for (; i + vecSize <= B.Length; i += vecSize)
        {
            var va = new Vector<long>(A, i + L); // T[] と開始インデックスで生成可
            var vb = new Vector<long>(B, i);
            result += Vector.Dot(va, vb);
        }
        // 余り要素（tail）
        for (; i < B.Length; i++)
            result += A[i + L] * B[i];
        io.WriteLine(result);
    }
}

#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif
