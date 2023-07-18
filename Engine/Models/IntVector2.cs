using System;
using System.Numerics;

namespace TacticsGame.Engine.Models
{
    public struct IntVector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public IntVector2(int X, int Y)
        {
            this.X = X;
            this.Y = Y;

        }

        public IntVector2(float X, float Y)
        {
            this.X = (int)X;
            this.Y = (int)Y;
        }

        public IntVector2(Vector2 vector2)
        {
            X = (int)vector2.X;
            Y = (int)vector2.Y;
        }
    }
}

