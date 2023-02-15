using Engine.Behaivors;

namespace Engine
{
    public class Scene
    {
        public string Name { get; set; }

        public Color BackgroundColor { get; set; }

        public AppObject MainCameraObject { get => AppObjects[0]; }

        public List<AppObject> AppObjects;

        public Scene()
        {
            AppObjects = new List<AppObject>();

            BackgroundColor = Color.Black;

            Name = "NONAME_SCENE";

            CreateCamera();
        }

        public void CreateCamera()
        {
            AppObject obj = new AppObject("Camera")
            {
                Tag = "Camera",
                CurrentScene = this
            };

            obj.AddComponent<Camera>();
            obj.AddComponent<SceneBackground>();

            AppObjects.Add(obj);
        }

        public virtual void Awake()
        {
            foreach (var item in AppObjects)
                if (item.IsActive) item.Awake();
        }
        public virtual void Start()
        {
            foreach (var item in AppObjects)
                if (item.IsActive)  item.Start();
        }
        public virtual void Update()
        {
            foreach (var item in AppObjects)
                if (item.IsActive)  item.Update();
        }
        public virtual void DrawUpdate()
        {
            foreach (var item in AppObjects)
                if (item.IsActive)  item.DrawUpdate();
        }
        public virtual void LateUpdate()
        {
            foreach (var item in AppObjects)
                if (item.IsActive) item.LateUpdate();
        }
        public virtual void OnExit()
        {
            foreach (var item in AppObjects)
                if (item.IsActive) item.OnExit();
        }
        public virtual void OnSceneChange()
        {
            foreach (var item in AppObjects)
                if (item.IsActive) item.OnSceneChange();
        }
    }
}
