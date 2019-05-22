using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class Coin : Bonus
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

        public Coin(Vector2 position)
        {
            sprite = new Sprite(Bonus.txtCoin, Values.coinFrameSize, Values.coinTiles, Values.coinTimeSpan);
            this.position = position;
            sprite.SetPosition(this.position);
            sprite.SetSpriteSize(Values.FoodSpriteResolution);
        }

        public void Update(GameTime gameTime)
        {
            this.position.X -= Values.platformsSpeed;
            sprite.SetPosition(this.position);
            sprite.SetRect((int)this.position.X, (int)this.position.Y, Values.FoodSpriteResolution, Values.FoodSpriteResolution);

            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.DrawAnimated(spriteBatch);
        }
    }
}
