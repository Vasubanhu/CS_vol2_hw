using System.Windows.Forms;

namespace Scroll_Shooter_Asteroids
{
    class Program
    {
        static void Main()
        {
            Form form = new Form()
            {
                Width = Screen.PrimaryScreen.Bounds.Width,
                Height = Screen.PrimaryScreen.Bounds.Height 
            };
            Game.Init(form);
            form.Show();
            Game.Load();
            Game.Draw();
            Application.Run(form);
        }
    }
}
