using System;
using System.Numerics;
using Raylib_cs;
using TacticsGame.Source.Interfaces;
using TacticsGame.Source.Models;
using TacticsGame.Source.UserInterface;

namespace TacticsGame.Source.Scenes
{
    public class SplashScreen : IScene
    {
        // Define UI Componenets
        GameStartButton gameStartButton;


        public SplashScreen()
        {
            gameStartButton = new GameStartButton(new IntVector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2),
                new IntVector2(300, 120), Color.BLACK);
            gameStartButton.SetCenterPivot();
        }

        public void Draw()
        {
            //TODO: Draw Button UI for Starting Game
            StartGameUI();

            //TODO: Draw Button UI for Quitting Game
        }

        public void Update()
        {
            if(Game.inputManager.LEFT_CLICK_LAST_FRAME
                && gameStartButton.WasClicked())
            {
                Console.WriteLine("clicked");

            }
        }

        public void StartGameUI()
        {
            Raylib.DrawRectangle(gameStartButton.position.X, gameStartButton.position.Y, gameStartButton.size.X, gameStartButton.size.Y, gameStartButton.color); ;
        }
    }
}

