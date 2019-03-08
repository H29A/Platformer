using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using Newtonsoft.Json;

namespace Platformer
{
    public class ScoresScreen : Screen
    {
        private Scores scoresObj; 

        public ScoresScreen()
        {
            scoresObj = JsonConvert.DeserializeObject<Scores>(File.ReadAllText(Values.scoresJsonPath));
            //Add something
            File.WriteAllText(Values.scoresJsonPath, JsonConvert.SerializeObject(scoresObj, Formatting.Indented));
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
