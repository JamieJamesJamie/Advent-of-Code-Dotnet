// <copyright file="Solver06Tests.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2022.Test.Days.Day06;

using AdventOfCode.Y2022.Days.Day06;

/// <summary>
/// Tests for <see cref="Solver06"/>.
/// </summary>
public class Solver06Tests : TestFixture
{
    /// <summary>
    /// Tests that <see cref="Solver06.Solve1"/> returns as expected.
    /// </summary>
    /// <param name="testFileSuffix">Suffix of the test file.</param>
    /// <param name="expected">The expected result.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    [Test]
    [Arguments("1", "7")]
    [Arguments("2", "5")]
    [Arguments("3", "6")]
    [Arguments("4", "10")]
    [Arguments("5", "11")]
    public async Task Solve_1_ReturnsExpected(string testFileSuffix, string expected) =>
        (await this.CreateSolver(testFileSuffix).Solve_1()).Should().Be(expected);

    /// <summary>
    /// Tests that <see cref="Solver06.Solve2"/> returns as expected.
    /// </summary>
    /// <param name="testFileSuffix">Suffix of the test file.</param>
    /// <param name="expected">The expected result.</param>
    /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
    [Test]
    [Arguments("1", "19")]
    [Arguments("2", "23")]
    [Arguments("3", "23")]
    [Arguments("4", "29")]
    [Arguments("5", "26")]
    public async Task Solve_2_ReturnsExpected(string testFileSuffix, string expected) =>
        (await this.CreateSolver(testFileSuffix).Solve_2()).Should().Be(expected);

    private Solver06 CreateSolver(string testFileSuffix) =>
        new(inputFilePath: this.InputFilePath(fileName: $"example{testFileSuffix}"));
}
