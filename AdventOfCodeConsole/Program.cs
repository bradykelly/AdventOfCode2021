using AdventOfCodeConsole.Runners;
using AdventOfCodeConsole.Runners._2021;
using BenchmarkDotNet.Running;

#if !DEBUG
BenchmarkRunner.Run<Day1Runner>();
#else
await new Day1Runner().Run();
#endif
