using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

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

        List<Bonus> bonuses;
        List<Bonus> Bonuses
        {
            get
            {
                return bonuses;
            }
        }

        Player player;

        public Platform(Player playerObj)
        {
            sprite = new Sprite(texture);

            do
            {
                generatedY = random.Next(100, 750);
            }
            while (!IsRangeNormal(generatedY));

            position = new Vector2(1024, generatedY);
            sprite.SetPosition(position);
            sprite.SetScale(random.Next(Values.LowerPlatformGenerationWidth, Values.UpperPlatformGenerationWidth) / 100f, 1);

            GenerateBonuses();

            player = playerObj;
        }

        public bool NextBool(Random random, int truePercentage = 50)
        {
            return random.NextDouble() < truePercentage / 100.0;
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

        private void GenerateBonuses()
        {
            bonuses = new List<Bonus>();

            int maxSlotsCount = (int)(sprite.Width / Values.FoodSpriteResolution);
            Vector2 slot = new Vector2(position.X * 1.05f, position.Y - sprite.Height * 3f);

            for (int i = 0; i < maxSlotsCount; i++)
            {
                if (NextBool(random, 35))
                {
                    bonuses.Add(new Coin(slot));
                }

                slot = new Vector2(slot.X + Values.FoodSpriteResolution, slot.Y);
            }
        }

        public void Update(GameTime gameTime)
        {
            position.X -= Values.platformsSpeed;
            sprite.SetPosition(position);

            if (bonuses.Count > 0)
            {
                foreach (Coin bonus in bonuses.ToArray())
                {
                    bonus.Update(gameTime);

                    if (Player.sptPlayer.Rect.Intersects(bonus.Sprite.Rect))
                    {
                        bonuses.Remove(bonus);
                        player.IncCoinCount();
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.DrawStatic(spriteBatch);

            if (bonuses.Count > 0)
            {
                foreach (Coin bonus in bonuses)
                {
                    bonus.Draw(spriteBatch);
                }
            }
        }
    }
}
