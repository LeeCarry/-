using System.Collections.Generic;
using System.Drawing;

namespace MazePath
{
    class BFSAlgorithm : IMaze
    {
        public List<Point> GetAIResult(int[,] Maze_Array)
        {
            int[,] move = { { 0, -1 }, { 0, 1 }, { -1, 0 }, { 1, 0 } };//计算上下左右
            Point begin = new Point();
            Queue<Node> queue = new Queue<Node>(223);
            int Row_Total = Maze_Array.GetLength(0);
            int Col_Total = Maze_Array.GetLength(1);
            Node[,] nodes = new Node[Row_Total, Col_Total];
            for (int i = 0; i < Row_Total; i++)
                for (int j = 0; j < Col_Total; j++)
                {
                    nodes[i, j] = new Node(Maze_Array[i, j], i, j);
                    if (Maze_Array[i, j] == -1)
                    {
                        begin.X = i;
                        begin.Y = j;
                    } 
                }
            Node Node_First = nodes[begin.X, begin.Y];
            queue.Enqueue(Node_First);
            while(queue.Count>0)
            {
                Node node = queue.Dequeue();
                for(int i=0;i<move.GetLength(0);i++)
                {
                    int x = node.x + move[i, 0];
                    int y = node.y + move[i, 1];
                    if(x>=0&&x<Row_Total&&y>=0&&y<Col_Total)
                    {
                        Node next = nodes[x, y];
                        if(next.value==-2)
                        {
                            List<Point> path = new List<Point>();
                            path.Add(new Point(next.x, next.y));
                            while(node.parent!=null)
                            {
                                path.Add(new Point(node.x, node.y));
                                node = node.parent;
                            }
                            return path;
                        }
                        if(next.value==0)
                        {
                            next.value = 2;
                            next.parent = node;
                            queue.Enqueue(next);
                        }
                    }
                }
            }
            return null;
        }

        public override string ToString()
        {
            return "广度优先搜索算法";
        }
    }
}
