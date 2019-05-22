using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class LevelScreen : Screen
    {
        Map map;
        Player player;

        public LevelScreen(string playerName)
        {
            player = new Player(playerName);
            map = new Map(player);
        }

        public override void LoadContent(ContentManager Content, InputManager inputManager)
        {
            base.LoadContent(Content, inputManager);

            map.LoadContent(content);
            player.LoadContent(Content);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime, Game game)
        {
            inputManager.Update();
            map.Update(gameTime);
            player.Update(gameTime, inputManager);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.GraphicsDevice.Clear(Color.LightBlue);
            map.Draw(spriteBatch);
            player.Draw(spriteBatch);

            spriteBatch.DrawString(font, $"{player.Name}: {player.CoinsCount}", Values.nameOnLevelScreenPosition, new Color(228, 209, 209));
        }
    }
}
