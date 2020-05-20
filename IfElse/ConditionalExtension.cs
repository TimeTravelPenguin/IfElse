#region Title Header

// Name: Phillip Smith
// 
// Solution: IfThenElse
// Project: IfElse
// File Name: ConditionalExtension.cs
// 
// Current Data:
// 2020-05-20 8:54 PM
// 
// Creation Date:
// 2020-05-20 7:29 PM

#endregion

using System;
using System.Diagnostics.CodeAnalysis;

namespace IfElse
{
  /// <summary>
  ///   Extenstion used to build <see cref="IConditional" /> composition
  /// </summary>
  public static class ConditionalExtension
  {
    /// <summary>
    ///   Creates a new <see cref="Conditional" /> object, providing the initial if statement
    /// </summary>
    /// <param name="method">
    ///   The action to invoke if <paramref name="condition" /> results in <see langword="true" />
    /// </param>
    /// <param name="condition">
    ///   The conditional function which satisfies whether the condition will be met
    /// </param>
    /// <returns>
    ///   <see cref="IConditional" />
    /// </returns>
    public static IConditional If(this Action method, Func<bool> condition)
    {
      if (method is null)
      {
        throw new ArgumentNullException(nameof(method));
      }

      if (condition is null)
      {
        throw new ArgumentNullException(nameof(condition));
      }

      return new Conditional(condition, method);
    }

    /// <summary>
    ///   Appends an additional conditional statement to the end of all other conditionals
    /// </summary>
    /// <param name="conditional">
    ///   The <see cref="IConditional" /> in which to append
    /// </param>
    /// <param name="condition">
    ///   The conditional function which satisfies whether the condition will be met
    /// </param>
    /// <param name="method">
    ///   The action to invoke if <paramref name="condition" /> results in <see langword="true" />
    /// </param>
    /// <returns>
    ///   <see cref="IConditional" />
    /// </returns>
    public static IConditional ElseIf([NotNull] this IConditional conditional, [NotNull] Func<bool> condition,
      [NotNull] Action method)
    {
      if (conditional is null)
      {
        throw new ArgumentNullException(nameof(conditional));
      }

      if (condition is null)
      {
        throw new ArgumentNullException(nameof(condition));
      }

      if (method is null)
      {
        throw new ArgumentNullException(nameof(method));
      }

      conditional.AppendElseIf(condition, method);
      return conditional;
    }

    /// <summary>
    ///   Sets the else action invocation for the event that not conditionals are satisfied
    /// </summary>
    /// <param name="conditional">
    ///   The <see cref="IConditional" /> in which to append
    /// </param>
    /// <param name="method">
    ///   The action to invoke if <paramref name="conditional" /> does not result in a satisfied conditional statement
    /// </param>
    /// <returns>
    ///   <see cref="IConditional" />
    /// </returns>
    public static IConditional Else([NotNull] this IConditional conditional,
      [NotNull] Action method)
    {
      if (conditional is null)
      {
        throw new ArgumentNullException(nameof(conditional));
      }

      if (method is null)
      {
        throw new ArgumentNullException(nameof(method));
      }

      conditional.SetElse(method);
      return conditional;
    }
  }
}