using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var S = io.ReadLine();
double max = 0;
for (var start = 0; start < S.Length - 1; start++)
{
    for (var len = 1; len <= S.Length - start; len++)
    {
        var pS = S.Substring(start, len);
        if (pS.StartsWith("t") && pS.EndsWith("t") && pS.Length >= 3)
        {
            var r = (double)(pS.Where(c => c == 't').Count() - 2) / (pS.Length - 2);
            max = Math.Max(max, r);
        }
    }
}

io.WriteLine(max);