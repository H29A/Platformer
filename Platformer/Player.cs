using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class Player
    {
        //Texture2D sprite;
        //public Texture2D Sprite
        //{
        //    get { return sprite; }
        //    private set { }
        //}

        string playerName = string.Empty;
        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            private set { }
        }

        //AnimationManager sptPlayer;
        TextureManager txt;

        private static Player instance;
        public static Player Instance
        {
            get
            {
                if (instance == null)
                    instance = new Player();
                return instance;
            }
        }

        private Player()
        {
            //sptPlayer = new AnimationManager(Values.sptPlayer, Values.playerFrameSize, Values.playerTiles);
            position = Values.playerStartPosition;
            txt = new TextureManager(Values.txtTextbox, Values.playerStartPosition);
        }

        public void LoadContent(ContentManager content)
        {
            txt.LoadContent(content);
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime, InputManager inputManager)
        {
            if (inputManager.KeyDown(Keys.Left) || inputManager.KeyDown(Keys.A))
            {
                position.X -= Values.playerStep;
            }

            if (inputManager.KeyDown(Keys.Right) || inputManager.KeyDown(Keys.D))
            {
                position.X += Values.playerStep;
            }

            if (inputManager.KeyDown(Keys.Space) || inputManager.KeyDown(Keys.Up))
            {
                position.Y -= Values.playerStep;
            }

            txt.Update(gameTime, position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            txt.Draw(spriteBatch);
        }
    }
}
