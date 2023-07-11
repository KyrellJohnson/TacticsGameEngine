using System;
using System.Numerics;
using Raylib_cs;
using TacticsGame.Source.Interfaces;
using TacticsGame.Source.Models;

namespace TacticsGame.Source.UserInterface
{
    public class GameStartButton : IUIButton
    {
        public IntVector2 position { get; private set; }
        public IntVector2 size { get; private set; }
        public Color color { get; private set; }

        public GameStartButton(IntVector2 position, IntVector2 size, Color color)
        {
            this.position = position;
            this.size = size;
            this.color = color;
        }

        public void OnClick()
        {
            throw new NotImplementedException();
        }

        public void SetCenterPivot()
        {
            position = new IntVector2(position.X - size.X/2 , position.Y - size.Y/2);
        }
    }
}

