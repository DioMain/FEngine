namespace Engine.Behaivors
{
    public class Camera : ObjectBehavior
    {
        public Camera() : base() { }

        public Vector2f GetScreenPosition(Vector2f position)
        {
            Vector2f halfScreenSize = new Vector2f(Runtime.WindowResolution.X / 2, Runtime.WindowResolution.Y / 2);

            Vector2f cameraPosition = SceneManager.MainCamera.MainObject.transform.Position;

            return new Vector2f(position.X - cameraPosition.X + halfScreenSize.X, -position.Y + cameraPosition.Y + halfScreenSize.Y);
        }
    }
}
