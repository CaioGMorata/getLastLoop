using System;
using System.Collections.Generic;

namespace EX_2
{
    class Program
    {

        private static string getLastLoop(string input)
        {
            var visited = new Dictionary<(int, int), int>();
            int x = 0, y = 0; // Mark the start of Cartesian Origin
            visited[(x, y)] = -1; // Mark the starting position

            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])  //Increment x,y vector
                {
                    case 'U': y++; break;
                    case 'D': y--; break;
                    case 'L': x--; break;
                    case 'R': x++; break;
                }

                var pos = (x, y); //Save key of dictionary

                if (visited.ContainsKey(pos)) //Identify when the robot returns to a point where it has already been
                {
                    int startIndex = visited[pos] + 1;
                    return input.Substring(startIndex, i - startIndex + 1);
                }

                visited[pos] = i; //Save position
            }

            return "Invalid Input!"; // Invalid Input
        }

        static void Main(string[] args)
        {
            Console.WriteLine(getLastLoop("RRRRDDDLLUUUUUUURRDDDDR"));
        }
    }
}
