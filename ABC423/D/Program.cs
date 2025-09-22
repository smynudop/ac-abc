using System.Diagnostics;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

void _main(MyIO io)
{
    var (N, K) = io.ReadInt2();
    var nyuten = new Queue<(int start, int duration, int num)>();
    while (N-- > 0)
    {
        var (A, B, C) = io.ReadInt3();
        nyuten.Enqueue((A, B, C));
    }
    var taiten = new PriorityQueue<(long time, int num), long>();

    long t = 0;
    var cnt = 0;
    while (nyuten.Count > 0)
    {
        var item = nyuten.Dequeue();
        t = Math.Max(item.start, t);
        //時間分まで退店させる
        while (taiten.Count > 0 && taiten.Peek().time <= t)
        {
            var titem = taiten.Dequeue();
            cnt -= titem.num;
        }

        while (cnt + item.num > K)
        {
            //退店を待つ
            var titem = taiten.Dequeue();
            t = titem.time;
            cnt -= titem.num;
        }
        io.WriteLine(t);
        cnt += item.num;
        taiten.Enqueue((t + item.duration, item.num), t + item.duration);
    }
}

#if DEBUG
MyDebugger.Run(_main);
#else
using var _io = new MyIO();
_main(_io);
#endif





