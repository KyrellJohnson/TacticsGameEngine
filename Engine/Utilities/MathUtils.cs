using System.Drawing;
using System.Numerics;
using TacticsGame.Engine.Models;

namespace TacticsGame.Engine.Utilities
{
    internal class MathUtils
    {
        public static bool PointInRectangle(int x1, int y1, int x2, int y2, int pointX, int pointY)
        {
            if (pointX > x1 && pointX < x2 && pointY > y1 && pointY < y2)
                return true;
            return false;
        }

        public static bool RectangleContainsPoint(Rectangle rectangle, IntVector2 position)
        {

            return rectangle.Contains(new Point(position.X, position.Y));
        }

        public static bool RectangleContainsPoint(Raylib_cs.Rectangle rectangle, IntVector2 position)
        {
            Rectangle rec = new Rectangle((int)rectangle.x, (int)rectangle.y, (int)rectangle.width, (int)rectangle.height);
            return rec.Contains(new Point(position.X, position.Y));
        }

        public static bool RectangleContainsPoint(Rectangle rectangle, Vector2 position)
        {
            return rectangle.Contains(new Point((int)position.X, (int)position.Y));
        }

        public static bool RectangleContainsPoint(Raylib_cs.Rectangle rectangle, Vector2 position)
        {
            Rectangle rec = new Rectangle((int)rectangle.x, (int)rectangle.y, (int)rectangle.width, (int)rectangle.height);
            return rec.Contains(new Point((int)position.X, (int)position.Y));
        }

    }
}
