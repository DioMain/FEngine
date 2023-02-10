global using SFML.System;
global using SFML.Window;
global using SFML.Graphics;
using Engine.PrefabScenes;

namespace Engine
{
    public static class Runtime
    {
        //public static event Action Invoke;
        //public static event Action Update;
        //public static event Action DrawUpdate;
        //public static event Action LateUpdate;

        private static Vector2u realResolution;
        public static Vector2u WindowResolution { get => realResolution; set { } }

        public static ConfigData EngineConfig;

        public static RenderWindow Win;

        public static void Main()
        {
            // LOG INIT STATE
            Log logObject = new Log();

            logObject.DublicateToConsole = true;

            Log.SetInstance(logObject);

            // CONFIG LOAD STATE
            if (Configuration.IsHaveConfigFile && Configuration.ConfigFileIsCorrect)
            {
                EngineConfig = Configuration.ReadConfigFile() ?? Configuration.DEFCONFIG;
            }
            else
            {
                EngineConfig = Configuration.DEFCONFIG;
                Configuration.WriteConfigFile(Configuration.DEFCONFIG);

                Log.SWriteLine("Config file not found or uncorrect!");
            }

            logObject.DublicateToConsole = EngineConfig.AllowDublicateLogInConsole;

            try
            {
                // ENGINE INIT STATE
                realResolution = EngineConfig.Resolution;

                Win = new RenderWindow(new VideoMode(realResolution.X, realResolution.Y), EngineConfig.WindowName);

                if (!EngineConfig.VerticalSyncEnabled)
                    Win.SetFramerateLimit(EngineConfig.FrameRateLimit);

                Win.SetVerticalSyncEnabled(EngineConfig.VerticalSyncEnabled);

                Win.Closed += Win_Closed;
                Win.Resized += Win_Resized;
                Win.KeyPressed += Win_KeyPressed;
                Win.KeyReleased += Win_KeyReleased;
                Win.MouseButtonPressed += Win_MouseButtonPressed;
                Win.MouseButtonReleased += Win_MouseButtonReleased;
                Win.MouseWheelScrolled += Win_MouseWheelScrolled;

                // INVOKE STATE
                if (SceneManager.CurrentScene.Name == "TEMP")
                {
                    SceneManager.ChangeScene(new TestScene());
                }

                //Invoke?.Invoke();
                SceneManager.CurrentScene.Awake();

                // ENGINE WORK STATE
                while (Win.IsOpen)
                {
                    Win.DispatchEvents();

                    //Update?.Invoke();
                    SceneManager.CurrentScene.Update();

                    Win.Clear();

                    //DrawUpdate?.Invoke();
                    SceneManager.CurrentScene.DrawUpdate();

                    Win.Display();

                    //LateUpdate?.Invoke();
                    SceneManager.CurrentScene.LateUpdate();

                    InputManager.UpdateKeys();
                }
            }
            catch (EngineException Error)
            {
                Log.Instance.DublicateToConsole = false;

                Log.SWriteLine("Сбой работы движка!");
                Log.SWriteLine($"{Error.Message}");

                Win.Close();
            }
            catch (SystemException SysExc)
            {
                Log.Instance.DublicateToConsole = false;

                Log.SWriteLine("Системная ошибка!");
                Log.SWriteLine($"{SysExc.Message}");

                Win.Close();
            }
        }

        private static void Win_MouseWheelScrolled(object? sender, MouseWheelScrollEventArgs e)
        {
            InputManager.SetWheelDelta(e.Delta); 
        }
        private static void Win_MouseButtonReleased(object? sender, MouseButtonEventArgs e)
        {
            InputManager.UnregisterKey(e.Button);
        }
        private static void Win_MouseButtonPressed(object? sender, MouseButtonEventArgs e)
        {
            InputManager.RegisterKey(e.Button);
        }
        private static void Win_KeyReleased(object? sender, KeyEventArgs e)
        {
            InputManager.UnregisterKey(e.Code);
        }
        private static void Win_KeyPressed(object? sender, KeyEventArgs e)
        {
            InputManager.RegisterKey(e.Code);
        }
        private static void Win_Resized(object? sender, SizeEventArgs e)
        {
            if (!EngineConfig.AllowResize) Win.Size = realResolution;
        }
        private static void Win_Closed(object? sender, EventArgs e)
        {
            SceneManager.CurrentScene.OnExit();

            Win.Close();
        }
    }
}
