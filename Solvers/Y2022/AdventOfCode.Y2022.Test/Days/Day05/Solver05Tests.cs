// <copyright file="Solver05Tests.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2022.Test.Days.Day05;

using AdventOfCode.Y2022.Days.Day05;

/// <summary>
/// Tests for <see cref="Solver05"/>.
/// </summary>
public class Solver05Tests : TestFixture
{
    private readonly Solver05 solver;

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver05Tests"/> class.
    /// </summary>
    public Solver05Tests() => this.solver = new Solver05(inputFilePath: this.InputFilePath());

    /// <summary>
    /// Tests that <see cref="Solver05.Solve1"/> returns as expected.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task Solve_1_ReturnsExpected() => (await this.solver.Solve_1()).Should().Be("CMZ");

    /// <summary>
    /// Tests that <see cref="Solver05.Solve2"/> returns as expected.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task Solve_2_ReturnsExpected() => (await this.solver.Solve_2()).Should().Be("MCD");
}
