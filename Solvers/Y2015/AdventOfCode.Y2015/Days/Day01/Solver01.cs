// <copyright file="Solver01.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2015.Days.Day01;

/// <summary>
/// Solver for day 1.
/// </summary>
public class Solver01 : BaseSolver<int, ulong?>
{
    private readonly IEnumerable<int> input;

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

        this.input = new ParsedFile(this.InputFilePath)
            .ToSingleString()
            .Select(direction => mappings[direction]);
    }

    /// <inheritdoc/>
    protected override int Solve1() => this.input.Sum();

    /// <inheritdoc/>
    protected override ulong? Solve2()
    {
        const int basementFloor = -1;
        int currentFloor = 0;

        foreach (
            (int position, int floorPosition) in this.input.Select(
                (element, index) => (index + 1, element)
            )
        )
        {
            currentFloor += floorPosition;

            if (currentFloor == basementFloor)
            {
                return (ulong)position;
            }
        }

        return null;
    }
}
