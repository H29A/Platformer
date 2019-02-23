using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Platformer
{
    public class Map
    {
        int[,] tileMap;
        int[,] TileMap
        {
            get { return tileMap; }
            set { tileMap = value; }
        }

        List<Block> blocks = new List<Block>();
    
        public Map()
        {
            tileMap = new int
            [
                (int)(ScreenManager.Instance.Dimensions.X / Values.mapTileSize), 
                (int)(ScreenManager.Instance.Dimensions.Y / Values.mapTileSize)
            ];

            for (int y = 0; y < tileMap.GetLength(1); y++)
            {
                for (int x = 0; x < tileMap.GetLength(0); x++)
                {
                    blocks.Add
                    (
                        new Block
                        (
                            new Vector2(x * Values.mapTileSize, y * Values.mapTileSize),
                            tileMap[x, y]
                        )
                    );
                }
            }

        }

        public void LoadContent(ContentManager content)
        {
            foreach (Block tile in blocks)
            {
                tile.LoadContent(content);
            }
        }

        public void UnloadContent () { }

        public void Update(GameTime gameTime) { }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Block tile in blocks)
            {
                spriteBatch.Draw(tile.Texture, tile.Position, Color.White);
            }
        }
    }
}
