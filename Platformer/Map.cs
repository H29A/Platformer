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

        List<AnimationManager> sptBackground = new List<AnimationManager>();

        Texture2D sptSky;

        public Map()
        {
            timeManager = new TimeManager(Values.newPlatformTiming);
        }

        public void LoadContent(ContentManager content)
        {
            sptSky = content.Load<Texture2D>(Values.sptSky);

            int offset = 0;
            for (int i = 0; i < 3; i++)
            {
                sptBackground.Add(new AnimationManager(Values.skyFrameSize, Values.skyTiles));
                sptBackground[i].Position = new Vector2(offset, sptBackground[i].Position.Y);
                offset += (int)Values.skyFrameSize.X;
            }
               
            Platform.texture = content.Load<Texture2D>(Values.txtPlatform);
        }

        public void UnloadContent () { }

        private void AddSkySprite()
        {
            sptBackground.Add(new AnimationManager(Values.skyFrameSize, Values.skyTiles));
            sptBackground[sptBackground.Count - 1].Position = new Vector2
                (
                    sptBackground[sptBackground.Count - 2].Position.X + Values.skyFrameSize.X,
                    0
                );
        }

        private bool IsSpriteBehindTheScreen(AnimationManager sprite)
        {
            if (sprite.Position.X + Values.skyFrameSize.X < 0)
            {
                return true;
            }

            return false;
        }

        private bool IsSpriteBeforeTheScreen(AnimationManager sprite)
        {
            if (sprite == sptBackground[sptBackground.Count - 1] &&
                sptBackground[sptBackground.Count - 1].Position.X + Values.skyFrameSize.X < Values.resolution.X)
            {
                return true;
            }

            return false;
        }

        private void MoveSprite(AnimationManager sprite)
        {
            sprite.Position = new Vector2(sprite.Position.X - Values.platformsSpeed, sprite.Position.Y);
        }

        public void Update(GameTime gameTime)
        {
            timeManager.Update(gameTime);

            foreach (AnimationManager currentSprite in sptBackground.ToArray())
            {
                MoveSprite(currentSprite);

                if (IsSpriteBehindTheScreen(currentSprite))
                {
                    sptBackground.Remove(currentSprite);
                }

                if (IsSpriteBeforeTheScreen(currentSprite))
                {
                    AddSkySprite();
                }

                currentSprite.Update(gameTime);
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
            foreach (AnimationManager sky in sptBackground.ToArray())
            {
                sky.Draw(spriteBatch, sptSky, 0);
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
