// <copyright file="Solver03.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2015.Days.Day03;

using System.Numerics;

/// <summary>
/// Solver for day 3.
/// </summary>
public class Solver03 : BaseSolver<int>
{
    private static readonly Dictionary<char, Vector2> DirectionMappings =
        new()
        {
            { '^', new(0, 1) },
            { 'v', new(0, -1) },
            { '>', new(1, 0) },
            { '<', new(-1, 0) },
        };

    private readonly string directions;

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver03"/> class.
    /// </summary>
    public Solver03()
        : this(null) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver03"/> class.
    /// </summary>
    /// <param name="inputFilePath">The expected input file path.</param>
    public Solver03(string? inputFilePath)
        : base(inputFilePath) =>
        this.directions = new ParsedFile(this.InputFilePath).ToSingleString();

    /// <inheritdoc/>
    protected override int Solve1()
    {
        Vector2 currentPosition = new(0, 0);
        HashSet<Vector2> housesVisited = [currentPosition];

        foreach (char direction in this.directions)
        {
            currentPosition = TraverseAndAddHouseVisit(housesVisited, currentPosition, direction);
        }

        return housesVisited.Count;
    }

    /// <inheritdoc/>
    protected override int Solve2()
    {
        Vector2 santaPosition = new(0, 0);
        Vector2 roboSantaPosition = new(0, 0);
        HashSet<Vector2> housesVisited = [santaPosition];

        foreach (
            (int index, char direction) in this.directions.Select(
                (direction, index) => (index, direction)
            )
        )
        {
            if (index % 2 == 0)
            {
                santaPosition = TraverseAndAddHouseVisit(housesVisited, santaPosition, direction);
            }
            else
            {
                roboSantaPosition = TraverseAndAddHouseVisit(
                    housesVisited,
                    roboSantaPosition,
                    direction
                );
            }
        }

        return housesVisited.Count;
    }

    /// <summary>
    /// Traverses to the next position and adds the new position to the <paramref name="housesVisited"/>.
    /// </summary>
    /// <param name="housesVisited">The set of houses to add the new position to.</param>
    /// <param name="currentPosition">The current position to traverse from.</param>
    /// <param name="direction">The direction to traverse to.</param>
    /// <returns>
    /// The position resulting from moving 1 house in the <paramref name="direction"/>
    /// from the <paramref name="currentPosition"/>.
    /// </returns>
    private static Vector2 TraverseAndAddHouseVisit(
        HashSet<Vector2> housesVisited,
        Vector2 currentPosition,
        char direction
    )
    {
        currentPosition += DirectionMappings[direction];
        housesVisited.Add(currentPosition);
        return currentPosition;
    }
}
