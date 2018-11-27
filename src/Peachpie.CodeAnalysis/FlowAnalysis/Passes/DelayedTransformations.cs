﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Pchp.CodeAnalysis;
using Pchp.CodeAnalysis.FlowAnalysis;
using Pchp.CodeAnalysis.Symbols;

namespace Pchp.CodeAnalysis.FlowAnalysis.Passes
{
    /// <summary>
    /// Stores certain types of transformations in parallel fashion and performs them serially afterwards.
    /// </summary>
    internal class DelayedTransformations
    {
        /// <summary>
        /// Routines with unreachable declarations.
        /// </summary>
        public ConcurrentBag<SourceRoutineSymbol> UnreachableRoutines { get; } = new ConcurrentBag<SourceRoutineSymbol>();

        public void Apply()
        {
            foreach (var routine in UnreachableRoutines)
            {
                routine.Flags |= RoutineFlags.IsUnreachable;
            }
        }
    }
}
