var fullInput =
@"0: 3
1: 2
2: 4
4: 4
6: 5
8: 6
10: 8
12: 8
14: 6
16: 6
18: 9
20: 8
22: 6
24: 10
26: 12
28: 8
30: 8
32: 14
34: 12
36: 8
38: 12
40: 12
42: 12
44: 12
46: 12
48: 14
50: 12
52: 12
54: 10
56: 14
58: 12
60: 14
62: 14
64: 14
66: 14
68: 14
70: 14
72: 14
74: 20
78: 14
80: 14
90: 17
96: 18";

var smallInput =
@"0: 3
1: 2
4: 4
6: 4";

var smallest = "";

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0;

var layers = input.Split(Environment.NewLine).Select(x => x.Split(": ").Select(int.Parse)).Select(x => (depth: x.First(), range: x.Last())).ToList();

for (; ; result++)
{
    if (TryDelay(result)) { break; }
}

bool TryDelay(int x)
{
    for (int i = 0; i <= layers.Max(x => x.depth); i++)
    {
        var (depth, range) = layers.SingleOrDefault(x => x.depth == i);
        if (range == 0) { continue; }
        if ((i + x) % (2 * range - 2) == 0)
        {
            return false;
        }
    }
    return true;
}

timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();