using AdventOfCodeConsole.Runners;
using BenchmarkDotNet.Running;

#if !DEBUG
    BenchmarkRunner.Run<Day6Runner>();
#else
    await new Day7Runner().Run();
#endif
