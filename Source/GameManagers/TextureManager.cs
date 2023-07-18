using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacticsGame.Source.GameManagers
{
    public class TextureManager
    {
        public Texture2D playerSprite;
        public Texture2D movementTileSprite;
        public Texture2D nonMovementTileSprite;

        public TextureManager()
        {
            playerSprite = Raylib.LoadTexture("../../../Assets/Sprites/Player_Sprite.png");
            movementTileSprite = Raylib.LoadTexture("../../../Assets/Sprites/green_tile.png");
            nonMovementTileSprite = Raylib.LoadTexture("../../../Assets/Sprites/red_tile.png");
        }
        
    }
}
