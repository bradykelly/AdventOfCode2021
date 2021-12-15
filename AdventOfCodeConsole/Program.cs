using AdventOfCodeConsole.Runners;
using AdventOfCodeConsole.Runners._2021;
using BenchmarkDotNet.Running;

#if !DEBUG
    BenchmarkRunner.Run<Day14Runner>();
#else
    await new Day14Runner().Run();
#endif
