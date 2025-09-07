using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

var T = io.ReadInt();
for (var _ = 0; _ < T; _++)
{
    var (a, b, c) = io.ReadLong3();

    //abcをやれるだけやる
    var m = Math.Min(Math.Min(a, c), b);


    //abcをやった後に、cかaが在庫切れなら、そこでおわり
    if (m == a || m == c)
    {
        io.WriteLine(m);
        continue;
    }

    //bが在庫切れなら、AACかACCを開催できる
    a -= m;
    c -= m;

    //もし、aが極端に多い場合は、cが律速
    if (a >= c * 2)
    {
        io.WriteLine(m + c);
    }
    //もし、cが極端に多い場合は、aが律速
    else if (c >= a * 2)
    {
        io.WriteLine(m + a);
    }
    //でなければ、最大限開催できる
    else
    {
        io.WriteLine(m + (a + c) / 3);
    }
}