using Engine.Intefaces;

namespace Engine.Behaivors
{
    public class CircleRenderer : ObjectBehavior, IRenderer
    {
        private CircleShape circle;

        public Color Color
        {
            get => circle.FillColor;

            set => circle.FillColor = value;
        }

        public float Radius
        {
            get => circle.Radius;

            set => circle.Radius = value;
        }

        public CircleRenderer()
        {
            circle = new CircleShape(50)
            {
                FillColor = new Color(255, 0, 255)
            };
        }
        public CircleRenderer(Color color)
        {
            circle = new CircleShape(50)
            {
                FillColor = color
            };
        }
        public CircleRenderer(Color color, float radius)
        {
            circle = new CircleShape(radius)
            {
                FillColor = color
            };
        }

        public override void DrawUpdate()
        {
            circle.Position = SceneManager.MainCamera.GetScreenPosition(MainObject.transform.Position);
            circle.Scale = MainObject.transform.Scale / SceneManager.MainCamera.Size;
            circle.Rotation = MainObject.transform.Rotation;

            Runtime.Win.Draw(circle);
        }

        public override object Clone()
        {
            CircleRenderer clone = new CircleRenderer(Color, Radius);

            return clone;
        }

        public Texture GetTexture() => circle.Texture;
    }
}
