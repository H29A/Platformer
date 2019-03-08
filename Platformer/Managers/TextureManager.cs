using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class TextureManager
    {
        private Texture2D texture;
        public Texture2D Texture
        {
            get { return texture; }
            private set { }
        }

        private string path;

        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            private set { }
        }

        public TextureManager(string path, Vector2 position)
        {
            this.path = path;
            this.position = position;
        }

        public TextureManager(Vector2 position)
        {
            this.position = position;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(path);
        }

        public void Update(GameTime gameTime, Vector2 position)
        {
            this.position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
