﻿using AoC2024;

var fullInput =
@"../.. => .#./###/##.
#./.. => ..#/.#./#.#
##/.. => ###/#../...
.#/#. => .#./..#/##.
##/#. => ..#/#.#/###
##/## => .##/.##/.#.
.../.../... => #.#./..##/##../###.
#../.../... => .###/.##./.##./....
.#./.../... => ####/..../..../.#.#
##./.../... => #.../#..#/#.../###.
#.#/.../... => ..##/###./..#./.#..
###/.../... => #.../#.#./..#./#.#.
.#./#../... => #.#./..#./.#../...#
##./#../... => ###./.###/#.##/.#..
..#/#../... => .##./.##./####/####
#.#/#../... => ..##/.#.#/##../#.##
.##/#../... => ...#/..##/...#/#...
###/#../... => ..../##.#/..#./###.
.../.#./... => ###./..##/#..#/#.#.
#../.#./... => #..#/..#./#.##/#..#
.#./.#./... => ##.#/..../...#/....
##./.#./... => #.#./.##./.###/####
#.#/.#./... => ####/.##./.#../##.#
###/.#./... => #.##/..../.#.#/.##.
.#./##./... => ##.#/#.##/#.##/..##
##./##./... => .###/..../#.../..#.
..#/##./... => ..../.#../..#./##..
#.#/##./... => #.##/##../..##/.#.#
.##/##./... => ..../..#./#..#/....
###/##./... => #..#/#.##/##.#/..##
.../#.#/... => ..../#.#./.##./.#.#
#../#.#/... => .###/.#.#/#.#./..#.
.#./#.#/... => ####/#.../.#../.##.
##./#.#/... => ..##/..#./.#.#/#.#.
#.#/#.#/... => #.##/##../##../#..#
###/#.#/... => .###/.##./.##./.#.#
.../###/... => ##.#/..##/...#/..##
#../###/... => ..##/####/..#./.###
.#./###/... => #.##/#.##/.##./..##
##./###/... => #.../.#.#/####/..##
#.#/###/... => #.../.###/..../.###
###/###/... => .##./####/##../..#.
..#/.../#.. => #..#/.###/.#.#/##.#
#.#/.../#.. => ###./.##./.##./##..
.##/.../#.. => .###/.#../...#/.#.#
###/.../#.. => ###./..##/..##/.#.#
.##/#../#.. => ##.#/...#/####/#.##
###/#../#.. => .#.#/...#/.###/#..#
..#/.#./#.. => #.#./.###/##../#...
#.#/.#./#.. => ####/..#./.###/##..
.##/.#./#.. => #.#./##../..../#.#.
###/.#./#.. => .#.#/#.#./#.../#.#.
.##/##./#.. => ##../.#../...#/..#.
###/##./#.. => ##../#.../.###/..#.
#../..#/#.. => ##../####/##.#/#.##
.#./..#/#.. => #..#/..../..#./#...
##./..#/#.. => ..#./..##/#.##/#.##
#.#/..#/#.. => #.##/..#./.#.#/.#..
.##/..#/#.. => ###./##../.#.#/##..
###/..#/#.. => #.#./.#.#/.#.#/#..#
#../#.#/#.. => #..#/.#.#/####/.#.#
.#./#.#/#.. => #.../#.##/#.../#.#.
##./#.#/#.. => .##./.#../.#.#/..#.
..#/#.#/#.. => ##.#/.###/#..#/#...
#.#/#.#/#.. => .#.#/.###/#..#/.#..
.##/#.#/#.. => ..#./####/.#../...#
###/#.#/#.. => .###/.#../.##./.#.#
#../.##/#.. => ..##/##.#/#.#./.###
.#./.##/#.. => ####/.##./..../.##.
##./.##/#.. => ...#/##../..##/..##
#.#/.##/#.. => .###/##.#/.###/..#.
.##/.##/#.. => ..#./##../..##/...#
###/.##/#.. => ###./.#.#/.###/.###
#../###/#.. => .##./##.#/##.#/..#.
.#./###/#.. => ...#/...#/##.#/#.##
##./###/#.. => .#../.#.#/.#.#/..#.
..#/###/#.. => ####/.#.#/..../##.#
#.#/###/#.. => ..../.###/.##./#.#.
.##/###/#.. => #.#./..##/.##./##..
###/###/#.. => .###/##.#/#.#./#.##
.#./#.#/.#. => ...#/###./..../####
##./#.#/.#. => ..../###./#.##/..##
#.#/#.#/.#. => #.../###./##.#/#...
###/#.#/.#. => #.../##../..#./..#.
.#./###/.#. => ###./..../.#.#/..#.
##./###/.#. => ##.#/..../.##./###.
#.#/###/.#. => #.##/##../...#/....
###/###/.#. => .##./####/##../.#..
#.#/..#/##. => .#.#/#.#./##.#/#.##
###/..#/##. => ####/##../..##/####
.##/#.#/##. => .#.#/#..#/####/##..
###/#.#/##. => #.##/.#../.###/.#..
#.#/.##/##. => ...#/.#.#/#.#./....
###/.##/##. => ..#./#.#./.###/###.
.##/###/##. => .###/.###/.##./.#..
###/###/##. => #.../#.../#.##/.#..
#.#/.../#.# => ..#./..../##../#.##
###/.../#.# => ..#./#.##/####/...#
###/#../#.# => #.../###./#.../...#
#.#/.#./#.# => ..##/#.##/.#.#/.#..
###/.#./#.# => #.../.#.#/#.#./##..
###/##./#.# => ##../.###/.#../...#
#.#/#.#/#.# => ..##/#.#./#.##/##..
###/#.#/#.# => .###/..##/..#./.###
#.#/###/#.# => ##.#/.###/..../.###
###/###/#.# => ##.#/#.##/##../..#.
###/#.#/### => ##../.#../#.#./##.#
###/###/### => .##./##../..#./.###";

var smallInput =
@"../.# => ##./#../...
.#./..#/### => #..#/..../..../#..#";

var smallest = "";

var input = smallInput;
input = fullInput;
//input = smallest;
var timer = System.Diagnostics.Stopwatch.StartNew();

var result = 0;

var init =
@".#.
..#
###";

var grid = Utils.Parse2DGrid(init, x => x == '#').grid;

string Hash(bool[][] bools) => string.Join("", bools.SelectMany(x => x));

var transformations = input.Split(Environment.NewLine).Select(x =>
{
    var split = x.Replace("/", Environment.NewLine).Split(" => ");

    var source = Utils.Parse2DGrid(split[0], x => x == '#').grid;
    var target = Utils.Parse2DGrid(split[1], x => x == '#').grid;

    var grids = new List<bool[][]>();
    for (var i = 0; i < 4; i++)
    {
        source = Utils.RotateClockwise(source);
        var flip = Utils.Flip(source);
        grids.Add(source);
        grids.Add(flip);
    }

    return (grids.Select(Hash).ToList(), target);
    //return (grids, target);
}).ToList();

void Print() => Utils.PrintGrid(grid, x => x ? "#" : ".");

Print();
for (int i = 0; i < (input.Length < 100 ? 2 : 5); i++)
{
    var maxX = grid.Length;
    var divide = maxX % 2 == 0 ? 2 : 3;
    var newGrids = new List<bool[][]>();
    for (int xOff = 0; xOff < maxX; xOff += divide)
    {
        for (int yOff = 0; yOff < maxX; yOff += divide)
        {
            var newGrid = new bool[divide][];
            for (int y = 0; y < divide; y++)
            {
                var newLine = new bool[divide];
                for (int x = 0; x < divide; x++)
                {
                    newLine[x] = grid[yOff + y][xOff + x];
                }
                newGrid[y] = newLine;
            }
            newGrids.Add(newGrid);
        }
    }

    newGrids = newGrids.Select(Hash).Select(x => transformations.Single(y => y.Item1.Contains(x)).target).ToList();

    //stitch
    var size = (int)Math.Sqrt(newGrids.Count);
    var blockSize = newGrids.First().Length;
    var fullSize = blockSize * size;
    grid = Enumerable.Range(0, fullSize).Select(x => new bool[fullSize]).ToArray();
    var kX = 0;
    var kY = 0;
    foreach (var item in newGrids)
    {
        for (int y = 0; y < item.Length; y++)
        {
            for (int x = 0; x < item.Length; x++)
            {
                grid[kY + y][kX + x] = item[y][x];
            }
        }
        kX += blockSize;
        if (kX == size * blockSize)
        {
            kX = 0;
            kY += blockSize;
        }
    }
    Print();
}

result = grid.SelectMany(x => x).Count(x => x);

timer.Stop();
Console.WriteLine(result); // 122 too low
Console.WriteLine(timer.ElapsedMilliseconds + "ms");
Console.ReadLine();