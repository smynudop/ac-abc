using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var T = io.ReadInt();
for (var _ = 0; _ < T; _++)
{
    var (N, M) = io.ReadInt2();
    var _2m = ModInt.Pow(2, M);
    var _2n1 = ModInt.Pow(2, N - 1);
    var _4n1 = ModInt.Pow(4, N - 1);
    var mC2 = new ModInt(M) * new ModInt(M - 1) / 2;
    var c0 = _2m;
    var c1 = _2m * M * (_2n1 - 1);
    var c2 = _2m * mC2 * (_4n1 - 2 * _2n1 + 1);
    io.WriteLine(c0 + c1 + c2);
}