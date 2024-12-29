// <copyright file="Solver01Tests.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2015.Test.Days.Day01;

using AdventOfCode.Y2015.Days.Day01;

/// <summary>
/// Tests for <see cref="Solver01"/>.
/// </summary>
public class Solver01Tests : TestFixture
{
    /// <summary>
    /// Tests that <see cref="Solver01.Solve1"/> returns as expected.
    /// </summary>
    /// <param name="exampleIndex">Index of the example.</param>
    /// <param name="expectedFloor">The expected floor.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Theory]
    [InlineData(1, 0)]
    [InlineData(2, 0)]
    [InlineData(3, 3)]
    [InlineData(4, 3)]
    [InlineData(5, 3)]
    [InlineData(6, -1)]
    [InlineData(7, -1)]
    [InlineData(8, -3)]
    [InlineData(9, -3)]
    [InlineData(10, -1)]
    [InlineData(11, -1)]
    public async Task Solve_1_ReturnsExpected(uint exampleIndex, int expectedFloor) =>
        (
            await new Solver01(
                inputFilePath: this.InputFilePath(fileName: $"example{exampleIndex}")
            ).Solve_1()
        )
            .Should()
            .Be($"{expectedFloor}");

    /// <summary>
    /// Tests that <see cref="Solver01.Solve2"/> returns as expected.
    /// </summary>
    /// <param name="exampleIndex">Index of the example.</param>
    /// <param name="expectedPosition">The expected position.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Theory]
    [InlineData(1, null)]
    [InlineData(2, null)]
    [InlineData(3, null)]
    [InlineData(4, null)]
    [InlineData(5, 1)]
    [InlineData(6, 3)]
    [InlineData(7, 1)]
    [InlineData(8, 1)]
    [InlineData(9, 1)]
    [InlineData(10, 1)]
    [InlineData(11, 5)]
    public async Task Solve_2_ReturnsExpected(uint exampleIndex, int? expectedPosition) =>
        (
            await new Solver01(
                inputFilePath: this.InputFilePath(fileName: $"example{exampleIndex}")
            ).Solve_2()
        )
            .Should()
            .Be($"{expectedPosition}");
}
