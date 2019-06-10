using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
            {
                font = Content.Load<SpriteFont>("Fonts/MainFont");
            }

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

        public bool IsClickedOn(Sprite item)
        {
            Vector2 position = inputManager.MouseState.Position.ToVector2();

            if (position.X >= item.Position.X &&
                position.Y >= item.Position.Y &&
                position.X <= item.Position.X + item.Texture.Width &&
                position.Y <= item.Position.Y + item.Texture.Height &&
                inputManager.MouseState.LeftButton == ButtonState.Released &&
                inputManager.PrevMouseState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }

            return false;
        }
    }
}
