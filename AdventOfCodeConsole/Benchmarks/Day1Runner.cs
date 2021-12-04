using AdventOfCodeConsole.Puzzles;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeConsole.Benchmarks;

[MemoryDiagnoser(false)]
[SimpleJob(launchCount: 1, warmupCount: 10, targetCount: 10)]
public class Day1Runner: DayRunnerBase<Day1>
{
    public Day1Runner() : base(1)
    {
    }
}