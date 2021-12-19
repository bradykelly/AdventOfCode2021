using AdventOfCodeConsole.Puzzles._2021;
using AdventOfCodeConsole.Runners._2021;
using AdventOfCodeConsole.Tools;
using BenchmarkDotNet.Running;

#if !DEBUG
    BenchmarkRunner.Run<Day12Runner>();
#else
    await new Day12Runner().Run();
#endif
