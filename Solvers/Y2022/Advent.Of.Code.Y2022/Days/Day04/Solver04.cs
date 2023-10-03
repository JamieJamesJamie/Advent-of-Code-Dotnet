// <copyright file="Solver04.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace Advent.Of.Code.Y2022.Days.Day04;

using Advent.Of.Code.Shared.AOCHelper;
using FileParser;

/// <summary>
/// Solver for day 4.
/// </summary>
public class Solver04 : BaseSolver<int>
{
    private readonly IEnumerable<Tuple<HashSet<int>, HashSet<int>>> sectionIds;

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver04"/> class.
    /// </summary>
    public Solver04()
        : this(null) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver04"/> class.
    /// </summary>
    /// <param name="inputFilePath">The expected input file path.</param>
    public Solver04(string? inputFilePath)
        : base(inputFilePath) => this.sectionIds = this.ParseInput();

    /// <inheritdoc/>
    protected override int Solve1() =>
        this.sectionIds.Count(
            sets => sets.Item1.IsSubsetOf(sets.Item2) || sets.Item2.IsSubsetOf(sets.Item1)
        );

    /// <inheritdoc/>
    protected override int Solve2() =>
        this.sectionIds.Count(sets => sets.Item1.Intersect(sets.Item2).Any());

    private IEnumerable<Tuple<HashSet<int>, HashSet<int>>> ParseInput()
    {
        ParsedFile file = new(this.InputFilePath, existingSeparator: new[] { ',', '-' });

        while (!file.Empty)
        {
            IParsedLine line = file.NextLine();

            int start1 = line.NextElement<int>();
            int end1 = line.NextElement<int>();
            int start2 = line.NextElement<int>();
            int end2 = line.NextElement<int>();

            yield return new(
                new(Enumerable.Range(start1, end1 - start1 + 1)),
                new(Enumerable.Range(start2, end2 - start2 + 1))
            );
        }
    }
}
