using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class Platform
    {
        Vector2 position;
        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        static Texture2D texture;
        public Sprite sprite;

        Random random = new Random((int) DateTime.Now.Ticks);

        int generatedY;

        public Platform()
        {
            sprite = new Sprite(texture);

            do
            {
                generatedY = random.Next(100, 750);
            }
            while (!IsRangeNormal(generatedY));

            position = new Vector2(1024, generatedY);
        }

        private bool IsRangeNormal(int value)
        {
            if (Map.platforms.Count == 0)
            {
                return true;
            }
            else
            {
                foreach (Platform platform in Map.platforms)
                {
                    if (platform.Position.Y - Values.UpperPlatformSpawnValue < value && 
                        platform.Position.Y + Values.LowerPlatformSpawnValue > value && 
                        platform.position.X > Values.resolution.X - 1.5 * sprite.Width)
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }

        public static void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(Values.txtPlatform);
        }

        public void Update(GameTime gameTime)
        {
            position.X -= Values.platformsSpeed;
            sprite.SetPosition(position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.DrawStatic(spriteBatch);
        }
    }
}
