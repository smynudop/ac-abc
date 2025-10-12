using System.Numerics;

namespace AtCoder.MyLib;


public readonly record struct Vec3D<T>(T X, T Y, T Z) where T : INumber<T>
{
    public static Vec3D<T> FromPoints(Point3D<T> start, Point3D<T> end)
    {
        return new Vec3D<T>(end.X - start.X, end.Y - start.Y, end.Z - start.Z);
    }

    public Vec3D<TResult> As<TResult>() where TResult : INumber<TResult>
    {
        return new Vec3D<TResult>(
            TResult.CreateChecked(this.X),
            TResult.CreateChecked(this.Y),
            TResult.CreateChecked(this.Z)
        );
    }

    /// <summary>
    /// 2つのベクトルの内積を計算します。
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public T InnerProduct(Vec3D<T> v)
    {
        return this.X * v.X
            + this.Y * v.Y
            + this.Z * v.Z;
    }

    /// <summary>
    /// 2つのベクトルの内積を計算します。
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public TResult InnerProduct<TResult>(Vec3D<T> v) where TResult : INumber<TResult>
    {
        //JIT最適化で消えてくれてちょっと速くなることを期待……
        if (typeof(T) == typeof(long) && typeof(TResult) == typeof(BigInteger))
        {
            return (TResult)(object)(
                (BigInteger)(long)(object)this.X * (BigInteger)(long)(object)v.X
                + (BigInteger)(long)(object)this.Y * (BigInteger)(long)(object)v.Y
                + (BigInteger)(long)(object)this.Z * (BigInteger)(long)(object)v.Z
            );
        }
        if (typeof(T) == typeof(Int128) && typeof(TResult) == typeof(BigInteger))
        {
            return (TResult)(object)(
                (BigInteger)(Int128)(object)this.X * (BigInteger)(Int128)(object)v.X
                + (BigInteger)(Int128)(object)this.Y * (BigInteger)(Int128)(object)v.Y
                + (BigInteger)(Int128)(object)this.Z * (BigInteger)(Int128)(object)v.Z
            );
        }
        return TResult.CreateChecked(this.X) * TResult.CreateChecked(v.X)
            + TResult.CreateChecked(this.Y) * TResult.CreateChecked(v.Y)
            + TResult.CreateChecked(this.Z) * TResult.CreateChecked(v.Z);
    }

    /// <summary>
    /// 2つのベクトルの内積を計算し、符号のみを返します。
    /// オーバーフローしないように頑張ります。
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public int InnerProductSign(Vec3D<T> v)
    {
        //このifは多分JIT最適化で消える たぶん
        if (typeof(T) == typeof(Int128))
        {
            return InnerProduct<BigInteger>(v).Sign;
        }
        else if (typeof(T) == typeof(long))
        {
            return InnerProduct<BigInteger>(v).Sign;
        }
        else if (typeof(T) == typeof(int))
        {
            return Int128.Sign(InnerProduct<Int128>(v));
        }
        return T.Sign(this.InnerProduct(v));
    }

    /// <summary>
    /// 2つのベクトルの外積を計算します。
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public Vec3D<T> OuterProduct(Vec3D<T> v)
    {
        return new Vec3D<T>(
            this.Y * v.Z - this.Z * v.Y,
            this.Z * v.X - this.X * v.Z,
            this.X * v.Y - this.Y * v.X
        );
    }

    /// <summary>
    /// 2つのベクトルの外積を計算します。
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public Vec3D<TResult> OuterProduct<TResult>(Vec3D<T> v) where TResult : INumber<TResult>
    {
        //JIT最適化で消えてくれてちょっと速くなることを期待……
        if (typeof(T) == typeof(long) && typeof(TResult) == typeof(Int128))
        {
            return new Vec3D<TResult>(
                (TResult)(object)((Int128)(long)(object)(this.Y) * (Int128)(long)(object)(v.Z) - (Int128)(long)(object)(this.Z) * (Int128)(long)(object)(v.Y)),
                (TResult)(object)((Int128)(long)(object)(this.Z) * (Int128)(long)(object)(v.X) - (Int128)(long)(object)(this.X) * (Int128)(long)(object)(v.Z)),
                (TResult)(object)((Int128)(long)(object)(this.X) * (Int128)(long)(object)(v.Y) - (Int128)(long)(object)(this.Y) * (Int128)(long)(object)(v.X))
            );
        }
        return new Vec3D<TResult>(
            TResult.CreateChecked(this.Y) * TResult.CreateChecked(v.Z) - TResult.CreateChecked(this.Z) * TResult.CreateChecked(v.Y),
            TResult.CreateChecked(this.Z) * TResult.CreateChecked(v.X) - TResult.CreateChecked(this.X) * TResult.CreateChecked(v.Z),
            TResult.CreateChecked(this.X) * TResult.CreateChecked(v.Y) - TResult.CreateChecked(this.Y) * TResult.CreateChecked(v.X)
        );
    }

    public static Vec3D<T> operator -(Vec3D<T> left, Vec3D<T> right)
    {
        return new Vec3D<T>(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
    }
}