using AdventOfCodeConsole;
using AdventOfCodeConsole.Benchmarks;
using BenchmarkDotNet.Running;

args = new[] { "/bench" };
if (args.Length > 0 && args[0] == "/bench")
{
    BenchmarkRunner.Run<Day3Bench>();
}
else
{
    await new Day3Bench().Run();
}
