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
        Texture2D playerSprite;
        public Camera2D camera;

        public LevelManager()
        {
            playerPositions = new Dictionary<Vector2, PlayerUnit>();
            playerSprite = new Texture2D();
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
            foreach(var player in playerUnits)
            {

                // find a random spanPoint
                Random rand = new Random();
                int randIndex = rand.Next(TilemapManager.spawnPoints.Count);

                playerPositions.Add(TilemapManager.spawnPoints.ElementAt(randIndex), player);
                TilemapManager.spawnPoints.RemoveAt(randIndex);                
            }

            selectedUnit = playerUnits[0];
            playerSprite = Raylib.LoadTexture(selectedUnit.PlayerSpriteSrc);
        }

        public void Update()
        {
            // Get Selected Player
            if(Game.inputManager.LEFT_CLICK_LAST_FRAME)
            {
                foreach(var player in playerPositions)
                {
                    var mousePos = Raylib.GetScreenToWorld2D(Game.inputManager.mousePosition, camera);

                    if (MathUtils.RectangleContainsPoint(new Rectangle(player.Key.X, player.Key.Y, player.Value.SpriteSize.X,player.Value.SpriteSize.Y), mousePos))
                    {
                        ChangeSelectedUnit(player.Value);
                    }
                }
            }
        }

        public void Draw()
        {
            foreach(var player in playerPositions)
            {

                Rectangle source = new Rectangle(0, 0, 32, 32);
                Rectangle dest = new Rectangle(player.Key.X, player.Key.Y, 32, 32);
                Raylib.DrawTexturePro(playerSprite, source, dest, Vector2.Zero, 0f, Color.WHITE);
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
            foreach(var movementPositions in selectedUnit.Movement)
            {
                Rectangle moveTile = new Rectangle(selectedUnit.PlayerPosition.X + (movementPositions.X * selectedUnit.SpriteSize.X),
                    selectedUnit.PlayerPosition.Y + (movementPositions.Y * selectedUnit.SpriteSize.Y),
                    selectedUnit.SpriteSize.X, selectedUnit.SpriteSize.Y
                );

                foreach(var position in playerPositions)
                {
                    //Console.WriteLine(MathUtils.RectangleContainsPoint(moveTile, position.Key));
                    if (!MathUtils.RectangleContainsPoint(moveTile, position.Key))
                    {
                        Raylib.DrawRectangle((int)moveTile.x, (int)moveTile.y, (int)moveTile.width, (int)moveTile.height, Color.DARKGREEN);
                        //Console.WriteLine(position.Key);
                    }
                    else
                    {
                        Raylib.DrawRectangle((int)moveTile.x, (int)moveTile.y, (int)moveTile.width, (int)moveTile.height, Color.RED);
                    }
                }
                
            }
        }
    }
}
