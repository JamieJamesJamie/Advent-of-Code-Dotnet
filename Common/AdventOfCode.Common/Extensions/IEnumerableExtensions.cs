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
        Func<List<T>, TResult>? resultSelector
    )
    {
        ImmutableList<IEnumerable<T>> sequencesList = sequences.ToImmutableList();

        ArgumentNullException.ThrowIfNull(resultSelector);
        if (!sequencesList.Any())
        {
            yield break;
        }

        ImmutableList<IEnumerator<T>> enumerators = sequencesList
            .Select(sequence => sequence.GetEnumerator())
            .ToImmutableList();

        try
        {
            while (enumerators.All(enumerator => enumerator.MoveNext()))
            {
                yield return resultSelector(
                    enumerators.Select(enumerator => enumerator.Current).ToList()
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

    /// <summary>
    /// Produces a sequence of results from the specified <paramref name="sequences"/>.
    /// </summary>
    /// <param name="sequences">The sequences to zip.</param>
    /// <typeparam name="T">The type of element contained in the underlying sequences.</typeparam>
    /// <returns>The zipped contents of <paramref name="sequences"/>.</returns>
    public static IEnumerable<List<T>> Zip<T>(this IEnumerable<IEnumerable<T>> sequences) =>
        Zip(sequences, zippedSequence => zippedSequence);
}
