namespace AtCoder.MyLib;

/// <summary>
/// いもす法で累積和を管理します。
/// </summary>
public class Imos
{
    private int Length { get; init; }
    private List<int> list { get; init; }
    private List<int>? _result = null;

    public Imos(int length)
    {
        this.Length = length;
        this.list = Enumerable.Repeat(0, length + 1).ToList();
    }

    /// <summary>
    /// 区間を追加します。indexには0～Nが使用できます。
    /// </summary>
    /// <param name="startIndex"></param>
    /// <param name="endIndex"></param>
    public void Add(int startIndex, int endIndex)
    {
        this.list[startIndex]++;
        this.list[endIndex]--;
        this._result = null;
    }

    /// <summary>
    /// 区間を追加します。indexには0～Nが使用できます。
    /// </summary>
    /// <param name="startIndex"></param>
    /// <param name="endIndex"></param>
    public void Add((int startIndex, int endIndex) t)
    {
        Add(t.startIndex, t.endIndex);
    }

    public IReadOnlyList<int> Result
    {
        get
        {
            return _result ?? CalcResult();
        }
    }

    private List<int> CalcResult()
    {
        var r = new List<int>(this.Length);
        var n = 0;
        for (var i = 0; i < this.Length; i++)
        {
            n += this.list[i];
            r.Add(n);
        }

        this._result = r;
        return r;
    }
}