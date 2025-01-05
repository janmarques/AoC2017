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

for (var i = 0; i < 40_000_000; i++)
{
    a = (a * aFactor) % max;
    b = (b * bFactor) % max;

    var aBytes = BitConverter.GetBytes(a).Take(2);
    var bBytes = BitConverter.GetBytes(b).Take(2);

    if(aBytes.SequenceEqual(bBytes))
    {
        result++;
    }
}


timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();