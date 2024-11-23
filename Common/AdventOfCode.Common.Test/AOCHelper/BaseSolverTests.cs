// <copyright file="BaseSolverTests.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Common.Test.AOCHelper;

using AdventOfCode.Common.AOCHelper;

/// <summary>
/// Tests for <see cref="BaseSolver{TSolve1, TSolve2}"/> and <see cref="BaseSolver{TSolve}"/>.
/// </summary>
public class BaseSolverTests
{
    /// <summary>
    /// Tests whether solving using <see cref="ChildSolver1"/> returns as expected.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task BaseSolver_TwoTypeparams_IntChar_Solves()
    {
        BaseSolver<int, char> solver = new ChildSolver1();

        solver.InputFilePath.Should().Be(ExpectedInputFilePath("01"));

        (await solver.Solve_1()).Should().Be("100");
        (await solver.Solve_2()).Should().Be("e");
    }

    /// <summary>
    /// Tests whether solving using <see cref="ChildSolver02"/> returns as expected.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task BaseSolver_TwoTypeparams_DoubleLong_Solves()
    {
        BaseSolver<double, long> solver = new ChildSolver02();

        solver.InputFilePath.Should().Be(ExpectedInputFilePath("02"));

        (await solver.Solve_1()).Should().Be("12.345");
        (await solver.Solve_2()).Should().Be("234");
    }

    /// <summary>
    /// Tests whether solving using <see cref="ChildSolver_03"/> returns as expected.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task BaseSolver_OneTypeparam_Solves()
    {
        BaseSolver<string> solver = new ChildSolver_03();

        solver.InputFilePath.Should().Be(ExpectedInputFilePath("03"));

        (await solver.Solve_1()).Should().Be("test1");
        (await solver.Solve_2()).Should().Be("test2");
    }

    /// <summary>
    /// Tests whether solving the first problem with a null solution returns as expected.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task Solve_1_NullSolution_ReturnsEmptyString()
    {
        BaseSolver<string?> solver = new NullSolver();

        solver.InputFilePath.Should().Be(ExpectedInputFilePath("00"));

        (await solver.Solve_1()).Should().Be(string.Empty);
    }

    /// <summary>
    /// Tests whether solving the second problem with a null solution returns as expected.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
    [Fact]
    public async Task Solve_2_NullSolution_ReturnsEmptyString()
    {
        BaseSolver<string?> solver = new NullSolver();

        solver.InputFilePath.Should().Be(ExpectedInputFilePath("00"));

        (await solver.Solve_2()).Should().Be(string.Empty);
    }

    /// <summary>
    /// Tests whether <see cref="BaseSolver{TSolve1, TSolve2}"/> returns a given custom input file path.
    /// </summary>
    [Fact]
    public void BaseSolver_TwoTypeparams_CustomInputFilePath_ReturnsCustomInputFilePath()
    {
        const string customPath = "customPath";

        BaseSolver<int, char> solver = new ChildSolver1(customPath);

        solver.InputFilePath.Should().Be(customPath);
    }

    /// <summary>
    /// Tests whether <see cref="BaseSolver{TSolve}"/> returns a given custom input file path.
    /// </summary>
    [Fact]
    public void BaseSolver_OneTypeparam_CustomInputFilePath_ReturnsCustomInputFilePath()
    {
        const string customPath = "customPath";

        BaseSolver<string> solver = new ChildSolver_03(customPath);

        solver.InputFilePath.Should().Be(customPath);
    }

    private static string ExpectedInputFilePath(string number) =>
        Path.Combine("Inputs", $"{number}.txt");

    private sealed class ChildSolver1(string? inputFilePath = null)
        : BaseSolver<int, char>(inputFilePath)
    {
        protected override int Solve1() => 100;

        protected override char Solve2() => 'e';
    }

    private sealed class ChildSolver02(string? inputFilePath = null)
        : BaseSolver<double, long>(inputFilePath)
    {
        protected override double Solve1() => 12.345;

        protected override long Solve2() => 234L;
    }

    private sealed class ChildSolver_03(string? inputFilePath = null)
        : BaseSolver<string>(inputFilePath)
    {
        protected override string Solve1() => "test1";

        protected override string Solve2() => "test2";
    }

    private sealed class NullSolver(string? inputFilePath = null)
        : BaseSolver<string?>(inputFilePath)
    {
        protected override string? Solve1() => null;

        protected override string? Solve2() => null;
    }
}
