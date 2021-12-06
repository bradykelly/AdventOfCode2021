using AdventOfCodeConsole.Runners;
using BenchmarkDotNet.Running;

//args = new[] { "/bench" };
if (args.Length > 0 && args[0] == "/bench")
{
    BenchmarkRunner.Run<Day6Runner>();
}
else
{
    await new Day6Runner().Run();
}
