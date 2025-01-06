//using AoC2024;
//using System.Collections.Concurrent;
//using System.Runtime.ExceptionServices;
//using System.Security.AccessControl;

//var fullInput =
//@"set i 31
//set a 1
//mul p 17
//jgz p p
//mul a 2
//add i -1
//jgz i -2
//add a -1
//set i 127
//set p 735
//mul p 8505
//mod p a
//mul p 129749
//add p 12345
//mod p a
//set b p
//mod b 10000
//snd b
//add i -1
//jgz i -9
//jgz a 3
//rcv b
//jgz b -1
//set f 0
//set i 126
//rcv a
//rcv b
//set p a
//mul p -1
//add p b
//jgz p 4
//snd a
//set a b
//jgz 1 3
//snd b
//set f 1
//add i -1
//jgz i -11
//snd a
//jgz f -16
//jgz a -19";

//var smallInput =
//@"snd 1
//snd 2
//snd p
//rcv a
//rcv b
//rcv c
//rcv d";

//var smallest = "";

//var input = smallInput;
//input = fullInput;
////input = smallest;
//var timer = System.Diagnostics.Stopwatch.StartNew();
//var result = 0L;

//var a = new Machine(input, 0);
//var b = new Machine(input, 1);
//a.Out = b.In;
//b.Out = a.In;

//Task.Run(() => a.Execute());
//Task.Run(() => b.Execute());

//timer.Stop();
//Console.WriteLine(result);
//Console.WriteLine(timer.ElapsedMilliseconds + "ms");
//Console.ReadLine();


//class Machine(string input, int processId)
//{
//    public int SendCnt { get; set; }
//    public BlockingCollection<long> Out { get; set; }
//    public BlockingCollection<long> In { get; set; } = new BlockingCollection<long> { };

//    public void Execute()
//    {
//        var registers = new Dictionary<char, long>()
//        {
//            { 'p', processId }
//        };

//        var lines = input.Split(Environment.NewLine).ToArray();
//        for (long i = 0; i < lines.Length; i++)
//        {
//            Utils.Counter(processId.ToString(), 1_000_000);
//            var line = lines[i];
//            var split = line.Split(" ").ToArray();
//            var register = split[1].Single();
//            var isRegister = char.IsLetter(register);
//            var bValue = long.MinValue;
//            if (split.Length > 2)
//            {
//                if (char.IsLetter(split[2], 0))
//                {
//                    registers.TryGetValue(split[2].Single(), out bValue);
//                }
//                else
//                {
//                    bValue = long.Parse(split[2]);
//                }

//            }
//            if (isRegister && !registers.ContainsKey(register))
//            {
//                registers[register] = 0;
//            }
//            var aValue = isRegister ? registers[register] : long.Parse(register.ToString());


//            switch (split[0])
//            {
//                case "snd":
//                    Out.Add(aValue);
//                    SendCnt++;
//                    //Console.WriteLine($"Program {processId} sending {register} {SendCnt}");
//                    break;
//                case "set":
//                    registers[register] = bValue;
//                    break;
//                case "add":
//                    registers[register] += bValue;
//                    break;
//                case "mul":
//                    registers[register] *= bValue;
//                    break;
//                case "mod":
//                    registers[register] %= bValue;
//                    break;
//                case "rcv":
//                    if (In.TryTake(out var inVal, TimeSpan.FromSeconds(2)))
//                    {
//                        registers[register] = inVal;
//                    }
//                    else
//                    {
//                        Console.WriteLine($"Program {processId} {SendCnt}");
//                        return;
//                    }
//                    break;
//                case "jgz":
//                    if (aValue > 0)
//                    {
//                        i += bValue - 1;
//                    }
//                    break;

//                default: throw new Exception();
//            }
//        }
//    }
//}