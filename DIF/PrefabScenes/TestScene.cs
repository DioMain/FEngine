using System;
using Engine;
using Engine.Behaivors;

namespace Engine.PrefabScenes
{
    public class TestScene : Scene
    {
        public TestScene() : base() { Name = "TEST SCENE"; }

        public AppObject rect0;
        public AppObject rect1;

        public override void Start()
        {
            rect0 = SceneManager.CreateObject(new Vector2f(-50, -50));

            rect0.AddComponent<TestRectshape>();

            rect1 = SceneManager.CreateObject(new Vector2f(150, 150));

            rect1.AddComponent<TestRectshape>();

            base.Start();
        }

        public override void Update()
        {
            base.Update();

            if (InputManager.GetKeyDown(Keyboard.Key.F1))
            {
                foreach (var item in AppObjects)
                {
                    Log.SWriteLine(item.ToString());
                }
            }

            if (InputManager.GetKeyDown(Keyboard.Key.Right))
                SceneManager.MainCamera.MainObject.transform.Position =
                    new Vector2f(SceneManager.MainCamera.MainObject.transform.Position.X + 50, SceneManager.MainCamera.MainObject.transform.Position.Y);

            if (InputManager.GetKeyDown(Keyboard.Key.Left))
                SceneManager.MainCamera.MainObject.transform.Position =
                    new Vector2f(SceneManager.MainCamera.MainObject.transform.Position.X - 50, SceneManager.MainCamera.MainObject.transform.Position.Y);

            if (InputManager.GetKeyDown(Keyboard.Key.Up))
                SceneManager.MainCamera.MainObject.transform.Position =
                    new Vector2f(SceneManager.MainCamera.MainObject.transform.Position.X, SceneManager.MainCamera.MainObject.transform.Position.Y + 50);

            if (InputManager.GetKeyDown(Keyboard.Key.Down))
                SceneManager.MainCamera.MainObject.transform.Position =
                    new Vector2f(SceneManager.MainCamera.MainObject.transform.Position.X, SceneManager.MainCamera.MainObject.transform.Position.Y - 50);

            if (InputManager.GetKeyDown(Keyboard.Key.D))
                rect0.transform.Position = new Vector2f(rect0.transform.Position.X + 50, rect0.transform.Position.Y);

            if (InputManager.GetKeyDown(Keyboard.Key.A))
                rect0.transform.Position = new Vector2f(rect0.transform.Position.X - 50, rect0.transform.Position.Y);

            if (InputManager.GetKeyDown(Keyboard.Key.W))
                rect0.transform.Position = new Vector2f(rect0.transform.Position.X, rect0.transform.Position.Y + 50);

            if (InputManager.GetKeyDown(Keyboard.Key.S))
                rect0.transform.Position = new Vector2f(rect0.transform.Position.X, rect0.transform.Position.Y - 50);
        }

        public override void DrawUpdate()
        {
            base.DrawUpdate();
        }
    }
}
