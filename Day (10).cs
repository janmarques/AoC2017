using System.Text;

var fullInput =
@"34,88,2,222,254,93,150,0,199,255,39,32,137,136,1,167";

var smallInput =
@"1,2,3";

var smallest = "";

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0;


var list = Enumerable.Range(0, 256).ToList();
//if (input.Length < 20)
//{
//    list = Enumerable.Range(0, 5).ToList();
//}

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
Console.WriteLine(str);

timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();