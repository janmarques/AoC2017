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
int targetSteps = 6;
var tape = new Dictionary<int, bool>();

try
{
    A();
}
catch
{

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

void A()
{
    stepsTaken++; if (stepsTaken > targetSteps) { throw new Exception(); }
    if (!GetValue())
    {
        WriteValue(true);
        MoveRight();
        B();
    }
    else
    {
        WriteValue(false);
        MoveLeft();
        B();
    }
}

void B()
{
    stepsTaken++; if (stepsTaken > targetSteps) { throw new Exception(); }
    if (!GetValue())
    {
        WriteValue(true);
        MoveLeft();
        A();
    }
    else
    {
        WriteValue(true);
        MoveRight();
        A();
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