using System;
using System.Drawing;

namespace Scroll_Shooter_Asteroids
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        /// <summary>
        /// Базовый конструктор объекта
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        /// <summary>
        /// Вывод графики
        /// </summary>
        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
            //Image skin = Image.FromFile("torpedo.png");
            //Game.Buffer.Graphics.DrawImage(skin, Pos.X, Pos.Y, Size.Width, Size.Height);
            //
        }
        /// <summary>
        /// Метод описывает поведение объекта(меняет направление на обратное), если его координаты выходят за область игрового пространства
        /// </summary>
        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
    }
}
