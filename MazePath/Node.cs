namespace MazePath
{
    class Node
    {
        public int x;//节点所在行
        public int y;//节点所在列
        public int value;//2代表访问过
        public Node parent;
        public Node(int v,int ax,int ay)
        {
            value = v;
            x = ax;
            y = ay;
        }
    }
}
