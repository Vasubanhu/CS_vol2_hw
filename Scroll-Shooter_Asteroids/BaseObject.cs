using System.Drawing;

namespace Scroll_Shooter_Asteroids
{
    /// <summary>
    /// Общий класс для объектов
    /// </summary>
    abstract class BaseObject : ICollision 
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        /// <summary>
        /// Базовый конструктор объекта
        /// </summary>
        /// <param name="pos">начальные координаты объекта</param>
        /// <param name="dir">направление движения объекта</param>
        /// <param name="size">размер объекта</param>
        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        /// <summary>
        /// Абстрактный метод для вывода графики
        /// </summary>
        public abstract void Draw();
        /// <summary>
        /// Метод описывает поведение объекта(меняет направление на обратное), если его координаты выходят за область игрового пространства
        /// </summary>
        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }

        public Rectangle Rect => new Rectangle(Pos, Size);
        /// <summary>
        /// Реализация проверки пересечения объектов
        /// </summary>
        /// <param name="o">принимает в качестве параметра объект</param>
        /// <returns></returns>
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
    }
}
