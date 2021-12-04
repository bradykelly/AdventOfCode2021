using AdventOfCodeConsole.Puzzles;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeConsole.Benchmarks;

public class DayRunnerBase<T> where T: IDay, new() 
{
    private readonly int _dayNumber;
    private string? _input;
    private int _output1;
    private int _output2;
    private T _day;

    public DayRunnerBase(int dayNumber)
    {
        _dayNumber = dayNumber;
        _day = new T();
    }

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
        _input = await AdventOfCode.GetInputForDay(_dayNumber);
    }

    [GlobalCleanup]
    public void ShowResults()
    {
        Console.WriteLine($"Day {_dayNumber} - Part 1: {_output1}");
        Console.WriteLine($"Day {_dayNumber} - Part 2: {_output2}");
    }

    [Benchmark]
    public void Part1() => _output1 = _day.Part1(_input!);

    [Benchmark]
    public void Part2() => _output2 = _day.Part2(_input!);
}