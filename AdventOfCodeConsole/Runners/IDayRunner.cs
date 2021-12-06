namespace AdventOfCodeConsole.Runners;

public interface IDayRunner
{
    public Task Setup();
    public void ShowResults();
    public void Part1();
    public void Part2();
}