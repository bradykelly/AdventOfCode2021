using AdventOfCodeConsole.Runners;
using AdventOfCodeConsole.Runners._2021;
using BenchmarkDotNet.Running;

#if !DEBUG
    BenchmarkRunner.Run<Day10Runner>();
#else
    await new Day10Runner().Run();
#endif
