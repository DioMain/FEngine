using Engine.Behaivors;

namespace Engine
{
    public class AppObject : ICloneable
    {
        public Scene? CurrentScene { get; set; }

        private bool isActive;
        public bool IsActive
        {
            get => isActive; 

            set
            {
                if (value) OnEnable();

                isActive = value;
            }
        }

        public int ID
        {
            get
            {
                if (CurrentScene == null) return -1;

                for (int i = 0; i < CurrentScene.AppObjects.Count; i++)
                {
                    if (CurrentScene.AppObjects[i] == this) 
                        return i;
                }

                return -1;
            }
        }

        public string Name { get; set; }
        public string Tag { get; set; }

        private List<ObjectBehavior> Components;

        public Behaivors.Transform transform { get => (Behaivors.Transform)Components[0]; }

        /// <summary>
        /// [Не рекомендуется, используйте SceneManager.CreateObject()]
        /// </summary>
        public AppObject()
        {
            CurrentScene = null;

            Name = "Object name";
            Tag = "Object";

            Components = new List<ObjectBehavior>();

            IsActive = true;

            AddComponent<Behaivors.Transform>();
        }
        /// <summary>
        /// [Не рекомендуется, используйте SceneManager.CreateObject()]
        /// </summary>
        public AppObject(string name)
        {
            CurrentScene = null;

            Name = name;
            Tag = "Object";

            Components = new List<ObjectBehavior>();

            IsActive = true;

            AddComponent<Behaivors.Transform>();
        }

        public void Awake()
        {
            foreach (var item in Components)
                if (item.IsEnabled) item.Awake();
        }
        public void Start()
        {
            foreach (var item in Components)
                if (item.IsEnabled) item.Start();
        }
        public void OnEnable()
        {
            foreach (var item in Components)
                if (item.IsEnabled) item.OnEnable();
        }
        public void Update()
        {
            foreach (var item in Components)
                if (item.IsEnabled) item.Update();
        }
        public void DrawUpdate()
        {
            foreach (var item in Components)
                if (item.IsEnabled) item.DrawUpdate();
        }
        public void LateUpdate()
        {
            foreach (var item in Components)
                if (item.IsEnabled) item.LateUpdate();
        }
        public void OnExit()
        {
            foreach (var item in Components)
                if (item.IsEnabled) item.OnExit();
        }
        public void OnSceneChange()
        {
            foreach (var item in Components)
                if (item.IsEnabled) item.OnSceneChange();
        }

        public bool ComponentIsExist<T>() where T : ObjectBehavior
        {
            foreach (var item in Components)
            {
                if (item is T)
                    return true;
            }

            return false;
        }

        public void AddComponent<T>() where T : ObjectBehavior, new()
        {
            if (ComponentIsExist<T>())
            {
                Log.SWriteLine("Обнаружена попытка добавить более одного компонента одного типа!");
                Log.SWriteLine($"AppObject[Scene: {CurrentScene.Name}, ID: {ID}, Name: {Name}, Tag: {Tag}, Type: {typeof(T).Name}];");
                return; 
            }

            Components.Add(new T() { MainObject = this });
        }
        public void AddComponent<T>(T value) where T : ObjectBehavior
        {
            if (ComponentIsExist<T>())
            {
                Log.SWriteLine("Обнаружена попытка добавить более одного компонента одного типа!");
                Log.SWriteLine($"AppObject[Scene: {CurrentScene.Name}, ID: {ID}, Name: {Name}, Tag: {Tag}, Type: {typeof(T).Name}]];");
                return;
            }

            value.MainObject = this;

            Components.Add(value);
        }

        public T? GetComponent<T>() where T : ObjectBehavior
        {
            for (int i = 0; i < Components.Count; i++)
            {
                if (Components[i] is T)
                    return Components[i] as T;
            }

            return null;
        }

        public void RemoveComponent<T>() where T : ObjectBehavior
        {
            if (!ComponentIsExist<T>())
            {
                Log.SWriteLine("Обнаружена попытка удалить не существующий компонент!");
                Log.SWriteLine($"AppObject[Scene: {CurrentScene.Name}, ID: {ID}, Name: {Name}, Tag: {Tag}];");
                return;
            }

            for (int i = 0; i < Components.Count; i++)
            {
                if (Components[i] is T)
                {
                    Components.Remove(Components[i]);
                    break;
                } 
            }
        }

        public object Clone()
        {
            AppObject copy = new AppObject(Name)
            {
                Tag = Tag,
                Components = new List<ObjectBehavior>()
            };

            for (int i = 0; i < Components.Count; i++)
            {
                copy.Components.Add((ObjectBehavior)Components[i].Clone());
                copy.Components[i].MainObject = copy;
            }

            return copy;
        }

        public override string ToString()
        {
            string str = $"{ID}. Name: {Name}, Tag: {Tag}, Scene: {CurrentScene?.Name}\n[";

            for (int i = 0; i < Components.Count; i++)
                str += $"{Components[i].GetType().Name}" + (i != Components.Count - 1 ? ":" : "");

            return str + "]";
        }
    }
}
