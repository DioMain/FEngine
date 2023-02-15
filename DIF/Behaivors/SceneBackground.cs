using Engine;
using Engine.Intefaces;
using SFML.Graphics;

namespace Engine.Behaivors
{
    internal class SceneBackground : ObjectBehavior, IRenderer
    {
        private RectangleShape _shape;
        
        public SceneBackground()
        {
            _shape = new RectangleShape((Vector2f)Runtime.WindowResolution);
        }

        public override void DrawUpdate()
        {
            if ((Vector2f)Runtime.WindowResolution != _shape.Size)
                _shape.Size = (Vector2f)Runtime.WindowResolution;

            if (_shape.FillColor != MainObject.CurrentScene.BackgroundColor)
                _shape.FillColor = MainObject.CurrentScene.BackgroundColor;

            Runtime.Win.Draw(_shape);
        }

        public Texture GetTexture() => _shape.Texture;
    }
}
