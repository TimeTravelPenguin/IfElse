#region Title Header

// Name: Phillip Smith
// 
// Solution: IfThenElse
// Project: IfElse
// File Name: ConditionAlreadyDefinedException.cs
// 
// Current Data:
// 2020-05-20 3:09 PM
// 
// Creation Date:
// 2020-05-20 2:47 PM

#endregion

using System;

namespace IfElse.Exceptions
{
  internal class ConditionAlreadyDefinedException : Exception
  {
    public ConditionAlreadyDefinedException(string message) : base(message)
    {
    }

    public ConditionAlreadyDefinedException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }
}