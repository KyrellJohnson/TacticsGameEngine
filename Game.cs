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
                Raylib.ClearBackground(Color.LIGHTGRAY);

                sceneManager.currentScene.Draw();

#if DEBUG
                Raylib.DrawFPS(10, 10);
                Raylib.DrawText($"UP KEY: {inputManager.UP_ACTION_KEY_PRESSED.ToString()}", 40, 40, 20, Color.RED);
                Raylib.DrawText($"DOWN KEY: {inputManager.DOWN_ACTION_KEY_PRESSED.ToString()}", 40, 80, 20, Color.RED);
                Raylib.DrawText($"LEFT KEY: {inputManager.LEFT_ACTION_KEY_PRESSED.ToString()}", 40, 120, 20, Color.RED);
                Raylib.DrawText($"RIGHT KEY: {inputManager.RIGHT_ACTION_KEY_PRESSED.ToString()}", 40, 160, 20, Color.RED);
                Raylib.DrawText($"RIGHT CLICK: {inputManager.RIGHT_CLICK_LAST_FRAME.ToString()}", 40, 200, 20, Color.RED);
                Raylib.DrawText($"LEFT CLICK: {inputManager.LEFT_CLICK_LAST_FRAME.ToString()}", 40, 240, 20, Color.RED);

#endif
                Raylib.EndDrawing();
                //**

            }
        }
    }
}

