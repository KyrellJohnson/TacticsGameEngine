using System;
using TacticsGame.Source.GameManagers;
using TacticsGame.Source.Interfaces;

namespace TacticsGame.Source.Scenes
{
    public class MainGame : IScene
    {
        TilemapManager tileMap;

        public MainGame()
        {
            DrawTileMap();
            tileMap = new TilemapManager();
        }

        public void Draw()
        {
           // tileMap.DrawTileMap();
            //throw new NotImplementedException();
        }

        public void Update()
        {
            //throw new NotImplementedException();
        }

        public void DrawTileMap()
        {
            // Load In Tilemaps


        }
    }
}

