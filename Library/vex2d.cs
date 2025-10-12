using System.Numerics;

namespace AtCoder.MyLib;


public readonly record struct Vec2D<T>(T X, T Y) where T : INumber<T>
{
    public static Vec2D<T> FromPoints(Point2D<T> start, Point2D<T> end)
    {
        return new Vec2D<T>(end.X - start.X, end.Y - start.Y);
    }

    public Vec2D<TResult> As<TResult>() where TResult : INumber<TResult>
    {
        return new Vec2D<TResult>(
            TResult.CreateChecked(this.X),
            TResult.CreateChecked(this.Y)
        );
    }

    public double Norm()
    {
        var dx = double.CreateChecked(X);
        var dy = double.CreateChecked(Y);
        return Math.Sqrt(dx * dx + dy * dy);
    }

    /// <summary>
    /// 2つのベクトルの内積を計算します。
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public T InnerProduct(Vec2D<T> v)
    {
        return this.X * v.X
            + this.Y * v.Y;
    }

    public static Vec2D<T> operator -(Vec2D<T> left, Vec2D<T> right)
    {
        return new Vec2D<T>(left.X - right.X, left.Y - right.Y);
    }

    public static Vec2D<T> operator /(Vec2D<T> left, T right)
    {
        return new Vec2D<T>(left.X / right, left.Y - right);
    }
}