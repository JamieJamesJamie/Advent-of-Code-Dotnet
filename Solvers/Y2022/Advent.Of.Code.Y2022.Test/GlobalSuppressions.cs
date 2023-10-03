// <copyright file="GlobalSuppressions.cs" company="JamieJamesJamie">
// Copyright (c) JamieJamesJamie. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "Reliability",
    "CA2007:Consider calling ConfigureAwait on the awaited task",
    Justification = "Conflicts with xUnit1030",
    Scope = "member",
    Target = "~M:Advent.Of.Code.Y2022.Test.Days.Day04.Solver04Tests.Solve_1_ReturnsExpected~System.Threading.Tasks.Task"
)]
