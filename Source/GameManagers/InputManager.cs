using System;
using System.Numerics;
using Raylib_cs;

namespace TacticsGame.Source.GameManagers
{
    public class InputManager
    {
        public bool LEFT_ACTION_KEY_PRESSED { get; private set; }
        public bool RIGHT_ACTION_KEY_PRESSED { get; private set; }
        public bool UP_ACTION_KEY_PRESSED { get; private set; }
        public bool DOWN_ACTION_KEY_PRESSED { get; private set; }

        public bool LEFT_CLICK_LAST_FRAME { get; private set; }

        public Vector2 mousePosition;

        KeyboardKey UpKey = KeyboardKey.KEY_W;
        KeyboardKey DownKey = KeyboardKey.KEY_S;
        KeyboardKey LeftKey = KeyboardKey.KEY_A;
        KeyboardKey RightKey = KeyboardKey.KEY_D;

        MouseButton leftClick = MouseButton.MOUSE_BUTTON_LEFT;

        public void GetAllInput()
        {
            if (Raylib.IsKeyDown(UpKey))
                UP_ACTION_KEY_PRESSED = true;
            else
                UP_ACTION_KEY_PRESSED = false;

            if (Raylib.IsKeyDown(DownKey))
                DOWN_ACTION_KEY_PRESSED = true;
            else
                DOWN_ACTION_KEY_PRESSED = false;

            if (Raylib.IsKeyDown(LeftKey))
                LEFT_ACTION_KEY_PRESSED = true;
            else
                LEFT_ACTION_KEY_PRESSED = false;

            if (Raylib.IsKeyDown(RightKey))
                RIGHT_ACTION_KEY_PRESSED = true;
            else
                RIGHT_ACTION_KEY_PRESSED = false;

            mousePosition = Raylib.GetMousePosition();

            if (Raylib.IsMouseButtonPressed(leftClick))
                LEFT_CLICK_LAST_FRAME = true;
            
        }

        public void ResetInput()
        {
            LEFT_CLICK_LAST_FRAME = false;
        }


    }
}

