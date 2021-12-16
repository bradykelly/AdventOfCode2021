using AdventOfCodeConsole.Puzzles._2021;
using AdventOfCodeConsole.Runners;
using AdventOfCodeConsole.Runners._2021;
using AdventOfCodeConsole.Tools;
using BenchmarkDotNet.Running;

#if !DEBUG
    BenchmarkRunner.Run<Day16Runner>();
#else
    await new Day16Runner().Run();
#endif
