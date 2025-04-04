﻿// <copyright file="TestFixture.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Common.Test.TestHelpers;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>
/// Test Fixture for Advent Of Code puzzles.
/// </summary>
[SuppressMessage(
    "Maintainability",
    "CA1515:Consider making public types internal",
    Justification = "This TestFixture is used in multiple Test projects"
)]
public abstract class TestFixture
{
    private const string ClassPrefix = "Solver";

    private string InputsDir => Path.Combine("Inputs", $"Day{this.CalculateIndex()}");

    /// <summary>
    /// Returns the path of the test input file.
    /// </summary>
    /// <param name="fileName">Name of the file to get the path of.</param>
    /// <param name="fileExtension">Extension of the file to get the path of.</param>
    /// <returns>The path of the test input file.</returns>
    protected string InputFilePath(string fileName = "example1", string fileExtension = "txt") =>
        Path.Combine(this.InputsDir, $"{fileName}.{fileExtension}");

    private string CalculateIndex()
    {
        string typeName = this.GetType().Name;

        string substring = typeName[
            (typeName.IndexOf(ClassPrefix, StringComparison.Ordinal) + ClassPrefix.Length)..
        ]
            .TrimStart('_');

        string numbersOnly = new(substring.TakeWhile(char.IsDigit).ToArray());

        uint digits = uint.TryParse(numbersOnly, out uint index) ? index : default;

        return digits.ToString("D2", CultureInfo.InvariantCulture);
    }
}
