using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class Magnet : Bonus
    {
        public Magnet(Vector2 position)
        {
            sprite = new Sprite(Bonus.txtMeat);
            this.position = position;
            sprite.SetPosition(this.position);
            sprite.SetSpriteSize(Values.MeatSpriteResolution);
        }

        public override void Update(GameTime gameTime)
        {
            this.position.X -=  Player.isOnLevelTwo ? Values.nextLevelSpeed : Values.platformsSpeed;

            sprite.SetPosition(this.position);
            sprite.SetRect((int)this.position.X, (int)this.position.Y, Values.MeatSpriteResolution, Values.MeatSpriteResolution);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            sprite.DrawStaticWithoutRect(spriteBatch);
        }
    }
}
