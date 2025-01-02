using AoC2024;
using System.Net.Http.Headers;
using static AoC2024.Utils;

var fullInput =
368078;

var smallInput =
400;

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

var elements = new Dictionary<(int x, int y), int>()
{
    {(x: 0,y: 0),1 }
};

for (int i = 1; i < input; i++)
{
    x += directions.ElementAt(facing % 4).Value.Item1;
    y += directions.ElementAt(facing % 4).Value.Item2;

    var value = Utils.DirectionsWithDiagonals.Sum(n => elements.SingleOrDefault(e => e.Key.x == x + n.x && e.Key.y == y + n.y).Value);
    elements[(x, y)] = value;
    //elements[(x, y)] = i;

    if (value > input)
    {
        result = value;
        break;
    }
    //if (i == 1)
    //{
    //    elements[(x, y)] = 1;
    //}

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

    //PrintGrid(elements, x => x.Key.x, x => x.Key.y, x => x.Value.ToString(), nullPrint: (_, _) => " ");
}

//result = Math.Abs(x) + Math.Abs(y);

timer.Stop();
Console.WriteLine(result); // 376087 too high
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();


//1 2 3 5 7 10 13 17 21
// 1 1 2 2 3  3  4  4  5 5 6 6 7 7  ..
//  0 1 0 1 0  1  .. 