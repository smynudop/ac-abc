using System.Diagnostics;

namespace AtCoder.MyLib;

public static class MyDebugger
{
    public static void Run(Action<MyIO> _main)
    {
        var sample = System.IO.File.ReadAllText("input.txt");
        var chunks = sample.Split("---").Select(x => x.Trim()).ToList();
        if (chunks.Count == 0)
        {
            Console.WriteLine("���͂�����܂���Binput.txt��ݒ肵�Ă�������");
            return;
        }

        // if (chunks.Count % 2 == 1)
        // {
        //     chunks.Add("");
        // }

        for (var i = 0; i < chunks.Count / 2; i++)
        {
            var input = chunks[i * 2];
            var output = chunks[i * 2 + 1];

            TextReader reader = new StringReader(chunks[i * 2]);
            TextWriter writer = new StringWriter();
            var sw = Stopwatch.StartNew();
            using var io = new MyIO(reader, writer);
            _main(io);
            sw.Stop();
            var result = writer.ToString()!.Trim();
            Console.Write($"Sample {i + 1}: ");
            Console.BackgroundColor = output == result ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed;
            Console.Write(output == result ? " OK " : " NG ");
            Console.ResetColor();
            Console.WriteLine($" elapsed: {sw.ElapsedMilliseconds}ms");
            Console.WriteLine(result);
            Console.WriteLine();
        }

    }
}