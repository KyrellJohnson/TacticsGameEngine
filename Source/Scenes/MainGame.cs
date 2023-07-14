using Raylib_cs;
using System;
using System.Numerics;
using TacticsGame.Engine.Interfaces;
using TacticsGame.Source.GameManagers;

namespace TacticsGame.Source.Scenes
{
    public class MainGame : IScene
    {
        TilemapManager tileMap;
        Camera2D camera;

        public MainGame()
        {
            tileMap = new TilemapManager();
        }

        public void Initalize()
        {
            camera = new Camera2D();
            camera.offset = Vector2.Zero;
            camera.zoom = 1f;
        }

        public void Draw()
        {
            Raylib.BeginMode2D(camera);
            tileMap.Draw();
            
            Vector2 mouseWorldPos = Raylib.GetScreenToWorld2D(Game.inputManager.mousePosition, camera);

            Raylib.DrawCircle((int)mouseWorldPos.X,  (int)mouseWorldPos.Y, 9f, Color.VIOLET);
            Raylib.DrawCircle((int)mouseWorldPos.X, (int)mouseWorldPos.Y, 4.5f, Color.WHITE);
            Raylib.DrawText($"POS: {(int)mouseWorldPos.X} | {(int)mouseWorldPos.Y}", 250, 250, 20, Color.RED);
            Raylib.EndMode2D();
        }

        public void Update()
        {
            // Handle Drag Camera Movement
            if(Game.inputManager.RIGHT_CLICK_LAST_FRAME)
            {
                Vector2 delta = Game.inputManager.mouseDelta;
                delta = Raymath.Vector2Scale(delta, -1f / camera.zoom);

                camera.target = Raymath.Vector2Add(camera.target, delta);
            }
            float wheel = Game.inputManager.mouseWheel;
            // Handle Zoom Camera Movement
            if (wheel != 0)
            {
                Vector2 mousePos = Game.inputManager.mousePosition;

                // Get the world point under the mouse
                Vector2 mouseWorldPos = Raylib.GetScreenToWorld2D(mousePos, camera);

                // Set the Offset to where the mouse is
                camera.offset = mousePos;

                // Set the target to match, so camera maps to world space
                camera.target = mouseWorldPos;

                // oom increment
                const float zoomIncrement = 0.25f;
                const float maxZoom = 2.5f;

                camera.zoom += (wheel * zoomIncrement);
                

                if(camera.zoom < zoomIncrement || camera.zoom > maxZoom)
                    camera.zoom -= (wheel * zoomIncrement);

            }

        }
    }
}

