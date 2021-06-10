using System;
using System.Collections.Generic;

namespace MazeGenerator
{
    internal class Maze
    {
        public readonly Cell[,] Cells;
        public readonly int Height;
        public readonly List<Cell> Neighbours = new();
        public Cell Finish;
        public Stack<Cell> Path = new();
        public Random Rnd = new();
        public List<Cell> Solve = new();
        public Cell Start;
        public List<Cell> Visited = new();
        public int Width;

        public Maze(int width, int height)
        {
            Start = new Cell(1, 1, true);
            Finish = new Cell(width - 3, height - 3, true);


            Width = width;
            Height = height;
            Cells = new Cell[width, height];
            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
                if (i % 2 != 0 && j % 2 != 0 && i < Width - 1 &&
                    j < Height - 1)
                    Cells[i, j] = new Cell(i, j);
                else
                    Cells[i, j] = new Cell(i, j, false, false);
            Path.Push(Start);
            Cells[Start.X, Start.Y] = Start;
        }

        public void SolveMaze()
        {
            var flag = false;
            foreach (var c in Cells)
                if (Cells[c.X, c.Y].IsCell)
                    Cells[c.X, c.Y].IsVisited = false;

            Path.Clear();
            Path.Push(Start);

            while (Path.Count != 0)
            {
                if (Path.Peek().X == Finish.X && Path.Peek().Y == Finish.Y) flag = true;

                if (!flag)
                {
                    Neighbours.Clear();
                    GetNeighboursSolve(Path.Peek());
                    if (Neighbours.Count != 0)
                    {
                        var nextCell = ChooseNeighbour(Neighbours);
                        nextCell.IsVisited = true;
                        Cells[nextCell.X, nextCell.Y].IsVisited = true;
                        Path.Push(nextCell);
                        Visited.Add(Path.Peek());
                    }
                    else
                    {
                        Path.Pop();
                    }
                }
                else
                {
                    Solve.Add(Path.Peek());
                    Path.Pop();
                }
            }
        }


        public void CreateMaze()
        {
            Cells[Start.X, Start.Y] = Start;
            while (Path.Count != 0)
            {
                Neighbours.Clear();
                GetNeighbours(Path.Peek());
                if (Neighbours.Count != 0)
                {
                    var nextCell = ChooseNeighbour(Neighbours);
                    RemoveWall(Path.Peek(), nextCell);
                    nextCell.IsVisited = true;
                    Cells[nextCell.X, nextCell.Y].IsVisited = true;
                    Path.Push(nextCell);
                }
                else
                {
                    Path.Pop();
                }
            }
        }

        private void GetNeighbours(Cell localcell)
        {
            var x = localcell.X;
            var y = localcell.Y;
            const int distance = 2;
            Cell[] possibleNeighbours =
            {
                new(x, y - distance),
                new(x + distance, y),
                new(x, y + distance),
                new(x - distance, y)
            };
            for (var i = 0; i < 4; i++)
            {
                var curNeighbour = possibleNeighbours[i];
                if (curNeighbour.X > 0 && curNeighbour.X < Width && curNeighbour.Y > 0 && curNeighbour.Y < Height)

                    if (Cells[curNeighbour.X, curNeighbour.Y].IsCell &&
                        !Cells[curNeighbour.X, curNeighbour.Y].IsVisited)

                        Neighbours.Add(curNeighbour);
            }
        }

        private void GetNeighboursSolve(Cell localcell)
        {
            var x = localcell.X;
            var y = localcell.Y;
            const int distance = 1;
            Cell[] possibleNeighbours =
            {
                new(x, y - distance),
                new(x + distance, y),
                new(x, y + distance),
                new(x - distance, y)
            };
            for (var i = 0; i < 4; i++)
            {
                var curNeighbour = possibleNeighbours[i];
                if (curNeighbour.X > 0 && curNeighbour.X < Width && curNeighbour.Y > 0 && curNeighbour.Y < Height)
                    if (Cells[curNeighbour.X, curNeighbour.Y].IsCell &&
                        !Cells[curNeighbour.X, curNeighbour.Y].IsVisited)

                        Neighbours.Add(curNeighbour);
            }
        }

        private Cell ChooseNeighbour(List<Cell> neighbours)
        {
            var r = Rnd.Next(neighbours.Count);
            return neighbours[r];
        }

        private void RemoveWall(Cell first, Cell second)
        {
            var xDiff = second.X - first.X;
            var yDiff = second.Y - first.Y;
            var addX = xDiff != 0 ? xDiff / Math.Abs(xDiff) : 0;
            var addY = yDiff != 0 ? yDiff / Math.Abs(yDiff) : 0;


            Cells[first.X + addX, first.Y + addY].IsCell = true;
            Cells[first.X + addX, first.Y + addY].IsVisited = true;
            second.IsVisited = true;
            Cells[second.X, second.Y] = second;
        }
    }
}