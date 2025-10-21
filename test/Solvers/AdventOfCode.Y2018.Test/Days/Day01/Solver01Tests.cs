// <copyright file="Solver01Tests.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2018.Test.Days.Day01;

using AdventOfCode.Y2018.Days.Day01;

/// <summary>
/// Tests for <see cref="Solver01"/>.
/// </summary>
public class Solver01Tests : TestFixture
{
    /// <summary>
    /// Tests that <see cref="Solver01.Solve1"/> returns as expected.
    /// </summary>
    /// <param name="exampleIndex">Index of the example.</param>
    /// <param name="expectedSum">The expected sum.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Theory]
    [InlineData(1, 3)]
    [InlineData(2, 3)]
    [InlineData(3, 0)]
    [InlineData(4, -6)]
    [InlineData(9, 0)]
    public async Task Solve_1_ReturnsExpected(uint exampleIndex, int expectedSum) =>
        (
            await new Solver01(
                inputFilePath: this.InputFilePath(fileName: $"example{exampleIndex}")
            ).Solve_1()
        )
            .Should()
            .Be($"{expectedSum}");

    /// <summary>
    /// Tests that <see cref="Solver01.Solve2"/> returns as expected.
    /// </summary>
    /// <param name="exampleIndex">Index of the example.</param>
    /// <param name="expectedFrequency">The expected frequency.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Theory]
    [InlineData(1, 2)]
    [InlineData(5, 0)]
    [InlineData(6, 10)]
    [InlineData(7, 5)]
    [InlineData(8, 14)]
    [InlineData(9, 0)]
    public async Task Solve_2_ReturnsExpected(uint exampleIndex, int expectedFrequency) =>
        (
            await new Solver01(
                inputFilePath: this.InputFilePath(fileName: $"example{exampleIndex}")
            ).Solve_2()
        )
            .Should()
            .Be($"{expectedFrequency}");
}
