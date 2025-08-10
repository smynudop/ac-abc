using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var N = io.ReadInt();
var S = io.ReadLine();
io.WriteLine(S.EndsWith("tea") ? "Yes" : "No");
