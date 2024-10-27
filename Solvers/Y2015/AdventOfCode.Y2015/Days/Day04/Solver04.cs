// <copyright file="Solver04.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2015.Days.Day04;

using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Solver for day 4.
/// </summary>
public class Solver04 : BaseSolver<int>
{
    private readonly string keyPrefix;

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver04"/> class.
    /// </summary>
    public Solver04()
        : this(null) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver04"/> class.
    /// </summary>
    /// <param name="inputFilePath">The expected input file path.</param>
    public Solver04(string? inputFilePath)
        : base(inputFilePath) =>
        this.keyPrefix = new ParsedFile(this.InputFilePath).ToSingleString();

    /// <inheritdoc/>
    protected override int Solve1() => this.FindMd5Hash(5);

    /// <inheritdoc/>
    protected override int Solve2() => this.FindMd5Hash(6);

    /// <summary>
    /// Finds the smallest key suffix that produces an MDF hash with the specified number of leading zeros.
    /// </summary>
    /// <param name="numLeadingZeros">The number of leading zeros that the MD5 hash should have.</param>
    /// <returns>The smallest key suffix that produces an MD5 hash with the specified number of leading zeros.</returns>
    private int FindMd5Hash(int numLeadingZeros)
    {
        string startsWithValue = new('0', numLeadingZeros);
        int keySuffix = 1;

        while (true)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes($"{this.keyPrefix}{keySuffix}");

#pragma warning disable CA5351 // Do Not Use Broken Cryptographic Algorithms
            byte[] hashBytes = MD5.HashData(inputBytes);
#pragma warning restore CA5351 // Do Not Use Broken Cryptographic Algorithms

            string hashString = Convert.ToHexString(hashBytes);

            if (hashString.StartsWith(startsWithValue, StringComparison.InvariantCulture))
            {
                return keySuffix;
            }

            keySuffix++;
        }
    }
}
