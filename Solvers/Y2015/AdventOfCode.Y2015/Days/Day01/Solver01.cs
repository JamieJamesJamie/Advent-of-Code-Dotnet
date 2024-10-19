// <copyright file="Solver01.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2015.Days.Day01;

/// <summary>
/// Solver for day 1.
/// </summary>
public class Solver01 : BaseSolver<int, uint?>
{
    private readonly IEnumerable<int> floorIncrements;

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
        : base(inputFilePath)
    {
        Dictionary<char, int> mappings = new() { { '(', 1 }, { ')', -1 } };

        this.floorIncrements = new ParsedFile(this.InputFilePath)
            .ToSingleString()
            .Select(direction => mappings[direction]);
    }

    /// <inheritdoc/>
    protected override int Solve1() => this.floorIncrements.Sum();

    /// <inheritdoc/>
    protected override uint? Solve2()
    {
        const int basementFloor = -1;
        int currentFloor = 0;

        foreach (
            (uint position, int floorIncrement) in this.floorIncrements.Select(
                (increment, index) => ((uint)index + 1, increment)
            )
        )
        {
            currentFloor += floorIncrement;

            if (currentFloor == basementFloor)
            {
                return position;
            }
        }

        return null;
    }
}
