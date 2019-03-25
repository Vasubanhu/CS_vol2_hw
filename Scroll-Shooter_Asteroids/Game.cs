using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scroll_Shooter_Asteroids
{
    /// <summary>
    /// Основный класс для описания действий игры
    /// </summary>
    class Game
    {
        public static BaseObject[] _objs;
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        /// <summary>
        /// Конструктор по умолчанию для класса Game
        /// </summary>
        static Game()
        {
        }
        /// <summary>
        /// Метод для инциализации события
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        /// <summary>
        /// Метод для иницализации игровой области
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            //Появление объектов в определенный интервал времени
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Метод для инициализации объектов в игровой области
        /// </summary>
        public static void Load()
        {
            Random r = new Random();

            _objs = new BaseObject[30];
            for (int i = 0; i < _objs.Length/2; i++)
            {
                _objs[i] = new BaseObject(new Point(300, 15 - i), new Point(-i, -i), new Size(32, 32));
            }
                
            for (int i = _objs.Length/4; i < _objs.Length; i++)
            {               
                _objs[i] = new Star(new Point(500 * r.Next(1,5), i * r.Next(20, 25)), new Point(-i, 0), new Size(5, 5));
            }
               
        }
        /// <summary>
        /// Вывод графики 
        /// </summary>
        public static void Draw()
        {
            // Проверяем вывод графики
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            //Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
            obj.Draw();
            Buffer.Render();
        }
        /// <summary>
        /// Метод для изменения состояния объектов
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
    }
}
