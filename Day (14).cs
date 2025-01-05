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
result = grid.SelectMany(x => x).Count(x => x);
//var xx = Hash("flqrgnkx-0");
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