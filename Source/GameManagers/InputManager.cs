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
        public bool RIGHT_CLICK_LAST_FRAME { get; private set; }

        public Vector2 mousePosition;
        public Vector2 mouseDelta;
        public float mouseWheel;

        KeyboardKey UpKey = KeyboardKey.KEY_W;
        KeyboardKey DownKey = KeyboardKey.KEY_S;
        KeyboardKey LeftKey = KeyboardKey.KEY_A;
        KeyboardKey RightKey = KeyboardKey.KEY_D;

        MouseButton leftClick = MouseButton.MOUSE_BUTTON_LEFT;
        MouseButton rightClick = MouseButton.MOUSE_BUTTON_RIGHT;

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


            if (Raylib.IsMouseButtonDown(leftClick))
                LEFT_CLICK_LAST_FRAME = true;
            else if (!Raylib.IsMouseButtonDown(leftClick))
                LEFT_CLICK_LAST_FRAME = false;

            if (Raylib.IsMouseButtonDown(rightClick))
                RIGHT_CLICK_LAST_FRAME = true;
            else if(!Raylib.IsMouseButtonDown(rightClick))
                RIGHT_CLICK_LAST_FRAME= false;

            mousePosition = Raylib.GetMousePosition();
            mouseDelta = Raylib.GetMouseDelta();
            mouseWheel = Raylib.GetMouseWheelMove();

        }

        public void ResetInput()
        {
            LEFT_CLICK_LAST_FRAME = false;
        }


    }
}

