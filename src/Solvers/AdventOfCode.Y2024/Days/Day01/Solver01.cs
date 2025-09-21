// <copyright file="Solver01.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2024.Days.Day01;

using System.Collections.Immutable;
using AdventOfCode.Common.Extensions;

/// <summary>
/// Solver for day 1.
/// </summary>
internal sealed class Solver01 : BaseSolver<uint>
{
    private readonly ImmutableList<IEnumerable<int>> locationIdLists;

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
        this.locationIdLists = [
            .. new ParsedFile(this.InputFilePath).Select(line => line.ToList<int>()).Zip(),
        ];

    /// <inheritdoc/>
    protected override uint Solve1() =>
        (uint)
            this
                .locationIdLists.Select(list => list.Order())
                .Zip(pair =>
                    int.Abs(
                        pair.Skip(1)
                            .Aggregate(
                                pair.First(),
                                (leftListLocationId, rightListLocationId) =>
                                    leftListLocationId - rightListLocationId
                            )
                    )
                )
                .Sum();

    /// <inheritdoc/>
    protected override uint Solve2()
    {
        IEnumerable<int> leftList = this.locationIdLists[0];
        IEnumerable<int> rightList = this.locationIdLists[1];

        return (uint)
            leftList.Sum(leftListElement =>
                leftListElement
                * rightList.Count(rightListElement => rightListElement == leftListElement)
            );
    }
}
