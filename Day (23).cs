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

var registers = new Dictionary<char, long>()
{
    { 'a', 1 }
};

int a, b, c, d, e, f, g, h = 0;
a = 1;


//set b 79
b = 79;

//set c b
c = b;

//jnz a 2
if (a != 0)
{
    //jnz 1 5 (skip)

}

//mul b 100
b *= 100;

//sub b -100000
b -= -100000;

//set c b
c = b;

//sub c -17000
c -= -17000;

//set f 1
f = 1;

//set d 2
d = 2;

//set e 2
e = 2;

//set g d
g = d;

//mul g e
g *= e;

//sub g b
g -= b;

//jnz g 2
if (g != 0)
{
    //set f 0
    f = 0;
}

//sub e -1
e -= 1;

//set g e
g = e;

//sub g b
g -= b;

//jnz g -8
if (g != 0)
{
    //todo do while?
}

//sub d -1
d -= 1;

//set g d
g = d;

//sub g b
g -= b;

//jnz g -13
if (g == 0)
{
    //todo do while?
}

//jnz f 2
if (f != 0)
{
    //sub h -1
    h -= 1;
}

//set g b
g = b;

//sub g c
g -= c;

//jnz g 2
if (g != 0)
{
    //jnz 1 3
    // TODO "return"
}
//sub b -17
b -= -17;

//jnz 1 -23
// todo while true

timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();