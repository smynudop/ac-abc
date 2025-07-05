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
}