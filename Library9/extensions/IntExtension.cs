using System.Numerics;
using System.Runtime.CompilerServices;

namespace AtCoder.MyLib;
public static class ModIntExtension
{
    public static ModInt ToModInt(this int val)
    {
        return new ModInt(val);
    }

    public static ModInt ToModInt(this long val)
    {
        return new ModInt(val);
    }

    /// <summary>
    /// �����Ă���bit�̐���Ԃ��܂�
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int PopCount(this int val)
    {
        return BitOperations.PopCount((uint)val);
    }

    /// <summary>
    /// �����Ă���bit�̐���Ԃ��܂�
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int PopCount(this long val)
    {
        return BitOperations.PopCount((ulong)val);
    }
}