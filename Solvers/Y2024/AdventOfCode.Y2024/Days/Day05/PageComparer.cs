// <copyright file="PageComparer.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

namespace AdventOfCode.Y2024.Days.Day05;

internal sealed class PageComparer : IComparer<uint>
{
    private readonly HashSet<PageOrderingRule> pageOrderingRules;

    public PageComparer(HashSet<PageOrderingRule> pageOrderingRules) =>
        this.pageOrderingRules = pageOrderingRules;

    /// <inheritdoc/>
    public int Compare(uint x, uint y) =>
        this.pageOrderingRules.Contains(new PageOrderingRule(x, y)) ? -1 : 1;
}
