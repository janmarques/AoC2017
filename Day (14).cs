using AoC2024;
using System.Text;

var fullInput =
@"stpzcrnm";

var smallInput =
@"flqrgnkx";

var smallest = "";

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0;

var grid = Enumerable.Range(0, 128).Select(x => Hash($"{input}-{x}")).ToArray();

int NumHash(int x, int y) => x + 128 * 128 * y;
var groups = new List<HashSet<(int, int)>>();

for (int i = 0; i < 128; i++)
{
    for (int j = 0; j < 128; j++)
    {
        if (!grid[i][j]) { continue; }
        var newGrp = new HashSet<(int, int)> { (i, j) };
        foreach (var dir in Utils.Directions)
        {
            var newX = i + dir.x;
            var newY = j + dir.y;
            if (newX < 0 || newY < 0 || newX > 127 || newY > 127) { continue; }
            if (!grid[newX][newY]) { continue; };
            newGrp.Add((newX, newY));
        }

        var existingXX = groups.Where(x => x.Any(y => newGrp.Contains(y))).ToList();
        if (!existingXX.Any())
        {
            groups.Add(newGrp);
        }
        else
        {
            var consolidated = existingXX.First();

            consolidated.UnionWith(newGrp);
            foreach (var item in existingXX.Skip(1).ToList())
            {
                consolidated.UnionWith(item);
                groups.Remove(item);
            }
        }
    }
}

result = groups.Count;

bool[] Hash(string input)
{
    var list = Enumerable.Range(0, 256).ToList();


    var lengths = ASCIIEncoding.ASCII.GetBytes(input).Select(x => (int)x).ToList();
    lengths.Add(17);
    lengths.Add(31);
    lengths.Add(73);
    lengths.Add(47);
    lengths.Add(23);

    var pos = 0;
    var skip = 0;
    for (int j = 0; j < 64; j++)
    {
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

            pos += (length + skip) % list.Count;
            skip++;
        }
    }

    var reses = new List<int>();
    for (int i = 0; i < 16; i++)
    {
        var span = list.Skip(i * 16).Take(16);
        var res = span.First();
        foreach (var item in span.Skip(1))
        {
            res ^= item;
        }
        reses.Add(res);
    }
    var str = Convert.ToHexStringLower(reses.Select(x => (byte)x).ToArray());
    var aaa = reses.Select(x => (byte)x).SelectMany(x => ToBits(x).Reverse().ToArray()).ToArray();
    return aaa;
}

IEnumerable<bool> ToBits(byte b)
{
    for (int i = 0; i < 8; i++)
    {
        yield return b % 2 == 1;
        b /= 2;
    }
}

timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();