using AdventOfCodeConsole.Runners._2021;
using AdventOfCodeConsole.Tools;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

#if !DEBUG
BenchmarkRunner.Run<Day12Runner>();
#else
await new Day20Runner().Run();
#endif
