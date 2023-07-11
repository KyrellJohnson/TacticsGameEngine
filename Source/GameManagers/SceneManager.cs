using System;
using TacticsGame.Source.Interfaces;
using TacticsGame.Source.Scenes;

namespace TacticsGame.Source.GameManagers
{
    public class SceneManager
    {
        // Generate a list of all scenese within the game
        public List<IScene> allScenes = new List<IScene>();

        // Set Current Scene
        public IScene currentScene { get; set; }

        /// <summary>
        /// Scene Manager to keep track of all scenes within the game
        /// Will also set initital scene as the splash screen
        /// </summary>
        public SceneManager()
        {
            allScenes.Add(new SplashScreen());
            

            currentScene = allScenes.First();
        }


    }
}

