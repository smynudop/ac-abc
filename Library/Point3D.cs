using System.Numerics;

namespace AtCoder.MyLib;

public readonly record struct Point3D<T>(T X, T Y, T Z) where T : INumber<T>
{
    public static Vec3D<T> operator -(Point3D<T> left, Point3D<T> right)
    {
        return Vec3D<T>.FromPoints(right, left);
    }
}

public static class Geometry
{
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
}