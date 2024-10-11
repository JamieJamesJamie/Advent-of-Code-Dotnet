// <copyright file="Solver03.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2022.Days.Day03;

using System;
using AdventOfCode.Common.Extensions;

/// <summary>
/// Solver for day 3.
/// </summary>
public class Solver03 : BaseSolver<int>
{
    private readonly IEnumerable<string> rucksacks;

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver03"/> class.
    /// </summary>
    public Solver03()
        : this(null) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver03"/> class.
    /// </summary>
    /// <param name="inputFilePath">The expected input file path.</param>
    public Solver03(string? inputFilePath)
        : base(inputFilePath) => this.rucksacks = this.ParseInput();

    /// <inheritdoc/>
    protected override int Solve1() =>
        this.rucksacks.Sum(rucksack =>
        {
            int compartmentLength = rucksack.Length / 2;

            char sharedCharacter = rucksack
                .Take(compartmentLength)
                .Intersect(rucksack.TakeLast(compartmentLength))
                .First();

            return CharacterPriority(sharedCharacter);
        });

    /// <inheritdoc/>
    protected override int Solve2()
    {
        const int step = 3;

        List<IEnumerable<string>> rucksackSets =
        [
            this.rucksacks.SliceStep(step),
            this.rucksacks.Skip(1).SliceStep(step),
            this.rucksacks.Skip(2).SliceStep(step),
        ];

        return rucksackSets
            .Zip(rucksackList =>
            {
                char sharedCharacter = rucksackList
                    .Skip(1)
                    .Aggregate(
                        new HashSet<char>(rucksackList.First()),
                        (sharedCharacters, rucksack) =>
                        {
                            sharedCharacters.IntersectWith(rucksack);
                            return sharedCharacters;
                        }
                    )
                    .First();

                return CharacterPriority(sharedCharacter);
            })
            .Sum();
    }

    private static int UppercasePriority(char character) => character - 'A' + 27;

    private static int LowercasePriority(char character) => character - 'a' + 1;

    private static int CharacterPriority(char character) =>
        char.IsUpper(character) ? UppercasePriority(character) : LowercasePriority(character);

    private IEnumerable<string> ParseInput()
    {
        ParsedFile file = new(this.InputFilePath);

        while (!file.Empty)
        {
            yield return file.NextLine().ToSingleString(wordSeparator: string.Empty);
        }
    }
}
