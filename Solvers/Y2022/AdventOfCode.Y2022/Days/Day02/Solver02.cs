// <copyright file="Solver02.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2022.Days.Day02;

/// <summary>
/// Solver for day 2.
/// </summary>
public class Solver02 : BaseSolver<int>
{
    private static readonly Dictionary<char, Move> OpponentTranslations =
        new()
        {
            { 'A', Move.Rock },
            { 'B', Move.Paper },
            { 'C', Move.Scissors },
        };

    private static readonly Dictionary<char, Move> MyTranslationsPart1 =
        new()
        {
            { 'X', Move.Rock },
            { 'Y', Move.Paper },
            { 'Z', Move.Scissors },
        };

    private static readonly Dictionary<char, Outcome> MyTranslationsPart2 =
        new()
        {
            { 'X', Outcome.Lose },
            { 'Y', Outcome.Draw },
            { 'Z', Outcome.Win },
        };

    private readonly IEnumerable<(char, char)> roundInformation;

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
            Move opponentMove = OpponentTranslations[round.Item1];
            Move myMove = MyTranslationsPart1[round.Item2];

            int gameOutcome = (int)GetOutcome(opponentMove, myMove);
            int moveOutcome = (int)myMove;

            return gameOutcome + moveOutcome;
        });

    /// <inheritdoc />
    protected override int Solve2() =>
        this.roundInformation.Sum(round =>
        {
            Move opponentMove = OpponentTranslations[round.Item1];
            Outcome myOutcome = MyTranslationsPart2[round.Item2];

            Move myMove = GetMove(opponentMove, myOutcome);

            return (int)myOutcome + (int)myMove;
        });

    private static Outcome GetOutcome(Move opponentMove, Move myMove)
    {
        if ((int)myMove % Enum.GetNames(typeof(Move)).Length == (int)opponentMove - 1)
        {
            return Outcome.Lose;
        }

        if (myMove == opponentMove)
        {
            return Outcome.Draw;
        }

        return Outcome.Win;
    }

    private static Move GetMove(Move opponentMove, Outcome myOutcome)
    {
        if (GetOutcome(opponentMove, Move.Rock) == myOutcome)
        {
            return Move.Rock;
        }

        if (GetOutcome(opponentMove, Move.Paper) == myOutcome)
        {
            return Move.Paper;
        }

        return Move.Scissors;
    }

    private IEnumerable<(char, char)> ParseInput()
    {
        ParsedFile file = new(this.InputFilePath);

        while (!file.Empty)
        {
            string line = file.NextLine().ToSingleString(wordSeparator: string.Empty);

            yield return (line[0], line[1]);
        }
    }
}
