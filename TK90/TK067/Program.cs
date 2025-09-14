using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    string ope(string s)
    {
        long val = 0;
        long b = 1;
        for(var i = 0; i < s.Length; i++)
        {
            val += (s[s.Length - 1 - i] - '0') * b;
            b *= 8;
        }
        string n9 = "";
        if (val == 0)
        {
            return "0";
        }
        while (val > 0)
        {
            n9 = (val % 9).ToString() + n9;
            val /= 9;
        }
        return n9.Replace("8", "5");
    }
    var (N, K) = io.ReadLine().SplitAs<string, int>();
    for(var i = 0; i < K; i++)
    {
        N = ope(N);
    }
    io.WriteLine(N);
}

#if DEBUG
using var io = new MyIO(new StreamReader("input.txt"));
_main(io);
#else
using var io = new MyIO();
_main(io);
#endif