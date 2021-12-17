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

    public long Part1(string input)
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
                var x = fieldSplit.Length > 1 ? field.Split(':')[1] : "";
            }
            if (required.AllPresent())
            {
                validDocs++;
            }
            required.Reset();
        }
        return validDocs;
    }

    public long Part2(string input)
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
                //foreach (var field in fieldSplit)
                //{

                //    var value = field.Split(':')[1];
                //    switch (field.Split(':')[0])
                //    {
                //        case "byr":
                //            if (!int.TryParse(value, out var yearb) || yearb is < 1920 or > 2002) valid = true;
                //            break;

                //        case "iyr":
                //            if (!int.TryParse(value, out var yeari) || yeari is < 2010 or > 2020) valid = false;
                //            break;

                //        case "eyr":
                //            if (!int.TryParse(value, out var yeare) || yeare is < 2020 or > 2030) valid = false;
                //            break;

                //        case "hgt":
                //            var rxHg = new Regex(@"(^\d{3})(cm)\b|(^\d{2})(in)");
                //            var mxHg = rxHg.Match(value);
                //            if (!mxHg.Success || mxHg.Groups.Count != 2)
                //            {
                //                valid = false;
                //                break;
                //            }

                //            if (mxHg.Groups[1].Value == "cm" && int.Parse(mxHg.Groups[0].Value) is < 150 or > 193) valid = false;
                //            if (mxHg.Groups[1].Value == "in" && int.Parse(mxHg.Groups[0].Value) is < 59 or > 76) valid = false;
                //            valid = false;
                //            break;

                //        case "hcl":
                //            var rxCl = new Regex(@"^#[0-9a-f]{6}$");
                //            valid = rxCl.Match(value).Success;
                //            break;

                //        case "ecl":
                //            const string set = " amb blu brn gry grn hzl oth ";
                //            if (!set.Contains($" {value} ")) valid = false;
                //            break;

                //        case "pid":
                //            var rxPd = new Regex(@"^\d{9}$");
                //            valid = rxPd.Match(value).Success;
                //            break;

                //        case "cid":
                //            break;
                //    }

                //}
                if (valid) validDocs++;
                required.Reset();
            }
        }

        return validDocs;
    }
}
