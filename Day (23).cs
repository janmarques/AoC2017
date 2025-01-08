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

Console.WriteLine(Exec());

int Exec()
{

    int a = 0, b = 0, c = 0, d = 0, e = 0, f = 0, g = 0, h = 0;

    a = 0;
    b = 79;
    c = b;

    if (a != 0)
    {
        b *= 100; result++;
        b += 100000;
        c = b;
        c += 17000;
        f = 1;
    }

    while (true)
    {
        d = 2;
        for (g = -1; g != 0;)
        {
            e = 2;

            for (g = -1; g != 0;)
            {
                g = d;
                g *= e; result++;
                g -= b;

                if (g == 0)
                {
                    f = 0;
                }

                e++;
                g = e;
                g -= b;
            }

            d++;
            g = d;
            g -= b;
        }

        if (f == 0)
        {
            h++;
        }

        g = b;
        g -= c;

        if (g == 0)
        {
            return h;
        }
        b += 17;

    }
}


timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();