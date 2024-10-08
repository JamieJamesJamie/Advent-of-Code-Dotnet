// <copyright file="IEnumerableExtensions.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Common.Extensions;

using System.Collections.Immutable;

/// <summary>
/// Extension methods for <see cref="IEnumerable{T}"/>.
/// </summary>
public static class IEnumerableExtensions
{
    /// <summary>
    /// Enumerates through <paramref name="sequence"/> and produces a sequence of every
    /// "<paramref name="step"/>"th element.
    /// </summary>
    /// <param name="sequence">The sequence to enumerate through.</param>
    /// <param name="step">
    /// The number of elements to skip for every step through the <paramref name="sequence"/>.
    /// </param>
    /// <typeparam name="T">The type of the elements in <paramref name="sequence"/>.</typeparam>
    /// <returns>
    /// A sequence of every "<paramref name="step"/>"th element of <paramref name="sequence"/>.
    /// </returns>
    public static IEnumerable<T> SliceStep<T>(this IEnumerable<T> sequence, int step = 1) =>
        step is 1 or -1 ? sequence : sequence.Where((_, index) => index % step == 0);

    /// <summary>
    /// Produces a sequence of results from the specified <paramref name="sequences"/>.
    /// </summary>
    /// <param name="sequences">The sequences to zip.</param>
    /// <typeparam name="T">The type of element contained in the underlying sequences.</typeparam>
    /// <returns>The zipped contents of <paramref name="sequences"/>.</returns>
    public static IEnumerable<IEnumerable<T>> Zip<T>(this IEnumerable<IEnumerable<T>> sequences) =>
        Zip(sequences, zippedSequence => zippedSequence);

    /// <summary>
    /// Produces a sequence of results from the specified <paramref name="sequences"/>.
    /// The result is calculated based on <paramref name="resultSelector"/>.
    /// </summary>
    /// <param name="sequences">The sequences to zip.</param>
    /// <param name="resultSelector">The function to perform on each zipped set of elements.</param>
    /// <typeparam name="T">The type of element contained in the underlying sequences.</typeparam>
    /// <typeparam name="TResult">The type that each zipped element should resolve to.</typeparam>
    /// <returns>
    /// The zipped contents of <paramref name="sequences"/> with
    /// <paramref name="resultSelector"/> applied to each element.
    /// </returns>
    public static IEnumerable<TResult> Zip<T, TResult>(
        this IEnumerable<IEnumerable<T>> sequences,
        Func<IEnumerable<T>, TResult>? resultSelector
    )
    {
        ArgumentNullException.ThrowIfNull(resultSelector);
        return ZipIterator(sequences, resultSelector);
    }

    private static IEnumerable<TResult> ZipIterator<T, TResult>(
        IEnumerable<IEnumerable<T>> sequences,
        Func<IEnumerable<T>, TResult> resultSelector
    )
    {
        ImmutableList<IEnumerable<T>> sequencesList = sequences.ToImmutableList();

        if (sequencesList.IsEmpty)
        {
            yield break;
        }

        ImmutableList<IEnumerator<T>> enumerators = sequencesList
            .Select(sequence => sequence.GetEnumerator())
            .ToImmutableList();

        try
        {
            while (enumerators.TrueForAll(enumerator => enumerator.MoveNext()))
            {
                yield return resultSelector(
                    enumerators.Select(enumerator => enumerator.Current).ToImmutableList()
                );
            }
        }
        finally
        {
            foreach (IEnumerator<T> enumerator in enumerators)
            {
                enumerator.Dispose();
            }
        }
    }
}
