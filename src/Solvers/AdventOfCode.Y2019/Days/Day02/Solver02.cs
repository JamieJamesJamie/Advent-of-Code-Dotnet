// <copyright file="Solver02.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2019.Days.Day02;

using System.Globalization;

/// <summary>
/// Solver for day 2.
/// </summary>
internal sealed class Solver02 : BaseSolver<int>
{
    private static readonly Dictionary<int, Func<int, int, int>> Operations = new()
    {
        { 1, static (input1, input2) => input1 + input2 },
        { 2, static (input1, input2) => input1 * input2 },
    };

    private readonly List<int> program;

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
        : base(inputFilePath) => this.program = this.ParseInput();

    /// <inheritdoc/>
    protected override int Solve1()
    {
        int position = 0;

        while (this.program[position] != 99)
        {
            int input1 = this.program[this.program[position + 1]];
            int input2 = this.program[this.program[position + 2]];

            this.program[this.program[position + 3]] = Operations[this.program[position]]
                (input1, input2);

            position += 4;
        }

        return this.program[0];
    }

    /// <inheritdoc/>
    protected override int Solve2() => 0; // TODO: Complete Year 2019 Day 2 Part 2

    private List<int> ParseInput()
    {
        ParsedFile file = new(this.InputFilePath);

        return
        [
            .. file.ToSingleString()
                .Split(',')
                .Select(value => int.Parse(value, CultureInfo.InvariantCulture)),
        ];
    }
}
