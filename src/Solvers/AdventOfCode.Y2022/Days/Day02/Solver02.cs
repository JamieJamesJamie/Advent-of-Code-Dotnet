﻿// <copyright file="Solver02.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2022.Days.Day02;

/// <summary>
/// Solver for day 2.
/// </summary>
internal sealed class Solver02 : BaseSolver<int>
{
    private static readonly Dictionary<char, Move> OpponentTranslations = new()
    {
        { 'A', Move.Rock },
        { 'B', Move.Paper },
        { 'C', Move.Scissors },
    };

    private static readonly Dictionary<char, Move> MyTranslationsPart1 = new()
    {
        { 'X', Move.Rock },
        { 'Y', Move.Paper },
        { 'Z', Move.Scissors },
    };

    private static readonly Dictionary<char, Outcome> MyTranslationsPart2 = new()
    {
        { 'X', Outcome.Lose },
        { 'Y', Outcome.Draw },
        { 'Z', Outcome.Win },
    };

    private readonly IEnumerable<RoundInformation> roundInformation;

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver02"/> class.
    /// </summary>
    public Solver02()
        : this(null) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver02"/> class.
    /// </summary>
    /// <param name="inputFilePath">The expected input file path.</param>
    public Solver02(string? inputFilePath)
        : base(inputFilePath) => this.roundInformation = this.ParseInput();

    private enum Move
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3,
    }

    private enum Outcome
    {
        Win = 6,
        Lose = 0,
        Draw = 3,
    }

    /// <inheritdoc />
    protected override int Solve1() =>
        this.roundInformation.Sum(round =>
        {
            Move opponentMove = OpponentTranslations[round.OpponentKey];
            Move myMove = MyTranslationsPart1[round.MyKey];

            int gameOutcome = (int)GetOutcome(opponentMove, myMove);
            int moveOutcome = (int)myMove;

            return gameOutcome + moveOutcome;
        });

    /// <inheritdoc />
    protected override int Solve2() =>
        this.roundInformation.Sum(round =>
        {
            Move opponentMove = OpponentTranslations[round.OpponentKey];
            Outcome myOutcome = MyTranslationsPart2[round.MyKey];

            Move myMove = GetMove(opponentMove, myOutcome);

            return (int)myOutcome + (int)myMove;
        });

    private static Outcome GetOutcome(Move opponentMove, Move myMove) =>
        (int)myMove % Enum.GetNames<Move>().Length == (int)opponentMove - 1 ? Outcome.Lose
        : myMove == opponentMove ? Outcome.Draw
        : Outcome.Win;

    private static Move GetMove(Move opponentMove, Outcome myOutcome) =>
        GetOutcome(opponentMove, Move.Rock) == myOutcome ? Move.Rock
        : GetOutcome(opponentMove, Move.Paper) == myOutcome ? Move.Paper
        : Move.Scissors;

    private IEnumerable<RoundInformation> ParseInput()
    {
        ParsedFile file = new(this.InputFilePath);

        while (!file.Empty)
        {
            string line = file.NextLine().ToSingleString(wordSeparator: string.Empty);

            yield return new RoundInformation(line[0], line[1]);
        }
    }

    private sealed record RoundInformation(char OpponentKey, char MyKey);
}
