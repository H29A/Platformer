using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class Player
    {
        TimeManager timeManager;

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

        Sprite sptPlayer;
        Texture2D txtPlayer;

        bool isJumping;

        public Player(string name)
        {
            timeManager = new TimeManager(Values.jumpTimeSpan);

            this.name = name;
            isJumping = false;
        }

        public void LoadContent(ContentManager content)
        {
            txtPlayer = content.Load<Texture2D>(Values.sptPlayer);
            sptPlayer = new Sprite(txtPlayer, Values.playerFrameSize, Values.playerTiles, Values.playerTimeSpan);
            sptPlayer.SetPosition(position);
        }

        public void UnloadContent() { }

        public void Update(GameTime gameTime, InputManager inputManager)
        {
            timeManager.Update(gameTime);
            sptPlayer.SetPosition(position);
            sptPlayer.SetRect((int)position.X, (int)position.Y, (int)Values.playerFrameSize.X, (int)Values.playerFrameSize.Y);
            sptPlayer.Update(gameTime);

            foreach (Platform platform in Map.platforms)
            {
                Rectangle item = new Rectangle((int)platform.Position.X, (int)platform.Position.Y, Platform.texture.Width, Platform.texture.Height);
                if (sptPlayer.Rect.isOnTopOf(item))
                {
                    position.Y = item.Y - Values.playerFrameSize.Y;

                    if ((inputManager.KeyDown(Keys.Space) || inputManager.KeyDown(Keys.Up)) && !isJumping)
                    {
                        isJumping = true;
                        timeManager.StartTimer();
                    }
                }
                else
                {
                    position.Y += Values.gravitation;
                }
            }

            if (timeManager.IsTimeOver() && isJumping)
            {
                timeManager.CleanTimer();
                isJumping = false;
            }

            if (isJumping)
            {
                position.Y -= Values.playerJump;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sptPlayer.DrawAnimated(spriteBatch);
        }
    }
}
