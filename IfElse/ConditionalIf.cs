#region Title Header

// Name: Phillip Smith
// 
// Solution: IfThenElse
// Project: IfElse
// File Name: ConditionalIf.cs
// 
// Current Data:
// 2020-05-20 8:58 PM
// 
// Creation Date:
// 2020-05-20 7:29 PM

#endregion

using System;

namespace IfElse
{
  /// <summary>
  ///   A conditional statement used by <see cref="Conditional" />
  /// </summary>
  public class ConditionalIf
  {
    private Func<bool> IfCondition { get; }
    private Action Method { get; }
    private ConditionalIf ElseIf { get; set; }

    /// <summary>
    ///   Constructor for <see cref="ConditionalIf" /> to set conditional function and activation method
    /// </summary>
    /// <param name="condition">
    ///   The conditional function which satisfies whether the condition will be met
    /// </param>
    /// <param name="method">
    ///   The action to invoke if <paramref name="condition" /> results in <see langword="true" />
    /// </param>
    public ConditionalIf(Func<bool> condition, Action method)
    {
      IfCondition = condition;
      Method = method;
    }

    internal void AddElseIf(Func<bool> condition, Action method)
    {
      if (method is null)
      {
        throw new ArgumentNullException(nameof(method));
      }

      if (ElseIf is null)
      {
        ElseIf = new ConditionalIf(condition, method);
      }
      else
      {
        ElseIf.AddElseIf(condition, method);
      }
    }

    /// <summary>
    ///   Recursive function used to iterate and determine if a condition is to be met
    /// </summary>
    /// <returns>
    ///   A <see cref="bool" /> indicating if a conditional was satisfied and method invoked
    /// </returns>
    public bool RunCondition()
    {
      if (IfCondition.Invoke())
      {
        Method.Invoke();
        return true;
      }

      return ElseIf != null && ElseIf.RunCondition();
    }
  }
}