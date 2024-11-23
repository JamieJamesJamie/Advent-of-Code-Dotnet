// <copyright file="Solver01.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2022.Days.Day01;

/// <summary>
/// Solver for day 1.
/// </summary>
internal sealed class Solver01 : BaseSolver<long>
{
    private readonly IEnumerable<int> groupSums;

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
        this.groupSums = ParsedFile
            .ReadAllGroupsOfLines<int>(this.InputFilePath)
            .ConvertAll(group => group.Sum());

    /// <inheritdoc/>
    protected override long Solve1() => this.groupSums.Max();

    /// <inheritdoc/>
    protected override long Solve2() => this.groupSums.OrderDescending().Take(3).Sum();
}
