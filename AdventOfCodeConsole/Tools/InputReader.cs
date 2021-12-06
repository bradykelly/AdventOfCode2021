using System.Collections.Immutable;
using System.Net;

namespace AdventOfCodeConsole.Tools;

internal static class InputReader
{
    internal static async Task<string?> GetInputForDay(int day)
    {
        string? input;

        var filename = $"Day_{day}_Input.txt";
        if (!File.Exists(filename))
        {
            string url = $"https://adventofcode.com/2021/day/{day}/input";
            var cookies = new CookieContainer();
            cookies.Add(new Cookie()
            {
                Domain = ".adventofcode.com",
                Name = "session",
                Value = "53616c7465645f5f2939cfe82e006a3e07c1c95295a20341dde1cd43e6e054f5df8c56b57e4ee6103d01ef1b13d67f51"
            });
            using var handler = new HttpClientHandler() { CookieContainer = cookies };
            using var client = new HttpClient(handler);
            input = await client.GetStringAsync(url);
            await File.WriteAllTextAsync(filename, input);
        }
        else
        {
            input = await File.ReadAllTextAsync(filename);
        }

        return input;
    }

    internal static async Task<ImmutableArray<string>> GetLinesForDay(int day)
    {
        var input = await GetInputForDay(day);
        return input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToImmutableArray();
    }

    internal static ReadOnlySpan<int> GetIntsFromLine(string line)
    {
        return line.Split(',').Select(int.Parse).ToImmutableArray().AsSpan();
    }
}