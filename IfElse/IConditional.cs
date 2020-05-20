#region Title Header

// Name: Phillip Smith
// 
// Solution: IfThenElse
// Project: IfElse
// File Name: IConditional.cs
// 
// Current Data:
// 2020-05-20 9:00 PM
// 
// Creation Date:
// 2020-05-20 7:29 PM

#endregion

using System;
using System.Diagnostics.CodeAnalysis;

namespace IfElse
{
  /// <summary>
  ///   Interface for conditional objects.
  /// </summary>
  /// <seealso cref="Conditional" />
  public interface IConditional
  {
    internal void AppendElseIf(Func<bool> condition, Action method);
    internal void SetElse([NotNull] Action condition);

    /// <summary>
    ///   Processes the current <see cref="IConditional" /> for a satisfied condition
    /// </summary>
    void Process();
  }
}