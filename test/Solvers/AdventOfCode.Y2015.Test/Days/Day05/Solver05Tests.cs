// <copyright file="Solver05Tests.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2015.Test.Days.Day05;

using AdventOfCode.Y2015.Days.Day05;

/// <summary>
/// Tests for <see cref="Solver05"/>.
/// </summary>
public class Solver05Tests : TestFixture
{
    /// <summary>
    /// Tests that <see cref="Solver05.Solve1"/> returns as expected.
    /// </summary>
    /// <param name="exampleIndex">Index of the example.</param>
    /// <param name="expectedNumNiceStrings">The expected number of nice strings.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 0)]
    [InlineData(4, 0)]
    [InlineData(5, 0)]
    [InlineData(6, 2)]
    public async Task Solve_1_ReturnsExpected(uint exampleIndex, uint expectedNumNiceStrings) =>
        (
            await new Solver05(
                inputFilePath: this.InputFilePath(fileName: $"example{exampleIndex}")
            ).Solve_1()
        )
            .Should()
            .Be($"{expectedNumNiceStrings}");

    /// <summary>
    /// Tests that <see cref="Solver05.Solve2"/> returns as expected.
    /// </summary>
    /// <param name="exampleIndex">Index of the example.</param>
    /// <param name="expectedNumNiceStrings">The expected number of nice strings.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Theory]
    [InlineData(7, 1)]
    [InlineData(8, 1)]
    [InlineData(9, 0)]
    [InlineData(10, 0)]
    [InlineData(11, 2)]
    public async Task Solve_2_ReturnsExpected(uint exampleIndex, uint expectedNumNiceStrings) =>
        (
            await new Solver05(
                inputFilePath: this.InputFilePath(fileName: $"example{exampleIndex}")
            ).Solve_2()
        )
            .Should()
            .Be($"{expectedNumNiceStrings}");
}
