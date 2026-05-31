// <copyright file="IEnumerableExtensionsTests.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Common.Test.Extensions;

using AdventOfCode.Common.Extensions;

/// <summary>
/// Tests for <see cref="IEnumerableExtensions"/>.
/// </summary>
public class IEnumerableExtensionsTests
{
    /// <summary>
    /// Valid test data for <see cref="IEnumerableExtensions.SliceStep{T}"/>.
    /// </summary>
    private static readonly IEnumerable<(int, int[])> SliceStepData =
    [
        (2, [1, 3, 5]),
        (3, [1, 4]),
        (-2, [1, 3, 5]),
    ];

    /// <summary>
    /// Valid test data for <see cref="IEnumerableExtensions.Zip{T,TResult}"/>.
    /// </summary>
    private static readonly IEnumerable<(int[][], int[][])> ZipCustomResultSelectorIntegerData =
    [
        (
            [
                [1, 2, 3],
                [4, 5, 6],
            ],
            [
                [4, 1],
                [5, 2],
                [6, 3],
            ]
        ),
        (
            [
                [1, 2, 3],
                [4, 5],
            ],
            [
                [4, 1],
                [5, 2],
            ]
        ),
        (
            [
                [1, 2],
                [3, 4, 5],
            ],
            [
                [3, 1],
                [4, 2],
            ]
        ),
        ([], []),
        (
            [
                [],
            ],
            []
        ),
        (
            [
                [1],
            ],
            [
                [1],
            ]
        ),
    ];

    /// <summary>
    /// Valid test data for <see cref="IEnumerableExtensions.Zip{T}"/>.
    /// </summary>
    private static readonly IEnumerable<(int[][], int[][])> ZipDefaultResultSelectorIntegerData =
    [
        (
            [
                [1, 2, 3],
                [4, 5, 6],
            ],
            [
                [1, 4],
                [2, 5],
                [3, 6],
            ]
        ),
        (
            [
                [1, 2],
                [3, 4],
                [5, 6],
            ],
            [
                [1, 3, 5],
                [2, 4, 6],
            ]
        ),
        (
            [
                [1, 2, 3],
                [4, 5],
            ],
            [
                [1, 4],
                [2, 5],
            ]
        ),
        (
            [
                [1, 2],
                [3, 4, 5],
            ],
            [
                [1, 3],
                [2, 4],
            ]
        ),
        ([], []),
        (
            [
                [],
            ],
            []
        ),
        (
            [
                [1],
            ],
            [
                [1],
            ]
        ),
    ];

    private static readonly IEnumerable<int> SliceStepInput = [1, 2, 3, 4, 5];

    /// <summary>
    /// Tests whether <see cref="IEnumerableExtensions.Cycle{T}"/> returns
    /// expected outputs given valid inputs.
    /// </summary>
    /// <param name="sequence">Input.</param>
    /// <param name="count">The number of elements to take from the start of the sequence.</param>
    /// <param name="expected">Expected output.</param>
    [Test]
    [Arguments(new[] { 1, 2, 3 }, 3, new[] { 1, 2, 3 })]
    [Arguments(new[] { 1, 2, 3 }, 6, new[] { 1, 2, 3, 1, 2, 3 })]
    [Arguments(new[] { 1, 2, 3 }, 4, new[] { 1, 2, 3, 1 })]
    [Arguments(new[] { 1, 2 }, 4, new[] { 1, 2, 1, 2 })]
    [Arguments(new[] { 1, 2, 3 }, 0, new int[] { })]
    [Arguments(new[] { 1, 2, 3 }, 1, new[] { 1 })]
    [Arguments(new int[] { }, 2, new int[] { })]
    public void Cycle_ReturnsExpected(int[] sequence, int count, int[] expected) =>
        sequence.Cycle().Take(count).Should().BeEquivalentTo(expected);

    /// <summary>
    /// Tests whether <see cref="IEnumerableExtensions.Cycle{T}"/> throws
    /// expected exception given <see langword="null"/> input.
    /// </summary>
    [Test]
    public void Cycle_SequenceNull_ThrowsArgumentNullException()
    {
        Func<IEnumerable<int>> cycle = () => IEnumerableExtensions.Cycle<int>(null);

        cycle.Should().ThrowExactly<ArgumentNullException>();
    }

    /// <summary>
    /// Tests whether <see cref="IEnumerableExtensions.SliceStep{T}"/> returns
    /// expected outputs given valid inputs.
    /// </summary>
    /// <param name="step">Input.</param>
    /// <param name="expectedOutput">Expected output.</param>
    [Test]
    [MethodDataSource(nameof(SliceStepData))]
    public void SliceStep_WithStepInput_ReturnsExpected(
        int step,
        IEnumerable<int> expectedOutput
    ) =>
        SliceStepInput
            .SliceStep(step)
            .Should()
            .BeEquivalentTo(expectedOutput, options => options.WithStrictOrdering());

    /// <summary>
    /// Tests whether <see cref="IEnumerableExtensions.SliceStep{T}"/> returns
    /// the same object if the provided step is 1 or -1.
    /// </summary>
    /// <param name="step">Input.</param>
    [Test]
    [Arguments(1)]
    [Arguments(-1)]
    public void SliceStep_WithSingleStep_ReturnsSameEnumerable(int step) =>
        SliceStepInput.SliceStep(step).Should().BeSameAs(SliceStepInput);

    /// <summary>
    /// Tests whether <see cref="IEnumerableExtensions.SliceStep{T}"/> returns
    /// the same object if no inputs are provided.
    /// </summary>
    [Test]
    public void SliceStep_NoStepInput_ReturnsExpected() =>
        SliceStepInput.SliceStep().Should().BeSameAs(SliceStepInput);

    /// <summary>
    /// Tests whether <see cref="IEnumerableExtensions.Zip{T,TResult}"/> returns
    /// expected outputs given valid inputs, that the custom result selector
    /// is the identity function, <c>T</c> is of type <see langword="int"/>,
    /// and <c>TResult</c> is an <see cref="IEnumerable{T}"/> containing
    /// elements of type <see langword="int"/>.
    /// </summary>
    [Test]
    public void Zip_CustomResultSelector_IdentityFunctionSelector_ReturnsExpected() =>
        new List<List<int>>()
        {
            new() { 1, 2, 3 },
            new() { 4, 5, 6 },
        }
            .Zip(x => x)
            .Should()
            .BeEquivalentTo(
                new List<List<int>>()
                {
                    new() { 1, 4 },
                    new() { 2, 5 },
                    new() { 3, 6 },
                },
                options => options.WithStrictOrdering()
            );

    /// <summary>
    /// Tests whether <see cref="IEnumerableExtensions.Zip{T,TResult}"/> returns
    /// expected outputs given valid inputs, that the custom result selector
    /// is the reverse function, <c>T</c> is of type <see langword="int"/>,
    /// and <c>TResult</c> is an <see cref="IEnumerable{T}"/> containing
    /// elements of type <see langword="int"/>.
    /// </summary>
    /// <param name="input">Sequence to zip.</param>
    /// <param name="expectedOutput">Expected output.</param>
    [Test]
    [MethodDataSource(nameof(ZipCustomResultSelectorIntegerData))]
    public void Zip_CustomResultSelector_ReverseFunctionSelector_IntegerElements_ReturnsExpected(
        IEnumerable<IEnumerable<int>> input,
        IEnumerable<IEnumerable<int>> expectedOutput
    ) =>
        input
            .Zip(x => x.Reverse())
            .Should()
            .BeEquivalentTo(expectedOutput, options => options.WithStrictOrdering());

    /// <summary>
    /// Tests whether <see cref="IEnumerableExtensions.Zip{T,TResult}"/> returns
    /// expected outputs given valid inputs, that the custom result selector
    /// is the reverse function, <c>T</c> is of type <see langword="string"/>,
    /// and <c>TResult</c> is an <see cref="IEnumerable{T}"/> containing
    /// elements of type <see langword="string"/>.
    /// </summary>
    [Test]
    public void Zip_CustomResultSelector_ReverseFunctionSelector_StringElements_ReturnsExpected() =>
        new List<List<string>>()
        {
            new() { "aaa", "bbb", "ccc" },
            new() { "ddd", "eee" },
        }
            .Zip(x => x.Reverse())
            .Should()
            .BeEquivalentTo(
                new List<List<string>>()
                {
                    new() { "ddd", "aaa" },
                    new() { "eee", "bbb" },
                },
                options => options.WithStrictOrdering()
            );

    /// <summary>
    /// Tests whether <see cref="IEnumerableExtensions.Zip{T,TResult}"/> throws
    /// an <see cref="ArgumentNullException"/> when given a <see langword="null"/> result selector.
    /// </summary>
    [Test]
    public void Zip_CustomResultSelector_NullSelector_ThrowsArgumentNullException() =>
        new List<List<int>>()
            .Invoking(x => x.Zip<int, int?>(null).ToArray())
            .Should()
            .ThrowExactly<ArgumentNullException>();

    /// <summary>
    /// Tests whether <see cref="IEnumerableExtensions.Zip{T}"/> returns
    /// expected outputs given valid inputs, that the custom result selector
    /// is the reverse function and <c>T</c> is of type <see langword="int"/>.
    /// </summary>
    /// <param name="input">Sequence to zip.</param>
    /// <param name="expectedOutput">Expected output.</param>
    [Test]
    [MethodDataSource(nameof(ZipDefaultResultSelectorIntegerData))]
    public void Zip_DefaultResultSelector_IntegerElements_ReturnsExpected(
        IEnumerable<IEnumerable<int>> input,
        IEnumerable<IEnumerable<int>> expectedOutput
    ) =>
        input
            .Zip()
            .Should()
            .BeEquivalentTo(expectedOutput, options => options.WithStrictOrdering());

    /// <summary>
    /// Tests whether <see cref="IEnumerableExtensions.Zip{T}"/> returns
    /// expected outputs given valid inputs, that the custom result selector
    /// is the reverse function and <c>T</c> is of type <see langword="string"/>.
    /// </summary>
    [Test]
    public void Zip_DefaultResultSelector_StringElements_ReturnsExpected() =>
        new List<List<string>>()
        {
            new() { "aaa", "bbb", "ccc" },
            new() { "ddd", "eee" },
        }
            .Zip()
            .Should()
            .BeEquivalentTo(
                new List<List<string>>()
                {
                    new() { "aaa", "ddd" },
                    new() { "bbb", "eee" },
                },
                options => options.WithStrictOrdering()
            );
}
