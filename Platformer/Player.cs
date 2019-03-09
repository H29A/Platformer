using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class Player
    {
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

        Rectangle player;

        public void LoadContent(ContentManager content)
        {
            sptPlayer.LoadContent(content);
        }

        public void UnloadContent() { }

        public void Update(GameTime gameTime, InputManager inputManager)
        {
            player = new Rectangle((int)position.X, (int)position.Y, (int)Values.playerFrameSize.X, (int)Values.playerFrameSize.Y);

            foreach (Platform platform in Map.platforms)
            {
                Rectangle item = new Rectangle((int)platform.Position.X, (int)platform.Position.Y, Platform.texture.Width, Platform.texture.Height);
                if (player.isOnTopOf(item))
                {
                    position.Y = item.Y - Values.playerFrameSize.Y;
                }
                else
                {
                    position.Y += Values.gravitation;
                }
            }

            if (inputManager.KeyDown(Keys.Space) || inputManager.KeyDown(Keys.Up))
            {
                position.Y -= Values.playerJump;
            }
            
            sptPlayer.Position = position;
            sptPlayer.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sptPlayer.Draw(spriteBatch, 0);
        }
    }
}
