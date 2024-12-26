// <copyright file="Solver05.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2024.Days.Day05;

using System.Globalization;

/// <summary>
/// Solver for day 5.
/// </summary>
internal sealed class Solver05 : BaseSolver<uint>
{
    private readonly HashSet<PageOrderingRule> pageOrderingRules;

    private readonly List<IEnumerable<uint>> updatePageNumbers;

    private readonly PageComparer pageComparer;

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver05"/> class.
    /// </summary>
    public Solver05()
        : this(null) { }

    public Solver05(string? inputFilePath)
        : base(inputFilePath)
    {
        List<List<string>> parsedLines = ParsedFile.ReadAllGroupsOfLines(this.InputFilePath);

        List<string> pageOrderingRulesLines = parsedLines[0];
        List<string> updatePageNumbersLines = parsedLines[^1];

        this.pageOrderingRules = pageOrderingRulesLines
            .Select(rule =>
            {
                string[] pageNumbers = rule.Split('|');
                return new PageOrderingRule(
                    uint.Parse(pageNumbers[0], CultureInfo.InvariantCulture),
                    uint.Parse(pageNumbers[^1], CultureInfo.InvariantCulture)
                );
            })
            .ToHashSet();

        this.updatePageNumbers = updatePageNumbersLines
            .Select(update =>
                update
                    .Split(',')
                    .Select(pageNumber => uint.Parse(pageNumber, CultureInfo.InvariantCulture))
            )
            .ToList();

        this.pageComparer = new(this.pageOrderingRules);
    }

    private IEnumerable<int> IterateMiddlePages(bool isOrdered)
    {
        foreach (IEnumerable<uint> update in this.updatePageNumbers)
        {
            IOrderedEnumerable<uint> orderedUpdate = update.Order(this.pageComparer);
        }
    }

    private int SumMiddlePages(bool isOrdered) => this.IterateMiddlePages(isOrdered).Sum();

    /// <inheritdoc/>
    protected override uint Solve1() => throw new NotImplementedException();

    /// <inheritdoc/>
    protected override uint Solve2() => throw new NotImplementedException();
}
