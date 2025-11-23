// <copyright file="Solver01.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2019.Days.Day01;

/// <summary>
/// Solver for day 1.
/// </summary>
internal sealed class Solver01 : BaseSolver<int>
{
    private readonly IReadOnlyList<int> masses;

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver01"/> class.
    /// </summary>
    public Solver01()
        : this(null) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver01"/> class.
    /// </summary>
    /// <param name="inputFilePath">The expected input file path.</param>
    public Solver01(string? inputFilePath)
        : base(inputFilePath) =>
        this.masses =
            ParsedFile.ReadAllGroupsOfLines<int>(this.InputFilePath).FirstOrDefault() ?? [];

    /// <inheritdoc/>
    protected override int Solve1() => this.masses.Sum(FuelRequired);

    /// <inheritdoc/>
    protected override int Solve2() => this.masses.Sum(FuelRequiredPart2);

    private static int FuelRequired(int mass) => (mass / 3) - 2;

    private static int FuelRequiredPart2(int mass)
    {
        int fuelRequired = FuelRequired(mass);
        return fuelRequired <= 0 ? 0 : fuelRequired + FuelRequiredPart2(fuelRequired);
    }
}
