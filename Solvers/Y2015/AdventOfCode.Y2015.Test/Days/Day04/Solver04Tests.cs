// <copyright file="Solver04Tests.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2015.Test.Days.Day04;

using AdventOfCode.Y2015.Days.Day04;

/// <summary>
/// Tests for <see cref="Solver04"/>.
/// </summary>
public class Solver04Tests : TestFixture
{
    /// <summary>
    /// Tests that <see cref="Solver04.Solve1"/> returns as expected.
    /// </summary>
    /// <param name="exampleIndex">Index of the example.</param>
    /// <param name="expectedKeySuffix">The expected key suffix.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Theory]
    [InlineData(1, 609043)]
    [InlineData(2, 1048970)]
    public async Task Solve_1_ReturnsExpected(uint exampleIndex, uint expectedKeySuffix) =>
        (
            await new Solver04(
                inputFilePath: this.InputFilePath(fileName: $"example{exampleIndex}")
            ).Solve_1()
        )
            .Should()
            .Be($"{expectedKeySuffix}");

    /// <summary>
    /// Tests that <see cref="Solver04.Solve2"/> returns as expected.
    /// </summary>
    /// <param name="exampleIndex">Index of the example.</param>
    /// <param name="expectedKeySuffix">The expected key suffix.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Theory]
    [InlineData(1, 6742839)]
    [InlineData(2, 5714438)]
    public async Task Solve_2_ReturnsExpected(uint exampleIndex, uint expectedKeySuffix) =>
        (
            await new Solver04(
                inputFilePath: this.InputFilePath(fileName: $"example{exampleIndex}")
            ).Solve_2()
        )
            .Should()
            .Be($"{expectedKeySuffix}");
}
