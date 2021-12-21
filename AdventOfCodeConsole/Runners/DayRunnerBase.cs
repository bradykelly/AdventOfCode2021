using AdventOfCodeConsole.Puzzles;
using AdventOfCodeConsole.Tools;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeConsole.Runners;

[MemoryDiagnoser]
[SimpleJob(launchCount: 1, warmupCount: 5, targetCount: 10)]
public class DayRunnerBase<T> where T: IDay, new() 
{
    private readonly int _dayNumber;
    private readonly int _year;
    private string? _input;
    private ulong _output1;
    private ulong _output2;
    private T _day;

    public DayRunnerBase(int year=2021)
    {
        //var genType = this.GetType().BaseType;
        //var paramTypeName = genType.GetGenericArguments()[0].Name;
        //if (int.TryParse(paramTypeName.Replace("Day", ""), out var dayNumber))
        //    _dayNumber = dayNumber;
        _day = new T();
        _dayNumber = T.DayNumber;
        _year = year;
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
        _input = await InputReader.GetInputForDay(_dayNumber, _year);
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