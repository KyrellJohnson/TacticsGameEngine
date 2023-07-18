using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Engine.Models;

namespace TacticsGame.Source.Entities.Models
{
    public class PlayerUnit
    {
        public string Name { get; set; }
        public Texture2D PlayerSprite { get; set; }
        public SpriteSize SpriteSize { get; set; }
        public IntVector2 PlayerPosition { get; set; }
        public List<IntVector2> Movement { get; set; }

        public PlayerUnit(string name, SpriteSize spriteSize)
        {
            Name = name;
            SpriteSize = spriteSize;
            PlayerSprite = Game.textureManager.playerSprite;
            Movement = new List<IntVector2>();
            Movement.Add(new IntVector2(0, 1));
            Movement.Add(new IntVector2(0, 2));
            Movement.Add(new IntVector2(0, -1));
            Movement.Add(new IntVector2(0, -2));
            Movement.Add(new IntVector2(1, 0));
            Movement.Add(new IntVector2(2, 0));
            Movement.Add(new IntVector2(-1, 0));
            Movement.Add(new IntVector2(-2, 0));
            Movement.Add(new IntVector2(1, 1));
            Movement.Add(new IntVector2(-1, 1));
            Movement.Add(new IntVector2(-1, -1));
            Movement.Add(new IntVector2(1, -1));
        }
    }

    public struct SpriteSize
    {
        public int X;
        public int Y;

        public SpriteSize(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
