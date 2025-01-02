
//var fullInput =
//@"4	10	4	1	8	4	9	14	5	1	14	15	0	15	3	5";

//var smallInput =
//@"0	2	7	0";

//var smallest = "";

//var input = smallInput;
//input = fullInput;
////input = smallest;
//var timer = System.Diagnostics.Stopwatch.StartNew();

//var result = 0;

//var blocks = input.Split('\t', ' ').Select(int.Parse).ToArray();

//string Hash(int[] ints) => string.Join("\t", ints);

//var visited = new Dictionary<string, (int, int)>()
//{
//    { Hash(blocks), (1,0) }
//};

//while (true)
//{
//    result++;
//    blocks = Balance(blocks);
//    var hash = Hash(blocks);
//    if (!visited.ContainsKey(hash))
//    {
//        visited[hash] = (1, result);
//    }
//    else
//    {
//        result = result - visited[hash].Item2;
//        break;
//    }
//}

//int[] Balance(int[] blocks)
//{
//    var max = blocks.Max();
//    var maxIndex = Array.IndexOf(blocks, max);

//    blocks[maxIndex] = 0;
//    for (int i = 1; i <= max; i++)
//    {
//        blocks[(maxIndex + i) % blocks.Length]++;
//    }

//    return blocks;
//}

//timer.Stop();
//Console.WriteLine(result);
//Console.WriteLine(timer.ElapsedMilliseconds + "ms");
//Console.ReadLine();