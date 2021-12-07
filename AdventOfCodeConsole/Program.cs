using AdventOfCodeConsole.Runners;
using AdventOfCodeConsole.Runners._2021;
using BenchmarkDotNet.Running;

#if !DEBUG
    BenchmarkRunner.Run<Day7Runner>();
#else
    await new Day7Runner().Run();
#endif
