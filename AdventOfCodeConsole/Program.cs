using AdventOfCodeConsole.Runners._2021;
using BenchmarkDotNet.Running;

#if !DEBUG
    BenchmarkRunner.Run<Day2Runner>();
#else
    await new Day2Runner().Run();
#endif
