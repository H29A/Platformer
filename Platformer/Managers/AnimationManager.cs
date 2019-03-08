using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class AnimationManager
    {
        int timeSinceLastFrame = 0;
        int millisecondsPerFrame = 80;

        readonly string path;
        readonly Vector2 frameSize;
        readonly Point tilesMatrix;

        Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }


        Texture2D texture;
        public Texture2D Texture
        {
            get { return texture; }
            private set { }
        }

        Point currentFrame = new Point(0, 0);
        public Point CurrentFrame
        {
            get { return currentFrame; }
            private set { }
        }

        public AnimationManager(string path, Vector2 frameSize, Point tilesMatrix)
        {
            this.path = path;
            this.frameSize = frameSize;
            this.tilesMatrix = tilesMatrix;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(path);
        }

        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                ++currentFrame.X;
                if (currentFrame.X >= tilesMatrix.X)
                {
                    currentFrame.X = 0;
                    ++currentFrame.Y;
                    if (currentFrame.Y >= tilesMatrix.Y)
                        currentFrame.Y = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteEffects direction)
        {
            spriteBatch.Draw
                (
                    this.texture,
                    new Vector2(position.X, position.Y),
                    new Rectangle
                        (
                            Convert.ToInt32(currentFrame.X * frameSize.X),
                            Convert.ToInt32(currentFrame.Y * frameSize.Y),
                            Convert.ToInt32(frameSize.X),
                            Convert.ToInt32(frameSize.Y)
                        ),
                    Color.White,
                    0,
                    Vector2.Zero,
                    1,
                    direction,
                    0
               );
        }
    }
}
