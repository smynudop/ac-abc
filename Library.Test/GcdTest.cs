namespace AtCoder.MyLib;

[TestClass]
public class GcdTest
{
    [TestMethod]
    public void gcd()
    {
        Assert.AreEqual(GCD.gcd(12, 21), 3);
        Assert.AreEqual(GCD.gcd(21, 12), 3);

        Assert.AreEqual(GCD.gcd(57, 49), 1);
        Assert.AreEqual(GCD.gcd(49, 57), 1);

        Assert.AreEqual(GCD.gcd(7, 0), 7);
        Assert.AreEqual(GCD.gcd(0, 7), 7);
    }

    [TestMethod]
    public void gcdex()
    {
        Assert.AreEqual(GCD.gcdex(111, 30, 3), (3, -11));
    }
}