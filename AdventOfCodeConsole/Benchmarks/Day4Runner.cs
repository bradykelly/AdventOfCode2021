using AdventOfCodeConsole.Puzzles;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeConsole.Benchmarks;

[MemoryDiagnoser(false)]
[SimpleJob(launchCount: 1, warmupCount: 10, targetCount: 10)]
public class Day4Runner : DayRunnerBase<Day4>
{
    public Day4Runner() : base(4)
    {
    }
}
