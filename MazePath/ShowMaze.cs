using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MazePath
{
    public partial class ShowMaze : Control
    {
        private const int Edge_Len = 32;
        private const int Line_Width = 1;
        private const int X_Total = 15;
        private const int Y_Total = 15;
        private int[,] Maze_Array;
        private SolidBrush BG_Brush = new SolidBrush(Color.LightGray);
        private HatchBrush Balk_Brush = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Red, Color.White);
        private Pen Line_Pen = new Pen(Color.Black, Line_Width);
        private Graphics graphic;
        private Point begin, end;
        private bool Begin_Move;
        /*Point.X代表所在的行数，Point.Y代表所在的列数*/
        public ShowMaze()
        {
            InitializeComponent();
            Width = X_Total * (Edge_Len + Line_Width) + Line_Width;
            Height = Y_Total * (Edge_Len + Line_Width) + Line_Width;
            Maze_Array = new int[X_Total, Y_Total];//用于保存状态，-2==结束，-1==开始，0==空白，1==障碍物
            begin = new Point(0, 0);
            end = new Point(X_Total - 1, Y_Total - 1);
            Maze_Array[begin.X, begin.Y] = -1;
            Maze_Array[end.X, end.Y] = -2;
            BackColor = Color.LightSkyBlue;
            AllowDrop = true;
            DoubleBuffered = true;
            graphic = CreateGraphics();
        }

        //通过Point计算出矩阵
        private Rectangle PointToRect(int row, int col)
        {
            Rectangle rect = new Rectangle();
            rect.X = col * (Edge_Len + Line_Width) + Line_Width;
            rect.Y = row * (Edge_Len + Line_Width) + Line_Width;
            rect.Width = Edge_Len;
            rect.Height = Edge_Len;
            return rect;
        }

        //搜索出最短路径并画出箭头
        public bool SearchPath(IMaze im)
        {
            Refresh();
            SolidBrush Font_Brush = new SolidBrush(Color.DarkBlue);
            Font ft = new Font("宋体", 20);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            List<Point> path = im.GetAIResult(Maze_Array);
            if (path == null)
                return false;
            for (int i = path.Count - 1; i > 0; i--)
            {
                string next = string.Empty;
                if (path[i - 1].Y - path[i].Y == 1)
                    next = "→";
                else if (path[i - 1].Y - path[i].Y == -1)
                    next = "←";
                else if (path[i - 1].X - path[i].X == 1)
                    next = "↓";
                else if (path[i - 1].X - path[i].X == -1)
                    next = "↑";
                graphic.DrawString(next, ft, Font_Brush, PointToRect(path[i].X, path[i].Y), format);
            }
            return true;
        }

        //清空所有路障
        public void EmptyAllBalk()
        {
            for (int i = 0; i < Maze_Array.GetLength(0); i++)
                for (int j = 0; j < Maze_Array.GetLength(1); j++)
                    if (Maze_Array[i, j] == 1)
                        Maze_Array[i, j] = 0;
            Refresh();
        }

        //设置全为路障
        public void SetAllBalk()
        {
            for (int i = 0; i < Maze_Array.GetLength(0); i++)
                for (int j = 0; j < Maze_Array.GetLength(1); j++)
                    if (Maze_Array[i, j] == 0)
                        Maze_Array[i, j] = 1;
            Refresh();
        }

        //重载鼠标按下事件
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int col = e.X / (Edge_Len + Line_Width);
                int row = e.Y / (Edge_Len + Line_Width);
                Rectangle rect = PointToRect(row, col);
                if (Maze_Array[row, col] == 0)
                {
                    graphic.FillRectangle(Balk_Brush, rect);
                    Maze_Array[row, col] = 1;
                }
                else if (Maze_Array[row, col] == 1)
                {
                    graphic.FillRectangle(BG_Brush, rect);
                    Maze_Array[row, col] = 0;
                }
                else if (Maze_Array[row, col] == -1)
                {
                    Begin_Move = true;
                    DoDragDrop(begin, DragDropEffects.Copy | DragDropEffects.Move);
                }
                else if (Maze_Array[row, col] == -2)
                {
                    Begin_Move = false;
                    DoDragDrop(end, DragDropEffects.Copy | DragDropEffects.Move);
                }
            }
        }

        //重载鼠标移动事件
        protected override void OnMouseMove(MouseEventArgs e)
        {
            int col = e.X / (Edge_Len + Line_Width);
            int row = e.Y / (Edge_Len + Line_Width);
            if (row < 0 || row > X_Total - 1 || col < 0 || col > Y_Total - 1)
                return;
            if (e.Button == MouseButtons.Left)
            {
                if (Maze_Array[row, col] == 0)
                {
                    graphic.FillRectangle(Balk_Brush, PointToRect(row, col));
                    Maze_Array[row, col] = 1;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (Maze_Array[row, col] == 1)
                {
                    graphic.FillRectangle(BG_Brush, PointToRect(row, col));
                    Maze_Array[row, col] = 0;
                }
            }    
        }

        //判断拖放的数据是否是Point型
        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            if (drgevent.Data.GetDataPresent(typeof(Point)))
                drgevent.Effect = DragDropEffects.Move;
            else
                drgevent.Effect = DragDropEffects.None;
        }

        //计算拖放结束所在的单元格
        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            Point p = (Point)drgevent.Data.GetData(typeof(Point));
            Point e = PointToClient(new Point(drgevent.X, drgevent.Y));
            int col = e.X / (Edge_Len + Line_Width);
            int row = e.Y / (Edge_Len + Line_Width);
            if (Maze_Array[row, col] < 0)
                return;
            graphic.FillRectangle(BG_Brush, PointToRect(p.X, p.Y));
            graphic.FillRectangle(BG_Brush, PointToRect(row,col));
            Maze_Array[p.X, p.Y] = 0;
            if (Begin_Move)
            {
                iLico.Draw(graphic, col * (Edge_Len + Line_Width) + Line_Width, row * (Edge_Len + Line_Width) + Line_Width, 0);
                Maze_Array[row, col] = -1;
                begin.X = row;
                begin.Y = col;
            } 
            else
            {
                iLico.Draw(graphic, col * (Edge_Len + Line_Width) + Line_Width, row * (Edge_Len + Line_Width) + Line_Width, 1);
                Maze_Array[row, col] = -2;
                end.X = row;
                end.Y = col;
            }
        }

        //重绘
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics gp = e.Graphics;
            gp.FillRectangle(BG_Brush, ClientRectangle);
            for(int i=0;i<=X_Total;i++)
            {
                int x = i * (Edge_Len + Line_Width);
                gp.DrawLine(Line_Pen, x, 0, x, Height);
            }
            for(int i=0;i<=Y_Total;i++)
            {
                int y = i * (Edge_Len + Line_Width);
                gp.DrawLine(Line_Pen, 0, y, Width, y);
            }
            for (int i = 0; i < Maze_Array.GetLength(0); i++)
                for (int j = 0; j < Maze_Array.GetLength(1); j++)
                    if (Maze_Array[i, j] == 1)
                        gp.FillRectangle(Balk_Brush, PointToRect(i, j));
            iLico.Draw(gp, begin.Y * (Edge_Len + Line_Width) + Line_Width, begin.X * (Edge_Len + Line_Width) + Line_Width, 0);
            iLico.Draw(gp, end.Y * (Edge_Len + Line_Width) + Line_Width, end.X * (Edge_Len + Line_Width) + Line_Width, 1);
    
        }
    }
}
