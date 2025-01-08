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

var grid = Utils.ParseCoordGrid(input, x => new Cell { X = x.x, Y = x.y, State = x.c == '#' ? State.Infected : State.Clean }).ToDictionary(x => (x.X, x.Y));

var x = (int)Math.Sqrt(grid.Count) / 2;
var y = x;
var facing = 'N';

string EnumPr(State state)
{
    return state switch
    {
        State.Clean => ".",
        State.Weakened => "W",
        State.Infected => "#",
        State.Flagged => "F",
        _ => throw new Exception(),
    };
}
void Print() => Utils.PrintGrid(grid.Values, x => x.X, x => x.Y, x => EnumPr(x.State), nullPrint: (_, _) => ".");

for (var i = 0; i < 10000000; i++)
{
    //Utils.Counter("d", expectedTotal: 10000000, timer: true);
    var cell = GetOrCreate();
    switch (cell.State)
    {
        case State.Clean:
            facing = Utils.RotateLeft(facing);
            cell.State = State.Weakened;
            break;
        case State.Weakened:
            cell.State = State.Infected;
            result++;
            break;
        case State.Infected:
            facing = Utils.RotateRight(facing);
            cell.State = State.Flagged;
            break;
        case State.Flagged:
            facing = Utils.InverseDirection(facing);
            cell.State = State.Clean;
            break;
        default: throw new Exception();
    }

    var dir = Utils.Directions.Single(x => x.icon == facing);
    x += dir.x;
    y += dir.y;


    //Print();
}

Cell GetOrCreate()
{
    if (!grid.TryGetValue((x, y), out var value))
    {
        value = new Cell { X = x, Y = y, State = State.Clean };
        grid[(x, y)] = value;
    }
    return value;
}


timer.Stop();
Console.WriteLine(result);
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();

class Cell
{
    public int X { get; set; }
    public int Y { get; set; }
    public State State { get; set; }
}

enum State
{
    Clean, Weakened, Infected, Flagged
}