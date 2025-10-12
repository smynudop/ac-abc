
Str con = new Str();
Console.WriteLine(con.getter); // 42
Console.WriteLine(con.initial); // 42

Str def = default;
Console.WriteLine(def.getter); // 42 
Console.WriteLine(def.initial); // 0! (コンストラクタが呼ばれていないため)


struct Str
{
    public Str() { }

    /// <summary>
    /// getterのショートハンドなので、defaultで初期化しても動作する
    /// </summary>
    public int getter { get => 42; }

    /// <summary>
    /// 内部フィールドのコンストラクタ初期化なので、defaultで初期化されると意図どおりに動作しない
    /// (default(int) = 0 になる)
    /// </summary>
    public int initial { get; } = 42;
}
