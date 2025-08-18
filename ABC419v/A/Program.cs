using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var S = io.ReadLine();
io.WriteLine(S switch
{
    "red" => "SSS",
    "blue" => "FFF",
    "green" => "MMM",
    _ => "Unknown"
});
