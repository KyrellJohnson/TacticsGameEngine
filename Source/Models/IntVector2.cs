using System;
using System.Numerics;

namespace TacticsGame.Source.Models
{
    public struct IntVector2
    {
        public int X;
        public int Y;

        public IntVector2(int X, int Y)
        {
            this.X = X;
            this.Y = Y;

        }

        public IntVector2(Vector2 vector2)
        {
            this.X = (int)vector2.X;
            this.Y = (int)vector2.Y;
        }
    }
}

