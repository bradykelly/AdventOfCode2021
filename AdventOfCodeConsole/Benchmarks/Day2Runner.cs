using AdventOfCodeConsole.Puzzles;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeConsole.Benchmarks;

[MemoryDiagnoser(false)]
[SimpleJob(launchCount: 1, warmupCount: 10, targetCount: 10)]
public class Day2Runner: DayRunnerBase<Day2>
{
    public Day2Runner() : base(2)
    {
    }
}
