using AoC2024;
using System.Collections.Concurrent;
using System.Runtime.ExceptionServices;
using System.Security.AccessControl;

var fullInput =
@"set b 79
set c b
jnz a 2
jnz 1 5
mul b 100
sub b -100000
set c b
sub c -17000
set f 1
set d 2
set e 2
set g d
mul g e
sub g b
jnz g 2
set f 0
sub e -1
set g e
sub g b
jnz g -8
sub d -1
set g d
sub g b
jnz g -13
jnz f 2
sub h -1
set g b
sub g c
jnz g 2
jnz 1 3
sub b -17
jnz 1 -23";

var smallInput =
@"";

var smallest = "";

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();
var result = 0L;

var a = new Machine(input, 0);
var b = new Machine(input, 1);
a.Out = b.In;
b.Out = a.In;

a.Execute();

//Task.Run(() => a.Execute());
//Task.Run(() => b.Execute());

timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();


class Machine(string input, int processId)
{
    public int MulCnt { get; set; }
    public BlockingCollection<long> Out { get; set; }
    public BlockingCollection<long> In { get; set; } = new BlockingCollection<long> { };

    public void Execute()
    {
        var registers = new Dictionary<char, long>()
        {
            { 'p', processId }
        };

        var lines = input.Split(Environment.NewLine).ToArray();
        for (long i = 0; i < lines.Length; i++)
        {
            Utils.Counter(processId.ToString(), 1_000_000);
            var line = lines[i];
            var split = line.Split(" ").ToArray();
            var register = split[1].Single();
            var isRegister = char.IsLetter(register);
            var bValue = long.MinValue;
            if (split.Length > 2)
            {
                if (char.IsLetter(split[2], 0))
                {
                    registers.TryGetValue(split[2].Single(), out bValue);
                }
                else
                {
                    bValue = long.Parse(split[2]);
                }

            }
            if (isRegister && !registers.ContainsKey(register))
            {
                registers[register] = 0;
            }
            var aValue = isRegister ? registers[register] : long.Parse(register.ToString());


            switch (split[0])
            {
                case "set":
                    registers[register] = bValue;
                    break;
                case "sub":
                    registers[register] -= bValue;
                    break;
                case "mul":
                    registers[register] *= bValue;
                    MulCnt++;
                    Console.WriteLine($"Program {processId} sending {register} {MulCnt}");
                    break;
                case "jnz":
                    if (aValue != 0)
                    {
                        i += bValue - 1;
                    }
                    break;

                default: throw new Exception();
            }
        }
    }
}