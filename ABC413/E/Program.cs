using System.Buffers;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();


var T = io.ReadInt();
for (var _i = 0; _i < T; _i++)
{
    var N = io.ReadInt();
    var P = io.ReadIntList(1 << N).ToArray();

    var sp = P.AsSpan();
    for (var i = 0; i < N; i++)
    {
        var l = 1 << i;
        for (var j = 0; j < (1 << (N - i - 1)); j++)
        {
            var idx = (j * 2) << i;
            var idx2 = (j * 2 + 1) << i;

            if (sp[idx] > sp[idx2])
            {
                Util.Swap(sp.Slice(idx, l), sp.Slice(idx2, l));
            }
        }
    }
    io.WriteLine(P);
}