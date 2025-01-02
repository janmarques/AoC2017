using AoC2024;
using static AoC2024.Utils;

var fullInput =
368078;

var smallInput =
13;

var smallest = 1024;

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0;

var first = true;
var step = 1;
var stepCounter = 0;
var facing = 0;


var directions = new Dictionary<char, (int, int)>() {
        {'E', (1, 0) },
        {'N', (0, -1) },
        {'W', (-1, 0) },
        {'S', (0, 1) },
    };

var x = 0;
var y = 0;

for (int i = 1; i < input; i++)
{
    x += directions.ElementAt(facing % 4).Value.Item1;
    y += directions.ElementAt(facing % 4).Value.Item2;

    stepCounter++;

    if (stepCounter == step)
    {
        if (first)
        {
        }
        else
        {
            step++;
        }

        stepCounter = 0;
        facing++;
        first = !first;
    }
}

result = Math.Abs(x) + Math.Abs(y);

timer.Stop();
Console.WriteLine(result); // 370 too low
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();


//1 2 3 5 7 10 13 17 21
// 1 1 2 2 3  3  4  4  5 5 6 6 7 7  ..
//  0 1 0 1 0  1  .. 