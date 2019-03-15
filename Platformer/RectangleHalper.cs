using Microsoft.Xna.Framework;

namespace Platformer
{
    static class RectangleHalper
    {
        public static bool isOnTopOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Bottom >= r2.Top - 5 &&
                r1.Bottom <= r2.Top + 5 &&
                r1.Right >= r2.Left + 3 &&
                r1.Left <= r2.Right - 3);
        }
    }
}
