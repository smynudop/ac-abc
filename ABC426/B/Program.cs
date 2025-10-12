using System.Diagnostics;
using System.Reflection.Metadata;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var S = io.ReadLine();
    var dic = new Dictionary<char, int>();
    foreach (var c in S)
    {
        if (dic.ContainsKey(c) == false) dic[c] = 0;
        dic[c]++;
    }
    foreach (var kvp in dic)
    {
        if (kvp.Value == 1)
        {
            io.WriteLine(kvp.Key);
        }
    }
}
#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif
