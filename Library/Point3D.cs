using System.Numerics;

namespace AtCoder.MyLib;

public readonly record struct Point3D<T>(T X, T Y, T Z) where T : INumber<T>
{
    public static Vec3D<T> operator -(Point3D<T> left, Point3D<T> right)
    {
        return Vec3D<T>.FromPoints(right, left);
    }
}

public readonly record struct Point2D<T>(T X, T Y) where T : INumber<T>
{
}

public static partial class Geometry3D
{
    /// <summary>
    /// 2点を通る方程式 ax + by + c = 0 の係数a,b,cを返します。
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    public static (long a, long b, long c) Line(Point2D<int> p1, Point2D<int> p2)
    {
        long dx = (long)p2.X - p1.X;
        long dy = (long)p2.Y - p1.Y;

        // dx(y-y1) = dy(x-x1)
        // <=> dy・x - dx・y + dx・y1 - dy・x1 = 0;
        var a = dy;
        var b = -dx;
        var c = dx * p1.Y - dy * p1.X;

        var gcd = GCD.gcd(Math.Abs(a), Math.Abs(b));
        a /= gcd;
        b /= gcd;
        c /= gcd;

        return (a, b, c);
    }

    /// <summary>
    /// 2つの線分がクロスするかどうかを判定(端点が重なる場合はFalse)
    /// </summary>
    /// <param name="A"></param>
    /// <param name="B"></param>
    /// <param name="C"></param>
    /// <param name="D"></param>
    public static bool IsCross<T>(
        Point3D<T> A,
        Point3D<T> B,
        Point3D<T> C,
        Point3D<T> D
    ) where T : INumber<T>
    {
        if (!IsSamePlane(A, B, C, D))
        {
            return false;
        }
        var AB = B - A;
        var CD = D - C;

        var AC = C - A;
        var AD = D - A;

        var CA = A - C;
        var CB = B - C;

        var ABxAC = AB.OuterProduct<Int128>(AC);
        var ABxAD = AB.OuterProduct<Int128>(AD);
        var CDxCA = CD.OuterProduct<Int128>(CA);
        var CDxCB = CD.OuterProduct<Int128>(CB);

        return ABxAC.InnerProductSign(ABxAD) < 0
            && CDxCA.InnerProductSign(CDxCB) < 0;
    }

    /// <summary>
    /// 2つの線分が同一平面上にあるかを判定
    /// </summary>
    /// <param name="A"></param>
    /// <param name="B"></param>
    /// <param name="C"></param>
    /// <param name="D"></param>
    public static bool IsSamePlane<T>(
        Point3D<T> A,
        Point3D<T> B,
        Point3D<T> C,
        Point3D<T> D
    ) where T : INumber<T>
    {
        var u = B - A;
        var v = D - C;

        //(b-a)・(u × v) == 0 が条件
        var ca = (C - A).As<Int128>();
        return ca.InnerProductSign(u.OuterProduct<Int128>(v)) == 0;
    }

    /// <summary>
    /// サッポロ距離、もとい、マンハッタン距離を算出
    /// </summary>
    /// <param name="A"></param>
    /// <param name="B"></param>
    public static int SapporoDistance<T>(
        Point3D<int> A,
        Point3D<int> B
    ) where T : INumber<T>
    {
        var C = A - B;
        return Math.Abs(C.X) + Math.Abs(C.Y) + Math.Abs(C.Z);
    }
}