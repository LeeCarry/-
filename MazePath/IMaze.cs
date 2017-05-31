using System.Collections.Generic;
using System.Drawing;

namespace MazePath
{
    public interface IMaze
    {
        List<Point> GetAIResult(int[,] Maze_Array);
    }
}
