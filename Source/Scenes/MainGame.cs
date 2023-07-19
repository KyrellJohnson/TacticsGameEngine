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
        LevelManager levelManager;
        Camera2D camera;
        float CameraZoomLastFrame;
        Vector2 CameraOffsetLastFrame;

        public MainGame()
        {
            tileMap = new TilemapManager();
            levelManager = new LevelManager();
        }

        public void Initalize()
        {
            tileMap.Initalize(tilemapSrc: "../../../Assets/Tilemaps/Level_Main.tmx", tilesetTextureSrc: "../../../Assets/tileset x1.png", collisionLayerName: "Walls");
            levelManager.Initalize(spawnPoints: tileMap.spawnPoints);

            camera = new Camera2D();
            camera.offset = Vector2.Zero;
            camera.zoom = 1f;

        }

        public void Draw()
        {
            //Raylib.DrawText($"Selected Unit: {camera.target.ToString()}", 40, 280, 20, Color.RED);

            Raylib.BeginMode2D(camera);

            
            tileMap.Draw();
            levelManager.Draw();
            

            Raylib.EndMode2D();


        }

        public void Update()
        {
            levelManager.Update();
            levelManager.colliderPos = tileMap.colliderPositions;

            // function to handle drag and zoom events
            HandleCameraMovement();

            // Update Camera Object in tilemap and levelmanager classes
            tileMap.camera = camera;
            levelManager.camera = camera;
        }

        void HandleCameraMovement()
        {
            // Handle Drag Camera Movement
            if (Game.inputManager.RIGHT_CLICK_LAST_FRAME)
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


                if (camera.zoom < zoomIncrement || camera.zoom > maxZoom)
                    camera.zoom -= (wheel * zoomIncrement);

            }
        }
    }
}

