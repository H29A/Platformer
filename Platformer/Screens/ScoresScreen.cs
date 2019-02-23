using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Platformer
{
    public class ScoresScreen : Screen
    {
        public ScoresScreen()
        {

        }

        public override void LoadContent(ContentManager Content, InputManager inputManager)
        {
            base.LoadContent(Content, inputManager);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime, Game game)
        {
            inputManager.Update();

            if (inputManager.KeyPressed(Keys.Escape))
            {
                ScreenManager.Instance.AddScreen(new MenuScreen(), inputManager);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
