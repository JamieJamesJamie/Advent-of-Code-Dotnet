﻿// <copyright file="BaseSolver{TSolve1,TSolve2}.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Common.AOCHelper;

using AoCHelper;

/// <summary>
/// Abstract Base Class to solve Advent of Code puzzles.
/// </summary>
/// <typeparam name="TSolve1">The return type of the answer for part 1 of the problem.</typeparam>
/// <typeparam name="TSolve2">The return type of the answer for part 2 of the problem.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="BaseSolver{TSolve1, TSolve2}"/> class.
/// </remarks>
/// <param name="inputFilePath">The expected input file path.</param>
public abstract class BaseSolver<TSolve1, TSolve2>(string? inputFilePath) : BaseDay
{
    private readonly string? inputFilePath = inputFilePath;

    /// <inheritdoc/>
    public sealed override string InputFilePath => this.inputFilePath ?? base.InputFilePath;

    /// <summary>
    /// Gets prefix to look for on class names when running solvers for AOC problems.
    /// </summary>
    protected sealed override string ClassPrefix => "Solver";

    /// <summary>
    /// Solves part 1 of the problem.
    /// </summary>
    /// <returns>The result of part 1 of the problem.</returns>
    public sealed override ValueTask<string> Solve_1() =>
        new(this.Solve1()?.ToString() ?? string.Empty);

    /// <summary>
    /// Solves part 2 of the problem.
    /// </summary>
    /// <returns>The result of part 2 of the problem.</returns>
    public sealed override ValueTask<string> Solve_2() =>
        new(this.Solve2()?.ToString() ?? string.Empty);

    /// <summary>
    /// Solves part 1 of the problem.
    /// </summary>
    /// <returns>The result of part 1 of the problem.</returns>
    protected abstract TSolve1 Solve1();

    /// <summary>
    /// Solves part 2 of the problem.
    /// </summary>
    /// <returns>The result of part 2 of the problem.</returns>
    protected abstract TSolve2 Solve2();
}
