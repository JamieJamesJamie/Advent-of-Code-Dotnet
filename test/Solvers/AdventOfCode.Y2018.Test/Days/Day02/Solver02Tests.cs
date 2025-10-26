// <copyright file="Solver02Tests.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2018.Test.Days.Day02;

using AdventOfCode.Y2018.Days.Day02;

/// <summary>
/// Tests for <see cref="Solver02"/>.
/// </summary>
public class Solver02Tests : TestFixture
{
    /// <summary>
    /// Tests that <see cref="Solver02.Solve1"/> returns as expected.
    /// </summary>
    /// <param name="exampleIndex">Index of the example.</param>
    /// <param name="expectedSum">The expected sum.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Theory]
    [InlineData(1, 12)]
    [InlineData(2, 0)]
    public async Task Solve_1_ReturnsExpected(uint exampleIndex, int expectedSum) =>
        (
            await new Solver02(
                inputFilePath: this.InputFilePath(fileName: $"example{exampleIndex}")
            ).Solve_1()
        )
            .Should()
            .Be($"{expectedSum}");

    /// <summary>
    /// Tests that <see cref="Solver02.Solve2"/> returns as expected.
    /// </summary>
    /// <param name="exampleIndex">Index of the example.</param>
    /// <param name="expectedLetters">The expected letters.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Theory]
    [InlineData(3, "fgij")]
    [InlineData(2, "")]
    public async Task Solve_2_ReturnsExpected(uint exampleIndex, string expectedLetters) =>
        (
            await new Solver02(
                inputFilePath: this.InputFilePath(fileName: $"example{exampleIndex}")
            ).Solve_2()
        )
            .Should()
            .Be(expectedLetters);
}
