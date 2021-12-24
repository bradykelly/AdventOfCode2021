using AdventOfCodeConsole.Runners._2021;
using AdventOfCodeConsole.Tools;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

#if !DEBUG
BenchmarkRunner.Run<Day15Runner>();
#else
await new Day15Runner().Run();
#endif
