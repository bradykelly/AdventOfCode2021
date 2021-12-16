using AdventOfCodeConsole.Puzzles._2021;
using AdventOfCodeConsole.Runners;
using AdventOfCodeConsole.Runners._2021;
using AdventOfCodeConsole.Tools;
using BenchmarkDotNet.Running;

#if !DEBUG
    BenchmarkRunner.Run<Day14Runner>();
#else
    await new Day12Runner().Run();
#endif
