// <copyright file="Solver04.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2022.Days.Day04;

/// <summary>
/// Solver for day 4.
/// </summary>
internal sealed class Solver04 : BaseSolver<int>
{
    private static readonly char[] ExistingSeparator = [',', '-'];

    private readonly IEnumerable<SectionAssignmentPair> sectionIds;

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
        this.sectionIds.Count(sets =>
            sets.Elf1Sections.IsSubsetOf(sets.Elf2Sections)
            || sets.Elf2Sections.IsSubsetOf(sets.Elf1Sections)
        );

    /// <inheritdoc/>
    protected override int Solve2() =>
        this.sectionIds.Count(sets => sets.Elf1Sections.Intersect(sets.Elf2Sections).Any());

    private IEnumerable<SectionAssignmentPair> ParseInput()
    {
        ParsedFile file = new(this.InputFilePath, existingSeparator: ExistingSeparator);

        while (!file.Empty)
        {
            IParsedLine line = file.NextLine();

            int start1 = line.NextElement<int>();
            int end1 = line.NextElement<int>();
            int start2 = line.NextElement<int>();
            int end2 = line.NextElement<int>();

            yield return new(
                [.. Enumerable.Range(start1, end1 - start1 + 1)],
                [.. Enumerable.Range(start2, end2 - start2 + 1)]
            );
        }
    }

    private sealed record SectionAssignmentPair(
        HashSet<int> Elf1Sections,
        HashSet<int> Elf2Sections
    );
}
