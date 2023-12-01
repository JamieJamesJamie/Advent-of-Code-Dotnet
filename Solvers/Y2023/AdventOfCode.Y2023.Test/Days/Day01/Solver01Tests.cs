// <copyright file="Solver01Tests.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2023.Test.Days.Day01;

using AdventOfCode.Y2023.Days.Day01;

/// <summary>
/// Tests for <see cref="Solver01"/>.
/// </summary>
public class Solver01Tests : TestFixture
{
    /// <summary>
    /// Tests that <see cref="Solver01.Solve1"/> returns as expected.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    [Fact]
    public async Task Solve_1_ReturnsExpected() =>
        (await new Solver01(inputFilePath: this.InputFilePath(fileName: $"example1")).Solve_1())
            .Should()
            .Be("142");

    /// <summary>
    /// Tests that <see cref="Solver01.Solve2"/> returns as expected.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    [Fact]
    public async Task Solve_2_ReturnsExpected() =>
        (await new Solver01(inputFilePath: this.InputFilePath(fileName: $"example2")).Solve_2())
            .Should()
            .Be("281");
}
