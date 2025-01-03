var fullInput =
@"34,88,2,222,254,93,150,0,199,255,39,32,137,136,1,167";

var smallInput =
@"3,4,1,5";

var smallest = "";

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0;

var list = Enumerable.Range(0, 256).ToList();
if (input.Length < 20)
{
    list = Enumerable.Range(0, 5).ToList();
}

var lengths = input.Split(",").Select(int.Parse).ToList();

var pos = 0;
var skip = 0;
foreach (var length in lengths)
{
    var take = new List<int>();
    for (int i = 0; i < length; i++)
    {
        take.Add(list[(pos + i) % list.Count]);
    }

    take.Reverse();

    for (int i = 0; i < length; i++)
    {
        list[(pos + i) % list.Count] = take[i];
    }

    pos += (length+skip) % list.Count;
    skip++;
}

result = list[0] * list[1];

timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();