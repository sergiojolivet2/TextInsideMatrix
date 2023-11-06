using TextInsideMatrix;

string filePath = @"../../../input.txt";
string[] lines = File.ReadAllLines(filePath);
var Parser = new Parser();
char[,] grid = Parser.ConvertToCharArray(lines);

string longestSequence = Parser.FindLongestSequence(grid);

Console.WriteLine(longestSequence);