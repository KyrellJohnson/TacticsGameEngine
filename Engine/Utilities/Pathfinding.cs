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

        public static Position[] FindPath(short[,] grid, Vector2 start, Vector2 end, bool useDiagonals = false)
        {
            PathFinderOptions pathFinderOptions = new PathFinderOptions
            {
                PunishChangeDirection = true,
                UseDiagonals = useDiagonals
            };

            WorldGrid worldGrid = new WorldGrid(grid);
            PathFinder pathFinder = new PathFinder(worldGrid, pathFinderOptions);

            Position pathStart = new Position((int)start.X/32, (int)start.Y / 32);
            Position pathEnd = new Position((int)end.X / 32, (int)end.Y / 32);

           // Raylib.DrawRectangle(pathStart.Row*32, pathStart.Column * 32, 32, 32, Color.BEIGE);
          //  Raylib.DrawRectangle(pathEnd.Row * 32, pathEnd.Column * 32, 32, 32, Color.BLACK);

            Position[] path = pathFinder.FindPath(pathStart, pathEnd);

            if(path.Length != 0)
                if (path.Last().Row != pathEnd.Row && path.Last().Column != pathEnd.Column)
                    return new Position[0];

            return path;

        }
    }
}
