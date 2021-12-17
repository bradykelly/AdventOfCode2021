using AdventOfCodeConsole.Runners._2020;
using BenchmarkDotNet.Running;

#if !DEBUG
    BenchmarkRunner.Run<Day4Runner>();
#else
    await new Day4Runner().Run();
#endif
