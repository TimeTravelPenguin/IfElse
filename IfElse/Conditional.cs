#region Title Header

// Name: Phillip Smith
// 
// Solution: IfThenElse
// Project: IfElse
// File Name: Conditional.cs
// 
// Current Data:
// 2020-05-20 8:42 PM
// 
// Creation Date:
// 2020-05-20 7:29 PM

#endregion

using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using IfElse.Exceptions;

namespace IfElse
{
  /// <summary>
  ///   Conditional object contains the conditions of each if, else-if, and else statement
  /// </summary>
  public sealed class Conditional : IConditional
  {
    private ConditionalIf IfCondition { get; }
    private Action ElseCondition { get; set; }

    void IConditional.AppendElseIf(Func<bool> condition, Action method)
    {
      if (IfCondition is null)
      {
        throw new NullReferenceException();
      }

      if (method is null)
      {
        throw new ArgumentNullException(nameof(method));
      }

      IfCondition.AddElseIf(condition, method);
    }

    void IConditional.SetElse([NotNull] Action condition)
    {
      if (ElseCondition != null)
      {
        throw new ConditionAlreadyDefinedException(string.Format(CultureInfo.InvariantCulture,
          ExceptionMessage.ConditionAlreadyDefined, nameof(ElseCondition)));
      }

      ElseCondition = condition ?? throw new NoNullAllowedException();
    }

    /// <summary>
    ///   Processes the conditional statements, executing the first that returns a true condition
    /// </summary>
    public void Process()
    {
      var success = IfCondition.RunCondition();
      if (!success)
      {
        ElseCondition?.Invoke();
      }
    }


    /// <summary>
    ///   Conditional constructor for the initial if condition.
    /// </summary>
    /// <param name="condition">
    ///   A function with <see cref="bool" /> return type used to determine if a statement satisfies a
    ///   condition. This is the initial if statement.
    /// </param>
    /// <param name="method">
    ///   The action to invoke if <paramref name="condition" /> results in a <see langword="true" /> value
    /// </param>
    public Conditional([NotNull] Func<bool> condition, [NotNull] Action method)
    {
      if (condition is null)
      {
        throw new ArgumentNullException(nameof(condition));
      }

      if (method is null)
      {
        throw new ArgumentNullException(nameof(method));
      }

      IfCondition = new ConditionalIf(condition, method);
    }
  }
}