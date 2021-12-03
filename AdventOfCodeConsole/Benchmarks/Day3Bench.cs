using AdventOfCodeConsole.Puzzles;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeConsole.Benchmarks;

[MemoryDiagnoser(false)]
[SimpleJob(launchCount: 1, warmupCount: 10, targetCount: 10)]
public class Day3Bench : IDayBench
{
    private string? _input;
    private int _output1;
    private int _output2;

    public async Task Run()
    {
        await Setup();
        Part1();
        Part2();
        ShowResults();
    }

    [GlobalSetup]
    public async Task Setup()
    {
        _input = await AdventOfCode.GetInputForDay(3);
    }

    [GlobalCleanup]
    public void ShowResults()
    {
        Console.WriteLine($"Part 1: {_output1}");
        Console.WriteLine($"Part 2: {_output2}");
    }

    [Benchmark]
    public void Part1() => _output1 = Day3.Part1(_input!);

    [Benchmark]
    public void Part2() => _output2 = Day3.Part2(_input!);
}