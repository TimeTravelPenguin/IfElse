#region Title Header

// Name: Phillip Smith
// 
// Solution: IfThenElse
// Project: IfElse
// File Name: ConditionAlreadyDefinedException.cs
// 
// Current Data:
// 2020-05-20 8:14 PM
// 
// Creation Date:
// 2020-05-20 7:29 PM

#endregion

using System;

namespace IfElse.Exceptions
{
  /// <summary>
  ///   Class containing ConditionAlreadyDefinedException
  /// </summary>
  public class ConditionAlreadyDefinedException : Exception
  {
    /// <summary>
    ///   <see cref="ConditionAlreadyDefinedException" /> providing exception message
    /// </summary>
    /// <param name="message">Exception message</param>
    public ConditionAlreadyDefinedException(string message) : base(message)
    {
    }

    /// <summary>
    ///   <see cref="ConditionAlreadyDefinedException" /> providing exception message and inner exception
    /// </summary>
    /// <param name="message">Exception message</param>
    /// <param name="innerException">Inner exception</param>
    public ConditionAlreadyDefinedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    /// <summary>
    ///   Default exception
    /// </summary>
    public ConditionAlreadyDefinedException()
    {
    }
  }
}