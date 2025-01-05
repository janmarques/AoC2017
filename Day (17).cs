using AoC2024;

var fullInput = 380;

var smallInput = 3;

var smallest = "";

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0;

var steps = input;

var pos = 0;
var lst = new List<int>(50000000) { 0 };
var hashset = new HashSet<int>();
for (int i = 0; i < 50000000; i++)
{
    //Utils.Counter("i", expectedTotal: 50000000, timer: true);
    pos = (pos + steps) % lst.Count;
    lst.Insert(pos + 1, i + 1);
    pos++;
    if (hashset.Add(lst[1]))
    {
        Console.WriteLine($"{i} {lst[1]}");
    }
    if (lst[1] != 665)
    {

    }
}


result = lst[lst.IndexOf(0) + 1];

timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();