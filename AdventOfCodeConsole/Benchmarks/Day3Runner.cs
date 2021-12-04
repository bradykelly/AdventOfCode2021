using AdventOfCodeConsole.Puzzles;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeConsole.Benchmarks;

[MemoryDiagnoser(false)]
[SimpleJob(launchCount: 1, warmupCount: 10, targetCount: 10)]
public class Day3Runner : DayRunnerBase<Day3>
{
    public Day3Runner() : base(3)
    {
    }
}