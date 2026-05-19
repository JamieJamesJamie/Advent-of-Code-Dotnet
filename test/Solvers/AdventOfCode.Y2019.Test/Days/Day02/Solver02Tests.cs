// <copyright file="Solver02Tests.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2019.Test.Days.Day02;

using AdventOfCode.Y2019.Days.Day02;

/// <summary>
/// Tests for <see cref="Solver02"/>.
/// </summary>
public class Solver02Tests : TestFixture
{
    /// <summary>
    /// Tests that <see cref="Solver02.Solve1"/> returns as expected.
    /// </summary>
    /// <param name="exampleIndex">Index of the example.</param>
    /// <param name="expectedValue">The expected value.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Test]
    [Arguments(1, 3500)]
    [Arguments(2, 2)]
    [Arguments(3, 2)]
    [Arguments(4, 2)]
    [Arguments(5, 30)]
    public async Task Solve_1_ReturnsExpected(uint exampleIndex, uint expectedValue) =>
        (
            await new Solver02(
                inputFilePath: this.InputFilePath(fileName: $"example{exampleIndex}")
            ).Solve_1()
        )
            .Should()
            .Be($"{expectedValue}");
}
