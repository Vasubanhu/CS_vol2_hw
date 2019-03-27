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
        private static Asteroid[] _asteroids;
        private static Bullet _bullet;
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
            Update();
            Draw();          
        }
        /// <summary>
        /// Метод для иницализации игровой области
        /// </summary>
        /// <param name="form">получение формы</param>
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
            //Появление объектов в определенный интервал времени
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;

            Load();
        }
        /// <summary>
        /// Метод для инициализации объектов в игровой области
        /// </summary>
        public static void Load()
        {
            _objs = new BaseObject[30];
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            _asteroids = new Asteroid[3];
            Random rnd = new Random();

            for (int i = 0; i < _objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Star(new Point(1000, rnd.Next(0, Height)), new Point(-r, r), new Size(3, 3));
            }

            for (int i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids[i] = new Asteroid(new Point(1000, rnd.Next(0, Height)), new Point(-r / 5, r), new Size(r, r));
            }
        }
        /// <summary>
        /// Вывод графики 
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (BaseObject ast in _asteroids)
                ast.Draw();
            _bullet.Draw();
            Buffer.Render();
        }
        /// <summary>
        /// Метод для изменения состояния объектов
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            foreach (BaseObject ast in _asteroids)
                ast.Update();
            _bullet.Update();
        }
    }
}
