using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class Player
    {
        bool movingLeft;

        string name = string.Empty;
        public string Name
        {
            get { return Name; }
            set { Name = value; }
        }

        Vector2 position = Values.playerStartPosition;
        public Vector2 Position
        {
            get { return position; }
            private set { }
        }

        AnimationManager sptPlayer;

        public Player(string name)
        {
            this.name = name;
            sptPlayer = new AnimationManager(Values.sptPlayer, Values.playerFrameSize, Values.playerTiles);
            sptPlayer.Position = position;
        }

        private bool IsCollide(Texture2D sprite1, Texture2D sprite2, Rectangle player, Rectangle item)
        {
            Color[] colorData1 = new Color[sprite1.Width * sprite1.Height];
            Color[] colorData2 = new Color[sprite2.Width * sprite2.Height];
            sprite1.GetData<Color>(colorData1);
            sprite2.GetData<Color>(colorData2);

            int top, bottom, left, right;

            top = Math.Max(player.Top, item.Top);
            bottom = Math.Min(player.Bottom, item.Bottom);
            left = Math.Max(player.Left, item.Left);
            right = Math.Min(player.Right, item.Right);

            for(int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    Color A = colorData1[(y - player.Top) * (player.Width) + (x - player.Left)];
                    Color B = colorData2[(y - item.Top) * (item.Width) + (x - item.Left)];

                    if (A.A != 0 && B.A != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void LoadContent(ContentManager content)
        {
            sptPlayer.LoadContent(content);
        }

        public void UnloadContent()
        {
            
        }

        public void Update(GameTime gameTime, InputManager inputManager)
        {
            if (inputManager.KeyDown(Keys.Left) || inputManager.KeyDown(Keys.A))
            {
                position.X -= Values.playerStep;
                sptPlayer.Update(gameTime);
                movingLeft = true;
            }
            else 
            if (inputManager.KeyDown(Keys.Right) || inputManager.KeyDown(Keys.D))
            {
                position.X += Values.playerStep;
                sptPlayer.Update(gameTime);
                movingLeft = false;
            }

            if (inputManager.KeyDown(Keys.Space) || inputManager.KeyDown(Keys.Up))
            {
                position.Y -= Values.playerStep;
                sptPlayer.Update(gameTime);
            }

            sptPlayer.Position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (movingLeft)
            {
                sptPlayer.Draw(spriteBatch, SpriteEffects.FlipHorizontally);
            }
            else
            {
                sptPlayer.Draw(spriteBatch, 0);
            }
        }
    }
}
