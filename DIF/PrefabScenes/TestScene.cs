using System;
using Engine;
using Engine.Behaivors;

namespace Engine.PrefabScenes
{
    public class TestScene : Scene
    {
        public TestScene() : base() { Name = "TEST SCENE"; BackgroundColor = new Color(100, 100, 100); }

        private AppObject obj0;
        private AppObject obj1;
        private AppObject obj2;

        public override void Start()
        {

            obj0 = SceneManager.CreateObject();

            obj0.AddComponent<BoxRenderer>();

            obj1 = SceneManager.CreateObject(new Vector2f(100, 100), obj0);

            obj1.GetComponent<BoxRenderer>().Color = Color.Red;

            obj2 = SceneManager.CreateObject(new Vector2f(-300, 150));

            obj2.AddComponent<CircleRenderer>();

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

            if (InputManager.GetKeyDown(Keyboard.Key.Hyphen))
                SceneManager.MainCamera.Size -= 0.1f;

            if (InputManager.GetKeyDown(Keyboard.Key.Add))
                SceneManager.MainCamera.Size += 0.1f;
        }

        public override void DrawUpdate()
        {
            base.DrawUpdate();
        }
    }
}
