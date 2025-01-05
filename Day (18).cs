using System.Runtime.ExceptionServices;

var fullInput =
@"set i 31
set a 1
mul p 17
jgz p p
mul a 2
add i -1
jgz i -2
add a -1
set i 127
set p 735
mul p 8505
mod p a
mul p 129749
add p 12345
mod p a
set b p
mod b 10000
snd b
add i -1
jgz i -9
jgz a 3
rcv b
jgz b -1
set f 0
set i 126
rcv a
rcv b
set p a
mul p -1
add p b
jgz p 4
snd a
set a b
jgz 1 3
snd b
set f 1
add i -1
jgz i -11
snd a
jgz f -16
jgz a -19";

var smallInput =
@"set a 1
add a 2
mul a a
mod a 5
snd a
set a 0
rcv a
jgz a -1
set a 1
jgz a -2";

var smallest = "";

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0L;

var registers = new Dictionary<char, long>();

var lines = input.Split(Environment.NewLine).ToArray();
for (long i = 0; i < lines.Length; i++)
{
    var line = lines[i];
    var split = line.Split(" ").ToArray();
    var register = split[1].Single();
    var pValue = long.MinValue;
    if (split.Length > 2)
    {
        if (char.IsLetter(split[2], 0))
        {
            registers.TryGetValue(split[2].Single(), out pValue);
        }
        else
        {
            pValue = long.Parse(split[2]);
        }

    }
    if (!registers.ContainsKey(register))
    {
        registers[register] = 0;
    }

    switch (split[0])
    {
        case "snd":
            result = registers[register];
            break;
        case "set":
            registers[register] = pValue;
            break;
        case "add":
            registers[register] += pValue;
            break;
        case "mul":
            registers[register] *= pValue;
            break;
        case "mod":
            registers[register] %= pValue;
            break;
        case "rcv":
            Console.WriteLine(result);
            goto end;
            break;
        case "jgz":
            if (registers[register] > 0)
            {
                i += pValue - 1;
            }
            break;

        default: throw new Exception();
    }
}
end:;

timer.Stop();
Console.WriteLine(result); // 862 too low
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();