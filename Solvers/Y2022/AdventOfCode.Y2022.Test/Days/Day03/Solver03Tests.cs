// <copyright file="Solver03Tests.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2022.Test.Days.Day03;

using AdventOfCode.Y2022.Days.Day03;

/// <summary>
/// Tests for <see cref="Solver03"/>.
/// </summary>
public class Solver03Tests : TestFixture
{
    private readonly Solver03 solver;

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver03Tests"/> class.
    /// </summary>
    public Solver03Tests() => this.solver = new Solver03(inputFilePath: this.InputFilePath());

    /// <summary>
    /// Tests that <see cref="Solver03.Solve1"/> returns as expected.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task Solve_1_ReturnsExpected() => (await this.solver.Solve_1()).Should().Be("157");

    /// <summary>
    /// Tests that <see cref="Solver03.Solve2"/> returns as expected.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task Solve_2_ReturnsExpected() => (await this.solver.Solve_2()).Should().Be("70");
}
