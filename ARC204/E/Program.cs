using AtCoder.MyLib;
using var io = new MyIO(args);
SourceExpander.Expander.Expand();

checked
{
    var (N, M, L) = io.ReadInt3();
    var A = io.ReadIntList(N);

    var R = new List<long>(N - L + 1);
    long first = 0;
    for (var i = 0; i < L; i++)
    {
        first += A[i];
    }
    first %= M;
    R.Add(first);
    for (var i = 0; i < N - L + 1 - 1; i++)
    {
        first = (first - A[i] + A[i + L] + M) % M;
        R.Add(first);
    }

    long answer = 0;
    for (var i = 0; i < R.Count; i++)
    {
        var aa = R[i] == 0 ? 0 : M - R[i];
        answer += aa;
        for (var j = 0; j < L - 1; j++)
        {
            var ii = i + j;
            if (ii > R.Count - 1) break;
            R[ii] = (R[ii] + aa) % M;
        }
    }

    io.WriteLine(answer);
}
