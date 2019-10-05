using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public abstract class Bonus
    {
        public Sprite Sprite
        {
            get
            {
                return sprite;
            }
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        protected Sprite sprite;
        protected Vector2 position;

        public static Texture2D txtCoin;
        public static Texture2D txtMeat;

        public static void LoadContent(ContentManager content)
        {
            txtCoin = content.Load<Texture2D>(Values.sptCoin);
            txtMeat = content.Load<Texture2D>(Values.txtMeat);
        }

        public virtual void Update(GameTime gameTime)
        {
            sprite.SetRect((int)this.position.X, (int)this.position.Y, Values.FoodSpriteResolution, Values.FoodSpriteResolution);
            sprite.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
