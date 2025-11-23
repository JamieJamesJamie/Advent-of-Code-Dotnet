// <copyright file="Solver01Tests.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2019.Test.Days.Day01;

using AdventOfCode.Y2019.Days.Day01;

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
    [InlineData(1, 2)]
    [InlineData(2, 2)]
    [InlineData(3, 654)]
    [InlineData(4, 33583)]
    [InlineData(5, 34241)]
    [InlineData(6, 0)]
    public async Task Solve_1_ReturnsExpected(uint exampleIndex, uint expectedSum) =>
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
    /// <param name="expectedSum">The expected sum.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 2)]
    [InlineData(3, 966)]
    [InlineData(4, 50346)]
    [InlineData(5, 51316)]
    [InlineData(6, 0)]
    public async Task Solve_2_ReturnsExpected(uint exampleIndex, uint expectedSum) =>
        (
            await new Solver01(
                inputFilePath: this.InputFilePath(fileName: $"example{exampleIndex}")
            ).Solve_2()
        )
            .Should()
            .Be($"{expectedSum}");
}
