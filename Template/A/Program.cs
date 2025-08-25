using AtCoder.MyLib;
SourceExpander.Expander.Expand();

void _main(MyIO2 io)
{

}

#if DEBUG
using var reader = new StreamReader(Console.OpenStandardInput(), Console.InputEncoding, false, 1 << 20);
using var writer = new StreamWriter(Console.OpenStandardOutput(), Console.OutputEncoding, 1 << 20) { AutoFlush = false };
using var io = new MyIO2(reader, writer);
_main(io);
#else
using var io = new MyIO2();
_main(io);
#endif