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
    /// Valid <see cref="TheoryData{T}"/> for <see cref="IEnumerableExtensions.SliceStep{T}"/>.
    /// </summary>
    public static readonly TheoryData<int, int[]> SliceStepData = new()
    {
        { 2, [1, 3, 5] },
        { 3, [1, 4] },
        { -2, [1, 3, 5] },
    };

    /// <summary>
    /// Valid <see cref="TheoryData{T}"/> for <see cref="IEnumerableExtensions.Zip{T,TResult}"/>.
    /// </summary>
    public static readonly TheoryData<
        object[][],
        object[][],
        Func<IEnumerable<object>, object>
    > ZipCustomResultSelectorData = new()
    {
        {
            [
                [1, 2, 3],
                [4, 5, 6],
            ],
            [
                [1, 4],
                [2, 5],
                [3, 6],
            ],
            x => x
        },
        {
            [
                [1, 2, 3],
                [4, 5, 6],
            ],
            [
                [4, 1],
                [5, 2],
                [6, 3],
            ],
            x => x.Reverse()
        },
        {
            [
                [1, 2, 3],
                [4, 5],
            ],
            [
                [4, 1],
                [5, 2],
            ],
            x => x.Reverse()
        },
        {
            [
                [1, 2],
                [3, 4, 5],
            ],
            [
                [3, 1],
                [4, 2],
            ],
            x => x.Reverse()
        },
        { [], [], x => x.Reverse() },
        {
            [
                [],
            ],
            [],
            x => x.Reverse()
        },
        {
            [
                [1],
            ],
            [
                [1],
            ],
            x => x.Reverse()
        },
        {
            [
                ["aaa", "bbb", "ccc"],
                ["ddd", "eee"],
            ],
            [
                ["ddd", "aaa"],
                ["eee", "bbb"],
            ],
            x => x.Reverse()
        },
    };

    /// <summary>
    /// Valid <see cref="TheoryData{T}"/> for <see cref="IEnumerableExtensions.Zip{T}"/>.
    /// </summary>
    public static readonly TheoryData<object[][], object[][]> ZipDefaultResultSelectorData = new()
    {
        {
            [
                [1, 2, 3],
                [4, 5, 6],
            ],
            [
                [1, 4],
                [2, 5],
                [3, 6],
            ]
        },
        {
            [
                [1, 2],
                [3, 4],
                [5, 6],
            ],
            [
                [1, 3, 5],
                [2, 4, 6],
            ]
        },
        {
            [
                [1, 2, 3],
                [4, 5],
            ],
            [
                [1, 4],
                [2, 5],
            ]
        },
        {
            [
                [1, 2],
                [3, 4, 5],
            ],
            [
                [1, 3],
                [2, 4],
            ]
        },
        { [], [] },
        {
            [
                [],
            ],
            []
        },
        {
            [
                [1],
            ],
            [
                [1],
            ]
        },
        {
            [
                ["aaa", "bbb", "ccc"],
                ["ddd", "eee"],
            ],
            [
                ["aaa", "ddd"],
                ["bbb", "eee"],
            ]
        },
    };

    private static readonly IEnumerable<int> SliceStepInput = [1, 2, 3, 4, 5];

    /// <summary>
    /// Tests whether <see cref="IEnumerableExtensions.SliceStep{T}"/> returns
    /// expected outputs given valid inputs.
    /// </summary>
    /// <param name="step">Input.</param>
    /// <param name="expectedOutput">Expected output.</param>
    [Theory]
    [MemberData(nameof(SliceStepData))]
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
    [Theory]
    [InlineData(1)]
    [InlineData(-1)]
    public void SliceStep_WithSingleStep_ReturnsSameEnumerable(int step) =>
        SliceStepInput.SliceStep(step).Should().BeSameAs(SliceStepInput);

    /// <summary>
    /// Tests whether <see cref="IEnumerableExtensions.SliceStep{T}"/> returns
    /// the same object if no inputs are provided.
    /// </summary>
    [Fact]
    public void SliceStep_NoStepInput_ReturnsExpected() =>
        SliceStepInput.SliceStep().Should().BeSameAs(SliceStepInput);

    /// <summary>
    /// Tests whether <see cref="IEnumerableExtensions.Zip{T,TResult}"/> returns
    /// expected outputs given valid inputs.
    /// </summary>
    /// <param name="input">Sequence to zip.</param>
    /// <param name="expectedOutput">Expected output.</param>
    /// <param name="resultSelector">Function to perform on zipped elements.</param>
    [Theory]
    [MemberData(nameof(ZipCustomResultSelectorData))]
    public void Zip_CustomResultSelector_ReturnsExpected(
        IEnumerable<IEnumerable<object>> input,
        IEnumerable<IEnumerable<object>> expectedOutput,
        Func<IEnumerable<object>, object> resultSelector
    ) =>
        input
            .Zip(resultSelector)
            .Should()
            .BeEquivalentTo(expectedOutput, options => options.WithStrictOrdering());

    /// <summary>
    /// Tests whether <see cref="IEnumerableExtensions.Zip{T,TResult}"/> throws
    /// an <see cref="ArgumentNullException"/> when given a <see langword="null"/> result selector.
    /// </summary>
    [Fact]
    public void Zip_CustomResultSelector_NullSelector_ThrowsArgumentNullException() =>
        new List<List<int>>()
            .Invoking(x => x.Zip<int, int?>(null).ToArray())
            .Should()
            .ThrowExactly<ArgumentNullException>();

    /// <summary>
    /// Tests whether <see cref="IEnumerableExtensions.Zip{T}"/> returns
    /// expected outputs given valid inputs.
    /// </summary>
    /// <param name="input">Sequence to zip.</param>
    /// <param name="expectedOutput">Expected output.</param>
    [Theory]
    [MemberData(nameof(ZipDefaultResultSelectorData))]
    public void Zip_DefaultResultSelector_ReturnsExpected(
        IEnumerable<IEnumerable<object>> input,
        IEnumerable<IEnumerable<object>> expectedOutput
    ) =>
        input
            .Zip()
            .Should()
            .BeEquivalentTo(expectedOutput, options => options.WithStrictOrdering());
}
