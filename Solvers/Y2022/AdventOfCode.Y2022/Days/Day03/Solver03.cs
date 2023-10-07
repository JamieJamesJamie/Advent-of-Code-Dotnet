// <copyright file="Solver03.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2022.Days.Day03;

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

            HashSet<char> compartment1 = new(rucksack[..compartmentLength]);
            HashSet<char> compartment2 = new(rucksack[compartmentLength..]);

            IEnumerable<char> intersection = compartment1.Intersect(compartment2);

            return CharacterPriority(intersection.First());
        });

    /// <inheritdoc/>
    protected override int Solve2()
    {
        int summedPriorities = 0;

        using (IEnumerator<string> rucksack1 = this.GetEveryNthRucksack(3).GetEnumerator())
        using (IEnumerator<string> rucksack2 = this.GetEveryNthRucksack(1).GetEnumerator())
        using (IEnumerator<string> rucksack3 = this.GetEveryNthRucksack(2).GetEnumerator())
        {
            while (rucksack1.MoveNext() && rucksack2.MoveNext() && rucksack3.MoveNext())
            {
                HashSet<char> contents1 = new(rucksack1.Current);
                HashSet<char> contents2 = new(rucksack2.Current);
                HashSet<char> contents3 = new(rucksack3.Current);

                char sharedCharacter = contents1.Intersect(contents2).Intersect(contents3).First();

                summedPriorities += CharacterPriority(sharedCharacter);
            }
        }

        return summedPriorities;
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

    private IEnumerable<string> GetEveryNthRucksack(int nCount) =>
        this.rucksacks.Where((element, index) => (index + nCount) % 3 == 0);
}
