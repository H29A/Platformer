using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        readonly Vector2 frameSize; //Размер фрейма X Y pixels
        readonly Point tilesMatrix; //Матрица

        Texture2D texture; //Спрайт
        public Texture2D Texture
        {
            get { return texture; }
            private set { }
        }

        Vector2 position; //Позиция анимации X Y coords

        Point currentFrame = new Point(0, 0); //Текущий кадр из матрицы
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

        public void Update(GameTime gameTime, Vector2 position)
        {
            this.position = position;

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

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
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
                    SpriteEffects.None,
                    0
               );
        }

        public void Draw(SpriteBatch spriteBatch)
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
                    SpriteEffects.None,
                    0
               );
        }
    }
}
