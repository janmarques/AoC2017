//using AoC2024;
//using System.Collections.Concurrent;
//using System.Runtime.ExceptionServices;
//using System.Security.AccessControl;

//var fullInput =
//@"set b 79
//set c b
//jnz a 2
//jnz 1 5
//mul b 100
//sub b -100000
//set c b
//sub c -17000
//set f 1
//set d 2
//set e 2
//set g d
//mul g e
//sub g b
//jnz g 2
//set f 0
//sub e -1
//set g e
//sub g b
//jnz g -8
//sub d -1
//set g d
//sub g b
//jnz g -13
//jnz f 2
//sub h -1
//set g b
//sub g c
//jnz g 2
//jnz 1 3
//sub b -17
//jnz 1 -23";

//var smallInput =
//@"";

//var smallest = "";

//var input = smallInput;
//input = fullInput;
////input = smallest;
//var timer = System.Diagnostics.Stopwatch.StartNew();
//var result = 0L;

//result = Exec();

//int Exec()
//{
//    int b = 0, c = 0, h = 0;

//    b = 79;
//    c = b;

//    b *= 100;
//    b += 100000;
//    c = b;
//    c += 17000;


//    for (; b - 17 < c; b = b + 17)
//    {
//        if (!IsPrime(b))
//        {
//            h++;
//        }
//    }
//    return h;
//}


//timer.Stop();
//Console.WriteLine(result); //1001 too high
//Console.WriteLine(timer.ElapsedMilliseconds + "ms");
//Console.ReadLine();

//bool IsPrime(int n)
//{
//    if (n > 1)
//    {
//        return Enumerable.Range(1, n).Where(x => n % x == 0)
//                         .SequenceEqual(new[] { 1, n });
//    }

//    return false;
//}