// <copyright file="Solver02.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2023.Days.Day02;

using System.Globalization;
using System.Text.RegularExpressions;

/// <summary>
/// Solver for day 2.
/// </summary>
public partial class Solver02 : BaseSolver<int>
{
    private readonly IEnumerable<MatchCollection> matchCollections;

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver02"/> class.
    /// </summary>
    public Solver02()
        : this(null) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver02"/> class.
    /// </summary>
    /// <param name="inputFilePath">The expected input file path.</param>

    public Solver02(string? inputFilePath)
        : base(inputFilePath) => this.matchCollections = this.ParseInput();

    /// <inheritdoc/>
    protected override int Solve1() =>
        this.matchCollections.Sum(matches =>
            (
                IsMatchPossible(matches, "red", 12)
                && IsMatchPossible(matches, "green", 13)
                && IsMatchPossible(matches, "blue", 14)
            )
                ? int.Parse(matches[0].Groups["game"].Value, CultureInfo.InvariantCulture)
                : 0
        );

    /// <inheritdoc/>
    protected override int Solve2() =>
        this.matchCollections.Sum(matches =>
            SmallestPossibleMatch(matches, "red")
            * SmallestPossibleMatch(matches, "green")
            * SmallestPossibleMatch(matches, "blue")
        );

    [GeneratedRegex(
        "(?<=\\s)((?<game>\\d+):|(?<red>\\d+)(?=(\\s)) red|(?<green>\\d+)(?=(\\s)) green|(?<blue>\\d+)(?=(\\s)) blue)",
        RegexOptions.ExplicitCapture
    )]
    private static partial Regex regex();

    private static IEnumerable<int> SelectMatches(MatchCollection matches, string colour) =>
        matches
            .Where(match => match.Groups[colour].Success)
            .Select(match => int.Parse(match.Groups[colour].Value, CultureInfo.InvariantCulture));

    private static bool IsMatchPossible(MatchCollection matches, string colour, int limit) =>
        SelectMatches(matches, colour).All(num => num <= limit);

    private static int SmallestPossibleMatch(MatchCollection matches, string colour) =>
        SelectMatches(matches, colour).Max();

    private IEnumerable<MatchCollection> ParseInput()
    {
        ParsedFile file = new(this.InputFilePath);

        while (!file.Empty)
        {
            yield return regex().Matches(file.NextLine().ToSingleString());
        }
    }
}
