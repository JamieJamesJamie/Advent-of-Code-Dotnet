// <copyright file="Solver02.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2018.Days.Day02;

using System.Collections.Immutable;
using CommunityToolkit.HighPerformance;

/// <summary>
/// Solver for day 2.
/// </summary>
internal sealed class Solver02 : BaseSolver<int, string>
{
    private readonly IReadOnlyList<string> letters;

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
        : base(inputFilePath) =>
        this.letters = ParsedFile.ReadAllGroupsOfLines(this.InputFilePath).FirstOrDefault() ?? [];

    /// <inheritdoc/>
    protected override int Solve1()
    {
        ImmutableList<ImmutableHashSet<int>> counts =
        [
            .. this.letters.Select(line =>
                line.Distinct().Select(character => line.Count(character)).ToImmutableHashSet()
            ),
        ];

        return counts.Count(line => line.Contains(2)) * counts.Count(line => line.Contains(3));
    }

    /// <inheritdoc/>
    protected override string Solve2()
    {
        foreach ((int line1Index, string line1) in this.letters.Index())
        {
            foreach (string line2 in this.letters.Skip(line1Index + 1))
            {
                string lettersToReturn = new([
                    .. line1
                        .Zip(line2)
                        .Where(characters => characters.First == characters.Second)
                        .Select(characters => characters.First),
                ]);

                if (lettersToReturn.Length == line1.Length - 1)
                {
                    return lettersToReturn;
                }
            }
        }

        return string.Empty;
    }
}
