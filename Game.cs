using Raylib_cs;
using TacticsGame.Source.GameManagers;

namespace TacticsGame
{
    public class Game
    {
        public static SceneManager sceneManager = new SceneManager();
        public static InputManager inputManager = new InputManager();
        public void Run()
        {
            // Set Up Start Up Configs
            Initalize();

            // Run Update Loop
            GameLoop();
            Raylib.CloseWindow();
        }

        public void Initalize()
        {
            Raylib.InitWindow(1280, 720, "Game");
            //camera.
        }

        public void GameLoop()
        {
            while (!Raylib.WindowShouldClose())
            {
                inputManager.GetAllInput();

                //Logic Update
                sceneManager.currentScene.Update();

                //Draw
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                sceneManager.currentScene.Draw();


                Raylib.DrawFPS(10, 10);
                Raylib.DrawText($"UP KEY: {inputManager.UP_ACTION_KEY_PRESSED.ToString()}", 40, 40, 20, Color.RED);
                Raylib.DrawText($"SCENE: {sceneManager.GetCurrentSceneName()}", 200, 40, 12, Color.RED);
                Raylib.DrawText($"RIGHT CLICK KEY: {inputManager.RIGHT_CLICK_LAST_FRAME.ToString()}", 40, 140, 20, Color.RED);


                Raylib.EndDrawing();
                //**

                inputManager.ResetInput();


            }
        }
    }
}

