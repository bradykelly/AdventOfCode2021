using System.Diagnostics;
using System.Text.RegularExpressions;

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

    public static int DayNumber => 4;

    public ulong Part1(string input)
    {
        var docs = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        var validDocs = 0;
        var required = new PassportFields();
        foreach (var doc in docs)
        {
            var docSplit = doc.Split(' ', '\n');
            foreach (var field in docSplit)
            {
                var fieldSplit = field.Split(':');
                required.Fields[field.Split(':')[0]] = true;
                _ = fieldSplit.Length > 1 ? field.Split(':')[1] : "";
            }
            if (required.AllPresent())
            {
                validDocs++;
            }
            required.Reset();
        }
        return (ulong)validDocs;
    }

    public ulong Part2(string input)
    {
        var docs = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
        var validDocs = 0;
        var required = new PassportFields();
        foreach (var doc in docs)
        {
            var docsSplit = doc.Split(' ', '\n');
            foreach (var field in docsSplit)
            {
                required.Fields[field.Split(':')[0]] = true;
            }
            if (required.AllPresent())
            {
                var valid = true;
                foreach (var field in docsSplit)
                {
                    var fieldSplit = field.Split(':');
                    var name = fieldSplit[0];
                    var value = fieldSplit.Length > 1 ? field.Split(':')[1] : "";
                    switch (name)
                    {
                        case "byr":
                            if (!int.TryParse(value, out var yearb) || yearb is < 1920 or > 2002) valid = false;
                            break;

                        case "iyr":
                            if (!int.TryParse(value, out var yeari) || yeari is < 2010 or > 2020) valid = false;
                            break;

                        case "eyr":
                            if (!int.TryParse(value, out var yeare) || yeare is < 2020 or > 2030) valid = false;
                            break;

                        case "hgt":
                            var rxHg = new Regex(@"^(\d{3})(cm)$|^(\d{2})(in)$");
                            var mxHg = rxHg.Match(value);
                            if (!mxHg.Success || mxHg.Groups.Count < 3)
                            {
                                valid = false;
                                break;
                            }

                            if (mxHg.Groups[2].Value == "cm" && int.Parse(mxHg.Groups[1].Value) is < 150 or > 193) valid = false;
                            if (mxHg.Groups[2].Value == "in" && int.Parse(mxHg.Groups[1].Value) is < 59 or > 76) valid = false;
                            break;

                        case "hcl":
                            var rxCl = new Regex(@"^#[0-9a-f]{6}$");
                            if (!rxCl.Match(value).Success)
                                valid = false;
                            break;

                        case "ecl":
                            const string set = " amb blu brn gry grn hzl oth ";
                            if (!set.Contains($" {value} ")) valid = false;
                            break;

                        case "pid":
                            var rxPd = new Regex(@"^\d{9}$");
                            if (!rxPd.Match(value).Success)
                                valid = false;
                            break;

                        case "cid":
                            break;
                    }
                }

                if (valid)
                {
                    Debug.Print(doc);
                    validDocs++;
                }
            }
            required.Reset();
        }

        return (ulong)validDocs;
    }
}
