// <copyright file="Solver01.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2018.Days.Day01;

using AdventOfCode.Common.Extensions;

/// <summary>
/// Solver for day 1.
/// </summary>
internal sealed class Solver01 : BaseSolver<int>
{
    private readonly IReadOnlyList<int> frequencyChanges;

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
        : base(inputFilePath) =>
        this.frequencyChanges =
            ParsedFile.ReadAllGroupsOfLines<int>(this.InputFilePath).FirstOrDefault() ?? [];

    /// <inheritdoc/>
    protected override int Solve1() => this.frequencyChanges.Sum();

    /// <inheritdoc/>
    protected override int Solve2()
    {
        int currentFrequency = 0;

        HashSet<int> encounteredFrequencies = [currentFrequency];

        foreach (int frequencyChange in this.frequencyChanges.Cycle())
        {
            currentFrequency += frequencyChange;

            if (!encounteredFrequencies.Add(currentFrequency))
            {
                return currentFrequency;
            }
        }

        return currentFrequency;
    }
}
