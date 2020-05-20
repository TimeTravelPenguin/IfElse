![nuget version](https://img.shields.io/nuget/vpre/IfElse)

# ElseIf
This is a fluent if, else-if, else syntax

## Notice
This repo is a joke.
Do not use this.
This is a dumb idea.

## How to use

Observe the following example:
```cs
public enum Colour
{
  Red,
  Green,
  Blue,
  Unknown
}

public static void Main(string[] args)
{
  Action output = () => Console.WriteLine("Colour contained!");
  Action unknown = () => Console.WriteLine("Colour is unknown");
  Action fail = () => Console.WriteLine("Colour is not contained");

  Colour[] colours = {Colour.Red, Colour.Green};
  var colour = Colour.Red;

  var conditional = output.If(() => colours.Contains(colour))
    .ElseIf(() => colour == Colour.Unknown, unknown)
    .Else(fail);

  conditional.Process();

  colour = Colour.Unknown;
  conditional.Process();

  colour = Colour.Blue;
  conditional.Process();
}
```
This yeilds the following output:
```
Colour contained!
Colour is unknown
Colour is not contained
```

EZPZ
