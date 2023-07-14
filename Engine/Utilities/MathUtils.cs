using System.Drawing;
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

        public static bool RectangleContainsPoint(Rectangle rectangle, IntVector2 mousePos)
        {

            return rectangle.Contains(new Point(mousePos.X, mousePos.Y));
        }


    }
}
