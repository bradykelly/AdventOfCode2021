using AdventOfCodeConsole.Puzzles._2021;
using AdventOfCodeConsole.Runners;
using AdventOfCodeConsole.Runners._2021;
using AdventOfCodeConsole.Tools;
using BenchmarkDotNet.Running;

#if !DEBUG
    BenchmarkRunner.Run<Day13Runner>();
#else
    await new Day13Runner().Run();
#endif
