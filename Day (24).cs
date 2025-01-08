using System.Numerics;
using System.Xml.Linq;

var fullInput =
@"48/5
25/10
35/49
34/41
35/35
47/35
34/46
47/23
28/8
27/21
40/11
22/50
48/42
38/17
50/33
13/13
22/33
17/29
50/0
20/47
28/0
42/4
46/22
19/35
17/22
33/37
47/7
35/20
8/36
24/34
6/7
7/43
45/37
21/31
37/26
16/5
11/14
7/23
2/23
3/25
20/20
18/20
19/34
25/46
41/24
0/33
3/7
49/38
47/22
44/15
24/21
10/35
6/21
14/50";

var smallInput =
@"0/2
2/2
2/3
3/4
3/5
0/1
10/1
9/10";

var smallest = "";

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0;

var nodes = input.Split(Environment.NewLine).Select(x => x.Split("/").Select(int.Parse)).Select(x => new Node { In = x.First(), Out = x.Last() }).ToList();

int Strength(Node n) => n.In + n.Out;
int OpenConnection(Node n, int usedSide) => n.In == usedSide ? n.Out : n.In;

var pq = new PriorityQueue<(Node current, HashSet<Node> unvisited, int openConnection, int strength, int length), int>();
foreach (var node in nodes.Where(x => x.In == 0 || x.Out == 0))
{
    pq.Enqueue((node, nodes.Where(x => x != node).ToHashSet(), OpenConnection(node, 0), Strength(node), 1), Strength(node));
}


var bridges = new List<(int length, int strength)>();

while (pq.Count > 0)
{
    (Node current, HashSet<Node> unvisited, int openConnection, int strength, int length) = pq.Dequeue();

    bridges.Add((length, strength));

    foreach (var item in unvisited.Where(x => x.In == openConnection || x.Out == openConnection))
    {
        var newStrength = strength + Strength(item);
        pq.Enqueue((item, unvisited.Where(x => x != item).ToHashSet(), OpenConnection(item, openConnection), newStrength, length + 1), newStrength);
    }

}

result = bridges.OrderByDescending(x => x.length).ThenByDescending(x => x.strength).First().strength;
timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();

class Node
{
    public int In { get; set; }
    public int Out { get; set; }
    public override string ToString() => $"{In}/{Out}";
}