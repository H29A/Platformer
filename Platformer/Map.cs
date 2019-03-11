using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Platformer
{
    public class Map
    {
        TimeManager timeManager;

        static public List<Platform> platforms = new List<Platform>();

        List<Sprite> sptBackground = new List<Sprite>();

        Texture2D txtSky;

        public Map()
        {
            timeManager = new TimeManager(Values.spawnPlatformTimeSpan);
        }

        public void LoadContent(ContentManager content)
        {
            txtSky = content.Load<Texture2D>(Values.sptSky);

            float offset = 0;
            for (int i = 0; i < 3; i++)
            {
                sptBackground.Add(new Sprite(txtSky, Values.skyFrameSize, Values.skyTiles, Values.skyTimeSpan));
                sptBackground[i].SetPosition(offset, sptBackground[i].Position.Y);
                offset += (float)Values.skyFrameSize.X;
            }

            Platform.texture = content.Load<Texture2D>(Values.txtPlatform);
        }

        public void UnloadContent () { }

        private void AddSkySprite()
        {
            sptBackground.Add(new Sprite(txtSky, Values.skyFrameSize, Values.skyTiles, Values.skyTimeSpan));
            sptBackground[sptBackground.Count - 1].SetPosition(
                sptBackground[sptBackground.Count - 2].Position.X + Values.skyFrameSize.X,
                0);
        }

        private bool IsSpriteBehindTheScreen(Sprite sprite)
        {
            if (sprite.Position.X + Values.skyFrameSize.X < 0)
            {
                return true;
            }

            return false;
        }

        private bool IsSpriteBeforeTheScreen(Sprite sprite)
        {
            if (sprite == sptBackground[sptBackground.Count - 1] &&
                sptBackground[sptBackground.Count - 1].Position.X + Values.skyFrameSize.X < Values.resolution.X)
            {
                return true;
            }

            return false;
        }

        private void MoveSprite(Sprite sprite)
        {
            sprite.SetPosition(sprite.Position.X - Values.platformsSpeed, sprite.Position.Y);
        }

        public void Update(GameTime gameTime)
        {
            timeManager.Update(gameTime);

            foreach (Sprite sprite in sptBackground.ToArray())
            {
                MoveSprite(sprite);

                if (IsSpriteBehindTheScreen(sprite))
                {
                    sptBackground.Remove(sprite);
                }

                if (IsSpriteBeforeTheScreen(sprite))
                {
                    AddSkySprite();
                }

                sprite.Update(gameTime);
            }

            if (platforms.Count == 0)
            {
                timeManager.StartTimer();
            }

            if (timeManager.IsTimeOver())
            {
                platforms.Add(new Platform());
                timeManager.CleanTimer();
                timeManager.StartTimer();
            }

            if (platforms.Count > 0)
            {
                foreach (Platform platform in platforms.ToArray())
                {
                    if (platform.Position.X + Platform.texture.Width < 0)
                    {
                        platforms.Remove(platform);
                    }
                    else
                    {
                        platform.Update(gameTime);
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite sky in sptBackground.ToArray())
            {
                sky.DrawAnimated(spriteBatch);
            }

            if (platforms.Count > 0)
            {
                foreach (Platform platform in platforms)
                {
                    platform.Draw(spriteBatch);
                }
            } 
        }
    }
}
