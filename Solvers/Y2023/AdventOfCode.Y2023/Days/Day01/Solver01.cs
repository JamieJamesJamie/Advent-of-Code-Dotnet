// <copyright file="Solver01.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2023.Days.Day01;

/// <summary>
/// Solver for day 1.
/// </summary>
public class Solver01 : BaseSolver<int>
{
    private static readonly Dictionary<string, int> NumberMappings =
        new()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 },
        };

    private static readonly Dictionary<string, int> NumberMappingsReversed = NumberMappings
        .Select(
            numberMapping =>
                new KeyValuePair<string, int>(
                    new string(numberMapping.Key.Reverse().ToArray()),
                    numberMapping.Value
                )
        )
        .ToDictionary();

    private readonly IEnumerable<string> lines;

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver01"/> class.
    /// </summary>
    public Solver01()
        : this(null) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver01"/> class.
    /// </summary>
    /// <param name="inputFilePath">The expected input file path.</param>
    public Solver01(string? inputFilePath)
        : base(inputFilePath) => this.lines = this.ParseInput();

    /// <inheritdoc/>
    protected override int Solve1() =>
        this.lines.Sum(
            line =>
                (
                    10
                    * (
                        int.TryParse(line.First(char.IsDigit).ToString(), out int tensDigit)
                            ? tensDigit
                            : 0
                    )
                )
                + (
                    int.TryParse(line.Last(char.IsDigit).ToString(), out int unitsDigit)
                        ? unitsDigit
                        : 0
                )
        );

    /// <inheritdoc/>
    protected override int Solve2() =>
        this.lines.Sum(line => (10 * FindNumber(line)) + FindNumber(line, reverse: true));

    private static int FindNumber(string line, bool reverse = false)
    {
        if (reverse)
        {
            line = new string(line.Reverse().ToArray());
        }

        Dictionary<string, int> mappings = reverse ? NumberMappingsReversed : NumberMappings;

        for (int characterIndex = 0; characterIndex < line.Length; characterIndex++)
        {
            if (int.TryParse(line[characterIndex].ToString(), out int digit))
            {
                return digit;
            }

            int wordNumber = mappings
                .FirstOrDefault(
                    numberMapping =>
                        line[characterIndex..].StartsWith(
                            numberMapping.Key,
                            StringComparison.InvariantCulture
                        )
                )
                .Value;

            if (wordNumber != 0)
            {
                return wordNumber;
            }
        }

        return 0;
    }

    private IEnumerable<string> ParseInput()
    {
        ParsedFile file = new(this.InputFilePath);

        while (!file.Empty)
        {
            yield return file.NextLine().ToSingleString(wordSeparator: string.Empty);
        }
    }
}
