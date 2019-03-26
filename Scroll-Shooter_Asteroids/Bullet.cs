using System.Drawing;

namespace Scroll_Shooter_Asteroids
{
    /// <summary>
    /// Класс для реализации игрового объекта Bullet
    /// </summary>
    class Bullet : BaseObject
    {
        /// <summary>
        /// Наследуемый конструктор объекта Bullet
        /// </summary>
        /// <param name="pos">начальные координаты объекта</param>
        /// <param name="dir">направление движения объекта</param>
        /// <param name="size">размер объекта</param>
        public Bullet (Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        /// <summary>
        /// Переопределенный метод для отображения объекта Bullet
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// Переопределенный метод для логики движения объекта Bullet
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + 3; 
        }
    }
}
