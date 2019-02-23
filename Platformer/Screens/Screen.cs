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
    public abstract class Screen
    {
        public static SpriteFont font;
        protected ContentManager content;
        public InputManager inputManager;

        public virtual void LoadContent(ContentManager Content, InputManager inputManager)
        {
            if (font == null)
                font = Content.Load<SpriteFont>("Fonts/CyrillicFont");

            content = new ContentManager(Content.ServiceProvider, "Content");
            this.inputManager = inputManager;
        }

        public virtual void UnloadContent()
        {
            content.Unload();
            inputManager = null;
        }

        public virtual void Update(GameTime gameTime, Game game) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
