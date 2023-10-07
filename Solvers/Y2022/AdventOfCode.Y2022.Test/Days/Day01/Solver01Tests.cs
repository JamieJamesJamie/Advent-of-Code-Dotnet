// <copyright file="Solver01Tests.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2022.Test.Days.Day01;

using AdventOfCode.Y2022.Days.Day01;

/// <summary>
/// Tests for <see cref="Solver01"/>.
/// </summary>
public class Solver01Tests : TestFixture
{
    private readonly Solver01 solver;

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver01Tests"/> class.
    /// </summary>
    public Solver01Tests() =>
        this.solver = new Solver01(inputFilePath: this.InputFilePath("example"));

    /// <summary>
    /// Tests that <see cref="Solver01.Solve1"/> returns as expected.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task Solve_1_ReturnsExpected() =>
        (await this.solver.Solve_1()).Should().Be("24000");

    /// <summary>
    /// Tests that <see cref="Solver01.Solve2"/> returns as expected.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task Solve_2_ReturnsExpected() =>
        (await this.solver.Solve_2()).Should().Be("45000");
}
