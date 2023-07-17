using System;

namespace TacticsGame.Engine.Interfaces
{
    public interface IScene
    {
        /// <summary>
        /// Run startup scripts for the current scene (Setup tilemaps, player spawns, etc... )
        /// </summary>
        public void Initalize();
        /// <summary>
        /// Runs every frams to handle all game logic not pertaining to drawing on the screen
        /// </summary>
        public void Update();
        /// <summary>
        /// Draw method, run everyframe to draw images/textures to screen
        /// </summary>
        public void Draw();
    }
}

