namespace AdventOfCodeConsole.Benchmarks;

public interface IDayBench
{
    public Task Setup();
    public void ShowResults();
    public void Part1();
    public void Part2();
}