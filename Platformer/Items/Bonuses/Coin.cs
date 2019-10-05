using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class Coin : Bonus
    {
        public Coin(Vector2 position)
        {
            sprite = new Sprite(Bonus.txtCoin, Values.coinFrameSize, Values.coinTiles, Values.coinTimeSpan);
            this.position = position;
            sprite.SetPosition(this.position);
            sprite.SetSpriteSize(Values.FoodSpriteResolution);
        }

        public override void Update(GameTime gameTime)
        {
            if (Player.isUnderBonus)
            {
                if (this.position.X > Player.position.X)
                {
                    this.position.X -= Values.platformsSpeed * 2;
                }
                else if (this.position.X < Player.position.X)
                {
                    this.position.X += Values.platformsSpeed * 2;
                }

                if (this.position.Y > Player.position.Y + 10)
                {
                    this.position.Y -= 5;
                }
                else if (this.position.Y < Player.position.Y - 10)
                {
                    this.position.Y += 5;
                }
            }
            else
            {
                this.position.X -= Player.isOnLevelTwo ? Values.nextLevelSpeed : Values.platformsSpeed;
            }

            sprite.SetPosition(this.position);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.DrawAnimated(spriteBatch);
        }
    }
}
