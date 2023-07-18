using System;
using System.Numerics;
using Raylib_cs;
using TacticsGame.Engine.Interfaces;
using TacticsGame.Engine.Models;
using TacticsGame.Engine.Models.UIElements;
using TacticsGame.Source.UserInterface.Buttons;

namespace TacticsGame.Source.Scenes
{
    public class SplashScreen : IScene
    {
        // Define UI Componenets
        GameStartButton gameStartButton;


        public SplashScreen()
        {
            gameStartButton = new GameStartButton(new IntVector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2),
                new IntVector2(300, 120), Color.BLACK, new UIText("Start Game", Color.WHITE, new IntVector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2), 20));
            gameStartButton.SetCenterPivot();
            gameStartButton.text!.SetCenterPivot();
        }

        public void Draw()
        {
            StartGameUI();
        }

        public void Update()
        {
            if(Game.inputManager.LEFT_CLICK_LAST_FRAME
                && gameStartButton.WasClicked(new IntVector2 (Game.inputManager.mousePosition)))
            {
                gameStartButton.OnClick();
            }
        }

        public void StartGameUI()
        {
            gameStartButton.DrawButton(withText: true);
        }

        public void Initalize()
        {
            //throw new NotImplementedException();
        }
    }
}

