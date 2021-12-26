using AdventOfCodeConsole.Runners;

#if !DEBUG
BenchmarkRunner.Run<Day15Runner>();
#else
await new Day15Runner().Run();
#endif
