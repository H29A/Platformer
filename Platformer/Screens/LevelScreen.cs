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
    public class LevelScreen : Screen
    {
        public LevelScreen()
        {

        }

        public override void LoadContent(ContentManager Content, InputManager inputManager)
        {
            base.LoadContent(Content, inputManager);
            Player.Instance.LoadContent(Content);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime, Game game)
        {
            inputManager.Update();
            Player.Instance.Update(gameTime, inputManager);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.Clear(Color.LightBlue);
            Player.Instance.Draw(spriteBatch);
        }
    }
}
