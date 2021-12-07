using BenchmarkDotNet.Validators;

namespace AdventOfCodeConsole.Puzzles._2020;

public class Day4 : IDay
{
    private class PassportFields
    {
        public Dictionary<string, bool> Fields { get; } = new();

        public PassportFields()
        {
            Fields.Add("byr", false);
            Fields.Add("iyr", false);
            Fields.Add("eyr", false);
            Fields.Add("hgt", false);
            Fields.Add("hcl", false);
            Fields.Add("ecl", false);
            Fields.Add("pid", false);
            Fields.Add("cid", false);
        }

        public void Reset()
        {
            foreach (var name in Fields.Keys)
            {
                Fields[name] = false;
            }
        }

        public bool AllPresent()
        {
            foreach (var name in Fields.Keys)
            {
                if (name != "cid" && Fields[name] == false)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public long Part1(string input)
    {
        var docs = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

        var validDocs = 0;
        var required = new PassportFields();
        foreach (var doc in docs)
        {
            var fields = doc.Split(' ', '\n');
            foreach (var field in fields)
            {
                required.Fields[field.Split(':')[0]] = true;
            }

            if (!required.AllPresent())
            {
                continue;
            }

            var valid = true;
            foreach (var field in fields)
            {
                var value = field.Split(':')[1];
                switch (field.Split(':')[0])
                {
                    case "byr":
                        if (!int.TryParse(value, out var yearb) && yearb is < 1920 or > 2002)
                            valid = false;
                        break;
                    case "iyr":
                        if (!int.TryParse(value, out var yeari) && yeari is < 2010 or > 2020)
                            valid = false;
                        break;
                    case "eyr":
                        if (!int.TryParse(value, out var yeare) && yeare is < 2020 or > 2030)
                            valid = false;
                        break;
                    case "hgt":
                        if (!value.EndsWith("cm") && !value.StartsWith("in"))
                        {
                            valid = false;
                            break;
                        }
                        if (value.EndsWith("cm"))
                            if (!int.TryParse(value.Replace("cm", ""), out var heightcm) || heightcm is < 150 or > 193)
                                valid = false;
                        if (value.EndsWith("in"))
                            if (!int.TryParse(value.Replace("in", ""), out var heightin) || heightin is < 59 or > 76)
                                valid = false;
                        valid = false;
                        break;
                    case "hcl":
                        break;
                    case "ecl":
                        break;
                    case "pid":
                        break;
                }
            }

            required.Reset();
        }

        return validDocs;
    }

    public long Part2(string input)
    {
        return 0;
    }
}
