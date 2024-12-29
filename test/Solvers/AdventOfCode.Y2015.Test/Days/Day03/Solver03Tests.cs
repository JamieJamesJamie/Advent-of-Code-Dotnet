// <copyright file="Solver03Tests.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2015.Test.Days.Day03;

using AdventOfCode.Y2015.Days.Day03;

/// <summary>
/// Tests for <see cref="Solver03"/>.
/// </summary>
public class Solver03Tests : TestFixture
{
    /// <summary>
    /// Tests that <see cref="Solver03.Solve1"/> returns as expected.
    /// </summary>
    /// <param name="exampleIndex">Index of the example.</param>
    /// <param name="expectedHousesVisited">The expected number of houses visited.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 4)]
    [InlineData(3, 2)]
    [InlineData(4, 2)]
    public async Task Solve_1_ReturnsExpected(uint exampleIndex, int expectedHousesVisited) =>
        (
            await new Solver03(
                inputFilePath: this.InputFilePath(fileName: $"example{exampleIndex}")
            ).Solve_1()
        )
            .Should()
            .Be($"{expectedHousesVisited}");

    /// <summary>
    /// Tests that <see cref="Solver03.Solve2"/> returns as expected.
    /// </summary>
    /// <param name="exampleIndex">Index of the example.</param>
    /// <param name="expectedHousesVisited">The expected number of houses visited.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 3)]
    [InlineData(3, 11)]
    [InlineData(4, 3)]
    public async Task Solve_2_ReturnsExpected(uint exampleIndex, int expectedHousesVisited) =>
        (
            await new Solver03(
                inputFilePath: this.InputFilePath(fileName: $"example{exampleIndex}")
            ).Solve_2()
        )
            .Should()
            .Be($"{expectedHousesVisited}");
}
