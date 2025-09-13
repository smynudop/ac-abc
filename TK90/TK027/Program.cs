using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var set = new HashSet<string>();
    var N = io.ReadInt();
    for(var i = 1; i <= N; i++)
    {
        var s = io.ReadLine();
        if (!set.Contains(s))
        {
            io.WriteLine(i);
            set.Add(s);
        }
    }


}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif