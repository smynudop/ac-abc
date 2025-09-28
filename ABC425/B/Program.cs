using System.Diagnostics;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var N = io.ReadInt();
    var A = io.ReadIntArray(N);

    var nums = Enumerable.Range(1, N).ToList();
    var result = new int[N];
    for (var i = 0; i < N; i++)
    {
        if (A[i] == -1)
        {
            continue;
        }
        if (nums.Contains(A[i]))
        {
            result[i] = A[i];
            nums.Remove(A[i]);
        }
        else
        {
            io.WriteLine("No");
            return;
        }
    }
    for (var i = 0; i < N; i++)
    {
        if (result[i] == 0)
        {
            result[i] = nums.First();
            nums.Remove(nums.First());
        }
    }
    io.WriteLine("Yes");
    io.WriteLine(result);
}
#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif
