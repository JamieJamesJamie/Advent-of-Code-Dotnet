// <copyright file="Solver07Tests.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2022.Test.Days.Day07;

using AdventOfCode.Y2022.Days.Day07;

/// <summary>
/// Tests for <see cref="Solver07"/>.
/// </summary>
public class Solver07Tests : TestFixture
{
    private readonly Solver07 solver;

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver07Tests"/> class.
    /// </summary>
    public Solver07Tests() => this.solver = new Solver07(inputFilePath: this.InputFilePath());

    /// <summary>
    /// Tests that <see cref="Solver07.Solve1"/> returns as expected.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task Solve_1_ReturnsExpected() =>
        (await this.solver.Solve_1()).Should().Be("95437");

    /// <summary>
    /// Tests that <see cref="Solver07.Solve2"/> returns as expected.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task Solve_2_ReturnsExpected() =>
        (await this.solver.Solve_2()).Should().Be("24933642");
}
