using AdventOfCodeConsole.Puzzles;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeConsole.Benchmarks
{
    [MemoryDiagnoser(false)]
    [SimpleJob(launchCount: 1, warmupCount: 10, targetCount: 10)]
    public class Day2Bench
    {
        private string? _input;
        private int _output1;
        private int _output2;

        [GlobalSetup]
        public async Task Setup()
        {
            _input = await AdventOfCode.GetInputForDay(2);
        }

        [GlobalCleanup]
        public void ShowResults()
        {
            Console.WriteLine($"Part 1: {_output1}");
            Console.WriteLine($"Part 2: {_output2}");
        }

        [Benchmark]
        public void Part1() => _output1 = Day2.Part1(_input);

        [Benchmark]
        public void Part2() => _output2 = Day2.Part2(_input);
    }
}
