namespace Engine.Behaivors
{
    public class Camera : ObjectBehavior
    {
        private float size;
        public float Size
        {
            get => size; 
            set => size = value < 0.1f ? 0.1f : value;
        }

        public Camera() : base()
        {
            size = 1f;
        }

        public Vector2f GetScreenPosition(Vector2f position)
        {
            Vector2f halfScreenSize = new Vector2f(Runtime.WindowResolution.X / 2, Runtime.WindowResolution.Y / 2);

            Vector2f cameraPosition = SceneManager.MainCamera.MainObject.transform.Position;

            return new Vector2f((position.X - cameraPosition.X) / Size + halfScreenSize.X, 
                                (-position.Y + cameraPosition.Y) / Size + halfScreenSize.Y);
        }

        public Vector2f GetScreenScale(Vector2f scale)
        {
            return new Vector2f();
        }
    }
}
