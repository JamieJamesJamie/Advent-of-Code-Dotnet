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
    public static readonly TheoryData<int, List<int>> SliceStepData =
        new()
        {
            {
                2,
                new() { 1, 3, 5 }
            },
            {
                3,
                new() { 1, 4 }
            },
            {
                -2,
                new() { 1, 3, 5 }
            },
        };

    /// <summary>
    /// Valid <see cref="TheoryData{T}"/> for <see cref="IEnumerableExtensions.Zip{T,TResult}"/>.
    /// </summary>
    public static readonly TheoryData<
        List<List<object>>,
        List<List<object>>,
        Func<List<object>, object>
    > ZipCustomResultSelectorData =
        new()
        {
            {
                new()
                {
                    new() { 1, 2, 3 },
                    new() { 4, 5, 6 },
                },
                new()
                {
                    new() { 1, 4 },
                    new() { 2, 5 },
                    new() { 3, 6 },
                },
                x => x
            },
            {
                new()
                {
                    new() { 1, 2, 3 },
                    new() { 4, 5, 6 },
                },
                new()
                {
                    new() { 4, 1 },
                    new() { 5, 2 },
                    new() { 6, 3 },
                },
                ReverseFunction
            },
            {
                new()
                {
                    new() { 1, 2, 3 },
                    new() { 4, 5 },
                },
                new()
                {
                    new() { 4, 1 },
                    new() { 5, 2 },
                },
                ReverseFunction
            },
            {
                new()
                {
                    new() { 1, 2 },
                    new() { 3, 4, 5 },
                },
                new()
                {
                    new() { 3, 1 },
                    new() { 4, 2 },
                },
                ReverseFunction
            },
            { new(), new(), ReverseFunction },
            {
                new() { new() },
                new(),
                ReverseFunction
            },
            {
                new() { new() { 1 } },
                new() { new() { 1 } },
                ReverseFunction
            },
            {
                new()
                {
                    new() { "aaa", "bbb", "ccc" },
                    new() { "ddd", "eee" },
                },
                new()
                {
                    new() { "ddd", "aaa" },
                    new() { "eee", "bbb" },
                },
                ReverseFunction
            },
        };

    /// <summary>
    /// Valid <see cref="TheoryData{T}"/> for <see cref="IEnumerableExtensions.Zip{T}"/>.
    /// </summary>
    public static readonly TheoryData<
        List<List<object>>,
        List<List<object>>
    > ZipDefaultResultSelectorData =
        new()
        {
            {
                new()
                {
                    new() { 1, 2, 3 },
                    new() { 4, 5, 6 },
                },
                new()
                {
                    new() { 1, 4 },
                    new() { 2, 5 },
                    new() { 3, 6 },
                }
            },
            {
                new()
                {
                    new() { 1, 2, 3 },
                    new() { 4, 5 },
                },
                new()
                {
                    new() { 1, 4 },
                    new() { 2, 5 },
                }
            },
            {
                new()
                {
                    new() { 1, 2 },
                    new() { 3, 4, 5 },
                },
                new()
                {
                    new() { 1, 3 },
                    new() { 2, 4 },
                }
            },
            { new(), new() },
            {
                new() { new() },
                new()
            },
            {
                new() { new() { 1 } },
                new() { new() { 1 } }
            },
            {
                new()
                {
                    new() { "aaa", "bbb", "ccc" },
                    new() { "ddd", "eee" },
                },
                new()
                {
                    new() { "aaa", "ddd" },
                    new() { "bbb", "eee" },
                }
            },
        };

    private static readonly IEnumerable<int> SliceStepInput = new List<int> { 1, 2, 3, 4, 5 };

    private static Func<List<object>, object> ReverseFunction =>
        x =>
        {
            x.Reverse();
            return x;
        };

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
        Func<List<object>, object> resultSelector
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
