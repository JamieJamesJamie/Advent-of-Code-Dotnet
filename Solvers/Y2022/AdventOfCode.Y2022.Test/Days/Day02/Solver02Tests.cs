// <copyright file="Solver02Tests.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2022.Test.Days.Day02;

using AdventOfCode.Y2022.Days.Day02;

/// <summary>
/// Tests for <see cref="Solver02"/>.
/// </summary>
public class Solver02Tests : TestFixture
{
    private readonly Solver02 solver;

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver02Tests"/> class.
    /// </summary>
    public Solver02Tests() =>
        this.solver = new Solver02(inputFilePath: this.InputFilePath("example"));

    /// <summary>
    /// Tests that <see cref="Solver02.Solve1"/> returns as expected.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    [Fact]
    public async Task Solve_1_ReturnsExpected() => (await this.solver.Solve_1()).Should().Be("15");

    /// <summary>
    /// Tests that <see cref="Solver02.Solve2"/> returns as expected.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    [Fact]
    public async Task Solve_2_ReturnsExpected() => (await this.solver.Solve_2()).Should().Be("12");
}
