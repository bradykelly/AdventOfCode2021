using AdventOfCodeConsole;
using AdventOfCodeConsole.Benchmarks;
using BenchmarkDotNet.Running;


//var summary = BenchmarkRunner.Run<Day2Bench>();
var runner = new Day3Bench();
await runner.Setup();
runner.Part1();
runner.Part2();
runner.ShowResults();
