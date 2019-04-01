using System.Drawing;

namespace Scroll_Shooter_Asteroids
{
    /// <summary>
    /// Интерфейс для опредления столкновения объектов
    /// </summary>
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
}
