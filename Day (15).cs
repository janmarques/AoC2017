var fullInput =
@"";

var smallInput =
@"";

var smallest = "";

var input = smallInput;
//input = fullInput;
//input = smallest;

var aFactor = 16807L;
var bFactor = 48271L;

var a = 65L;
var b = 8921L;

a = 703;
b = 516;


var max = 2147483647;

var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0;

IEnumerable<long> GetAs()
{
    while (true)
    {

        a = (a * aFactor) % max;
        if (a % 4 == 0)
        {
            yield return a;
        }
    }
}

IEnumerable<long> GetBs()
{
    while (true)
    {
        b = (b * bFactor) % max;
        if (b % 8 == 0)
        {
            yield return b;
        }
    }
}

var aS = GetAs().Take(5_000_000).ToArray();
var bS = GetBs().Take(5_000_000).ToArray();

for (var i = 0; i < 5_000_000; i++)
{
    var la = aS.ElementAt(i);
    var lb = bS.ElementAt(i);

    var aBytes = BitConverter.GetBytes(la).Take(2);
    var bBytes = BitConverter.GetBytes(lb).Take(2);

    if (aBytes.SequenceEqual(bBytes))
    {
        result++;
    }
}


timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();