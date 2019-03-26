using System.Drawing;

namespace Scroll_Shooter_Asteroids
{
    class Star : BaseObject
    {
        Image img = Image.FromFile("..\\..\\img\\clover.png");
        /// <summary>
        /// Наследуемый конструктор объекта Star
        /// </summary>
        /// <param name="pos">начальные координаты объекта</param>
        /// <param name="dir">направление движения объекта</param>
        /// <param name="size">размер объекта</param>
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        /// <summary>
        /// Переопределенный метод для отображения звезд
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos.X, Pos.Y, 16, 16);
            //--------------------------------------------------------
            //Game.Buffer.Graphics.DrawLine(Pens.Wheat, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            //Game.Buffer.Graphics.DrawLine(Pens.Blue, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }
        /// <summary>
        /// Переопределенный метод для логики движения объекта Star
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
