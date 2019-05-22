using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public abstract class Bonus
    {
        public static Texture2D txtCoin;
        protected Sprite sprite;
        protected Vector2 position;

        public static void LoadContent(ContentManager content)
        {
            txtCoin = content.Load<Texture2D>(Values.sptCoin);
        }
    }
}
