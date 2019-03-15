using Microsoft.Xna.Framework.Input;

namespace Platformer
{
    public class InputManager
    {
        KeyboardState prevKeyState, keyState;

        public KeyboardState PrevKeyState
        {
            get
            {
                return prevKeyState;
            }
            set
            {
                prevKeyState = value;
            }
        }

        public KeyboardState KeyState
        {
            get
            {
                return keyState;
            }
            set
            {
                keyState = value;
            }
        }

        MouseState prevMouseState, mouseState;

        public MouseState PrevMouseState
        {
            get
            {
                return prevMouseState;
            }
            set
            {
                prevMouseState = value;
            }
        }

        public MouseState MouseState
        {
            get
            {
                return mouseState;
            }
            set
            {
                mouseState = value;
            }
        }

        public void Update()
        {
            prevKeyState = keyState;
            keyState = Keyboard.GetState();

            prevMouseState = mouseState;
            mouseState = Mouse.GetState();
        }

        public bool KeyPressed(Keys key)
        {
            if (keyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key))
                return true;
            return false;
        }

        public bool KeyPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (KeyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key))
                    return true;
            }
            return false;
        }

        public bool KeyReleased(Keys key)
        {
            if (keyState.IsKeyUp(key) && prevKeyState.IsKeyDown(key))
                return true;
            return false;
        }

        public bool KeyReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (KeyState.IsKeyUp(key) && prevKeyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }

        public bool KeyDown(Keys key)
        {
            if (keyState.IsKeyDown(key))
                return true;
            return false;
        }

        public bool KeyDown(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (keyState.IsKeyDown(key))
                    return true;
            }
            return false;
        }
    }
}
