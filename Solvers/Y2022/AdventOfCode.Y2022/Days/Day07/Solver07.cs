// <copyright file="Solver07.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2022.Days.Day07;

using System.Runtime.CompilerServices;
using TreeCollections;

/// <summary>
/// Solver for day 7.
/// </summary>
public class Solver07 : BaseSolver<int>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Solver07"/> class.
    /// </summary>
    public Solver07()
        : this(null) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Solver07"/> class.
    /// </summary>
    /// <param name="inputFilePath">The expected input file path.</param>
    public Solver07(string? inputFilePath)
        : base(inputFilePath) { }

    /// <inheritdoc/>
    protected override int Solve1() => throw new NotImplementedException();

    /// <inheritdoc/>
    protected override int Solve2() => throw new NotImplementedException();

    private ReadOnlyEntityTreeNode<string, Node> ParseInput()
    {
        ReadOnlyEntityTreeNode<string, Node> root = new(node => node.name, new("/"));
        ReadOnlyEntityTreeNode<string, Node> currentNode = root;

        ParsedFile file = new(this.InputFilePath);

        while (!file.Empty)
        {
            List<string> line = file.NextLine().ToList<string>();

            if (line[0] != "$")
            {
                ProcessFile();
            }
            else if (line[1] == "cd")
            {
                currentNode = ChangeDirectory();
            }
        }

        return root;
    }

    private void ProcessFile() { }

    private ReadOnlyEntityTreeNode<string, Node> ChangeDirectory() { }

    private static int SumSize(this ReadOnlyEntityTreeNode<string, Node> node)
    {
        return node.Depth;
    }

    private sealed record Node(string name, int size = 0);
}
