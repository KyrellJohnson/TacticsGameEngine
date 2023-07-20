using System.Drawing;
using System.Numerics;
using AStar;
using AStar.Options;
using Raylib_cs;
using TacticsGame.Engine.Models;
using Color = Raylib_cs.Color;

namespace TacticsGame.Engine.Utilities
{
    public class Pathfinding
    {
        public static Point[] FindPath(short[,] grid, IntVector2 start, IntVector2 end, bool useDiagonals = false)
        {
            PathFinderOptions pathFinderOptions = new PathFinderOptions
            {
                PunishChangeDirection = true,
                UseDiagonals = useDiagonals,
            };

            WorldGrid worldGrid = new WorldGrid(grid);
            PathFinder pathFinder = new PathFinder(worldGrid, pathFinderOptions);

            Point pathStart = new Point(start.X, start.Y);
            Point pathEnd = new Point(end.X, end.Y);

            Point[] path = pathFinder.FindPath(pathStart, pathEnd);

            return path;

        }

        public static Point[] FindPath(short[,] grid, Vector2 start, Vector2 end, bool useDiagonals = false)
        {
            PathFinderOptions pathFinderOptions = new PathFinderOptions
            {
                PunishChangeDirection = true,
                UseDiagonals = useDiagonals
            };

            WorldGrid worldGrid = new WorldGrid(grid);
            PathFinder pathFinder = new PathFinder(worldGrid, pathFinderOptions);

            Point pathStart = new Point((int)start.X/32, (int)start.Y / 32);
            Point pathEnd = new Point((int)end.X / 32, (int)end.Y / 32);

            if (start.X / 32 == 15 && start.Y / 32 == 19)
            {
                Raylib.DrawRectangle(pathStart.X * 32, pathStart.Y * 32, 32, 32, Color.BEIGE);
                Raylib.DrawRectangle(pathEnd.X * 32, pathEnd.Y * 32, 32, 32, Color.BLACK);
            }

                

            Point[] path = pathFinder.FindPath(pathStart, pathEnd);

            if(path.Length != 0)
                if (path.Last().X != pathEnd.X && path.Last().Y != pathEnd.Y)
                    return new Point[0];

            return path;

        }
    }
}
