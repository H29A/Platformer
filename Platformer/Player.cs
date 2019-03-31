using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class Player
    {
        Timer jumpTimer;
        Timer fallTimer;

        string name = string.Empty;
        public string Name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }

        Vector2 position = Values.playerStartPosition;
        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        Sprite sptPlayer;
        Texture2D txtPlayer;

        bool isJumping;
        bool isFalling;

        public Player(string name)
        {
            jumpTimer = new Timer(Values.jumpTimeSpan);
            fallTimer = new Timer(Values.fallTimeSpan);

            this.name = name;
            isJumping = false;
        }

        public void LoadContent(ContentManager content)
        {
            txtPlayer = content.Load<Texture2D>(Values.sptPlayer);
            sptPlayer = new Sprite(txtPlayer, Values.playerFrameSize, Values.playerTiles, Values.playerTimeSpan);
            sptPlayer.SetPosition(position);
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime, InputManager inputManager)
        {
            jumpTimer.Update(gameTime);
            fallTimer.Update(gameTime);

            sptPlayer.SetPosition(position);
            sptPlayer.SetRect((int)position.X, (int)position.Y, (int)Values.playerFrameSize.X, (int)Values.playerFrameSize.Y);
            sptPlayer.Update(gameTime);

            foreach (Platform platform in Map.platforms)
            {
                Rectangle item = new Rectangle((int)platform.Position.X, (int)platform.Position.Y, Platform.texture.Width, Platform.texture.Height);
                if (sptPlayer.Rect.isOnTopOf(item))
                {
                    fallTimer.CleanTimer();
                    position.Y = item.Y - Values.playerFrameSize.Y;

                    if ((inputManager.KeyDown(Keys.Space) || inputManager.KeyDown(Keys.Up)) && !isJumping)
                    {
                        isJumping = true;
                        jumpTimer.StartTimer();
                    }
                }
                else 
                {
                    isFalling = true;
                }
            }

            if (jumpTimer.IsTimeOver() && isJumping)
            {
                jumpTimer.CleanTimer();
                isJumping = false;

                fallTimer.StartTimer();
            }

            if (isJumping)
            {
                position.Y -= jumpTimer.ResidualTime * Values.playerGravity + Values.playerJumpAcceleration;
            }

            if(isFalling)
            {
                if (!fallTimer.IsTimerStarted())
                {
                    fallTimer.StartTimer();
                }

                position.Y += fallTimer.ElapsedTime * Values.playerGravity;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sptPlayer.DrawAnimated(spriteBatch);
        }
    }
}
