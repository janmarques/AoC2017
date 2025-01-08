using AoC2024;

var fullInput =
@"...#.#.####.....#.##..###
##.#.###..#.....#.##...#.
..#.##..#.#.##.#...#..###
###...##....###.#..#...#.
...#..#.........##..###..
#..#.#.#.#.#.#.#.##.####.
#...#.##...###...##..#..#
##...#.###..###...####.##
###..#.#####.##..###.#.##
#..#....#.##..####...####
...#.#......###.#..#..##.
.#.#...##.#.#####..###.#.
.....#..##..##..###....##
#.#..###.##.##.#####.##..
###..#..###.##.#..#.##.##
.#######.###....######.##
..#.#.###.##.##...###.#..
#..#.####...###..###..###
#...#..###.##..##...#.#..
........###..#.#.##..##..
.#############.#.###..###
##..#.###....#.#..#..##.#
..#.#.#####....#..#####..
.#.#..#...#...##.#..#....
##.#..#..##........#..##.";

var smallInput =
@"..#
#..
...";

var smallest = "";

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0;

var grid = Utils.ParseCoordGrid(input, x => new Cell { X = x.x, Y = x.y, Infected = x.c == '#' }).ToList();

var x = (int)Math.Sqrt(grid.Count) / 2;
var y = x;
var facing = 'N';


void Print() => Utils.PrintGrid(grid, x => x.X, x => x.Y, x => x.Infected ? "#" : ".", nullPrint: (_, _) => ".");

for (var i = 0; i < 10000; i++)
{
    var cell = GetOrCreate();
    facing = cell.Infected ? Utils.RotateRight(facing) : Utils.RotateLeft(facing);

    cell.Infected = !cell.Infected;
    if (cell.Infected) { result++; }

    var dir = Utils.Directions.Single(x => x.icon == facing);
    x += dir.x;
    y += dir.y;


    //Print();
}

Cell GetOrCreate()
{
    var cell = grid.SingleOrDefault(c => c.X == x && c.Y == y);
    if (cell == default)
    {
        cell = new Cell { X = x, Y = y, Infected = false };
        grid.Add(cell);
    }
    return cell;
}


timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();

class Cell
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool Infected { get; set; }
}