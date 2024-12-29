// <copyright file="Solver05.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2015.Days.Day05;

using System.Text.RegularExpressions;

/// <summary>
/// Solver for day 5.
/// </summary>
internal sealed class Solver05 : BaseSolver<int>
{
    private const string ContainsAtLeast1RepeatingLetterRegex = @"(?<character>\w)\k<character>";

    private const string ContainsNonOverlappingPairOfLetterRegex = @"(?<pair>\w\w).*\k<pair>";
    private const string ContainsRepeatedLetterWith1LetterInbetweenRegex =
        @"(?<outer>\w)\w\k<outer>";

    private static readonly IEnumerable<string> ForbiddenStrings = ["ab", "cd", "pq", "xy"];

    private static readonly string AtLeast3VowelsRegex = string.Join(
        ".*",
        Enumerable.Repeat("[aeiou]", 3)
    );

    private static readonly string DoesNotContainForbiddenStringRegex =
        $"^((?!{string.Join('|', ForbiddenStrings)}).)*$";

    private readonly string input;

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver05"/> class.
    /// </summary>
    public Solver05()
        : this(null) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver05"/> class.
    /// </summary>
    /// <param name="inputFilePath">The expected input file path.</param>
    public Solver05(string? inputFilePath)
        : base(inputFilePath) =>
        this.input = new ParsedFile(this.InputFilePath).ToSingleString(Environment.NewLine);

    /// <inheritdoc/>
    protected override int Solve1() =>
        this.NumNiceStrings(
            AtLeast3VowelsRegex,
            ContainsAtLeast1RepeatingLetterRegex,
            DoesNotContainForbiddenStringRegex
        );

    /// <inheritdoc/>
    protected override int Solve2() =>
        this.NumNiceStrings(
            ContainsNonOverlappingPairOfLetterRegex,
            ContainsRepeatedLetterWith1LetterInbetweenRegex
        );

    private static string AllRegexes(params string[] regexes) =>
        string.Join(string.Empty, regexes.Select(regex => $"(?=^.*{regex}.*$)"));

    private int NumNiceStrings(params string[] regexes) =>
        Regex.Matches(this.input, AllRegexes(regexes), RegexOptions.Multiline).Count;
}
