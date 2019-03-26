using System.Drawing;

namespace Scroll_Shooter_Asteroids 
{
    /// <summary>
    /// Класс для реализации игрового объекта Asteroid
    /// </summary>
    class Asteroid : BaseObject
    {
        public int Power { get; set; }
        /// <summary>
        /// Наследуемый конструктор объекта Asteroid
        /// </summary>
        /// <param name="pos">начальные координаты объекта</param>
        /// <param name="dir">направление движения объекта</param>
        /// <param name="size">размер объекта</param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }
        /// <summary>
        /// Переопределенный метод для отображения объекта Asteroid
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
    }
}
