#region Title Header

// Name: Phillip Smith
// 
// Solution: IfThenElse
// Project: IfElse.Tests
// File Name: ConditionalTests.cs
// 
// Current Data:
// 2020-05-20 6:44 PM
// 
// Creation Date:
// 2020-05-20 3:09 PM

#endregion

using AllOverIt.Fixture;
using FluentAssertions;
using Xunit;

namespace IfElse.Tests
{
  public class ConditionalTests : AoiFixtureBase
  {
    [Fact]
    public void DoubleConditionFalse()
    {
      var resultA = false;
      var resultB = false;

      void Action()
      {
        resultA = true;
        resultB = true;
      }

      var condition = new Conditional(() => false, Action);

      condition.Process();
      resultA.Should()
        .Be(false);
      resultB.Should()
        .Be(false);
    }

    [Fact]
    public void DoubleConditionTrue()
    {
      var resultA = false;
      var resultB = false;

      void Action()
      {
        resultA = true;
        resultB = true;
      }

      var condition = new Conditional(() => true, Action);

      condition.Process();
      resultA.Should()
        .Be(true);
      resultB.Should()
        .Be(true);
    }

    [Fact]
    public void ElseRuns()
    {
      static void IfCondition()
      {
        Assert.True(false);
      }

      static void ElseCondition()
      {
        Assert.True(true);
      }

      var conditional = new Conditional(() => false, IfCondition);
      conditional.Else(ElseCondition);

      conditional.Process();
    }

    [Fact]
    public void SingleConditionFalse()
    {
      var result = false;

      void Action()
      {
        result = true;
      }

      var condition = new Conditional(() => false, Action);

      condition.Process();
      result.Should()
        .Be(false);
    }

    [Fact]
    public void SingleConditionTrue()
    {
      var result = false;

      void Action()
      {
        result = true;
      }

      var condition = new Conditional(() => true, Action);

      condition.Process();
      result.Should()
        .Be(true);
    }
  }
}