using Engine;

namespace Engine.Behaivors
{
    public class TestRectshape : ObjectBehavior
    {
        private RectangleShape shape;

        public TestRectshape()
        {
            shape = new RectangleShape(new Vector2f(100, 100))
            {
                FillColor = Color.Green,
            };
        }

        public override void DrawUpdate()
        {
            base.DrawUpdate();

            shape.Position = SceneManager.MainCamera.GetScreenPosition(MainObject.transform.Position);

            //Console.WriteLine($"{MainObject.transform.Position.X}, {MainObject.transform.Position.Y}: " +
            //    $"{SceneManager.MainCamera.MainObject.transform.Position.X}, {SceneManager.MainCamera.MainObject.transform.Position.Y}");

            Runtime.Win.Draw(shape);
        }
    }
}
