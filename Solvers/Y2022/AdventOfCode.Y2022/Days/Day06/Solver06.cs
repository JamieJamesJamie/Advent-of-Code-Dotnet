// <copyright file="Solver06.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2022.Days.Day06;

using System.Collections;

/// <summary>
/// Solver for day 6.
/// </summary>
public class Solver06 : BaseSolver<int>
{
    private readonly string input;

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver06"/> class.
    /// </summary>
    public Solver06()
        : this(null) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver06"/> class.
    /// </summary>
    /// <param name="inputFilePath">The expected input file path.</param>
    public Solver06(string? inputFilePath)
        : base(inputFilePath) => this.input = File.ReadAllText(this.InputFilePath);

    /// <inheritdoc/>
    protected override int Solve1() => this.GetMarker(4);

    /// <inheritdoc/>
    protected override int Solve2() => this.GetMarker(14);

    /// <summary>
    /// Returns the marker for the input given the number of distinct characters that there should be to indicate a marker.
    /// </summary>
    /// <param name="numDistinctCharacters">The number of distinct characters that there should be to indicate a marker.</param>
    /// <returns>The number of characters that need to be processed before the marker is detected.</returns>
    private int GetMarker(int numDistinctCharacters)
    {
        Queue window = new(numDistinctCharacters);

        for (int characterIndex = 0; characterIndex <= this.input.Length; characterIndex++)
        {
            if (window.Count == numDistinctCharacters)
            {
                window.Dequeue();
            }

            window.Enqueue(this.input[characterIndex]);

            if (window.ToArray().Distinct().Count() == numDistinctCharacters)
            {
                return characterIndex + 1;
            }
        }

        return -1;
    }
}
