using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AStar;
using Raylib_cs;
using TacticsGame.Engine.Models;
using TacticsGame.Engine.Utilities;
using TacticsGame.Source.Entities.Models;
using TacticsGame.Source.Scenes;

namespace TacticsGame.Source.GameManagers
{
    public class LevelManager
    {
        PlayerUnit[]? playerUnits;
        PlayerUnit selectedUnit;

        Dictionary<Vector2, PlayerUnit> playerPositions;
        List<Vector2> spawnPoints;
        short[,] grid;
        short[,] gridCopy;
        public List<Vector2> colliderPos;

        public Camera2D camera;

        public LevelManager()
        {
            spawnPoints = new List<Vector2>();
            playerPositions = new Dictionary<Vector2, PlayerUnit>();
            selectedUnit = new PlayerUnit();
        }

        public void Initalize(List<Vector2> spawnPoints, short[,] grid, List<Vector2> colliderPositions)
        {

            this.spawnPoints = spawnPoints;
            this.grid = grid;
            this.colliderPos = colliderPositions;

            // Get All Current Player Units
            playerUnits = new PlayerUnit[] {
                new PlayerUnit(name: "Unit1", new SpriteSize(32,32)),
            };

            // Set Spawn Locations For Player Units
            foreach (var player in playerUnits)
            {

                // find a random spanPoint
                Random rand = new Random();
                int randIndex = rand.Next(spawnPoints.Count);

                playerPositions.Add(spawnPoints.ElementAt(randIndex), player);
                spawnPoints.RemoveAt(randIndex);
            }

            selectedUnit = playerUnits[0];


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
            gridCopy = (short[,])grid.Clone();

            foreach (var player in playerPositions)
            {

                Rectangle source = new Rectangle(0, 0, 32, 32);
                Rectangle dest = new Rectangle(player.Key.X, player.Key.Y, 32, 32);
                Raylib.DrawTexturePro(player.Value.PlayerSprite, source, dest, Vector2.Zero, 0f, Color.WHITE);
                player.Value.PlayerPosition = new IntVector2(dest.x, dest.y);
                var a = (int)(dest.y / selectedUnit.SpriteSize.X);
                var b = (int)(dest.x / selectedUnit.SpriteSize.Y);


                gridCopy[(int)(dest.y / selectedUnit.SpriteSize.X), (int)dest.x / selectedUnit.SpriteSize.Y] = 0;
            }

            for (int i = 0; i < selectedUnit.Movement.Count; i++)
            {

                var arrPos2 = selectedUnit.PlayerPosition.X + (selectedUnit.Movement.ElementAt(i).X * selectedUnit.SpriteSize.X);

                var arrPos1 = selectedUnit.PlayerPosition.Y + (selectedUnit.Movement.ElementAt(i).Y * selectedUnit.SpriteSize.Y);

                var x = (selectedUnit.PlayerPosition.X + (selectedUnit.Movement.ElementAt(i).X * selectedUnit.SpriteSize.X));
                var y = selectedUnit.PlayerPosition.Y + (selectedUnit.Movement.ElementAt(i).Y * selectedUnit.SpriteSize.Y);

                if (!MathUtils.PointInListOfPoint(new Vector2(selectedUnit.PlayerPosition.X + (selectedUnit.Movement.ElementAt(i).X * selectedUnit.SpriteSize.X), selectedUnit.PlayerPosition.Y + (selectedUnit.Movement.ElementAt(i).Y * selectedUnit.SpriteSize.Y)), colliderPos))
                {
                    gridCopy[arrPos1 / selectedUnit.SpriteSize.X, arrPos2 / selectedUnit.SpriteSize.Y] = 0;

                }

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
            Vector2[] colliderPositions = colliderPos.ToArray();

            for (int i = 0; i < selectedUnit.Movement.Count; i++)
            {
                Rectangle moveTile = new Rectangle(selectedUnit.PlayerPosition.X + (selectedUnit.Movement.ElementAt(i).X * selectedUnit.SpriteSize.X),
                    selectedUnit.PlayerPosition.Y + (selectedUnit.Movement.ElementAt(i).Y * selectedUnit.SpriteSize.Y),
                    selectedUnit.SpriteSize.X, selectedUnit.SpriteSize.Y
                );




                Rectangle src = new Rectangle(0, 0, 32, 32);

                Vector2 s = new Vector2((int)moveTile.x, (int)moveTile.y);
                Vector2 e = new Vector2(selectedUnit.PlayerPosition.X, selectedUnit.PlayerPosition.Y);


                Position[] nPoints = Pathfinding.FindPath(gridCopy,start: s, end: e);

                if(nPoints == null)
                {
                    Console.WriteLine('0');
                }

                if (!MathUtils.RectangleContainsListOfPoints(moveTile, currentPlayerPositions) && !MathUtils.RectangleContainsListOfPoints(moveTile, colliderPositions) && nPoints != null)
                {
                    Raylib.DrawTexturePro(Game.textureManager.movementTileSprite, src, moveTile, Vector2.Zero, 0f, Color.WHITE);
                }
                else
                {
                    //Raylib.DrawTexturePro(Game.textureManager.nonMovementTileSprite, src, moveTile, Vector2.Zero, 0f, Color.WHITE);

                }

                if (moveTile.x / 32 == 15 && moveTile.y / 32 == 19)
                {
                    foreach (var n in nPoints)
                    {
                        Raylib.DrawRectangle((int)n.Row * 32, (int)n.Column * 32, (int)moveTile.width, (int)moveTile.height, Color.PINK);
                    }

                }


            }

            //for (int i = 0; i < gridCopy.GetLength(0); i++)
            //{
            //    for (int j = 0; j < gridCopy.GetLength(1); j++)
            //    {
            //        Console.Write(gridCopy[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}


        }


    }
}

