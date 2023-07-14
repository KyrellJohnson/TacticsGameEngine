using System;
using TacticsGame.Engine.Interfaces;
using TacticsGame.Source.Scenes;

namespace TacticsGame.Source.GameManagers
{
    public class SceneManager
    {
        // Generate a list of all scenese within the game
        public static Dictionary<string, IScene> allScenes = new Dictionary<string, IScene>();

        // Set Current Scene
        public IScene currentScene { get; set; }

        /// <summary>
        /// Scene Manager to keep track of all scenes within the game
        /// Will also set initital scene as the splash screen
        /// </summary>
        public SceneManager()
        {
            allScenes.Add("Splash", new SplashScreen());
            allScenes.Add("Main", new MainGame());

            currentScene = allScenes["Splash"];
        }

        public void ChangeScene(string scene)
        {
            currentScene = allScenes[scene];
            currentScene.Initalize();
        }

        public string GetCurrentSceneName()
        {
            return allScenes.First(x => x.Value == currentScene).Key;
        }

    }
}

