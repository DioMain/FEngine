using Engine.Behaivors;
using Engine.DefaultScenes;

namespace Engine
{
    public static class SceneManager
    {
        /// <summary>
        /// Не рекомендуется изменять в ручную
        /// </summary>
        public static Scene CurrentScene { get; private set; }

        public static Camera MainCamera
        {
            get
            {
                if (CurrentScene.AppObjects.Count == 0 ||
                    !CurrentScene.MainCameraObject.ComponentIsExist<Camera>())
                    throw new EngineException($"FATAL: На сцене отсутствует камера или её компонент!\nEngine[Scene: {CurrentScene.Name}]");

#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
                return CurrentScene.MainCameraObject.GetComponent<Camera>();
#pragma warning restore CS8603
            }
        }

        static SceneManager()
        {
            CurrentScene = new TempScene();
        }

        public static AppObject CreateObject()
        {
            AppObject obj = new AppObject($"AppObject{CurrentScene.AppObjects.Count}")
            {
                CurrentScene = CurrentScene
            };

            CurrentScene.AppObjects.Add(obj);

            return obj;
        }
        public static AppObject CreateObject(AppObject Original, bool CloneOtherTransform = false)
        {
            AppObject obj = (AppObject)Original.Clone();

            obj.CurrentScene = CurrentScene;

            if (!CloneOtherTransform)
            {
                obj.transform.Rotation = 0;
                obj.transform.Scale = new Vector2f(1, 1);
            }

            CurrentScene.AppObjects.Add(obj);

            return obj;
        }
        public static AppObject CreateObject(Vector2f position)
        {
            AppObject obj = new AppObject($"AppObject{CurrentScene.AppObjects.Count}")
            {
                CurrentScene = CurrentScene
            };

            obj.transform.Position = position;

            CurrentScene.AppObjects.Add(obj);

            return obj;
        }
        public static AppObject CreateObject(Vector2f position, AppObject Original, bool CloneOtherTransform = false)
        {
            AppObject obj = (AppObject)Original.Clone();

            obj.CurrentScene = CurrentScene;

            obj.transform.Position = position;

            if (!CloneOtherTransform)
            {
                obj.transform.Rotation = 0;
                obj.transform.Scale = new Vector2f(1, 1);
            }

            CurrentScene.AppObjects.Add(obj);

            return obj;
        }

        public static AppObject GetObjectByID(int ID)
        {
            if (ID < 0 || ID >= CurrentScene.AppObjects.Count)
            {
                Log.SWriteLine("Объект не найден!");
                Log.SWriteLine($"Scene[Name: {CurrentScene.Name}, ObjectID: {ID}]");
                return new AppObject();
            }
                
            return CurrentScene.AppObjects[ID];
        }
        public static AppObject GetObjectByName(string name)
        {
            foreach (var item in CurrentScene.AppObjects)
            {
                if (item.Name == name)
                    return item;
            }

            Log.SWriteLine("Объект не найден!");
            Log.SWriteLine($"Scene[Name: {CurrentScene.Name}, ObjectName: {name}]");
            return new AppObject();
        }
        public static AppObject[] GetObjectsByTag(string tag)
        {
            List<AppObject> list = new List<AppObject>();

            foreach (var item in CurrentScene.AppObjects)
            {
                if (item.Tag == tag)
                    list.Add(item);
            }

            return list.ToArray();
        }

        public static void ChangeScene(Scene newScene)
        {
            CurrentScene.OnSceneChange();

            CurrentScene = newScene;

            if (CurrentScene.AppObjects.Count == 0 ||
                !CurrentScene.MainCameraObject.ComponentIsExist<Camera>())
                throw new EngineException($"FATAL: На сцене отсутствует камера или её компонент!\nEngine[Scene: {CurrentScene.Name}]");

            CurrentScene.Start();
        }
    }
}
