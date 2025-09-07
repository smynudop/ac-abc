using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var a = io.ReadInt();
var (b, c) = io.ReadInt2();
var s = io.ReadLine();

io.WriteLine((a + b + c).ToString() + " " + s);