#region Title Header

// Name: Phillip Smith
// 
// Solution: IfThenElse
// Project: IfElse
// File Name: IConditional.cs
// 
// Current Data:
// 2020-05-20 6:42 PM
// 
// Creation Date:
// 2020-05-20 1:30 PM

#endregion

using System;
using System.Diagnostics.CodeAnalysis;

namespace IfElse
{
  public interface IConditional
  {
    internal void AppendElseIf(Func<bool> condition, Action method);
    internal void SetElse([NotNull] Action condition);
    void Process();
  }
}