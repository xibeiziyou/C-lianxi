using System;
using System.Collections.Generic;

namespace C_练习
{
    /// <summary>
    /// 您在迷宫 NxN 中的位置 [0， 0]，并且您只能在四个基本方向之一（即北、东、南、西）上移动。
    /// 如果可以到达位置 [N-1， N-1] 或其他位置，则返回。true or false
    /// 空位置标记为 。.
    /// 墙壁上有标记。W
    /// 在所有测试用例中，开始和退出位置都是空的。
    /// 例：
    /// string a = ".W.\n" +
    ///            ".W.\n" +
    ///            "...";
    /// return ture;
    /// </summary>
    internal class 探路者系列_1_找到出口
    {

        public static bool PathFinder(string maze)
        {
            double a = Math.Sqrt(maze.Length + 5 / 4) - 1 / 2;
            int v = (int)a;
            List<List<char>> zon = 地图数组化(maze,v);
            // Your code here!!
            return 探路(zon, v);
        }
        public static List<List<char>> 地图数组化(string maze,int v)
        {
            char[] chars = maze.ToCharArray();
            int j = 0;
            List<List<char>> zon = new List<List<char>>();
            for (int z = 0; z < v; z++)
            {
                List<char> list = new List<char>();
                for (int i = 0; i < v; i++)
                {
                    list.Add(chars[j]);
                    j++;
                }
                j++;
                zon.Add(list);
            }
            return zon;
        }
        public static bool 探路(List<List<char>> zon,int v)
        {
            int x = 0;
            int y = 0;
            int o = 0;
            char mu;
            mu = zon[x][y];
            Stack<int[]> stack = new Stack<int[]>();
            List<int[]> list = new List<int[]>();
            Stack<int> ints = new Stack<int>();
            return 判断(x, y, o, zon,stack, list, ints,mu,v);
        }
        public static bool 判断(int x, int y, int o, List<List<char>> zon, Stack<int[]> stack, List<int[]> list, Stack<int> ints, char mu,int v)
        {
            list = 周围(x,y,zon,list, v);
            switch (list.Count)
            {
                case 0:
                    while (o > 1)
                    {
                        回溯(x, y, o, zon, stack, list, ints, mu, v);
                        o--;
                    }
                    zon[x][y] = 'W';
                    int[] ints1 = stack.Pop();
                    x = ints1[0];
                    y = ints1[1];
                    mu = zon[x][y] = '.';
                    if (ints.Count == 0 && 周围(x, y, zon, list,v).Count == 0)
                    {
                        return false;
                    }
                    else 
                    {
                        o = ints.Pop();
                        return 判断(x, y, o, zon, stack, list, ints, mu, v);
                    }
                case 1:
                    o++;
                    return 前进(x, y, o, zon, stack, list, ints, mu, v);
                default:
                    ints.Push(o);
                    o = 0;
                    return 前进(x, y, o, zon, stack, list, ints, mu, v);
            }
        }
        public static bool 前进(int x, int y, int o, List<List<char>> zon, Stack<int[]> stack, List<int[]> list, Stack<int> ints, char mu, int v)
        {
            zon[x][y] = 'w';
            stack.Push(new int[] {x,y});
            x = list[0][0];
            y = list[0][1];
            mu = zon[x][y];
            if (x == y && x == v - 1)
            {
                return true;
            }
            else 
            {
                return 判断(x, y, o, zon, stack, list, ints, mu, v);
            }
        }
        public static void 回溯(int x, int y, int o, List<List<char>> zon, Stack<int[]> stack, List<int[]> list, Stack<int> ints, char mu, int v)
        {
            int[] ints1 = stack.Pop();
            x = ints1[0];
            y = ints1[1];
            mu = zon[x][y] = '.';
        }
        public static List<int[]> 周围(int x, int y, List<List<char>> zon, List<int[]> list,int v)
        {
            list.Clear();
            if (y + 1 < v && zon[x][y + 1] == '.') { list.Add(new int[] { x, y + 1 }); }
            if (x + 1 < v && zon[x + 1][y] == '.') { list.Add(new int[] { x + 1, y }); }
            if (y - 1 >= 0 && zon[x][y - 1] == '.') { list.Add(new int[] { x, y - 1 }); }
            if (x - 1 >= 0 && zon[x - 1][y] == '.') { list.Add(new int[] { x - 1, y }); }
            return list;
        }

        public static bool PathFinder优化(string maze)
        {
            // 计算迷宫的边长
            int size = (int)Math.Sqrt(maze.Replace("\n", "").Length);

            // 将迷宫转换为二维数组
            char[,] mazeGrid = ParseMaze(maze, size);

            // 使用 DFS 深度优先搜索
            return FindPath(mazeGrid, size);
        }

        private static char[,] ParseMaze(string maze, int size)
        {
            char[,] grid = new char[size, size];
            int index = 0;

            foreach (char c in maze.Replace("\n", ""))
            {
                grid[index / size, index % size] = c;
                index++;
            }

            return grid;
        }

        private static bool FindPath(char[,] maze, int size)
        {
            Stack<(int x, int y)> stack = new Stack<(int, int)>();
            stack.Push((0, 0)); // 起点入栈
            maze[0, 0] = 'v';  // 标记为已访问

            // 深度优先搜索
            while (stack.Count > 0)
            {
                var (x, y) = stack.Pop();

                // 如果到达终点，返回成功
                if (x == size - 1 && y == size - 1)
                    return true;

                // 遍历四个方向
                foreach (var (nx, ny) in GetNeighbors(x, y, size))
                {
                    if (maze[nx, ny] == '.')
                    {
                        stack.Push((nx, ny));
                        maze[nx, ny] = 'v'; // 标记为已访问
                    }
                }
            }

            return false; // 无法到达终点
        }

        private static IEnumerable<(int x, int y)> GetNeighbors(int x, int y, int size)
        {
            // 上下左右四个方向
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            for (int i = 0; i < 4; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];
                if (nx >= 0 && nx < size && ny >= 0 && ny < size)
                {
                    yield return (nx, ny);
                }
            }
        }

    }
}
