// <copyright file="Solver06Tests.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2015.Test.Days.Day06;

using AdventOfCode.Y2015.Days.Day06;

public class Solver06Tests : TestFixture
{
    [Theory]
    [InlineData(1, 1_000_000)]
    [InlineData(2, 1_000)]
    [InlineData(3, 0)]
    [InlineData(4, 998_996)]
    [InlineData(5, 1)]
    [InlineData(6, 1_000_000)]
    public async Task Solve_1_ReturnsExpected(uint exampleIndex, uint expectedNumLights) =>
        (
            await new Solver06(
                inputFilePath: this.InputFilePath(fileName: $"example{exampleIndex}")
            ).Solve_1()
        )
            .Should()
            .Be($"{expectedNumLights}");

    [Theory]
    [InlineData(1, 1_000_000)]
    [InlineData(2, 2_000)]
    [InlineData(3, 0)]
    [InlineData(4, 1_001_996)]
    [InlineData(5, 1)]
    [InlineData(6, 2_000_000)]
    public async Task Solve_2_ReturnsExpected(uint exampleIndex, uint expectedNumLights) =>
        (
            await new Solver06(
                inputFilePath: this.InputFilePath(fileName: $"example{exampleIndex}")
            ).Solve_2()
        )
            .Should()
            .Be($"{expectedNumLights}");
}
