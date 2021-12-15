using AdventOfCodeConsole.Runners;
using AdventOfCodeConsole.Runners._2021;
using BenchmarkDotNet.Running;

#if !DEBUG
    BenchmarkRunner.Run<Day11Runner>();
#else
    await new Day11Runner().Run();
#endif
