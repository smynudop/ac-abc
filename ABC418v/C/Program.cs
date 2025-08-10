using System.Security.Cryptography.X509Certificates;
using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

int nibutan(List<int> lst, int target)
{
    int left = 0; // 探索範囲の左端
    int right = lst.Count; // 探索範囲の右端（配列の範囲外を初期値にする）

    // 左端が右端と一致するまでループ（探索範囲が存在する限り繰り返す）
    while (left < right)
    {
        int mid = (left + right) / 2; // 探索範囲の中央を計算

        // 中央の要素が k 以下の場合、探索範囲を右側に絞り込む
        if (lst[mid] < target)
        {
            left = mid + 1; // 探索範囲の左端を更新
        }
        // 中央の要素が k より大きい場合、探索範囲を左側に絞り込む
        else
        {
            right = mid; // 探索範囲の右端を更新
        }
    }

    // 探索終了時、right（または left）が k を超える最初のインデックス
    return right;
}

var (N, Q) = io.ReadInt2();
var A = io.ReadIntList(N);
A.Sort();
var wa = Util.Ruiseki(A);
for (var _ = 0; _ < Q; _++)
{
    var b = io.ReadInt();
    if (b > A[N - 1])
    {
        io.WriteLine(-1);
        continue;
    }

    var ii = nibutan(A, b);

    long x = 0;
    if (ii > 0) x += wa[ii - 1];
    x += (long)(b - 1) * (N - ii);
    x++;
    io.WriteLine(x);
}