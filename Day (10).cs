using System.Linq;

var fullInput =
@"34,88,2,222,254,93,150,0,199,255,39,32,137,136,1,167";

var smallInput =
@"3, 4, 1, 5";

var smallest = "";

var input = smallInput;
//input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0;

var list = Enumerable.Range(0, 256).Select(x => new Node { Value = x }).ToDictionary(x => x.Value);
if (input.Length < 20)
{
    list = Enumerable.Range(0, 5).Select(x => new Node { Value = x }).ToDictionary(x => x.Value);
}

for (var i = 0; i < list.Count; i++)
{
    list[i].Next = list[(i + 1) % list.Count];
    list[i].Previous = list[(list.Count + i - 1) % list.Count];
}

var lengths = input.Split(",").Select(int.Parse).ToList();

var pos = 0;
var skip = 0;
var pointer = list.First().Value;
foreach (var length in lengths)
{
    var items = new List<Node>();
    var tmpPointer = pointer;
    items.Add(tmpPointer);
    for (var i = 1; i < length; i++)
    {
        tmpPointer = tmpPointer.Next;
        items.Add(tmpPointer);
    }

    var beginExl = pointer.Previous;
    var endExl = tmpPointer.Next;


    foreach (var item in items)
    {
        (item.Previous, item.Next) = (item.Next, item.Previous);
    }

    beginExl.Next = items.Last();
    items.Last().Previous = beginExl;

    endExl.Previous = items.First();
    items.First().Next = endExl;


    pointer = endExl;
    for (int i = 0; i < skip; i++)
    {
        pointer = pointer.Next;
    }


    pos += length % list.Count;
    skip++;
}

timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();

class Node
{
    public int Value { get; set; }
    public Node Previous { get; set; }
    public Node Next { get; set; }
    public override string ToString() => Value.ToString();
}