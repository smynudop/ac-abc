var Q = int.Parse(Console.ReadLine()!);
var A = new List<(int c, int x)>();
var Ks = new List<int>();


for (var i = 0; i < Q; i++)
{
    var query = Console.ReadLine()!;
    if (query[0] == '1')
    {
        var s = query.Split(' ');
        A.Add((int.Parse(s[1]), int.Parse(s[2])));
    }
    else
    {
        var s = query.Split(' ');
        Ks.Add(int.Parse(s[1]));
    }
}

var AQueue = new Queue<(int c, int x)>(A);

var (left, current) = AQueue.Dequeue();

for (var i = 0; i < Ks.Count; i++)
{
    Int128 s = 0;
    var k = Ks[i];
    while (k > 0)
    {
        if (k < left)
        {
            s += (long)current * k;
            left -= k;
            k = 0;
        }
        else
        {
            s += (long)current * left;
            k -= left;
            if (AQueue.Count > 0)
            {
                (left, current) = AQueue.Dequeue();
            }
        }
    }
    Console.WriteLine(s);
}