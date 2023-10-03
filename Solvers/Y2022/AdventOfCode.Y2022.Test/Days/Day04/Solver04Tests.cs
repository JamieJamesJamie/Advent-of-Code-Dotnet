// <copyright file="Solver04Tests.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2022.Test.Days.Day04;

using AdventOfCode.Common.Test.TestHelpers;
using AdventOfCode.Y2022.Days.Day04;

/// <summary>
/// Tests for <see cref="Solver04"/>.
/// </summary>
public class Solver04Tests : TestFixture
{
    private readonly Solver04 solver;

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver04Tests"/> class.
    /// </summary>
    public Solver04Tests() =>
        this.solver = new Solver04(inputFilePath: this.InputFilePath("example"));

    /// <summary>
    /// Tests that <see cref="Solver04.Solve1"/> returns as expected.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task Solve_1_ReturnsExpected() =>
        (await this.solver.Solve_1()).Should().Be("2");

    /// <summary>
    /// Tests that <see cref="Solver04.Solve2"/> returns as expected.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task Solve_2_ReturnsExpected() =>
        (await this.solver.Solve_2()).Should().Be("4");
}
