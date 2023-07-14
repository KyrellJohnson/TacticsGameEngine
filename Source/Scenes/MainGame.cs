using System;
using TacticsGame.Source.GameManagers;
using TacticsGame.Source.Interfaces;

namespace TacticsGame.Source.Scenes
{
    public class MainGame : IScene
    {
        public MainGame()
        {
            DrawTileMap();
            TilemapManager n = new TilemapManager();
        }

        public void Draw()
        {
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

