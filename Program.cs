using System;

var fullInput =
@"";

var smallInput =
@"";

var smallest = "";

var input = smallInput;
//input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0;

int position = 0;
int stepsTaken = 0;
int targetSteps = 12134527;
var tape = new Dictionary<int, bool>();

object methodResult = A;
for (int i = 0; i < targetSteps; i++)
{
    methodResult = ((Func<object>)methodResult)();
}

result = tape.Count(x => x.Value);
timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();

void PrintGrid<T>(T[][] grid)
{
    for (int i = 0; i < grid.Length; i++)
    {
        for (int j = 0; j < grid[i].Length; j++)
        {
            Console.Write(grid[i][j]);
        }
        Console.WriteLine();
    }
}

object A()
{
    if (!GetValue())
    {
        WriteValue(true);
        MoveRight();
        return B;
    }
    else
    {
        WriteValue(false);
        MoveLeft();
        return C;
    }
}

object B()
{
    if (!GetValue())
    {
        WriteValue(true);
        MoveLeft();
        return A;
    }
    else
    {
        WriteValue(true);
        MoveRight();
        return C;
    }
}

object C()
{
    if (!GetValue())
    {
        WriteValue(true);
        MoveRight();
        return A;
    }
    else
    {
        WriteValue(false);
        MoveLeft();
        return D;
    }
}

object D()
{
    if (!GetValue())
    {
        WriteValue(true);
        MoveLeft();
        return E;
    }
    else
    {
        WriteValue(true);
        MoveLeft();
        return C;
    }
}

object E()
{
    if (!GetValue())
    {
        WriteValue(true);
        MoveRight();
        return F;
    }
    else
    {
        WriteValue(true);
        MoveRight();
        return A;
    }
}

object F()
{
    if (!GetValue())
    {
        WriteValue(true);
        MoveRight();
        return A;
    }
    else
    {
        WriteValue(true);
        MoveRight();
        return E;
    }
}

bool GetValue()
{
    if (tape.TryGetValue(position, out var value))
    {
        return value;
    }
    return false;
}

void WriteValue(bool value)
{
    tape[position] = value;
}

void MoveLeft()
{
    position++;
}

void MoveRight()
{
    position--;
}