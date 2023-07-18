using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using TacticsGame.Engine.Models;
using TacticsGame.Engine.Utilities;
using TacticsGame.Source.Entities.Models;
using TacticsGame.Source.Scenes;

namespace TacticsGame.Source.GameManagers
{
    public class LevelManager
    {
        PlayerUnit[] playerUnits;
        public PlayerUnit selectedUnit;
        Dictionary<Vector2, PlayerUnit> playerPositions;

        public Camera2D camera;
        public LevelManager()
        {
            playerPositions = new Dictionary<Vector2, PlayerUnit>();
        }

        public void Initalize()
        {

            // Get All Current Player Units
            playerUnits = new PlayerUnit[] {
                new PlayerUnit(name: "Unit1", new SpriteSize(32,32)),
                new PlayerUnit(name: "Unit2", new SpriteSize(32,32)),
                new PlayerUnit(name: "Unit3", new SpriteSize(32,32)),
                new PlayerUnit(name: "Unit4", new SpriteSize(32,32))
            };

            // Set Spawn Locations For Player Units
            foreach (var player in playerUnits)
            {

                // find a random spanPoint
                Random rand = new Random();
                int randIndex = rand.Next(TilemapManager.spawnPoints.Count);

                playerPositions.Add(TilemapManager.spawnPoints.ElementAt(randIndex), player);
                TilemapManager.spawnPoints.RemoveAt(randIndex);
            }

            selectedUnit = playerUnits[0];

            foreach (var x in selectedUnit.Movement)
            {
                Console.WriteLine(x);
            }

        }

        public void Update()
        {
            // Get Selected Player
            if (Game.inputManager.LEFT_CLICK_LAST_FRAME)
            {
                foreach (var player in playerPositions)
                {
                    var mousePos = Raylib.GetScreenToWorld2D(Game.inputManager.mousePosition, camera);

                    if (MathUtils.RectangleContainsPoint(new Rectangle(player.Key.X, player.Key.Y, player.Value.SpriteSize.X, player.Value.SpriteSize.Y), mousePos))
                    {
                        ChangeSelectedUnit(player.Value);
                    }
                }
            }
        }

        public void Draw()
        {
            foreach (var player in playerPositions)
            {

                Rectangle source = new Rectangle(0, 0, 32, 32);
                Rectangle dest = new Rectangle(player.Key.X, player.Key.Y, 32, 32);
                Raylib.DrawTexturePro(player.Value.PlayerSprite, source, dest, Vector2.Zero, 0f, Color.WHITE);
                player.Value.PlayerPosition = new IntVector2(dest.x, dest.y);
            }

            ShowUnitMovement();

        }

        public void ChangeSelectedUnit(PlayerUnit playerUnit)
        {
            selectedUnit = playerUnit;
        }

        public void ShowUnitMovement()
        {

            Vector2[] currentPlayerPositions = playerPositions.Keys.ToArray();
            Vector2[] colliderPositions = TilemapManager.colliderPositions.ToArray();

            for (int i = 0; i < selectedUnit.Movement.Count; i++)
            {
                Rectangle moveTile = new Rectangle(selectedUnit.PlayerPosition.X + (selectedUnit.Movement.ElementAt(i).X * selectedUnit.SpriteSize.X),
                    selectedUnit.PlayerPosition.Y + (selectedUnit.Movement.ElementAt(i).Y * selectedUnit.SpriteSize.Y),
                    selectedUnit.SpriteSize.X, selectedUnit.SpriteSize.Y
                );
                Rectangle src = new Rectangle(0, 0, 32, 32);

                if (!MathUtils.RectangleContainsListOfPoints(moveTile, currentPlayerPositions) && !MathUtils.RectangleContainsListOfPoints(moveTile, colliderPositions))
                {
                    Raylib.DrawTexturePro(Game.textureManager.movementTileSprite, src, moveTile, Vector2.Zero, 0f, Color.WHITE);
                }
                else
                {
                    Raylib.DrawTexturePro(Game.textureManager.nonMovementTileSprite, src, moveTile, Vector2.Zero, 0f, Color.WHITE);

                }
            }


        }


    }
}

