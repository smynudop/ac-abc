using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var (N, M) = io.ReadInt2();
var A = io.ReadIntList();
io.WriteLine(A.Sum() <= M ? "Yes" : "No");
