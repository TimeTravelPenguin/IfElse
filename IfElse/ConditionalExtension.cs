#region Title Header

// Name: Phillip Smith
// 
// Solution: IfThenElse
// Project: IfElse
// File Name: ConditionalExtension.cs
// 
// Current Data:
// 2020-05-20 6:26 PM
// 
// Creation Date:
// 2020-05-20 2:47 PM

#endregion

using System;
using System.Diagnostics.CodeAnalysis;

namespace IfElse
{
  public static class ConditionalExtension
  {
    public static IConditional If(this Action method, Func<bool> condition)
    {
      return new Conditional(condition, method);
    }

    public static IConditional ElseIf([NotNull] this IConditional conditional, Func<bool> condition,
      [NotNull] Action method)
    {
      conditional.AppendElseIf(condition, method);
      return conditional;
    }

    public static IConditional Else([NotNull] this IConditional conditional,
      [NotNull] Action method)
    {
      conditional.SetElse(method);
      return conditional;
    }
  }
}