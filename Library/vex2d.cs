namespace AtCoder.MyLib;


public readonly record struct Vec2D
{
    public int X { get; }
    public int Y { get; }

    public Vec2D(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public Vec2D((int x, int y) t)
    {
        this.X = t.x;
        this.Y = t.y;
    }

    public static Vec2D FromPoints((int x, int y) a, (int x, int y) b)
    {
        return new Vec2D(b.x - a.x, b.y - a.y);
    }

    public Vec2D NormalizeGcd()
    {
        if (X == 0)
        {
            return new Vec2D(0, 1);
        }
        if (Y == 0)
        {
            return new Vec2D(1, 0);
        }
        var g = gcd(X, Y);
        var sign = Math.Sign(X);
        return new Vec2D(X * sign / g, Y * sign / g);
    }

    private static int gcd(int x, int y)
    {
        int core(int x, int y)
        {
            if (y == 0) return x;
            return core(x % y, y);
        }

        var xx = Math.Abs(x);
        var yy = Math.Abs(y);
        return xx > yy ? core(xx, yy) : core(yy, xx);
    }



}