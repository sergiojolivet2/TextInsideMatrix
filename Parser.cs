using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextInsideMatrix
{
    public class Parser
    {
        public char[,] ConvertToCharArray(string[] lines)
        {
            int rows = lines.Length;
            int cols = lines[0].Split(',').Length;
            char[,] grid = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] characters = lines[i].Split(',');
                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = characters[j].Trim()[0];
                }
            }

            return grid;
        }

        public string FindLongestSequence(char[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            string longestSequence = string.Empty;

            // Check horizontal, vertical, and two diagonal directions
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Horizontal
                    longestSequence = CheckDirection(grid, i, j, 0, 1, longestSequence);
                    // Vertical
                    longestSequence = CheckDirection(grid, i, j, 1, 0, longestSequence);
                    // Diagonal down-right
                    longestSequence = CheckDirection(grid, i, j, 1, 1, longestSequence);
                    // Diagonal up-right
                    longestSequence = CheckDirection(grid, i, j, -1, 1, longestSequence);
                }
            }

            return longestSequence;
        }

        public string CheckDirection(char[,] grid, int row, int col, int rowStep, int colStep, string currentLongest)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            char currentChar = grid[row, col];
            int count = 1;
            string sequence = currentChar.ToString();

            int i = row + rowStep;
            int j = col + colStep;

            while (i >= 0 && i < rows && j >= 0 && j < cols && grid[i, j] == currentChar)
            {
                sequence += ", " + grid[i, j];
                count++;
                i += rowStep;
                j += colStep;
            }

            if (count > currentLongest.Split(',').Length)
            {
                return sequence;
            }

            return currentLongest;
        }
    }
}
