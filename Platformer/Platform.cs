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
            get { return position; }
        }

        static public Texture2D texture;

        Random random = new Random((int) DateTime.Now.Ticks);

        int generatedY;

        public Platform()
        {
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
                    if (platform.Position.Y - 100 < value && 
                        platform.Position.Y + 100 > value && 
                        platform.position.X > Values.resolution.X - 1.5 * texture.Width)
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }

        public static void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(Values.defaultTile);
        }

        public void Update(GameTime gameTime)
        {
            position.X -= Values.platformsSpeed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
