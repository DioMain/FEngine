using Engine;

namespace Engine.Behaivors
{
    public class Transform : ObjectBehavior
    {
        public Vector2f Position { get; set; }
        public float Rotation { get; set; }
        public Vector2f Scale { get; set; }

        public Transform() : base()
        {
            Position = new Vector2f(0, 0);
            Rotation = 0;
            Scale = new Vector2f(1, 1);
        }

        public override object Clone()
        {
            Transform clone = new Transform()
            {
                Position = Position,
                Rotation = Rotation,
                Scale = Scale
            };

            return clone;
        }
    }
}
