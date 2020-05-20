#region Title Header

// Name: Phillip Smith
// 
// Solution: IfThenElse
// Project: IfElse
// File Name: Conditional.cs
// 
// Current Data:
// 2020-05-20 6:25 PM
// 
// Creation Date:
// 2020-05-20 1:34 PM

#endregion

using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using IfElse.Exceptions;

namespace IfElse
{
  public class Conditional : IConditional
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
        throw new ConditionAlreadyDefinedException($"{nameof(ElseCondition)} is already defined");
      }

      ElseCondition = condition ?? throw new NoNullAllowedException();
    }

    public void Process()
    {
      var success = IfCondition.RunCondition();
      if (!success)
      {
        ElseCondition?.Invoke();
      }
    }

    public Conditional(Func<bool> condition, Action method)
    {
      if (method is null)
      {
        throw new NoNullAllowedException();
      }

      IfCondition = new ConditionalIf(condition, method);
    }
  }
}