// <copyright file="BaseSolver{TSolve}.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Common.AOCHelper;

/// <summary>
/// Abstract Base Class to solve Advent of Code puzzles.
/// </summary>
/// <typeparam name="TSolve">
/// The return type of the answers for both
/// part 1 and part 2 of the problem.
/// </typeparam>
public abstract class BaseSolver<TSolve> : BaseSolver<TSolve, TSolve>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseSolver{TSolve}"/> class.
    /// </summary>
    /// <param name="inputFilePath">The expected input file path.</param>
    protected BaseSolver(string? inputFilePath)
        : base(inputFilePath) { }
}
