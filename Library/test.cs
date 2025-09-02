namespace SandBox;

public readonly record struct Point(int X, int Y, int Z)
{
    public static Vector operator -(Point left, Point right)
    {
        return new Vector(
            (long)left.X - right.X,
            (long)left.Y - right.Y,
            (long)left.Z - right.Z
        );
    }
}

public readonly record struct Vector(long X, long Y, long Z)
{
    public long InnerProduct(Vector other)
    {
        return this.X * other.X
        + this.Y * other.Y
        + this.Z * other.Z;
    }
    public Vector OuterProduct(Vector other)
    {
        return new Vector(
            this.Y * other.Z - this.Z * other.Y,
            this.Z * other.X - this.X * other.Z,
            this.X * other.Y - this.Y * other.X
        );
    }
}

public static class PointUtil
{
    public static bool IsCross(Point a, Point b, Point c, Point d)
    {
        //同一平面にあるか判定
        var u = b - a;
        var v = d - c;
        if ((c - a).InnerProduct(u.OuterProduct(v)) != 0)
        {
            return false;
        }

        //交差するか判定
        var u1 = u.OuterProduct(c - a);
        var u2 = u.OuterProduct(d - a);
        var v1 = u.OuterProduct(a - c);
        var v2 = u.OuterProduct(b - c);

        return u1.InnerProduct(u2) < 0
            && v1.InnerProduct(v2) < 0;
    }
}
