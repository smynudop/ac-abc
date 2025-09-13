using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var N = io.ReadInt();
    if(N%2 == 1)
    {
        return;
    }

    var l = new List<(string str, int cnt)>();
    l.Add(("", 0));
    for(int i = 1; i <= N; i++)
    {
        var ll = new List<(string str, int cnt)>();
        foreach(var item in l)
        {
            if(item.cnt + i <= N)
            {
                ll.Add((item.str + "(", item.cnt + 1));
            }
            if(item.cnt > 0)
            {
                ll.Add((item.str + ")", item.cnt - 1));
            }
        }
        l = ll;
    }
    foreach(var item in l)
    {
        io.WriteLine(item.str);
    }
}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif