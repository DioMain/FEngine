using Engine.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Behaivors
{
    public class BoxRenderer : ObjectBehavior, IRenderer
    {
        private RectangleShape box;

        public Color Color
        {
            get => box.FillColor;

            set => box.FillColor = value;
        }

        public Vector2f Size
        {
            get => box.Size;

            set => box.Size = value;
        }

        public BoxRenderer()
        {
            box = new RectangleShape(new Vector2f(100, 100))
            {
                FillColor = new Color(255, 0, 255)
            };
        }
        public BoxRenderer(Color color)
        {
            box = new RectangleShape(new Vector2f(100, 100))
            {
                FillColor = color
            };
        }

        public override void DrawUpdate()
        {
            box.Position = SceneManager.MainCamera.GetScreenPosition(MainObject.transform.Position);
            box.Rotation = MainObject.transform.Rotation ;
            box.Scale = MainObject.transform.Scale / SceneManager.MainCamera.Size;

            Runtime.Win.Draw(box);
        }

        public override object Clone()
        {
            BoxRenderer clone = new BoxRenderer(box.FillColor)
            {
                Size = box.Size
            };

            return clone;
        }

        public Texture GetTexture() => box.Texture;
    }
}
