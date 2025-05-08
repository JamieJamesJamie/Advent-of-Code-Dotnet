// <copyright file="Solver05.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2022.Days.Day05;

using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.RegularExpressions;
using AdventOfCode.Common.Extensions;

/// <summary>
/// Solver for day 5.
/// </summary>
public partial class Solver05 : BaseSolver<string>
{
    private sealed record Instruction(int numToMove, string fromCrate, string toCrate);

    private SolverState initialSolverState;

    private string initialSolverStateJson;

    private SolverState solverState;

    private sealed partial class SolverState
    {
        public List<Instruction> instructions { get; set; }

        [GeneratedRegex(
            "move (?<move>\\d+) from (?<from>\\d+) to (?<to>\\d+)",
            RegexOptions.ExplicitCapture
        )]
        private static partial Regex instructionRegex();

        public SolverState(
            IEnumerable<string> crates,
            IEnumerable<string> stackLabels,
            IEnumerable<string> instructions
        )
        {
            this.instructions = instructions
                .Select(instruction =>
                {
                    Match match = instructionRegex().Matches(instruction)[0];

                    return new Instruction(
                        numToMove: int.Parse(
                            match.Groups["move"].Value,
                            CultureInfo.InvariantCulture
                        ),
                        fromCrate: match.Groups["from"].Value,
                        toCrate: match.Groups["to"].Value
                    );
                })
                .ToList();

            this.ParseCrates(crates, stackLabels.ToList());
        }

        public SortedDictionary<string, Stack<string>> stacks { get; set; } = new();

        private void ParseCrates(IEnumerable<string> crates, List<string> stackLabels)
        {
            foreach (string stackLabel in stackLabels)
            {
                this.stacks[stackLabel] = new();
            }

            foreach (string line in crates)
            {
                List<char> characters = line.Skip(1).SliceStep(4).ToList();

                for (int i = 0; i < characters.Count; i++)
                {
                    char character = characters[i];

                    if (char.IsUpper(character))
                    {
                        this.stacks[stackLabels[i]].Push(character.ToString());
                    }
                }
            }
        }

        public string TopCrates() =>
            string.Join(string.Empty, this.stacks.Values.Select(stack => stack.Peek()));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver05"/> class.
    /// </summary>
    public Solver05()
        : this(null) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver05"/> class.
    /// </summary>
    /// <param name="inputFilePath">The expected input file path.</param>
    public Solver05(string? inputFilePath)
        : base(inputFilePath)
    {
        this.ParseInput();
    }

    /// <inheritdoc/>
    protected override string Solve1()
    {
        this.ParseInstructionsPart1();

        return this.solverState.TopCrates();
    }

    /// <inheritdoc/>
    protected override string Solve2()
    {
        this.ParseInstructionsPart2();

        return this.solverState.TopCrates();
    }

    private void ParseInput()
    {
        List<List<string>> input = ParsedFile.ReadAllGroupsOfLines(this.InputFilePath);

        List<string> crates = input[0];
        crates.Reverse();

        this.initialSolverState = new(
            crates: crates.Skip(1),
            stackLabels: crates[0].Split(' ', StringSplitOptions.RemoveEmptyEntries),
            instructions: input[1]
        );
        this.initialSolverStateJson = JsonSerializer.Serialize(this.initialSolverState);
    }

    private void ParseInstructionsPart1()
    {
        SolverState? x = JsonSerializer.Deserialize<SolverState>(
            this.initialSolverStateJson,
            new JsonSerializerOptions() { }
        );

        ArgumentNullException.ThrowIfNull(x);

        solverState = x;

        foreach (Instruction instruction in this.solverState.instructions)
        {
            for (int i = 0; i < instruction.numToMove; i++)
            {
                this.solverState.stacks[instruction.toCrate].Push(
                    this.solverState.stacks[instruction.fromCrate].Pop()
                );
            }
        }
    }

    private void ParseInstructionsPart2()
    {
        SolverState? x = JsonSerializer.Deserialize<SolverState>(this.initialSolverStateJson);

        ArgumentNullException.ThrowIfNull(x);

        solverState = x;

        foreach (Instruction instruction in this.solverState.instructions)
        {
            List<string> crates = new();

            for (int i = 0; i < instruction.numToMove; i++)
            {
                crates.Add(this.solverState.stacks[instruction.fromCrate].Pop());
            }

            crates.Reverse();

            foreach (string crate in crates)
            {
                this.solverState.stacks[instruction.toCrate].Push(crate);
            }
        }
    }
}
