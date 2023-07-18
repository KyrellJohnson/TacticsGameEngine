using Raylib_cs;
using TacticsGame.Engine.Models;
using TacticsGame.Engine.Models.UIElements;

namespace TacticsGame.Source.UserInterface.Buttons
{
    public class GameStartButton : UIButton
    {
        public GameStartButton(IntVector2 position, IntVector2 size, Color color) : base(position, size, color)
        {
            
        }

        public GameStartButton(IntVector2 position, IntVector2 size, Color color, UIText text) : base(position, size, color, text)
        {
        }

        public new void OnClick()
        {
            Game.sceneManager.ChangeScene("Main");
        }
    }
}

