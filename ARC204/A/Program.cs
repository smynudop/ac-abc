using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var (N, L, R) = io.ReadInt3();
var A = io.ReadIntList(N);
var B = io.ReadIntList(N);

var Q = new Queue<int>();
var C = 0;
var i = 1;


for (var _ = 0; _ < N * 2; _++)
{
    if (true)
    {
        Q.Enqueue(i);
        C -= A[i - 1];
        C = Math.Max(0, C);
        i++;
    }
    else
    {
        var x = Q.Dequeue();
        C += B[x];
    }
}