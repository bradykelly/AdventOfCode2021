using AdventOfCodeConsole.Benchmarks;
using BenchmarkDotNet.Running;

//args = new[] { "/bench" };
if (args.Length > 0 && args[0] == "/bench")
{
    BenchmarkRunner.Run<Day5Runner>();
}
else
{
    await new Day5Runner().Run();
}
