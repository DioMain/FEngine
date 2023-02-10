using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class InputManager
    {
        private static List<Keyboard.Key> KeysDown;
        private static List<Keyboard.Key> KeysUp;
        private static List<Keyboard.Key> KeysPressed;

        private static List<Mouse.Button> MouseDown;
        private static List<Mouse.Button> MouseUp;
        private static List<Mouse.Button> MousePressed;

        public static float MouseWheelDelta { get; private set; }
        public static bool MouseWheelTriggered { get; private set; }

        static InputManager()
        {
            KeysDown= new List<Keyboard.Key>();
            KeysUp = new List<Keyboard.Key>();
            KeysPressed = new List<Keyboard.Key>();

            MouseDown = new List<Mouse.Button>();
            MouseUp = new List<Mouse.Button>();
            MousePressed = new List<Mouse.Button>();
        }

        /// <summary>
        /// Runtime method [Не рекомендуется]
        /// </summary>
        public static void RegisterKey(Keyboard.Key key)
        {
            if (!KeysDown.Contains(key) && !KeysPressed.Contains(key))
            {
                KeysDown.Add(key);
                KeysPressed.Add(key);
            }
        }
        /// <summary>
        /// Runtime method [Не рекомендуется]
        /// </summary>
        public static void RegisterKey(Mouse.Button key)
        {
            if (!MouseDown.Contains(key) && !MousePressed.Contains(key))
            {
                MouseDown.Add(key);
                MousePressed.Add(key);
            }
        }

        /// <summary>
        /// Runtime method [Не рекомендуется]
        /// </summary>
        public static void UnregisterKey(Keyboard.Key key)
        {
            if (KeysPressed.Contains(key))
            {
                KeysPressed.Remove(key);
                KeysUp.Add(key);
            }         
        }
        /// <summary>
        /// Runtime method [Не рекомендуется]
        /// </summary>
        public static void UnregisterKey(Mouse.Button key)
        {
            if (MousePressed.Contains(key))
            {
                MousePressed.Remove(key);
                MouseUp.Add(key);
            }              
        }

        /// <summary>
        /// Runtime method [Не рекомендуется]
        /// </summary>
        public static void SetWheelDelta(float value)
        {
            MouseWheelDelta = value;

            MouseWheelTriggered = true;
        }

        /// <summary>
        /// Runtime method [Не рекомендуется]
        /// </summary>
        public static void UpdateKeys()
        {
            MouseDown.Clear();
            KeysDown.Clear();

            MouseUp.Clear();
            KeysUp.Clear();

            MouseWheelTriggered = false;
            MouseWheelDelta = 0;
        }

        public static bool GetKeyDown(Keyboard.Key key) => KeysDown.Contains(key);
        public static bool GetKeyUp(Keyboard.Key key) => KeysUp.Contains(key);
        public static bool GetKey(Keyboard.Key key) => KeysPressed.Contains(key);

        public static bool GetMouseDown(Mouse.Button key) => MouseDown.Contains(key);
        public static bool GetMouseUp(Mouse.Button key) => MouseUp.Contains(key);
        public static bool GetMouse(Mouse.Button key) => MousePressed.Contains(key);
    }
}
