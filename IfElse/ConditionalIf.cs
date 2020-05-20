#region Title Header

// Name: Phillip Smith
// 
// Solution: IfThenElse
// Project: IfElse
// File Name: ConditionalIf.cs
// 
// Current Data:
// 2020-05-20 5:56 PM
// 
// Creation Date:
// 2020-05-20 2:02 PM

#endregion

using System;

namespace IfElse
{
  public class ConditionalIf
  {
    private Func<bool> IfCondition { get; }
    private Action Method { get; }
    private ConditionalIf ElseIf { get; set; }

    public ConditionalIf(Func<bool> condition, Action method)
    {
      IfCondition = condition;
      Method = method;
    }

    public void AddElseIf(Func<bool> condition, Action method)
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