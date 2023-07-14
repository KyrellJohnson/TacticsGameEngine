using System;
using System.Numerics;
using Raylib_cs;
using TacticsGame.Source.Interfaces;
using TacticsGame.Source.Models;

namespace TacticsGame.Source.UserInterface
{
    public class GameStartButton : UIButton
    {
        public GameStartButton(IntVector2 position, IntVector2 size, Color color) : base(position, size, color)
        {
            
        }

        public new void OnClick()
        {
            Game.sceneManager.ChangeScene("Main");
        }
    }
}

