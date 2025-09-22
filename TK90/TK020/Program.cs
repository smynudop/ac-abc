using AtCoder.MyLib;
using System.Runtime.CompilerServices;
void myExpand(string outputFileName = "Combine.csx", [CallerFilePath] string? cfp = null) 
{
    var d = Path.GetDirectoryName(cfp!)!;
    SourceExpander.Expander.Expand(outputFilePath: Path.Combine(d, outputFileName));
}
myExpand("submit.txt");

void _main(MyIO io)
{
    var (a,b,c) = io.ReadLong3();
    long x = 1;
    while(b-- > 0)
    {
        x *= c;
    }
    io.WriteLine(a < x ? "Yes" : "No");
}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif