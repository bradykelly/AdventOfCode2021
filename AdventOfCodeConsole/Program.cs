using AdventOfCodeConsole.Puzzles._2021;
using AdventOfCodeConsole.Runners._2021;
using AdventOfCodeConsole.Tools;
using BenchmarkDotNet.Running;

#if !DEBUG
    BenchmarkRunner.Run<Day11Runner>();
#else
    await new Day11Runner().Run();
#endif
