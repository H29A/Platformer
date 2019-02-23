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
    public class Block
    {
        string path;

        Texture2D texture;
        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        int type;
        int Type { get { return type; } }

        Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        bool isTouchable;
        bool IsTouchable { get { return isTouchable; } }

        public Block(Vector2 position, int type)
        {
            this.position = position;
            this.type = type;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(Values.defaultTile);
        }

        public void UnloadContent() { }

        public void Update(GameTime gameTime) { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.position, Color.White);
        }
    }
}
